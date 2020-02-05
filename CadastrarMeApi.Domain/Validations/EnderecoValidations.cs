using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.SharedKernel.Validation;

namespace CadastrarMeApi.Domain.Validations
{
    public static class EnderecoValidations
    {
        public static bool ValidLogradouro(this Endereco endereco)
        {
            return AssertionConcern.IsValid(
                AssertionConcern.AssertArgumentNotEmpty(endereco.Logradouro.ToString(), "Informe o logradouro"),
                AssertionConcern.AssertArgumentBiggerThanOrEquals(endereco.Logradouro.Length, 51, "Logradouro não pode ter mais que 50 caracteres")
            );
        }

        public static bool ValidBairro(this Endereco endereco)
        {
            return AssertionConcern.IsValid(
                AssertionConcern.AssertArgumentNotEmpty(endereco.Bairro.ToString(), "Informe o bairro"),
                AssertionConcern.AssertArgumentBiggerThanOrEquals(endereco.Bairro.Length, 41, "Bairro não pode ter mais que 40 caracteres")
            );
        }

        public static bool ValidCidade(this Endereco endereco)
        {
            return AssertionConcern.IsValid(
                AssertionConcern.AssertArgumentNotEmpty(endereco.Cidade.ToString(), "Informe a cidade"),
                AssertionConcern.AssertArgumentBiggerThanOrEquals(endereco.Cidade.Length, 41, "Cidade não pode ter mais que 40 caracteres")
            );
        }

        public static bool ValidEstado(this Endereco endereco)
        {
            return AssertionConcern.IsValid(
                AssertionConcern.AssertArgumentNotEmpty(endereco.Estado.ToString(), "Informe o estado"),
                AssertionConcern.AssertArgumentBiggerThanOrEquals(endereco.Estado.Length, 41, "Estado não pode ter mais que 40 caracteres")
            );
        }
    }
}