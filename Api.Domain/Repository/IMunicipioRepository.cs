using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Interfaces;
using Domain.Entities;

namespace Domain.Repository
{
    public interface IMuninicipioRepository : IRepository<MunicipioEntity>
    {
        Task<MunicipioEntity>GetCompleteById(Guid id);

        Task<MunicipioEntity> GetCompleteByIBGE(int codIBGE);

    }
}
