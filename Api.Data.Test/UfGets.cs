using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Api.Data.Context;
using Data.Implementations;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Api.Data.Seeds;

namespace Api.Data.Test
{

    
    public class UfGets 
    {
        private ServiceProvider _serviceProvide;

        public UfGets(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
            
        }

        [Fact(DisplayName = "Gets de UF")]
        [Trait("Gets", "UfEntity")]

        public async Task E_Possivel_Realizar_Gets_UF()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                UfImplementation _repositorio = new UfImplementation(context);
                UfEntity _entity = new UfEntity
                {
                        Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                        Sigla = "SP",
                        Nome = "São Paulo",
                };

                var _registroExiste = await _repositorio.ExistAsync(_entity.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_entity.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_entity.Sigla, _registroSelecionado.Sigla);
                Assert.Equal(_entity.Nome, _registroSelecionado.Nome);
                Assert.Equal(_entity.Id, _registroSelecionado.Id);


            }
        }
    }
}
