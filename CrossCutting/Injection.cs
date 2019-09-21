using Microsoft.Extensions.DependencyInjection;
using MMInfra.Collections;
using MMInfra.Interfaces;
using MMInfra.Service.Interfaces;
using MMInfra.Service.SMTP;
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

            // Infra.Data
            services.AddScoped<IUserDB, UserDB>();
            services.AddScoped<IUserResetPasswordDB, UserResetPasswordDB>();

            // Infra.Service
            services.AddScoped<ISmtpInfra, SmtpInfra>();
        }
    }
}
