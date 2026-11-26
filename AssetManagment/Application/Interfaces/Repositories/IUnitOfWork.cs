namespace Application.Interfaces.Repository;

public interface IUnitOfWork
{
    Task BeginTransactionAsync();
    Task CommitTrainsactionAsync();
    Task RollbackTransactionAsync();
    Task DisposeTransactionAsync();
}