using Microsoft.EntityFrameworkCore;

namespace DbContextLib
{
    /// <summary>
    /// Data base factory
    /// </summary>
    public class DbFactory : IDisposable
    {
        private bool _disposed;
        private readonly Func<AppDbContext?> _instanceFunc;
        private DbContext? _dbContext;
        public DbContext DbContext
            => (_dbContext ??= _instanceFunc.Invoke())
               ?? throw new Exception("DbContext is NULL!");

        public DbFactory(Func<AppDbContext?> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;
            _dbContext?.Dispose();
        }
    }
}