using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.SharedKernel.Validation;

namespace CadastrarMeApi.Domain.Validations
{
    public static class ClienteValidations
    {
        public static bool ValidNome(this Cliente cliente)
        {
            return AssertionConcern.IsValid(
                AssertionConcern.AssertArgumentNotEmpty(cliente.Nome.ToString(), "Informe o nome"),
                AssertionConcern.AssertArgumentBiggerThanOrEquals(cliente.Nome.Length, 31, "Nome não pode ter mais que 30 caracteres")
            );
        }

        public static bool ValidCPF(this Cliente cliente)
        {
            return AssertionConcern.IsValid(
                AssertionConcern.AssertArgumentNotEmpty(cliente.CPF.ToString(), "Informe o CPF"),
                AssertionConcern.AssertIsCpf(cliente.CPF.ToString(), "CPF inválido")
            );
        }

        public static bool ValidDataNascimento(this Cliente cliente)
        {
            return AssertionConcern.IsValid(
                AssertionConcern.AssertArgumentNotEmpty(cliente.DtNascimento.ToString(), "Informe a data de nascimento")
            );
        }
    }
}