using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class MunicipioImplementation : BaseRepository<MunicipioEntity>, IMunicipioRepository
    {
        private DbSet<MunicipioEntity> _dataset;

        public MunicipioImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<MunicipioEntity>();
        }

        public async Task<MunicipioEntity> GetCompleteByIBGE(int codIBGE)
        {
            return await _dataset
                .Include(m => m.Uf) // Inclui a relação com UfEntity
                .FirstOrDefaultAsync(m => m.CodIBGE == codIBGE);
        }

        public async Task<IEnumerable<MunicipioEntity>> SelectAllWithUfAsync()
        {
            return await _dataset
                .Include(m => m.Uf)
                .ToListAsync();
        }
    }

    internal interface IMunicipioRepository
    {
    }
}
