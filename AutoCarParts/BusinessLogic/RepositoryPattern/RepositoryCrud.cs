using AutoCarParts.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoCarParts.BusinessLogic.RepositoryPattern
{
    public class RepositoryCrud<T> : IRepositoryCrud<T> where T : class
    {
        private readonly AppDbContext _Context;
        private readonly DbSet<T> _dbSet;
        public RepositoryCrud(AppDbContext context)
        {
            _Context = context;
            _dbSet = _Context.Set<T>();
        }
        public bool AddInstance(T instance)
        {
            _dbSet.Add(instance);
            return _Context.SaveChanges()>0;
        }

        public bool DeleteInstanceByID(int id)
        {
            
            var instance= _dbSet.Find(id);
            if (instance != null)
            {
                _dbSet.Remove(instance);
                return _Context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
            
        }

        public T GetInstanceById(int id)
        {
            var r= _dbSet.Find(id);
            if (r != null)
            {
                return r;
            }
            else { return null; }
        }

        public bool Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);

                return _Context.SaveChanges() > 0;
            }
            catch { return false; }
            
        }
        public IEnumerable<T> GetAllEntities()
        {
            return _dbSet.ToList();
        }

       
    }
}
