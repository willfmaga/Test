using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Teste.Application.Interfaces;
using Teste.Application.Interfaces.Model;
using Teste.Domain.Entities;
using Teste.Domain.Interface.Services;

namespace Teste.WebAPI.Bus.Rabbit
{
    public class RabbitConsumer : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private IPessoaApp _pessoaApp;
        private IConnection _connection;
        private IModel _channel;

        public RabbitConsumer(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            Consumer();
        }

        public void Consumer()
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://localhost:5672"),
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: "PessoaIncluir", durable: false, exclusive: false, autoDelete: false, arguments: null);
            _channel.ExchangeDeclare(exchange: "Cadastro", type: ExchangeType.Fanout);

            _channel.QueueBind(queue: "PessoaIncluir", exchange: "Cadastro", routingKey: "", arguments: null);

            _channel.BasicQos(0, 1, false);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {


            var threadIncluirPessoa = new Thread(LerFilaIncluirPessoa);
            threadIncluirPessoa.Start();

            return Task.CompletedTask;
        }

        private void LerFilaIncluirPessoa()
        {
            var consumerPessoaIncluir = new EventingBasicConsumer(_channel);

            _channel.BasicConsume(queue: "PessoaIncluir", autoAck: false, consumer: consumerPessoaIncluir);

            consumerPessoaIncluir.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                try
                {
                    var request = JsonConvert.DeserializeObject<PessoaDTO>(message);

                    if (request is null)
                        throw new Exception("Mensagem Vazia");

                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        _pessoaApp = scope.ServiceProvider.GetRequiredService<IPessoaApp>();

                        _pessoaApp.Incluir(request);
                    }

                    _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    RabbitErrorHandling("PessoaIncluir", message, ex.Message);
                }

            };

        }

        private void RabbitErrorHandling(string queueName, string queueBody, string exceptionMessage)
        {
            string queueError = $"{queueName}_Error";
            _channel.QueueDeclare(queue: queueError, durable: false, exclusive: false, autoDelete: false, arguments: null);

            _channel.BasicPublish(exchange: string.Empty,
                routingKey: queueError,
                basicProperties: null,
                body: Encoding.UTF8.GetBytes(queueBody));


        }
    }
}
