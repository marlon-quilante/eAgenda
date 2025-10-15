using Microsoft.EntityFrameworkCore;

namespace eAgenda.Infraestrutura.Orm
{
    public static class AppDbContextFactory
    {
        public static AppDbContext CriarDbContext(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString, options => options.EnableRetryOnFailure(3));

            return new AppDbContext(builder.Options);
        }
    }
}
