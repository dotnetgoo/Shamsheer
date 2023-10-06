using System.Linq;
using System.Threading.Tasks;
using Shamsheer.Domain.Commons;
using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Shamsheer.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    ShamsheerDbContext dbContext;
    DbSet<TEntity> dbSet;

    public Repository()
    {
        dbContext = new ShamsheerDbContext();
        this.dbSet = dbContext.Set<TEntity>();
    }

    public async Task<TEntity> InsertAsync(TEntity entitiy)
    {
        await dbSet.AddAsync(entitiy);
        await dbContext.SaveChangesAsync();
        return entitiy;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var entity = await dbSet.FirstOrDefaultAsync(e => e.Id == id);
        dbSet.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public IQueryable<TEntity> SelectAllAsync()
        => this.dbSet;

    public async Task<TEntity> SelectByIdAsync(long id)
        => await dbSet.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<TEntity> UpdateAsync(TEntity entitiy)
    {
        var entities = (dbContext.Update(entitiy)).Entity;
        await dbContext.SaveChangesAsync();
        return entities;
    }
}

