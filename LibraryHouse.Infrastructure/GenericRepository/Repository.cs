using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryHouse.Infrastructure.ContextDb;

namespace LibraryHouse.Infrastructure.GenericRepository
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private readonly LibraryHouseDbContext _libraryHouseDbContext;

        public Repository(LibraryHouseDbContext libraryHouseDbContext)
        {
            _libraryHouseDbContext = libraryHouseDbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _libraryHouseDbContext.Set<T>().AddAsync(entity);
            await SaveAsync();
        }

        public void Add(T entity)
        {
            _libraryHouseDbContext.Set<T>().Add(entity);
            Save();
        }

        public async Task AddRangeAsync(T [] entities)
        {
            await _libraryHouseDbContext.Set<T>().AddRangeAsync(entities);
            await SaveAsync();
        }

        public void AddRange(T[] entities)
        {
            _libraryHouseDbContext.Set<T>().AddRange(entities);
            Save();
        }

        public T Get(int id)
        {
            return _libraryHouseDbContext.Set<T>().Find(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _libraryHouseDbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return _libraryHouseDbContext.Set<T>();
        }

        public void Update(T entity)
        {
            _libraryHouseDbContext.Set<T>().Update(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _libraryHouseDbContext.Set<T>().Remove(entity);
            Save();
        }

        public void Save()
        {
            _libraryHouseDbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _libraryHouseDbContext.SaveChangesAsync();
        }
    }
}
