using BaseEntityLib;
using DirectoryDomain;
using DirectoryDomain.ViewModels;

namespace ServicesLib.Directory
{
    public interface IDirectoryListService
    {
        IQueryable<DirectoriesList> GetAllDirectoriesLists();
        Response<DirectoriesList> GetDirectoryListById(Guid directoryListId);
        ReadDirectoryListVm GetDirectoryListWithData(Guid directoryListId);
        Response<DirectoriesList> AddDirectoryList(DirectoriesList directoryListEntity);
        Response<DirectoriesList> UpdateDirectoryList(DirectoriesList directoryListEntity);
        Response<DirectoriesList> UpdateDirectoryList(Guid directoryListId, string directoryListName);
        Response<DirectoriesList> DeleteDirectoryList(Guid directoryListId);
    }
}
