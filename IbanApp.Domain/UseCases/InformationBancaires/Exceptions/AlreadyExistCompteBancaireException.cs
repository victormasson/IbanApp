using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbanApp.Domain.UseCases.InformationBancaires.Exceptions
{
    public class AlreadyExistCompteBancaireException : Exception
    {
        public AlreadyExistCompteBancaireException(string iban) : base($"Il existe déjà un compte [{iban}]")
        {
        }
    }
}
