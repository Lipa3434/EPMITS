using EPMITS.Models;

public class PatientDetailsViewModel
{
    public Patient Patient { get; set; } = new Patient();
    public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    public List<Medication> Medications { get; set; } = new List<Medication>();
}
