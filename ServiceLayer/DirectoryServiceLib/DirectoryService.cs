using BaseEntityLib;
using DirectoryDomain.Directory;
using DirectoryServiceLib.Interface;
using EnumsLib;
using RepositoriesLib.Interfaces.Directory;
using UnitOfWorkLib;

namespace DirectoryServiceLib
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IDirectoryListRepository _list;
        private readonly IDirectoryEntityRepository _entity;
        private readonly IDirectoryRowColDataRepository _rowCol;
        private readonly IDirectoryRowRepository _row;
        private readonly IDirectoryColRepository _col;

        public DirectoryService(IUnitOfWork uow, IDirectoryListRepository list, IDirectoryEntityRepository entity, IDirectoryRowColDataRepository rowCol, IDirectoryRowRepository row, IDirectoryColRepository col)
        {
            _uow = uow;
            _list = list;
            _entity = entity;
            _rowCol = rowCol;
            _row = row;
            _col = col;
        }

        public Response<IQueryable<DirectoryEntity>> GetDirectoryEntities(Guid directoryListId)
        {
            var directories = _entity.GetAllDirectoriesEntitiesByListId(directoryListId);

            return directories;
        }
    }
}