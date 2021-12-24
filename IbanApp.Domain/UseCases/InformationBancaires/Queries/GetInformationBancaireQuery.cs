using IbanApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbanApp.Domain.UseCases.InformationBancaires.Queries
{
    public record GetInformationBancaireQuery(
        string IdSalarie,
        int Take = 20,
        int Skip = 0
    ) : IRequest<IEnumerable<InformationBancaireDto>>;

    public class GetInformationBancaireQueryHandler : IRequestHandler<GetInformationBancaireQuery, IEnumerable<InformationBancaireDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetInformationBancaireQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InformationBancaireDto>> Handle(GetInformationBancaireQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.InformationBancaires
                .Where(informationBancaire => informationBancaire.IdSalarie == request.IdSalarie)
                .Skip(request.Skip)
                .Take(request.Take)
                .Select(informationBancaire => new InformationBancaireDto(
                    informationBancaire.IdSalarie,
                    informationBancaire.NomBanque,
                    informationBancaire.Iban,
                    informationBancaire.Bic,
                    informationBancaire.TitulaireCompte,
                    informationBancaire.DateAjout)
                ));
        }
    }
}
