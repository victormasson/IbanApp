using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbanApp.Domain.UseCases.InformationBancaires.Queries
{
    public record InformationBancaireDto(
        string IdSalarie,
        string NomBanque,
        string Iban,
        string Bic,
        string? TitulaireCompte,
        DateTime DateAjout
    );
}
