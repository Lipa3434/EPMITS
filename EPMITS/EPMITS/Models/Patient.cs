using System.Collections.Generic;

namespace EPMITS.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MedicalHistory { get; set; } = string.Empty;
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public List<Caregiver> Caregivers { get; set; } = new List<Caregiver>();
    }
}
