﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.QuandoRequisitarGet
{
    public class RetornoGet
    {
        private UsersController _controller;

        [Fact(DisplayName = "É Possivel Realizar o Get")]

        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();


            serviceMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .ReturnsAsync(
         new UserDto
         {
             Id = Guid.NewGuid(),
             Email = email,
             Name = nome,
             CreateAt = DateTime.UtcNow,
         }
         );


            _controller = new UsersController( serviceMock.Object );
            var result = await _controller.Get(Guid.NewGuid());
            Assert.NotNull( result is OkObjectResult );
            var resultValue = ((OkObjectResult)result).Value as UserDto;
            Assert.NotNull(resultValue);
            Assert.Equal( nome, resultValue.Name );
            Assert.Equal( email, resultValue.Email );



        }
    }
}

