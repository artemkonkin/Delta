using BaseEntityLib;
using BaseRepositoryLib;
using DbContextLib;
using DirectoryDomain.Directory;
using RepositoriesLib.Interfaces.Directory;

namespace RepositoriesLib.Repositories.Directory;

public class DirectoryColRepository : Repository<DirectoryCol>, IDirectoryColRepository
{
    public DirectoryColRepository(DbFactory dbFactory) : base(dbFactory)
    {
    }

    public Response<IQueryable<DirectoryCol>> GetAllDirectoriesCols()
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryCol> GetDirectoryCol(Guid id)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryCol> AddDirectoryCol(DirectoryCol directoryColEntity)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryCol> AddEmptyDirectoryCol(string name)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryCol> EditDirectoryCol(DirectoryCol directoryColEntity)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryCol> RenameDirectoryCol(Guid id, string name)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryCol> DeleteDirectoryCol(Guid id)
    {
        throw new NotImplementedException();
    }
}