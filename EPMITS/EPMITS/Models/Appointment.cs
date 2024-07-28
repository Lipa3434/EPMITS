using System;

namespace EPMITS.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = default!;
    }
}
