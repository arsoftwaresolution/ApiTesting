using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace ApiTesting.Services
{
    public class UserManagementService : ApplicationService , ITransientDependency
    {
        private readonly RoleManagementService _roleManagement;
        private readonly ManagementApiClient _managementApiClient;
        private readonly IAuthenticationApiClient _authenticationApiClient;
        private readonly ICurrentUser _currentUser;

        public UserManagementService(
            RoleManagementService roleManagement,
            ICurrentUser currentUser,
            ManagementApiClient managementApiClient,
            IAuthenticationApiClient authenticationApiClient)
        {
            _roleManagement = roleManagement;
            _managementApiClient = managementApiClient;
            _authenticationApiClient = authenticationApiClient;
            _currentUser = currentUser;

        }
        public async Task<User> GetUserBlockByUserIdAsync(string id)
        {
            var blockUser = await _managementApiClient.Users.UpdateAsync(id, new UserUpdateRequest
            {
                Blocked = true,
            });
            return blockUser;
        }
        public async Task<User> DeleteUserBlockByUserIdAsync(string id)
        {
            var unBlockUser = await _managementApiClient.Users.UpdateAsync(id, new UserUpdateRequest
            {
                Blocked = false,
            });
            return unBlockUser;
        }
        public async Task<IList<User>> CheckUserExist(string email)
        {

            var checkUser = await _managementApiClient.Users.GetUsersByEmailAsync(email);
            var user=_currentUser.Roles;
            if (checkUser.Count<0)
            {
                return checkUser;
            }
            throw new UserFriendlyException("Not Exist");
        }
        public async Task UserEmailVerifirdAsync(string email)
        {

            var upd = await _managementApiClient.Users.UpdateAsync(email, new UserUpdateRequest
            {
                EmailVerified = true,
            }) ;
            throw new UserFriendlyException("Not Exist");
        }
        public async Task<string> AssignRolesUsersAsync(AssignUsersRequest id)
        {
            var roles = await _roleManagement.GetRolesAllAsync();
            if (roles.Count()>0)
            {
                var role = roles.FirstOrDefault(x => x.Name.Equals("Patient"));
                var assignUserRole = _managementApiClient.Roles.AssignUsersAsync(role.Id, new AssignUsersRequest
                {
                    Users =id.Users
                });
                return assignUserRole.ToString();
            }
            throw new UserFriendlyException("User role not assigned");
        }
        public async Task<IEnumerable<Role>> GetAllRolesAuthAsync()
        {
            var role = await _managementApiClient.Roles.GetAllAsync(new GetRolesRequest 
            { 
                NameFilter=""
            });
            var ro=role.Where(x => x.Name.Equals("Patient"));
            return ro;
        }
    }
}
