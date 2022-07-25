using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
namespace ApiTesting.Services
{
    public class RoleManagementService : ApplicationService
    {
        private readonly ManagementApiClient _managementApiClient;

        public RoleManagementService(ManagementApiClient managementApiClient)
        {
            _managementApiClient = managementApiClient;
        }
        public async Task<Role> CreateRolesAsync(RoleCreateRequest roleCreateRequest)
        {
            var createRole = await _managementApiClient.Roles.CreateAsync(new RoleCreateRequest
            {
                Name = roleCreateRequest.Name,
                Description = roleCreateRequest.Description,
            });
            return createRole;
        }
        public async Task<Role> UpdateRolesAsync(RoleUpdateRequest roleUpdateRequest, string id)
        {
            var updateRole = await _managementApiClient.Roles.UpdateAsync(id, new RoleUpdateRequest
            {
                Name = roleUpdateRequest.Name,
                Description = roleUpdateRequest.Description,
            });
            return updateRole;
        }
        public async Task<IPagedList<Role>> GetRolesAllAsync()
        {
            var getAllRole = await _managementApiClient.Roles.GetAllAsync(new GetRolesRequest
            {
                NameFilter = "",
            });
            return getAllRole;
        }
        public async Task<Role> GetRolesAsync(string id)
        {
            var getRoleById = await _managementApiClient.Roles.GetAsync(id);
            return getRoleById;
        }
        public Task DeleteRolesAsync(string id)
        {
            var deleteRoleById = _managementApiClient.Roles.DeleteAsync(id);
            return deleteRoleById;
        }
        public async Task<IPagedList<AssignedUser>> GetUserAsync(string id)
        {
            var getAssignedUser = await _managementApiClient.Roles.GetUsersAsync(id);
            return getAssignedUser;
        }
        public Task AssignRolesUsersAsync(AssignUsersRequest assignUsersRequest, string id)
        {
            var assignUserRole = _managementApiClient.Roles.AssignUsersAsync(id, new AssignUsersRequest
            {
                Users = assignUsersRequest.Users,
            });
            return assignUserRole;
        }
        public async Task AssignPermissionRolesAsync(string id, AssignPermissionsRequest assignPermissionsRequest)
        {
            await _managementApiClient.Roles.AssignPermissionsAsync(id, new AssignPermissionsRequest
            {
                Permissions = assignPermissionsRequest.Permissions,
            });
        }
        public async Task UpdatePermissionRolesAsync(string id, AssignPermissionsRequest assignPermissionsRequest)
        {
            await _managementApiClient.Roles.RemovePermissionsAsync(id, new AssignPermissionsRequest
            {
                Permissions = assignPermissionsRequest.Permissions,
            });
        }
        public async Task<IPagedList<Permission>> GetPermissionsRolesAsync(string id)
        {
            var getPermission = await _managementApiClient.Roles.GetPermissionsAsync(id, new PaginationInfo { });
            return getPermission;
        }

        public async Task<IPagedList<User>> GetAllUserAsync(GetUsersRequest usersRequest)
        {
            var userList = await _managementApiClient.Users.GetAllAsync(new GetUsersRequest
            {
                Connection = usersRequest.Connection,
                Fields = usersRequest.Fields,
                IncludeFields = usersRequest.IncludeFields,
                Query = usersRequest.Query,
                SearchEngine = usersRequest.SearchEngine,
                Sort = usersRequest.Sort,
            });
            return userList;
        }
    }
}
