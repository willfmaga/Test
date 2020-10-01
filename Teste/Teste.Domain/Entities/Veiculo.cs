namespace Teste.Domain.Entities
{
    public class Veiculo:BaseEntity
    {
        public string Placa { get; set; }

        public Pessoa pessoa { get; set; }
    }
}