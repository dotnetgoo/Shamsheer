using Shamsheer.Data.IRepositories;
using Shamsheer.Data.Repositories;
using Shamsheer.Service.Interfaces;
using Shamsheer.Service.Services;

namespace Shamsheer.Messenger.Api.Extensions;

public static class ServiceExtensions
{
    public static void AddCustomService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
