using BaseRepositoryLib;
using DbContextLib;
using RepositoriesLib.Interfaces;
using AppUser = UserDomain.AppUser;

namespace RepositoriesLib
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        public UserRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public AppUser NewUser(string userName, string email)
        {
            var user = new AppUser(userName, email);

            if (user.ValidOnAdd())
            {
                Add(user);
                return user;
            }
            else
                throw new Exception("User invalid");
        }
    }
}