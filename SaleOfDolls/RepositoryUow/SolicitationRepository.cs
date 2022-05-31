using SaleOfDolls.Data;
using SaleOfDolls.Models;
using SaleOfDolls.Uow.Interface;

namespace SaleOfDolls.RepositoryUow
{
    public class SolicitationRepository : BaseRepository<Solicitation>, ISolicitationRepository
    {
        public SolicitationRepository(DataContext context) : base(context)
        {
        }
    }
}