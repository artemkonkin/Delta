using BaseEntityLib;
using BaseRepositoryLib;
using DbContextLib;
using DirectoryDomain.Directory;
using EnumsLib;
using RepositoriesLib.Interfaces.Directory;

namespace RepositoriesLib.Repositories.Directory;

public class DirectoryRowRepository : Repository<DirectoryRow>, IDirectoryRowRepository
{
    public DirectoryRowRepository(DbFactory dbFactory) : base(dbFactory)
    {
    }

    public Response<IQueryable<DirectoryRow>> GetAllDirectoriesRows()
    {
        var directoryRows = Get(r => true);

        return new Response<IQueryable<DirectoryRow>>
        {
            Status = ResponseStatus.Success,
            Data = directoryRows,
            Message = null
        };
    }

    public Response<DirectoryRow> GetDirectoryRow(Guid id)
    {
        var directoryRows = Get(r => r.Id == id).First();

        return new Response<DirectoryRow>
        {
            Status = ResponseStatus.Success,
            Data = directoryRows,
            Message = null
        };
    }

    public Response<DirectoryRow> AddDirectoryRow(DirectoryRow directoryRowEntity)
    {
        Add(directoryRowEntity);

        return new Response<DirectoryRow>
        {
            Status = ResponseStatus.Success,
            Data = directoryRowEntity,
            Message = null
        };
    }

    public Response<DirectoryRow> EditDirectoryRow(DirectoryRow directoryRowEntity)
    {
        Update(directoryRowEntity);

        return new Response<DirectoryRow>
        {
            Status = ResponseStatus.Success,
            Data = directoryRowEntity,
            Message = null
        };
    }

    public Response<DirectoryRow> DeleteDirectoryRow(Guid id)
    {
        var directoryRows = Get(r => r.Id == id).First();

        Delete(directoryRows);

        return new Response<DirectoryRow>
        {
            Status = ResponseStatus.Success,
            Data = directoryRows,
            Message = null
        };
    }
}