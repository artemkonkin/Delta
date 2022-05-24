namespace UnitOfWorkLib
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}