using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Data.Implementations
{
    public class CepImplementation : BaseRepository<UfEntity>, ICepRepository
    {
        private DbSet<UfEntity> _dataset;
        public CepImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UfEntity>();

        }

        public async Task<CepEntity> InsertAsync(CepEntity item)
        {
            return await _dataset.Include(c => c.Municipios)
                        .ThenInclude(m => m.Uf)
                        .FirstOrDefault(u => u.Cep.Equals(Cep));
        }

        public Task<CepEntity> SelectAsync(string cep)
        {
            throw new NotImplementedException();
        }

        public Task<CepEntity> UpdateAsync(CepEntity item)
        {
            throw new NotImplementedException();
        }

        Task<CepEntity> IRepository<CepEntity>.SelectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<CepEntity>> IRepository<CepEntity>.SelectAsync()
        {
            throw new NotImplementedException();
        }
    }
}


      
