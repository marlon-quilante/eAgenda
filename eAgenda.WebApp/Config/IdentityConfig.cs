using eAgenda.Infraestrutura.Orm;
using Microsoft.AspNetCore.Identity;

namespace eAgenda.Dominio.ModuloAutenticacao
{
    public static class IdentityConfig
    {
        public static void AddIdentityProviderConfig(this IServiceCollection services)
        {
            services.AddIdentity<Usuario, Cargo>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
