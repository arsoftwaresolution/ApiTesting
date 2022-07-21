using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ApiTesting.Services
{
    public class UserManagementService:ApplicationService
    {
        private readonly ManagementApiClient _managementApiClient;

        public UserManagementService(ManagementApiClient managementApiClient)
        {
            _managementApiClient = managementApiClient;
        }
        public async Task<UserBlocks> GetUserBlockAsync(string id)
        {
            var blockUser= await _managementApiClient.UserBlocks.GetByUserIdAsync(id);
            return blockUser;
        }
        public async Task DeleteUserUnblockAsync(string id)
        {
            await _managementApiClient.UserBlocks.UnblockByUserIdAsync(id);
        }
        public async Task<UserBlocks> GetUserBlockByIdentifierAsync(string identifier)
        {
            var blockUser = await _managementApiClient.UserBlocks.GetByIdentifierAsync(identifier);
            return blockUser;
        }
        public async Task DeleteUserUnblockByIdentifierAsync(string identifier)
        {
            await _managementApiClient.UserBlocks.UnblockByIdentifierAsync(identifier);

        }
    }
}
