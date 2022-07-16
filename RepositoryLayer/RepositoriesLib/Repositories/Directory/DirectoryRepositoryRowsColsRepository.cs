using BaseEntityLib;
using BaseRepositoryLib;
using DbContextLib;
using DirectoryDomain.Directory;
using EnumsLib;
using RepositoriesLib.Interfaces.Directory;

namespace RepositoriesLib.Repositories.Directory;

public class DirectoryRowColDataRepository : Repository<DirectoryRowColData>, IDirectoryRowColDataRepository
{
    public DirectoryRowColDataRepository(DbFactory dbFactory) : base(dbFactory)
    {
    }

    public Response<IQueryable<DirectoryRowColData>> GetAllDirectoryRowsColsData()
    {
        var directoryRowColData = Get(d => true);

        return new Response<IQueryable<DirectoryRowColData>>
        {
            Status = ResponseStatus.Success,
            Data = directoryRowColData,
            Message = null
        };
    }

    public Response<DirectoryRowColData> GetDirectoryRowColColData(Guid rowColId)
    {
        var directoryRowColData = Get(d => d.Id == rowColId).First();

        return new Response<DirectoryRowColData>
        {
            Status = ResponseStatus.Success,
            Data = directoryRowColData,
            Message = null
        };
    }

    public Response<DirectoryRowColData> GetDirectoryRowColDataValueByRow(Guid rowId)
    {
        var directoryRowColData = Get(d => true)
            .First(r => r.DirectoryRowId == rowId);

        return new Response<DirectoryRowColData>
        {
            Status = ResponseStatus.Success,
            Data = directoryRowColData,
            Message = null
        };
    }

    public Response<DirectoryRowColData> GetDirectoryRowColDataValueByCol(Guid colId)
    {
        var directoryRowColData = Get(d => true)
            .First(r => r.DirectoryColId == colId);

        return new Response<DirectoryRowColData>
        {
            Status = ResponseStatus.Success,
            Data = directoryRowColData,
            Message = null
        };
    }

    public Response<DirectoryRowColData> AddDirectoryRowColData(DirectoryRowColData directoryRowColDataEntity)
    {
        Add(directoryRowColDataEntity);

        return new Response<DirectoryRowColData>
        {
            Status = ResponseStatus.Success,
            Data = directoryRowColDataEntity,
            Message = null
        };
    }

    public Response<DirectoryRowColData> EditDirectoryRowColColData(DirectoryRowColData directoryRowColDataEntity)
    {
        Update(directoryRowColDataEntity);

        return new Response<DirectoryRowColData>
        {
            Status = ResponseStatus.Success,
            Data = directoryRowColDataEntity,
            Message = null
        };
    }

    public Response<DirectoryRowColData> EditDirectoryRowColColDataValue(Guid rowColId, object value)
    {
        var directoryRowColData = Get(d => d.Id == rowColId).First();

        directoryRowColData.Value = value;

        Update(directoryRowColData);

        return new Response<DirectoryRowColData>
        {
            Status = ResponseStatus.Success,
            Data = directoryRowColData,
            Message = null
        };
    }

    public Response<DirectoryRowColData> DeleteDirectoryRowColData(Guid rowColId)
    {
        var directoryRowColData = Get(d => d.Id == rowColId).First();

        Delete(directoryRowColData);

        return new Response<DirectoryRowColData>
        {
            Status = ResponseStatus.Success,
            Data = directoryRowColData,
            Message = null
        };
    }
}