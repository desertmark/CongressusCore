using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace CongressusCore.Areas.Base {
    public class BaseRepository<T> where T: class {
        public DbContext Context;
        public BaseRepository(DbContext context) {
            Context = context;
        }
    
        public virtual async Task<IQueryable<T>>List() {
            return await Task.Run(() => Context.Set<T>().AsQueryable());
        }
    
        public virtual async Task Create(T Entity) {
            await Context.Set<T>().AddAsync(Entity);
            await Context.SaveChangesAsync();
        }
    }
}