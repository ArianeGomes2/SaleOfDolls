using SaleOfDolls.Data;
using SaleOfDolls.Models;
using SaleOfDolls.Uow.Interface;

namespace SaleOfDolls.RepositoryUow
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(DataContext context) : base(context)
        {
        }
    }
}