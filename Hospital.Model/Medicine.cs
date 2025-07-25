﻿namespace Hospital.Model
{
    public class Medicine
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public ICollection<MedicineReport> MedicineReports { get; set; }
        public ICollection<PerscribedMedicine> PerscribedMedicines { get; set; }

    }
}
