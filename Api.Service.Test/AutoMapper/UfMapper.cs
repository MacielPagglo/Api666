using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Domain.Dtos.Uf;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
public class UfMapper : BaseTesteService
{
    [Fact(DisplayName = " É Possivel Mapear Os Modelos de UF")]

    public void E_Possivel_Mapear_Os_Modelos_de_UF()
    {
        var model = new UfModel
        {
            Id = Guid.NewGuid(),
            Nome = Faker.Address.UsState(),
            Sigla = Faker.Address.UsState().Substring(1, 3),
            CreateAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
        };

        var listaEntity = new List<UfEntity>();
        for (int i = 0; i < 5; i++)
        {
            var item = new UfEntity
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.UsState(),
                Sigla = Faker.Address.UsState().Substring(1, 3),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };
            listaEntity.Add(item);

        }

        //model => entity

        var entity = Mapper.Map<UfEntity>(model);
            Assert.Equal(entity.Id, model.Id);
        Assert.Equal(entity.Nome, model.Nome);
        Assert.Equal(entity.Sigla, model.Sigla);
        Assert.Equal(entity.CreateAt, model.CreateAt);
        Assert.Equal(entity.UpdateAt, model.UpdateAt);


            //entity para dto

            var userDto = Mapper.Map<UfDto>(entity);

            Assert.Equal(entity.userDto.Id, userDto.Id);
            Assert.Equal(entity.userDto.Nome, userDto.Nome);
            Assert.Equal(entity.UserDto.Sigla, userDto.Sigla);
            

            var listaDto = Mapper.Map<List<UfDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count; i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listaDto[i].Sigla, listaEntity[i].Sigla);

            }



            //dto para model

            var userModel = Mapper.Map<UfDto>(model);
            Assert.Equal(userModel.Id, model.Id);
            Assert.Equal(userModel.Nome, model.Nome);
            Assert.Equal(userModel.Sigla, model.Sigla);




















    }
}
}

