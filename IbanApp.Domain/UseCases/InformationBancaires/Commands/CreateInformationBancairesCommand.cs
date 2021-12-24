using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IbanApp.Domain.Entities;
using IbanApp.Domain.Interfaces;
using IbanApp.Domain.Services.Interfaces;
using MediatR;

namespace IbanApp.Domain.UseCases.InformationBancaires.Commands
{
    public record CreateInformationBancairesCommand(
        IEnumerable<CreateInformationBancaireCommand> listInformationBancaire
    ) : IRequest<IEnumerable<InformationBancaire>>;

    public class CreateInformationBancairesCommandHandler : IRequestHandler<CreateInformationBancairesCommand, IEnumerable<InformationBancaire>>
    {
        private readonly IInformationBancaireService informationBancaireService;

        public CreateInformationBancairesCommandHandler(IInformationBancaireService informationBancaireService)
        {
            this.informationBancaireService = informationBancaireService;
        }

        public async Task<IEnumerable<InformationBancaire>> Handle(CreateInformationBancairesCommand request, CancellationToken cancellationToken)
        {
            var listInformationBancaireToAdd = request.listInformationBancaire.Select(informationBancaire =>
                new InformationBancaire(
                        Guid.NewGuid().ToString(),
                        informationBancaire.IdSalarie,
                        informationBancaire.NomBanque,
                        informationBancaire.Iban,
                        informationBancaire.Bic,
                        informationBancaire.TitulaireCompte,
                        DateTime.Now));

            return await informationBancaireService.AddInformationBancaires(listInformationBancaireToAdd, cancellationToken);
        }
    }
}
