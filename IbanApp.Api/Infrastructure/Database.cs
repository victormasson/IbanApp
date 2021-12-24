using IbanApp.Domain.Interfaces;
using IbanApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace IbanApp.Api.Infrastructure
{
    public record DatabaseConfig(string Host, string Port, string Database, string User, string Password)
    {
        public string GetConnection() =>
            $"Server={Host},{Port};Initial Catalog={Database};Persist Security Info=False;User ID={User};Password={Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }

    public static class Database
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var envUseInMemoryDatabase = Environment.GetEnvironmentVariable("UseInMemoryDatabase");
            if (!bool.TryParse(envUseInMemoryDatabase, out bool useInMemoryDatabase))
                useInMemoryDatabase = true;

            if (useInMemoryDatabase)
            {
                services.AddDbContext<ApplicationDbContext>(opt =>
                    opt.UseInMemoryDatabase("IbanApp"));
            }
            else
            {
                var DB_HOST = Environment.GetEnvironmentVariable("DB_HOST") ?? throw new Exception("DB_HOST is required");
                var DB_PORT = Environment.GetEnvironmentVariable("DB_PORT") ?? throw new Exception("DB_PORT is required");
                var DB_DB = Environment.GetEnvironmentVariable("DB_DB") ?? throw new Exception("DB_DB is required");
                var DB_USER = Environment.GetEnvironmentVariable("DB_USER") ?? throw new Exception("DB_USER is required");
                var DB_PASSWORD = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new Exception("DB_PASSWORD is required");

                var databaseConfig = new DatabaseConfig(
                    DB_HOST,
                    DB_PORT,
                    DB_DB,
                    DB_USER,
                    DB_PASSWORD);

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        databaseConfig.GetConnection(),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                    );
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}
