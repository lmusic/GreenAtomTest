using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestGreenAtom.Models;

namespace TestGreenAtom.DAL
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
        {
            protected readonly ProjectContext Context;
            private readonly DbSet<T> _entities;

            public Repository(ProjectContext context)
            {
                Context = context;
                _entities = context.Set<T>();
            }

            public async Task<List<T>> GetAll()
            {
                return await _entities.ToListAsync();
            }

            public Task<T> GetById(Guid id)
            {
                return _entities.FirstOrDefaultAsync(x => x.Id == id);
            }

            public async Task Insert(T entity)
            {
                if (entity == null) throw new ArgumentNullException("entity");

                await _entities.AddAsync(entity);
                await Context.SaveChangesAsync();
            }

            public async Task Insert(List<T> entities)
            {
                if (entities == null) throw new ArgumentNullException("entities");

                await _entities.AddRangeAsync(entities.AsEnumerable());
                await Context.SaveChangesAsync();
        }

            public async Task Update(T entity)
            {
                if (entity == null) throw new ArgumentNullException("entity");

                await Context.SaveChangesAsync();
            }

            public async Task Delete(Guid id)
            {
                if (id == null) throw new ArgumentNullException("entity");

                var entity = await _entities.FirstOrDefaultAsync(x => x.Id == id);
                _entities.Remove(entity);
                await Context.SaveChangesAsync();
            }

            public async Task<List<T>> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
            {
                return await Include(includeProperties).ToListAsync();
            }

            private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
            {
                IQueryable<T> query = _entities.AsNoTracking();
                return includeProperties
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
    }
}
