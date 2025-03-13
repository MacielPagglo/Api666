using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class MunicipioMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possivel Mapear Os Modelos de Municipio")]

        public void E_Possivel_Mapear_os_Modelos_Municipios()
        {
            var model = new MunicipioModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1, 100000),
                UfId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };

            var listaEntity = new List<MunicipioEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new MunicipioEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1000000, 99999999),
                    UfId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Uf = new UfEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 3)
                    }

                };

                listaEntity.Add(item);

            }



            //model => entity

            var entity = Mapper.Map<MunicipioEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.CodIBGE, model.CodIBGE);
            Assert.Equal(entity.UfId, model.UfId);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);


            //entity para dto

            var userDto = Mapper.Map<MunicipioDto>(entity);

            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Nome, entity.Nome);
            Assert.Equal(userDto.CodIBGE, entity.CodIBGE);
            Assert.Equal(userDto.UfId, userDto.UfId);


            var userDtoCompleto = Mapper.Map<MunicipioDtoCompleto>(listaEntity.FirstOrDefault());
            Assert.Equal(userDtoCompleto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(userDtoCompleto.Nome, listaEntity.FirstOrDefault().Nome);
            Assert.Equal(userDtoCompleto.CodIBGE, listaEntity.FirstOrDefault().CodIBGE);
            Assert.Equal(userDtoCompleto.UfId, listaEntity.FirstOrDefault().UfId);
            Assert.NotNull(userDtoCompleto.Uf);

            var listaDto = Mapper.Map<list<MunicipioDto>>(listaEntity);
            {
                Assert.True(listaDto.Count() == listaEntity.Count());
                for (int i = 0; i < listaDto.Count(); i++)
                {
                    Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                    Assert.Equal(listaDto[i].Nome, listaEntity[i].Nome);
                    Assert.Equal(listaDto[i].CodIBGE, listaEntity[i].CodIBGE);
                    Assert.Equal(listaDto[i].UfId, listaEntity[i].UfId);
                }

                var UserDtoCreateResult = Mapper.Map<MunicipioDtoCreateResult>(entity);

                Assert.Equal(UserDtoCreateResult.Id, entity.Id);
                Assert.Equal(UserDtoCreateResult.Nome, entity.Nome);
                Assert.Equal(UserDtoCreateResult.CodIBGE, entity.CodIBGE);
                Assert.Equal(UserDtoCreateResult.UfId, entity.UfId);
                Assert.Equal(UserDtoCreateResult.CreateAt, entity.CreateAt);
            }

            var UserDtoUpdateResult = Mapper.Map<MunicipioDtoUpdateResult>(entity);

            Assert.Equal(UserDtoUpdateResult.Id, entity.Id);
            Assert.Equal(UserDtoUpdateResult.Nome, entity.Nome);
            Assert.Equal(UserDtoUpdateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(UserDtoUpdateResult.UfId, entity.UfId);
            Assert.Equal(UserDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //dto para model

            var userModel = Mapper.Map<MunicipioModel>(userDto);

            Assert.Equal(userModel.Id, model.Id);
            Assert.Equal(userModel.Nome, model.Nome);
            Assert.Equal(userModel.CodIBGE, model.CodIBGE);
            Assert.Equal(userModel.UfId, model.UfId);
            Assert.Equal(userModel.UfId, model.UfId);

            var userDtoCreate = Mapper.Map<MunicipioDtoCreate>(userModel);

            Assert.Equal(userDtoCreate.Nome, userModel.Nome);
            Assert.Equal(userDtoCreate.CodIBGE, userModel.CodIBGE);
            Assert.Equal(userDtoCreate.UfId, userModel.UfId);

            var userDtoUpdate = Mapper.Map<MunicipioDtoUpdate>(userModel);
            Assert.Equal(userDtoUpdate.Nome, userModel.Nome);
            Assert.Equal(userDtoUpdate.CodIBGE, userModel.CodIBGE);
            Assert.Equal(userDtoUpdate.Id, userModel.Id);
            Assert.Equal(userDtoUpdate.UfId, userModel.UfId);






        }
    }
}


