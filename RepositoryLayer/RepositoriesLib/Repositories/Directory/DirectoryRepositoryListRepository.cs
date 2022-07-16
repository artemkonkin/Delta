using BaseEntityLib;
using BaseRepositoryLib;
using DbContextLib;
using DirectoryDomain;
using EnumsLib;
using RepositoriesLib.Interfaces.Directory;

namespace RepositoriesLib.Repositories.Directory
{
    public class DirectoryListRepository : Repository<DirectoriesList>, IDirectoryListRepository
    {
        public DirectoryListRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// Get all directory lists
        /// </summary>
        /// <returns></returns>
        public IQueryable<DirectoriesList> GetAllDirectoriesLists()
        {
            return Get(lists => true);
        }

        /// <summary>
        /// Get directory list
        /// </summary>
        /// <param name="directoryListId"> Directory list id </param>
        /// <returns></returns>
        public Response<DirectoriesList> GetDirectoryListById(Guid directoryListId)
        {
            var result = Get(lists => lists.Id == directoryListId);
            return new Response<DirectoriesList>
            {
                Status = ResponseStatus.Success,
                Data = result.Any()
                    ? result.First()
                    : throw new Exception($"Directory list {directoryListId} not fount."),
                Message = null
            };
        }

        /// <summary>
        /// Add directory list with guides
        /// </summary>
        /// <param name="directoryListEntity"> Directory list entity </param>
        /// <returns></returns>
        public Response<DirectoriesList> AddDirectoryList(DirectoriesList directoryListEntity)
        {
            Add(directoryListEntity);

            return new Response<DirectoriesList>
            {
                Status = ResponseStatus.Success,
                Data = directoryListEntity,
                Message = null
            };
        }

        /// <summary>
        /// Add empty directory list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Response<DirectoriesList> AddEmptyDirectoryList(string name)
        {
            var newList = new DirectoriesList
            {
                Name = name
            };

            Add(newList);

            return new Response<DirectoriesList>
            {
                Status = ResponseStatus.Success,
                Data = newList,
                Message = null
            };
        }

        /// <summary>
        /// Edit directory list
        /// </summary>
        /// <param name="directoryListEntity"> Directory list entity </param>
        /// <returns></returns>
        public Response<DirectoriesList> UpdateDirectoryList(DirectoriesList directoryListEntity)
        {
            Update(directoryListEntity);

            return new Response<DirectoriesList>
            {
                Status = ResponseStatus.Success,
                Data = directoryListEntity,
                Message = null
            };
        }

        /// <summary>
        /// Update directory list
        /// </summary>
        /// <param name="id"> Directory list id </param>
        /// <param name="name"> Directory list name </param>
        /// <returns></returns>
        public Response<DirectoriesList> RenameDirectoryList(Guid id, string name)
        {
            var guideList = Get(x => x.Id == id);

            if (!guideList.Any())
                throw new Exception($"Directory list {id} not fount.");

            var list = guideList.First();

            var updatedList = new DirectoriesList
            {
                Id = list.Id,
                Name = name,
                DirectoryEntities = list.DirectoryEntities
            };

            Update(updatedList);

            return new Response<DirectoriesList>
            {
                Status = ResponseStatus.Success,
                Data = updatedList,
                Message = null
            };
        }

        /// <summary>
        /// Delete directory list
        /// </summary>
        /// <param name="id"> Directory list id </param>
        /// <returns></returns>
        public Response<DirectoriesList> DeleteDirectoryList(Guid id)
        {
            var guideList = Get(x => x.Id == id);
            if (!guideList.Any())
                throw new Exception($"Directory list {id} not fount.");

            var deletedDirectoryList = guideList.First();

            Delete(deletedDirectoryList);

            return new Response<DirectoriesList>
            {
                Status = ResponseStatus.Success,
                Data = deletedDirectoryList,
                Message = null
            };
        }
    }
}
