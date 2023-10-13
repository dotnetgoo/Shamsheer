using System.Linq;
using System.Threading.Tasks;
using Shamsheer.Domain.Commons;
using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Shamsheer.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly ShamsheerDbContext _dbContext;
    private readonly DbSet<TEntity> dbSet;

    public Repository(ShamsheerDbContext dbContext)
    {
        this._dbContext = dbContext;
        this.dbSet = _dbContext.Set<TEntity>();
    }

    
    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        await this.dbSet.AddAsync(entity);
        return entity;
    }


    public async Task<bool> RemoveAsync(long id)
    {
        var entity = await this.dbSet.FirstOrDefaultAsync(e => e.Id == id);
        dbSet.Remove(entity);
        return true;
    }


    public async Task<bool> SaveChangeAsync()
        => await this._dbContext.SaveChangesAsync() > 0;


    public IQueryable<TEntity> SelectAll()
        => this.dbSet;



    public async Task<TEntity> SelectByIdAsync(long id)
        => await dbSet.FirstOrDefaultAsync(e => e.Id == id);



    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entities = (this._dbContext.Update(entity)).Entity;
        return entities;
    }
}

