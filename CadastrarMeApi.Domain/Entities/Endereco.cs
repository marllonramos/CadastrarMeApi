using CadastrarMeApi.Domain.Shared;

namespace CadastrarMeApi.Domain.Entities
{
    public class Endereco : Entity
    {
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public Endereco(string logradouro, string bairro, string cidade, string estado)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
    }
}