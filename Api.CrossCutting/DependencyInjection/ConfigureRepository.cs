using System;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            // Obter a variável de ambiente e verificar se ela não é nula
            var databaseType = Environment.GetEnvironmentVariable("DATABASE");

            // Usar uma expressão condicional segura para a verificação do tipo de banco de dados
            if (!string.IsNullOrEmpty(databaseType) && string.Equals(databaseType, "SQLSERVER", StringComparison.OrdinalIgnoreCase))
            {
                serviceCollection.AddDbContext<MyContext>(
                    options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }
            else
            {
                serviceCollection.AddDbContext<MyContext>(
                    options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }
        }
    }
}