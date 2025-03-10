using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos.Cep;

namespace Domain.Interfaces.Services.Cep
{
    public  interface ICepService
    {
        Task<CepDto> Get(Guid id);

        Task<CepDto> Get (string id);

        Task<CepDtoCreateResult> Post(CepDtoCreate cep);

        Task<CepDtoUpdateResult> Put(CepDtoUpdate cep); 


    }
}
