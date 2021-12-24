using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbanApp.Domain.Entities
{
    public record InformationBancaire(
        string IdInformationBancaire,
        string IdSalarie,
        string NomBanque,
        [StringLength(34, ErrorMessage = "L'IBAN {0} ne doit pas dépasser {1} caractères. ")]
        string Iban,
        [StringLength(11, ErrorMessage = "Le code BIC {0} ne doit pas dépasser {1} caractères. ")]
        string Bic,
        string? TitulaireCompte,
        DateTime DateAjout
    );
}
