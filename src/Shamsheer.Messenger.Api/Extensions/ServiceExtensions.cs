using Shamsheer.Data.Repositories;
using Shamsheer.Data.IRepositories;
using Shamsheer.Service.Services.Users;
using Shamsheer.Service.Services.Groups;
using Shamsheer.Service.Interfaces.Users;
using Shamsheer.Service.Interfaces.Groups;
using Shamsheer.Service.Services.UserGroups;
using Shamsheer.Service.Interfaces.UserGroup;
using Shamsheer.Service.Interfaces.Authorizations;
using Shamsheer.Service.Services.Authorizations;

namespace Shamsheer.Messenger.Api.Extensions;

public static class ServiceExtensions
{
    public static void AddCustomService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IGroupRoleService, GroupRoleService>();
        services.AddScoped<IUserGroupService, UserGroupService>();
        services.AddScoped<IGroupRoleRepository, GroupRoleRepository>();
        services.AddScoped<IUserGroupRepository, UserGroupRepository>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IGroupPermissionService, GroupPermissionService>();
        services.AddScoped<IGroupPermissionRepository, GroupPermissionRepository>();
    }
}
