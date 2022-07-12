using SaleOfDolls.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleOfDolls.Models
{
    public class Doll
    {
        public long DollId { get; set; }

        [Required]
        public Hair Hair { get; set; }

        [Required]
        [Column(TypeName = "tinyint")]
        public Eyes Eyes { get; set; }

        [Required]
        [Column(TypeName = "tinyint")]
        public Skin Skin { get; set; }

        [Required]
        [Column(TypeName = "tinyint")]
        public Clothing Clothing { get; set; }

        [Column(TypeName = "tinyint")]
        public Acessory Accessory { get; set; }

        public IEnumerable<Solicitation> Solicitation { get; set; }

    }
}