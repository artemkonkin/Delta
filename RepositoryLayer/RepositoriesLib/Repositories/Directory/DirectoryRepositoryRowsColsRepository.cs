using BaseEntityLib;
using BaseRepositoryLib;
using DbContextLib;
using DirectoryDomain.Directory;
using RepositoriesLib.Interfaces.Directory;

namespace RepositoriesLib.Repositories.Directory;

public class DirectoryRowColDataRepository : Repository<DirectoryRowColData>, IDirectoryRowColDataRepository
{
    public DirectoryRowColDataRepository(DbFactory dbFactory) : base(dbFactory)
    {
    }

    public Response<IQueryable<DirectoryRowColData>> GetAllDirectoryRowsColsData()
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRowColData> GetDirectoryRowColColData(Guid rowColId)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRowColData> GetDirectoryRowColDataValueByRow(Guid rowId)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRowColData> GetDirectoryRowColDataValueByCol(Guid colId)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRowColData> AddEmptyDirectoryRowColData(string rowColName)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRowColData> AddDirectoryRowColData(DirectoryRowColData directoryRowColDataEntity)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRowColData> EditDirectoryRowColColData(DirectoryRowColData directoryRowColDataEntity)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRowColData> EditDirectoryRowColColDataValue(Guid rowColId, object value)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRowColData> RenameDirectoryRowColData(Guid rowColId, string rowColName)
    {
        throw new NotImplementedException();
    }

    public Response<DirectoryRowColData> DeleteDirectoryRowColData(Guid rowColId)
    {
        throw new NotImplementedException();
    }
}