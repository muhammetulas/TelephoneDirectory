using TelephoneDirectory.Data.Entities;
using TelephoneDirectory.Data.Entities.ApiRequest;
using TelephoneDirectory.Data.Entities.ApiResponse;

namespace TelephoneDirectory.Services.Interfaces
{
    public interface IUserService
    {
        public IList<User> GetUsers();
        public UserResponse? GetUserById(int userId);
        public void Create(CreateUserRequest createUserRequest);
        public void Delete(int userId);
        public void AddUserInfrmation(UserInformationRequest userInformationRequest);
        public void DeleteUserInfrmation(int userId, int informationId);
        IList<UserInformation> GetAllUserInformationsData();
    }
}
