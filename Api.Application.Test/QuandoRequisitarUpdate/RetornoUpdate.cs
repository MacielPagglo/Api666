using Api.Application.Controllers;
using Moq;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using System;

namespace Api.Application.Test.QuandoRequisitarUpdate
{
    public class RetornoUpdate
    {
        private UsersController _controller;
            [Fact(DisplayName = "É Possivel Realizar o Update")]

            public async Task E_Possivel_Invocar_a_Controller_Update()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(
               new UserDtoUpdateResult
               {
                   Id = Guid.NewGuid(),
                   Email = email,
                   Name = nome,
                   UpdateAt = DateTime.UtcNow,
               }

               );

            _controller = new UsersController(serviceMock.Object);

            var userDtoUpdate = new UserDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = nome,
                Email = email,

            };

            var result = await _controller.Put(userDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserDtoUpdateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(userDtoUpdate.Name, resultValue.Name);
            Assert.Equal(userDtoUpdate.Email, resultValue.Email);

        }
    }
}
