using Api.Application.Controllers;
using Moq;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System.Threading.Tasks;
using System;

namespace Api.Application.Test.QuandoRequisitarDelete
{ 
    public class RetornoDelete
    {
        private UsersController _controller;
            [Fact(DisplayName = "É Possivel Realizar o Delete")]

            public async Task E_Possivel_Invocar_a_Controller_Delete()
        {
            var serviceMock = new Mock<IUserService>();   
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            _controller = new UsersController(serviceMock.Object);
                             
            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserDtoUpdateResult;
            Assert.NotNull(resultValue);
            Assert.True((Boolean)resultValue);


        }
    }
}
