using System;

namespace CadastrarMeApi.Domain.ViewModels.ClienteViewModels
{
    public class CriarClienteViewModel : IViewModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}