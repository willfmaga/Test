using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using FluentValidation.Results;

namespace Teste.Infra.CrossCutting.CustomError
{
    public class RepomVaiDeVisaException : Exception
    {
        private static List<MensagemErro> erros;

        public List<MensagemErro> Erros { get { return erros; }}

        public RepomVaiDeVisaException(ValidationResult validationResult)
        {
            erros = new List<MensagemErro>();

            foreach (var erro in validationResult.Errors)
            {
                var codigoErro = Convert.ToInt32(erro.ErrorCode);
                var nomeAtributo = erro.PropertyName;
                var msgDinamica = erro.ErrorMessage;

                var errobanco = getErro(codigoErro);

                erros.Add(errobanco);
            }
            
        }

        private MensagemErro getErro(int codigoErro)
        {
            var errors = new List<MensagemErro>()
           {
               new MensagemErro() { Codigo = 1, Descricao = "Campo nome inválido"},
               new MensagemErro() { Codigo = 2, Descricao = "Campo sobrenome inválido"}
           };

            return errors.Where(e => e.Codigo == codigoErro).SingleOrDefault();
        }
    }

    public class MensagemErro
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}