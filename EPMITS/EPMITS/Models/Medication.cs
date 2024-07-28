using System.Collections.Generic;

namespace EPMITS.Models
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
