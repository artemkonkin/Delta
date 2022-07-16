using BaseEntityLib;
using BaseRepositoryLib;
using DbContextLib;
using DirectoryDomain.Directory;
using EnumsLib;
using RepositoriesLib.Interfaces.Directory;

namespace RepositoriesLib.Repositories.Directory;

public class DirectoryEntityRepository : Repository<DirectoryEntity>, IDirectoryEntityRepository
{
    public DirectoryEntityRepository(DbFactory dbFactory) : base(dbFactory)
    {
    }

    public Response<IQueryable<DirectoryEntity>> GetAllDirectoriesEntities()
    {
        var directoryEntity = Get(e => true);
        return new Response<IQueryable<DirectoryEntity>>
        {
            Status = ResponseStatus.Success,
            Data = directoryEntity,
            Message = null
        };
    }

    public Response<DirectoryEntity> GetDirectoryEntity(Guid id)
    {
        var directoryEntity = Get(e => true).First();
        return new Response<DirectoryEntity>
        {
            Status = ResponseStatus.Success,
            Data = directoryEntity,
            Message = ""
        };
    }

    public Response<DirectoryEntity> AddDirectoryEntity(DirectoryEntity directoryEntity)
    {
        Add(directoryEntity);

        return new Response<DirectoryEntity>
        {
            Status = ResponseStatus.Success,
            Data = directoryEntity,
            Message = ""
        };
    }

    public Response<DirectoryEntity> AddEmptyDirectoryEntity(string name)
    {
        var directoryEntity = new DirectoryEntity()
        {
            Name = name
        };

        Add(directoryEntity);

        return new Response<DirectoryEntity>
        {
            Status = ResponseStatus.Success,
            Data = directoryEntity,
            Message = ""
        };
    }

    public Response<DirectoryEntity> EditDirectory(DirectoryEntity directoryEntity)
    {
        Update(directoryEntity);

        return new Response<DirectoryEntity>
        {
            Status = ResponseStatus.Success,
            Data = directoryEntity,
            Message = ""
        };
    }

    public Response<DirectoryEntity> RenameDirectoryEntity(Guid id, string name)
    {
        var directoryEntity = GetDirectoryEntity(id).Data;

        directoryEntity.Name = name;

        Update(directoryEntity);

        return new Response<DirectoryEntity>
        {
            Status = ResponseStatus.Success,
            Data = directoryEntity,
            Message = ""
        };
    }

    public Response<DirectoryEntity> DeleteDirectoryEntity(Guid id)
    {
        var directoryEntity = GetDirectoryEntity(id).Data;

        Delete(directoryEntity);

        return new Response<DirectoryEntity>
        {
            Status = ResponseStatus.Success,
            Data = new DirectoryEntity(),
            Message = ""
        };
    }
}