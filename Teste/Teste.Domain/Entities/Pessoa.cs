using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Teste.Domain.Entities
{
    [DataContract]
    public class Pessoa
    {
        [DataMember]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }

        public List<Veiculo> veiculos { get; set; }
    }
}
