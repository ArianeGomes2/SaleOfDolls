namespace SaleOfDolls.RepositoryUow.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Add(T Object);
        Task<T> Update(T Object);
        Task<T> Delete(T Object);
        Task<T> GetById(long Id);
        Task<IEnumerable<T>> GetAll();
    }
}