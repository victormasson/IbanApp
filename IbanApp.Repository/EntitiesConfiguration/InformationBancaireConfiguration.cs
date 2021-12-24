using IbanApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbanApp.Repository.Entities
{
    public class InformationBancaireConfiguration : IEntityTypeConfiguration<InformationBancaire>
    {
        public void Configure(EntityTypeBuilder<InformationBancaire> builder)
        {
            builder.HasKey(e => e.IdInformationBancaire);
            builder.Property(e => e.IdInformationBancaire)
                .IsRequired();

            builder.Property(e => e.Iban)
                .IsRequired();

            builder.Property(e => e.IdSalarie)
                .IsRequired();

            builder.Property(e => e.NomBanque)
                .IsRequired();

            builder.Property(e => e.Bic)
                .IsRequired();

            builder.Property(e => e.DateAjout)
                .IsRequired();

            builder.Property(e => e.TitulaireCompte)
                .IsRequired(false);
        }
    }
}
