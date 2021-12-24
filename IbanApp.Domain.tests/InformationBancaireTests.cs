using IbanApp.Domain.Entities;
using IbanApp.Domain.Services;
using Moq;
using System;
using Xunit;
using IbanApp.Repository;
using Microsoft.EntityFrameworkCore;
using IbanApp.Domain.Services.Interfaces;
using System.Threading;
using IbanApp.Domain.UseCases.InformationBancaires.Exceptions;
using System.Threading.Tasks;

namespace IbanApp.Domain.tests
{
    public class InformationBancaireTests
    {
        private ApplicationDbContext applicationDbContext;
        private InformationBancaireService informationBancaireService;

        public InformationBancaireTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ApplicationDbContextDatabase")
                .Options;

            applicationDbContext = new ApplicationDbContext(options);
            informationBancaireService = new InformationBancaireService(applicationDbContext);
        }

        [Fact]
        public async Task InformationBancaireTests_AddInformationBancaire_OK()
        {
            #region Arrange

            var informationBancaire = new InformationBancaire(
                "IdInformationBancaire",
                "IdSalarie",
                "NomBanque",
                "FR210076597417111400",
                "Bic",
                "TitulaireCompte",
                DateTime.Now);

            #endregion Arrange


            #region Act

            try
            {
                await informationBancaireService.AddInformationBancaire(informationBancaire, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Assert.Equal(typeof(AlreadyExistCompteBancaireException), ex.GetType());

                return;
            }

            #endregion Act

            #region Assert

            var informationBancaireAdded = await this.applicationDbContext.InformationBancaires.SingleAsync(CancellationToken.None);

            Assert.Equal(informationBancaireAdded, informationBancaire);

            #endregion Assert
        }

        [Fact]
        public async Task InformationBancaireTests_AddInformationBancaire_KO()
        {
            #region Arrange

            var informationBancaire = new InformationBancaire(
                "IdInformationBancaire",
                "IdSalarie",
                "NomBanque",
                "FR210076597417111400",
                "Bic",
                "TitulaireCompte",
                DateTime.Now);

            #endregion Arrange


            #region Act

            try
            {
                await informationBancaireService.AddInformationBancaire(informationBancaire, CancellationToken.None);
                await informationBancaireService.AddInformationBancaire(informationBancaire, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Assert.Equal(typeof(AlreadyExistCompteBancaireException), ex.GetType());

                return;
            }

            #endregion Act

            #region Assert

            var informationBancaireAdded = await this.applicationDbContext.InformationBancaires.SingleAsync(CancellationToken.None);

            Assert.Equal(informationBancaireAdded, informationBancaire);

            #endregion Assert
        }
    }
}