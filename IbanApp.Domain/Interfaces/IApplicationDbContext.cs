using IbanApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IbanApp.Domain.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<InformationBancaire> InformationBancaires { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}