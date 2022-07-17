using BaseEntityLib;
using DirectoryDomain.Directory;

namespace DirectoryServiceLib.Interface
{
    public interface IDirectoryService
    {
        public Response<IQueryable<DirectoryEntity>> GetDirectoryEntities(Guid directoryListId);
    }
}