using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        private readonly ManagementTaskDbContext _dbContext;
        protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();
        protected ManagementTaskDbContext Context => _dbContext;

        public RepositoryBase(ManagementTaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
            SaveChanges();
        }

        public virtual void AddRange(IEnumerable<TEntity> entity)
        {
            DbSet.AddRange(entity);
            SaveChanges();
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c=> c.Id == id);
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
                DbSet.Update(entity);
            SaveChanges();
        }

        private void SaveChanges() => _dbContext.SaveChanges();

        public List<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
    }
}
