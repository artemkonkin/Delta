using DirectoryDomain.Directory;
using DirectoryServiceLib.Interface.DirectoryInstanceFactory;
using RepositoriesLib.Interfaces.Directory;
using UnitOfWorkLib;

namespace DirectoryServiceLib.DirectoryInstanceFactory;

public class DirectoryInstance : IDirectoryInstance
{
    private readonly IUnitOfWork _uow;
    private readonly IDirectoryListRepository _directoryListRepository;
    private readonly IDirectoryEntityRepository _directoryEntityRepository;
    private readonly IDirectoryRowColDataRepository _directoryRowColDataRepository;
    private readonly IDirectoryRowRepository _directoryRowRepository;
    private readonly IDirectoryColRepository _directoryColRepository;

    private DirectoryEntity CurrentDirectory { get; set; }

    public DirectoryInstance(IUnitOfWork uow, IDirectoryListRepository directoryListRepository,
        IDirectoryEntityRepository directoryEntityRepository,
        IDirectoryRowColDataRepository directoryRowColDataRepository, IDirectoryRowRepository directoryRowRepository,
        IDirectoryColRepository directoryColRepository)
    {
        _uow = uow;

        _directoryListRepository = directoryListRepository;
        _directoryEntityRepository = directoryEntityRepository;
        _directoryRowColDataRepository = directoryRowColDataRepository;
        _directoryRowRepository = directoryRowRepository;
        _directoryColRepository = directoryColRepository;

        CurrentDirectory = new DirectoryEntity();
    }

    public DirectoryEntity GetCurrentDirectory()
    {
        return CurrentDirectory;
    }

    public DirectoryEntity SetCurrentDirectory(DirectoryEntity directoryEntity)
    {
        CurrentDirectory.Name = directoryEntity.Name;
        CurrentDirectory.DirectoryList = directoryEntity.DirectoryList;
        CurrentDirectory.DirectoryListId = directoryEntity.DirectoryListId;
        CurrentDirectory.DirectoryRows = directoryEntity.DirectoryRows;

        return CurrentDirectory;
    }

    public DirectoryEntity EditCurrentDirectory(DirectoryEntity directoryEntity)
    {
        CurrentDirectory.Name = directoryEntity.Name;
        CurrentDirectory.DirectoryList = directoryEntity.DirectoryList;
        CurrentDirectory.DirectoryListId = directoryEntity.DirectoryListId;
        CurrentDirectory.DirectoryRows = directoryEntity.DirectoryRows;

        return CurrentDirectory;
    }

    public DirectoryEntity ClearCurrentDirectory(Guid id)
    {
        CurrentDirectory = new DirectoryEntity();

        return CurrentDirectory;
    }

    public void AddColumns(IEnumerable<DirectoryCol> columns)
    {
        throw new NotImplementedException();
    }

    public void AddRows(IEnumerable<DirectoryRow> rows)
    {
        throw new NotImplementedException();
    }

    public void AddRowColData(DirectoryRowColData data)
    {
        throw new NotImplementedException();
    }

    public DirectoryEntity SaveDirectoryEntityToDataBase(DirectoryEntity directoryEntity)
    {
        _directoryEntityRepository.AddDirectoryEntity(directoryEntity);
        _uow.CommitAsync();

        throw new NotImplementedException();
    }
}