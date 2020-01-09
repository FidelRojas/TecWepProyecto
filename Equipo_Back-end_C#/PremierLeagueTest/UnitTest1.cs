using AutoMapper;
using PremierLeague.Data;
using PremierLeague.Data.Entities;
using PremierLeague.Data.Repository;
using PremierLeague.Exceptions;
using PremierLeague.Models;
using PremierLeague.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject2
{
    public class Unitest1
    {
        [Fact]
        public async void JugadoresService_ShouldReturnExceptionIfNotFound()
        {
            //arrange
            int brandId = 22;
            var MoqDealerRespository = new Mock<IPremierLeagueRepository>();
            var brandEntity = new EquipoEntity()
            {
                id = 1,
                nombre = "antonio",
                entrenador = "Antonio",
                estadio = "asd",
                fundacion = "1981",
                info = "qwe"
            };
            MoqDealerRespository.Setup(m => m.GetEquipoAsync(brandId, false)).Returns(Task.FromResult(brandEntity));

            var myProfile = new PremierLeagueProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);

            var brandService = new EquiposService(MoqDealerRespository.Object, mapper);
            //act 
            await Assert.ThrowsAsync<NotFoundItemException>(() => brandService.GetEquipoAsync(1, false));

        }
        [Fact]
        public void Should_Verify_All_Mock_Functions()
        {
            var id = 12;
            var nombre = "Fred Flinstone";
            var equipo = new EquipoEntity { id = id, nombre = nombre };
            var mock = new Mock<IPremierLeagueRepository>();
            mock.Setup(x => x.GetEquipoAsync(id,false)).Returns(Task.FromResult(equipo));
            Assert.Throws<MockException>(() => mock.VerifyAll());
        }
        /*[Fact]
        public void Should_Verify_Mock_Functions_Not_Executed_Marked_Verifiable()
        {
            var id = 12;
            var nombre = "Fred Flinstone";
            var equipo = new Equipo { id = id, nombre = nombre };
            var mock = new Mock<IRepo>();
            Expression<Func<IRepo, Customer>> call = x => x.Find(id);
            var errorMessage = "Method not called";
            mock.Setup(call).Returns(customer).Verifiable(errorMessage);
            var ex = Assert.Throws<MockException>(() => mock.Verify(call));
        }*/
    }

}