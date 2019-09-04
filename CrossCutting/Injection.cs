using Microsoft.Extensions.DependencyInjection;
using MMInfra;
using MMInfra.Interfaces;
using MMService;
using MMService.Interfaces;

namespace CrossCutting
{
    public class Injection
    {
        public static void config(IServiceCollection services)
        {
            // Service
            services.AddScoped<IUserService, UserService>();

            // Database
            services.AddScoped<IUserDB, UserDB>();
        }
    }
}
