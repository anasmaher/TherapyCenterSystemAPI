using Domain.Enums;

namespace Domain.Entities
{
    internal class Therapist
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public GenderEnum Gender { get; set; }

        public List<string> Specializations { get; set; }

        public int YearsOfExperience { get; set; }
        
        public bool IsAvailable { get; set; } = true;
    }
}
