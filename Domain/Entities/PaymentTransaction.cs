using Domain.Enums;

namespace Domain.Entities
{
    public class PaymentTransaction
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int AppointmentId { get; set; }

        public decimal Amount { get; set; }

        public PaymentMethod Method { get; set; }

        public PaymentStatus Status { get; set; }

        public string PaymobOrderId { get; set; }

        public string PaymobTransactionId { get; set; }

        public string ReferenceCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Appointment Appointment { get; set; }
    }
}
