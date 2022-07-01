using DirectoryDomain.Directory;

namespace RepositoriesLib.Interfaces.Directory
{
    public interface IDirectoryColumn
    {
        /* COLUMNS */

        #region COLUMNS

        /// <summary>
        /// Get all dirrectory cols
        /// </summary>
        /// <returns></returns>
        IQueryable<DirectoryCol> GetAllDirectoriesCols();

        /// <summary>
        /// Get dirrectory col
        /// </summary>
        /// <param name="id"> Col id </param>
        /// <returns></returns>
        DirectoryCol GetDirectoryCol(Guid id);

        /// <summary>
        /// Add dirrectory col
        /// </summary>
        /// <param name="directoryColEntity"> Directory col entity </param>
        /// <returns></returns>
        DirectoryCol AddDirectoryCol(DirectoryCol directoryColEntity);

        /// <summary>
        /// Add emty dirrectory col
        /// </summary>
        /// <param name="name"> Directory col name </param>
        /// <returns></returns>
        DirectoryCol AddEmptyDirectoryCol(string name);

        /// <summary>
        /// Edit dirrectory col
        /// </summary>
        /// <param name="directoryColEntity"> Directory col entity </param>
        /// <returns></returns>
        DirectoryCol EditDirectoryCol(DirectoryCol directoryColEntity);

        /// <summary>
        /// Rename dirrectory col
        /// </summary>
        /// <param name="id"> Directory col id </param>
        /// <param name="name"> Directory col name </param>
        /// <returns></returns>
        DirectoryCol RenameDirectoryCol(Guid id, string name);

        /// <summary>
        /// Delete dirrectory col
        /// </summary>
        /// <param name="id"> Directory col id </param>
        /// <returns></returns>
        IQueryable<DirectoryCol> DeleteDirectoryCol(Guid id);

        #endregion
    }
}
