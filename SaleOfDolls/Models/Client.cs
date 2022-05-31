using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleOfDolls.Models
{
    public class Client
    {
        public long ClientId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(11)]
        public string TaxNumber { get; set; }

        public IEnumerable<Solicitation> Solicitation { get; set; }
    }
}