using SaleOfDolls.Data;
using SaleOfDolls.Models;
using SaleOfDolls.Uow.Interface;

namespace SaleOfDolls.RepositoryUow
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {

        public ClientRepository(DataContext context) : base(context)
        {
        }
    }
}