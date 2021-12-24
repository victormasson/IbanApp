using IbanApp.Domain.Entities;
using IbanApp.Domain.Interfaces;
using IbanApp.Domain.Services.Interfaces;
using IbanApp.Domain.UseCases.InformationBancaires.Exceptions;
using MediatR;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace IbanApp.Domain.UseCases.InformationBancaires.Commands
{
    public record CreateInformationBancaireCommand(
        [Required] string IdSalarie,
        [Required] string NomBanque,
        [Required] string Iban,
        [Required] string Bic,
        string? TitulaireCompte
    ) : IRequest<InformationBancaire>;

    public class CreateInformationBancaireCommandHandler : IRequestHandler<CreateInformationBancaireCommand, InformationBancaire>
    {
        private readonly IInformationBancaireService informationBancaireService;

        public CreateInformationBancaireCommandHandler(IInformationBancaireService informationBancaireService)
        {
            this.informationBancaireService = informationBancaireService;
        }

        public async Task<InformationBancaire> Handle(CreateInformationBancaireCommand request, CancellationToken cancellationToken)
        {
            var entity = new InformationBancaire(
                Guid.NewGuid().ToString(),
                request.IdSalarie,
                request.NomBanque,
                request.Iban,
                request.Bic,
                request.TitulaireCompte,
                DateTime.Now);

            return await informationBancaireService.AddInformationBancaire(entity, cancellationToken);
        }
    }
}
