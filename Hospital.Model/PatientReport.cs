namespace Hospital.Model
{
    public class PatientReport
    {
        public int id { get; set; }
        public string Diagnose { get; set; }
        public ApplicationUser Doctor { get; set; }
        public ApplicationUser Patient { get; set; }
        public ICollection<PerscribedMedicine> perscribedMedicines { get; set; }

    }
}
