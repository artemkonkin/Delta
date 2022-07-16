using BaseEntityLib;
using BaseRepositoryLib;
using DbContextLib;
using DirectoryDomain.Directory;
using RepositoriesLib.Interfaces.Directory;

namespace RepositoriesLib.Repositories.Directory;

public class DirectoryRowRepository : Repository<DirectoryRow>, IDirectoryRowRepository
{
    public DirectoryRowRepository(DbFactory dbFactory) : base(dbFactory)
    {
    }

    public Response<IQueryable<DirectoryCol>> GetAllDirectoriesRows()
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRow> GetDirectoryRow(Guid id)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRow> GetDirectoryRowData(Guid id)
    {
        throw new NotImplementedException();
    }

    public Response<IQueryable<DirectoryCol>> GetDirectoryRowCols(Guid id)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRow> AddDirectoryRow(DirectoryRow directoryRowEntity)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRow> AddEmptyDirectoryRow(string name)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRow> EditDirectoryRow(DirectoryRow directoryRowEntity)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRow> RenameDirectoryRow(Guid id, string name)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRow> DeleteDirectoryRow(Guid id)
    {
        throw new NotImplementedException();
    }
}