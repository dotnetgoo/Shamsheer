using System.Linq;
using System.Threading.Tasks;
using Shamsheer.Domain.Commons;
using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Shamsheer.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    protected readonly ShamsheerDbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(ShamsheerDbContext dbContext)
    {
        this._dbContext = dbContext;
        this._dbSet = _dbContext.Set<TEntity>();
    }

    
    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var entry = await this._dbSet.AddAsync(entity);
        
        await _dbContext.SaveChangesAsync();

        return entry.Entity;
    }


    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await this._dbSet.FirstOrDefaultAsync(e => e.Id == id);
        _dbSet.Remove(entity);

        return await _dbContext.SaveChangesAsync() > 0;
    }


    public IQueryable<TEntity> SelectAll()
        => this._dbSet;

    public async Task<TEntity> SelectByIdAsync(long id)
        => await this._dbSet.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = this._dbContext.Update(entity);
        await this._dbContext.SaveChangesAsync();

        return entry.Entity;
    }
}

