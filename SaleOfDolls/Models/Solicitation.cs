using SaleOfDolls.Enuns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleOfDolls.Models
{
    public class Solicitation
    {
        public long SolicitationId { get; set; }

        [ForeignKey("ClientId")]
        public long ClientId { get; set; }
        public Client Client { get; set; }

        [Column(TypeName = "bigint")]
        public long RequestNumber { get; set; }

        [Required]
        [Column(TypeName = "decimal(15,2)")]
        public double Value { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime RequestDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DeliveryDate { get; set; }
        
        [Required]
        [Column(TypeName = "tinyint")]
        public FormOfPayment FormOfPayment { get; set; }
    }


}