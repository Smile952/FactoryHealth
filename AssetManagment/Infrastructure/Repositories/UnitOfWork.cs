using Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    AssetManagmentContext _context;
    IDbContextTransaction? transaction;
    public UnitOfWork(AssetManagmentContext context)
    {
        this._context = context;
    }
    public async Task CommitTrainsactionAsync()
    {
        await _context.SaveChangesAsync();
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public async Task BeginTransactionAsync()
    {
        transaction = await _context.Database.BeginTransactionAsync();
    }
    public async Task DisposeTransactionAsync()
    {
        if(transaction is not null)
            await transaction.DisposeAsync();
            transaction = null;
    }
}