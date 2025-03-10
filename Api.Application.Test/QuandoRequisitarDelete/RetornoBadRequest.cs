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
    public class RetornoBadRequest

    {
        private UsersController _controller;
            [Fact(DisplayName = "É Possivel Realizar o Delete")]

            public async Task E_Possivel_Invocar_a_Controller_Delete()
        {
            var serviceMock = new Mock<IUserService>();     
             serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                .ReturnsAsync(false);


            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Email", "Formato Inválido");


    

            var result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
        

      

        }
    }
}
