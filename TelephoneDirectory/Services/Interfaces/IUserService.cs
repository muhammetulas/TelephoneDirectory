using TelephoneDirectory.Data.Entities;
using TelephoneDirectory.Data.Entities.ApiRequest;

namespace TelephoneDirectory.Services.Interfaces
{
    public interface IUserService
    {
        public IList<User> GetUsers();
        public CreateUserRequest? GetUserById(int userId);
        public void Create(CreateUserRequest createUserRequest);
        public void Delete(int userId);
    }
}
