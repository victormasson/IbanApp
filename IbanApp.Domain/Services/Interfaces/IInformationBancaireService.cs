using IbanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbanApp.Domain.Services.Interfaces
{
    public interface IInformationBancaireService
    {
        /// <summary>
        /// Check and add one informationBancaire.
        /// </summary>
        /// <param name="entity">InformationBancaire</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>The informationBancaire created</returns>
        /// <exception cref="AlreadyExistCompteBancaireException"></exception>
        Task<InformationBancaire> AddInformationBancaire(InformationBancaire entity, CancellationToken cancellationToken);

        /// <summary>
        /// Check and add many informationBancaire.
        /// </summary>
        /// <param name="entity">InformationBancaire</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>list of informationBancaire created</returns>
        Task<IEnumerable<InformationBancaire>> AddInformationBancaires(IEnumerable<InformationBancaire> listEntity, CancellationToken cancellationToken);
    }
}
