using System.Linq;
using System.Collections.Generic;
using CadastrarMeApi.SharedKernel.Events;

namespace CadastrarMeApi.SharedKernel.Validation
{
    public static class AssertionConcern
    {
        public static bool IsValid(params DomainNotification[] validations)
        {
            var notificationsNotNull = validations.Where(validation => validation != null);
            NotifyAll(notificationsNotNull);

            return notificationsNotNull.Count().Equals(0);
        }

        public static void NotifyAll(IEnumerable<DomainNotification> notifications)
        {
            notifications.ToList().ForEach(validation =>
            {
                DomainEvent.Raise<DomainNotification>(validation);
            });
        }

        public static DomainNotification AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            int length = stringValue.Trim().Length;
            return (length < minimum || length > maximum)
                ? new DomainNotification("AssertArgumentLength", message) : null;
        }

        public static DomainNotification AssertArgumentNotEmpty(string stringValue, string message)
        {
            return (stringValue == null || stringValue.Trim().Length == 0)
                ? new DomainNotification("AssertArgumentNotEmpty", message) : null;
        }

        public static DomainNotification AssertArgumentNotNull(object object1, string message)
        {
            return (object1 == null)
                ? new DomainNotification("AssertArgumentNotNull", message) : null;
        }

        public static DomainNotification AssertArgumentLessThanOrEquals(decimal value, decimal minimum, string message)
        {
            return (value <= minimum)
                ? new DomainNotification("AssertArgumentLessThanOrEquals", message) : null;
        }

        public static DomainNotification AssertArgumentBiggerThanOrEquals(decimal value, decimal maximum, string message)
        {
            return (value >= maximum)
                ? new DomainNotification("AssertArgumentBiggerThanOrEquals", message) : null;
        }

        public static DomainNotification AssertIsCpf(string cpf, string message)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;

            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11) return new DomainNotification("AssertIsCpf", message);

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2) resto = 0; else resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2) resto = 0; else resto = 11 - resto;

            digito = digito + resto.ToString();
            bool isCpf = cpf.EndsWith(digito);

            return (!isCpf) ? new DomainNotification("AssertIsCpf", message) : null;
        }
    }
}