using System.Linq;
using System.Threading.Tasks;
using Shamsheer.Domain.Commons;
using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Shamsheer.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly ShamsheerDbContext dbContext;
    private readonly DbSet<TEntity> dbSet;

    public Repository()
    {
        dbContext = new ShamsheerDbContext();
        this.dbSet = dbContext.Set<TEntity>();
    }

    
    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        return entity;
    }


    public async Task<bool> RemoveAsync(long id)
    {
        var entity = await dbSet.FirstOrDefaultAsync(e => e.Id == id);
        dbSet.Remove(entity);
        return true;
    }


    public async Task<bool> SaveChangeAsync()
        => await this.dbContext.SaveChangesAsync() > 0;


    public IQueryable<TEntity> SelectAll()
        => this.dbSet;



    public async Task<TEntity> SelectByIdAsync(long id)
        => await dbSet.FirstOrDefaultAsync(e => e.Id == id);



    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entities = (dbContext.Update(entity)).Entity;
        return entities;
    }
}

