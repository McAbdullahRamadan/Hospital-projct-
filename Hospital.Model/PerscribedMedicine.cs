namespace Hospital.Model
{
    public class PerscribedMedicine
    {
        public int id { get; set; }
        public Medicine Medicines { get; set; }
        public PatientReport PatientReport { get; set; }

    }
}
