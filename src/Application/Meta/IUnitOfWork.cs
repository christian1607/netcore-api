using System;
namespace Application.Meta
{
	public interface IUnitOfWork
	{
		Task<int> SaveChanges(CancellationToken cancellationToken = default);
	}
}

