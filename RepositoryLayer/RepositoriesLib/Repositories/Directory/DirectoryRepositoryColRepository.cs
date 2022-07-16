using BaseEntityLib;
using BaseRepositoryLib;
using DbContextLib;
using DirectoryDomain.Directory;
using EnumsLib;
using RepositoriesLib.Interfaces.Directory;

namespace RepositoriesLib.Repositories.Directory;

public class DirectoryColRepository : Repository<DirectoryCol>, IDirectoryColRepository
{
    public DirectoryColRepository(DbFactory dbFactory) : base(dbFactory)
    {
    }

    public Response<IQueryable<DirectoryCol>> GetAllDirectoriesCols()
    {
        var directoryCol = Get(c => true);
        return new Response<IQueryable<DirectoryCol>>
        {
            Status = ResponseStatus.Success,
            Data = directoryCol,
            Message = null
        };
    }

    public Response<DirectoryCol> GetDirectoryCol(Guid id)
    {
        var directoryCol = Get(c => c.Id == id).First();
        return new Response<DirectoryCol>
        {
            Status = ResponseStatus.Success,
            Data = directoryCol,
            Message = null
        };
    }

    public Response<DirectoryCol> AddDirectoryCol(DirectoryCol directoryColEntity)
    {
        Add(directoryColEntity);
        return new Response<DirectoryCol>
        {
            Status = ResponseStatus.Success,
            Data = directoryColEntity,
            Message = null
        };
    }

    public Response<DirectoryCol> AddEmptyDirectoryCol(string name)
    {
        var directoryColEntity = new DirectoryCol();
        return new Response<DirectoryCol>
        {
            Status = ResponseStatus.Success,
            Data = directoryColEntity,
            Message = null
        };
    }

    public Response<DirectoryCol> EditDirectoryCol(DirectoryCol directoryColEntity)
    {
        Update(directoryColEntity);
        return new Response<DirectoryCol>
        {
            Status = ResponseStatus.Success,
            Data = directoryColEntity,
            Message = null
        };
    }

    public Response<DirectoryCol> RenameDirectoryCol(Guid id, string name)
    {
        var directoryColEntity = GetDirectoryCol(id).Data;

        directoryColEntity.Name = name;

        Update(directoryColEntity);

        return new Response<DirectoryCol>
        {
            Status = ResponseStatus.Success,
            Data = directoryColEntity,
            Message = null
        };
    }

    public Response<DirectoryCol> DeleteDirectoryCol(Guid id)
    {
        var directoryColEntity = Get(c => c.Id == id).First();

        Delete(directoryColEntity);

        return new Response<DirectoryCol>
        {
            Status = ResponseStatus.Success,
            Data = directoryColEntity,
            Message = null
        };
    }
}