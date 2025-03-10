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
    public class RetornoBadRequest
    {
        private UsersController _controller;
        [Fact(DisplayName = "É Possivel Realizar o Bad Request.")]

        public async Task E_Possivel_Invocar_a_Controller_Bad_Request()
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
            _controller.ModelState.AddModelError("Name", "É Um Campo Obrigatorio");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();

            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");

            _controller.Url = url.Object;

            var userDtoCreate = new UserDtoCreate

            {
                Name = nome,
                Email = email,
            };

            var result = await _controller.Post(userDtoCreate);
            Assert.True(result is BadRequestObjectResult);


        }
    }
}

      