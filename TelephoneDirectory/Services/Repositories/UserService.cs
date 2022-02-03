using TelephoneDirectory.Data.Entities;
using TelephoneDirectory.Data.Entities.ApiRequest;
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

        public CreateUserRequest? GetUserById(int userId)
        {
            using var context = new TelephoneDirectoryContext();
            var user = context.Users.FirstOrDefault(x => x.Uuid == userId);
            
            if(user != null)
            {
                var userInformations = context.UserInformations.Where(x => x.UserId == user.Uuid).ToList();

                var response = new CreateUserRequest
                {
                    FirmName = user.FirmName,
                    Name = user.Name,
                    SurName = user.SurName
                };

                foreach (var item in userInformations)
                {
                    response.UserInformations.Add(new UserInformationRequest
                    {
                        InformationContent = item.InformationContent,
                        UserId = item.UserId,
                        UserInformationType = item.UserInformationType
                    });
                }

                return response;
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

        public IList<User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
