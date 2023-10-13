using Shamsheer.Domain.Commons;
using System.Linq;
using System.Threading.Tasks;

namespace Shamsheer.Data.IRepositories;

public interface IRepository<TEntity> where TEntity : Auditable
{
    public Task<bool> DeleteAsync(long id);
    public IQueryable<TEntity> SelectAll();
    public Task<TEntity> SelectByIdAsync(long id);
    public Task<TEntity> InsertAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
}
