using SaleOfDolls.Data;
using SaleOfDolls.Models;
using SaleOfDolls.RepositoryUow.Interface;

namespace SaleOfDolls.RepositoryUow
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T Object)
        {
            try
            {
                _context.Add(Object);
                _context.SaveChanges();
                return Object;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Delete(T Object)
        {
            try
            {
                _context.Remove(Object);
                _context.SaveChanges();
                return Object;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> GetById(long Id)
        {
            return _context.Find<T>(Id);
        }

        public async Task<T> Update(T Object)
        {
            _context.Update(Object);
            _context.SaveChanges();
            return Object;
        }
    }
}