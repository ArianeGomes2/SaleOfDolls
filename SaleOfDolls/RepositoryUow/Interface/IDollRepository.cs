using SaleOfDolls.Models;
using SaleOfDolls.RepositoryUow.Interface;

namespace SaleOfDolls.Uow.Interface
{
    public interface IDollRepository : IBaseRepository<Doll>
    {
    }
}