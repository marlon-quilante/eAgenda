using eAgenda.Infraestrutura.Orm.ModuloCategoria;
using eAgenda.Infraestrutura.Orm.ModuloCompromisso;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using eAgenda.Infraestrutura.Orm.ModuloDespesa;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eAgenda.Infraestrutura.Orm
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCamadaInfraestrutura(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                var connectionString = configuration["SQL_CONNECTION_STRING"];

                opt.UseSqlServer(connectionString);
            });

            services.AddScoped<IRepositorioContato, RepositorioContato>();
            services.AddScoped<IRepositorioCompromisso, RepositorioCompromisso>();
            services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
            services.AddScoped<IRepositorioDespesa, RepositorioDespesa>();

            return services;
        }
    }
}
