using System;

namespace CadastrarMeApi.Domain.ViewModels.ClienteViewModels
{
    public class CriarClienteViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DtNascimento { get; set; }
    }
}