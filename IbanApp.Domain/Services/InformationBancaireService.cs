using IbanApp.Domain.Entities;
using IbanApp.Domain.Interfaces;
using IbanApp.Domain.Services.Interfaces;
using IbanApp.Domain.UseCases.InformationBancaires.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbanApp.Domain.Services
{
    public class InformationBancaireService : IInformationBancaireService
    {
        private readonly IApplicationDbContext context;

        public InformationBancaireService(IApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Check and add one informationBancaire.
        /// </summary>
        /// <param name="entity">InformationBancaire</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>The informationBancaire created</returns>
        /// <exception cref="AlreadyExistCompteBancaireException"></exception>
        public async Task<InformationBancaire> AddInformationBancaire(InformationBancaire entity, CancellationToken cancellationToken)
        {
            var alreadyExistCompteBancaire = context.InformationBancaires
                .Any(ib =>
                    ib.IdSalarie == entity.IdSalarie
                    && ib.Iban == entity.Iban
                );

            // Check already exist
            if (alreadyExistCompteBancaire)
                throw new AlreadyExistCompteBancaireException(entity.Iban);

            // Check Iban français
            CheckIban(entity.Iban);

            context.InformationBancaires.Add(entity);

            await context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        private void CheckIban(string iban)
        {
            var a = new String(iban.Take(2).ToArray());
            if ("FR" != a)
                throw new CheckIbanFrancaisException(iban);
        }

        /// <summary>
        /// Check and add many informationBancaire.
        /// </summary>
        /// <param name="entity">InformationBancaire</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>list of informationBancaire created</returns>
        public async Task<IEnumerable<InformationBancaire>> AddInformationBancaires(IEnumerable<InformationBancaire> listEntity, CancellationToken cancellationToken)
        {
            var informationBancaireUpdated = Array.Empty<InformationBancaire>().ToList();

            foreach (var entity in listEntity)
            {
                await this.AddInformationBancaire(entity, cancellationToken);

                informationBancaireUpdated.Add(entity);
            }

            return informationBancaireUpdated;
        }
    }
}
