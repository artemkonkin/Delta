using Microsoft.AspNetCore.Identity;
using UnitOfWorkLib;
using UserDomain;

namespace BaseServiceLib
{
    public abstract class BaseService : IBaseService
    {
        protected readonly IUnitOfWork Uow;
        protected readonly UserManager<AppUser> UserManager;

        protected BaseService(IUnitOfWork uow, UserManager<AppUser> userManager)
        {
            Uow = uow;
            UserManager = userManager;
        }
    }
}