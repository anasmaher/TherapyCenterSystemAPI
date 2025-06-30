using Domain.Enums;

namespace Application.Features.Patients.DTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public GenderEnum Gender { get; set; }
    }
}
