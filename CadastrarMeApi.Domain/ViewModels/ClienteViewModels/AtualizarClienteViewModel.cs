using System;

namespace CadastrarMeApi.Domain.ViewModels.ClienteViewModels
{
    public class AtualizarClienteViewModel : IViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DtNascimento { get; set; }
    }
}