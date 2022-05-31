using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleOfDolls.Models
{
    public class Address
    {
        public long AddressId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Street { get; set; }

        [Required]
        [MaxLength(50)]
        public string Neighborhood { get; set; }

        [Required]
        [MaxLength(8)]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        public IEnumerable<Client> Client { get; set; }
    }
}