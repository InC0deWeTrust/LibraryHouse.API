using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryHouse.Infrastructure.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);

        void Add(T entity);

        Task AddRangeAsync(T[] entities);

        void AddRange(T[] entities);

        T Get(int id);

        Task<T> GetAsync(int id);

        IQueryable<T> GetAll();

        void Update(T entity);

        void Delete(T entity);

        void Save();

        Task SaveAsync();
    }
}
