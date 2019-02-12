using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OutlayManager.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace OutlayManager.DataAccess
{
    public static class DataAccessDI
    {
        
        // Register DI dependencies
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            string connectionStr = configuration.GetConnectionString("OutlayManagerDatabase");
            services.AddDbContext<DataContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(connectionStr);
            });
            services.AddScoped(typeof(DbContext), typeof(DataContext));
        }

        public static void ConfigureMiddleware(this IApplicationBuilder app)
        {

        }
    }
}
