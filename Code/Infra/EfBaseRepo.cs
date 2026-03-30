using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abc.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra;

public class EfBaseRepo<TContext, TEntity> : IRepo<TEntity>
    where TContext : DbContext
    where TEntity : BaseEntity
{
    protected readonly TContext db;

    public EfBaseRepo(TContext context)
    {
        db = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<TEntity> CreateAsync(TEntity e)
    {
        await db.AddAsync(e);
        await db.SaveChangesAsync();
        return e;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetAsync(id);
        if (entity is null) return;
        db.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<TEntity> GetAsync(Guid id)
    {
        return await db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<TEntity>> GetAsync()
    {
        return await db.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity e)
    {
        db.Update(e);
        await db.SaveChangesAsync();
        return e;
    }
}

