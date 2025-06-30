using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Therapists.DTOs
{
    public class TherapistDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public List<string> Specializations { get; set; } = new();

        public int YearsOfExperience { get; set; }

        public bool IsAvailable { get; set; }
    }
}
