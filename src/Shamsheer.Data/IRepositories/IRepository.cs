using System.Linq;
using System.Threading.Tasks;

namespace Shamsheer.Data.IRepositories;

public interface IRepository<TEntitiy>
{
    public Task<bool> RemoveAsync(long id);
    public IQueryable<TEntitiy> SelectAllAsync();
    public Task<TEntitiy> SelectByIdAsync(long id);
    public Task<TEntitiy> InsertAsync(TEntitiy entitiy);
    public Task<TEntitiy> UpdateAsync(TEntitiy entitiy);
}
