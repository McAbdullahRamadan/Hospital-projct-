namespace Hospital.Model
{
    public class MedicineReport
    {
        public int id { get; set; }
        public Supplier Supplier { get; set; }
        public string Company { get; set; }
        public string Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirDate { get; set; }
        public string Country { get; set; }
        public Medicine Medicines { get; set; }

    }
}
