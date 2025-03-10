using Api.Domain.Interfaces.Services.User;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Xunit;
using System.Threading.Tasks;
using System;

namespace Api.Application.Test.QuandoRequisitarCreate
{
    public class RetornoCreated
    {
        private UsersController _controller;
        [Fact(DisplayName = "É Possivel Realizar o Created.")]

        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(
                new UserDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Email = email,
                    Name = nome,
                    CreateAt = DateTime.UtcNow,
                }
                
                );

            _controller = new UsersController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();

            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");

            _controller.Url = url.Object;

            var userDtoCreate = new UserDtoCreate

            {
                Name = nome,
                Email = email,
            };

            var result = await _controller.Post(userDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as UserDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(userDtoCreate.Name, resultValue.Name);
            Assert.Equal(userDtoCreate.Email, resultValue.Email);
        }
    }
}

      