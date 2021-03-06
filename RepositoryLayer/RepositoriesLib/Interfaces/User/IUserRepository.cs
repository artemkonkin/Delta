using BaseRepositoryLib;
using AppUser = UserDomain.AppUser;

namespace RepositoriesLib.Interfaces.User
{
    public interface IUserRepository : IRepository<AppUser>
    {
        AppUser NewUser(string userName, string email);
    }
}