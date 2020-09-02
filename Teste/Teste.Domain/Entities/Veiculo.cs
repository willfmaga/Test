namespace Teste.Domain.Entities
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }

        public Pessoa pessoa { get; set; }
    }
}