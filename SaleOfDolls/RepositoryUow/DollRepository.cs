using SaleOfDolls.Data;
using SaleOfDolls.Models;
using SaleOfDolls.Uow.Interface;

namespace SaleOfDolls.RepositoryUow
{
    public class DollRepository : BaseRepository<Doll>, IDollRepository
    {
        public DollRepository(DataContext context) : base(context)
        {
        }
    }
}