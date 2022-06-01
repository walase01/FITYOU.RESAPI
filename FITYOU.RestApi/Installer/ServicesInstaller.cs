using FITYOU.Services.user;

namespace FITYOU.RestApi.Installer
{
    public static class ServicesInstaller
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUser, User>();

            return services;
        }
    }
}
