namespace Domain.Entities
{
    internal class PaymentRecord
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaidAt { get; set; }
        
        public string Notes { get; set; }

        public PaymentMethod Method { get; set; }

        public PaymentStatus Status { get; set; }
    }
}
