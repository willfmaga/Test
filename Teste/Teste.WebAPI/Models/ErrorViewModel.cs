using FluentValidation.Results;
using System.Collections.Generic;
using Teste.Infra.CrossCutting.CustomError;

namespace Teste.WebAPI.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string requestId, List<MensagemErro> errors)
        {
            RequestId = requestId;
            Errors = errors;
        }

        public string RequestId { get; set; }
        public List<MensagemErro> Errors { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    }
}
