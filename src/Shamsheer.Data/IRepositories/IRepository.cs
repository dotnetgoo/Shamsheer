using System.Linq;
using System.Threading.Tasks;

namespace Shamsheer.Data.IRepositories;

public interface IRepository<TEntity>
{
    public Task<bool> SaveChangeAsync();
    public Task<bool> RemoveAsync(long id);
    public IQueryable<TEntity> SelectAll();
    public Task<TEntity> SelectByIdAsync(long id);
    public Task<TEntity> InsertAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
}
