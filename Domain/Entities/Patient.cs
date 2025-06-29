using Domain.Enums;

namespace Domain.Entities
{
    internal class Patient
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public GenderEnum Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int AssignedTherapistId { get; set; }
    }
}
