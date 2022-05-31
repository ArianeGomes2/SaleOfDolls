using SaleOfDolls.Enuns;

namespace SaleOfDolls.DTO
{
    public class SolicitationDTO
    {
        public long DollId { get; set; }
        public long ClientId { get; set; }

        public double Value { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public FormOfPayment FormOfPayment { get; set; }
    }
}