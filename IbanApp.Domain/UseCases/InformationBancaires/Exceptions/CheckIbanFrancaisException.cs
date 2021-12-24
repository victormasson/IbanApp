using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbanApp.Domain.UseCases.InformationBancaires.Exceptions
{
    public class CheckIbanFrancaisException : Exception
    {
        public CheckIbanFrancaisException(string iban) : base($"L'Iban [{iban}] n'est pas français, il devrait commencer par [FR]")
        {
        }
    }
}