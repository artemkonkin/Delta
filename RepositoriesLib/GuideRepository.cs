using System.Linq.Expressions;
using BaseRepositoryLib;
using DbContextLib;
using GuideDomain;
using RepositoriesLib.Interfaces;
using UserDomain;

namespace RepositoriesLib
{
    public class GuideRepository : Repository<GuidesList>, IUserRepository
    {
        public GuideRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public void Add(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void Update(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AppUser> Get(Expression<Func<AppUser, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public AppUser NewUser(string userName, string email)
        {
            throw new NotImplementedException();
        }
    }
}
