using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OutlayManager.BusinessLogic.Interfaces;
using OutlayManager.BusinessLogic.Services;

namespace OutlayManager.BusinessLogic
{
    public static class BusinessLogicDI
    {

        // Register DI dependencies
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
        }

        public static void ConfigureMiddleware(this IApplicationBuilder app)
        {

        }
    }
}