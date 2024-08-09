using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMovie.Domain.UnitOfWork;
using MyMovie.Infrastructure.UnitOfWork;
using System.Data;

namespace MyMovie.Infrastructure.DbExtension;
public static class DbExtension
{

    public static void AddMyConnection(this IServiceCollection services, IConfiguration configuration)
    {

        // configure connection string and inject
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddScoped<IDbConnection>(sp => new MySqlConnection(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWorkImpl>();

    }
}
