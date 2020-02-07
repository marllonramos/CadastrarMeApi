using System;

namespace CadastrarMeApi.Domain.ViewModels.EnderecoViewModels
{
    public class AtualizarEnderecoViewModel : IViewModel
    {
        public Guid Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Guid ClienteId { get; set; }
    }
}