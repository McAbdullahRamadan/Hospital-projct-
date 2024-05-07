namespace Hospital.Model
{
    public class Supplier
    {
        public int id { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<MedicineReport> MedicineReports { get; set; }

    }
}
