using BaseEntityLib;
using DirectoryDomain;

namespace RepositoriesLib.Interfaces.Directory
{
    public interface IDirectoriesList
    {
        #region GUIDES LISTS

        /// <summary>
        /// Get all directories lists
        /// </summary>
        /// <returns></returns>
        IQueryable<DirectoriesList> GetAllDirectoriesLists();

        /// <summary>
        /// Get directory list
        /// </summary>
        /// <param name="directoryListId"> Directory list id </param>
        /// <returns></returns>
        Response<DirectoriesList> GetDirectoryListById(Guid directoryListId);

        /// <summary>
        /// Add directory list with guides
        /// </summary>
        /// <param name="directoryListEntity"> Directory list entity </param>
        /// <returns></returns>
        Response<DirectoriesList> AddDirectoryList(DirectoriesList directoryListEntity);

        /// <summary>
        /// Add empty directory list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Response<DirectoriesList> AddEmptyDirectoryList(string name);

        /// <summary>
        /// Edit directory list
        /// </summary>
        /// <param name="directoryListEntity"> Directory list entity </param>
        /// <returns></returns>
        Response<DirectoriesList> UpdateDirectoriesList(DirectoriesList directoryListEntity);

        /// <summary>
        /// Update directory list
        /// </summary>
        /// <param name="id"> Directory list id </param>
        /// <param name="name"> Directory list name </param>
        /// <returns></returns>
        Response<DirectoriesList> RenameDirectoryList(Guid id, string name);

        /// <summary>
        /// Delete directory list
        /// </summary>
        /// <param name="id"> Directory list id </param>
        /// <returns></returns>
        Response<DirectoriesList> DeleteDirectoryList(Guid id);

        #endregion
    }
}
