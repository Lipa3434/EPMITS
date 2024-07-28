using System.Collections.Generic;

namespace EPMITS.Models
{
    public class Caregiver
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
