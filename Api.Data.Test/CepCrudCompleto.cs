using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Implementations;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class CepCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public CepCrudCompleto(DbTeste dbTeste)
        {

            _serviceProvide = dbTeste.ServiceProvider;
        }
        [Fact(DisplayName = "CRUD de Cep")]
        [Trait("CRUD", "CepEntity")]

        public async Task E_Possivel_Realizar_CRUD_Cep()
        {
            using (var context = _repositorio = new MunicipioImplementation(context))
            {
                MunicipioImplementation _repositorio = new MunicipioImplementation(Context);
                MunicipioEntity _entity = new MunicipioEntity
                {

                    Nome = Faker.Adress.City(),
                    CodIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                    UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Nome, _registroCriado.Nome);
                Assert.Equal(_entity.CodIBGE, _registroCriado.CodIBGE);
                Assert.Equal(_entity.UfId, _registroCriado.UfId);
                Assert.False(_registroCriado.Id == Guid.Empty);



            }
        }
    }
}








