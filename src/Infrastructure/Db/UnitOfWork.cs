using System;
using Application.Meta;

namespace Infrastructure.Db
{
	public class UnitOfWork : IUnitOfWork
	{
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
		}

        public Task<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

