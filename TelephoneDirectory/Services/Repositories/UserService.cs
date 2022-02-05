using TelephoneDirectory.Data.Entities;
using TelephoneDirectory.Data.Entities.ApiRequest;
using TelephoneDirectory.Data.Entities.ApiResponse;
using TelephoneDirectory.Data.Models;
using TelephoneDirectory.Services.Interfaces;

namespace TelephoneDirectory.Services.Repositories
{
    public class UserService : IUserService
    {
        public void Create(CreateUserRequest createUserRequest)
        {
            using var context = new TelephoneDirectoryContext();
            var user = new User
            {
                FirmName = createUserRequest.FirmName,
                Name = createUserRequest.Name,
                SurName = createUserRequest.SurName
            };
            context.Users.Add(user);
            context.SaveChanges();


            if (createUserRequest.UserInformations?.Count > 0)
            {
                foreach (var item in createUserRequest.UserInformations)
                {
                    var userInformation = new UserInformation
                    {
                        InformationContent = item.InformationContent,
                        UserId = user.Uuid,
                        UserInformationType = item.UserInformationType
                    };
                    context.UserInformations.Add(userInformation);
                    context.SaveChanges();
                }
            }

        }

        public UserResponse? GetUserById(int userId)
        {
            using var context = new TelephoneDirectoryContext();
            var user = context.Users.FirstOrDefault(x => x.Uuid == userId);
            
            if(user != null)
            {
                var userInformations = context.UserInformations.Where(x => x.UserId == user.Uuid).ToList();

                return new UserResponse
                {
                    FirmName = user.FirmName,
                    Name = user.Name,
                    SurName = user.SurName,
                    UserInformations = userInformations
                };
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public void Delete(int userId)
        {
            using var context = new TelephoneDirectoryContext();
            var user = context.Users.FirstOrDefault(x => x.Uuid == userId);

            if(user != null)
            {
                context.Remove(user);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public void AddUserInfrmation(UserInformationRequest userInformationRequest)
        {
            using var context = new TelephoneDirectoryContext();

            var user = context.Users.FirstOrDefault(x => x.Uuid == userInformationRequest.UserId);

            if(user != null)
            {
                context.UserInformations.Add(new UserInformation
                {
                    UserId = userInformationRequest.UserId,
                    InformationContent = userInformationRequest.InformationContent,
                    UserInformationType = userInformationRequest.UserInformationType
                });

                context.SaveChanges();
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public void DeleteUserInfrmation(int userId, int informationId)
        {
            using var context = new TelephoneDirectoryContext();

            var user = context.Users.FirstOrDefault(x => x.Uuid == userId);

            if (user != null)
            {
                var information = context.UserInformations.FirstOrDefault(x => x.InformationId == informationId && x.UserId == userId);

                if(information != null)
                {
                    context.UserInformations.Remove(information);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("User or Information not found");
                }
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public IList<User> GetUsers()
        {
            using var context = new TelephoneDirectoryContext();
            return context.Users.ToList();
        }

        public IList<UserInformation> GetAllUserInformationsData()
        {
            using var context = new TelephoneDirectoryContext();
            return context.UserInformations.ToList();
        }
    }
}
