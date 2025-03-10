using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.QuandoRequisitarGetAll
{
    public class RetornoGetAll
    {
        private UsersController _controller;

        [Fact(DisplayName = "É Possível Realizar o Get.")]

        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IUserService>();

            _ = serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
            new List<UserDto>
            {
                new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName,
                    Email = Faker.Internet.Email,
                    CreateAt = DateTime.UtcNow,
                }
            }
            );
            _controller = new UsersController(serviceMock.Object);
            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

                var resultValue = ((OkObjectResult)resultValue).Value as IEnumerable<UserDto>;

        }
    }
}
