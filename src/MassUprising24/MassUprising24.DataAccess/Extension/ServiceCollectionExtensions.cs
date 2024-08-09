using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MassUprising24.DataAccess.Extension;

public static class ServiceCollectionExtensions
{
    public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<MassUprising24Context>(opt => opt.UseSqlServer(connectionString));
        services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
    }
}