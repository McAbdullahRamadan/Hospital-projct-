namespace Hospital.Model
{
    public class Bill
    {
        public int id { get; set; }
        public int BillNumber { get; set; }
        public ApplicationUser Patient { get; set; }
        public Insurance Insurance { get; set; }
        public int DoctorCharge { get; set; }
        public decimal MedicineCharge { get; set; }
        public decimal RoomCharge { get; set; }
        public decimal OperationCharge { get; set; }
        public int NoOfDays { get; set; }
        public int NursnigCharge { get; set; }
        public int LabCharge { get; set; }
        public decimal Advance { get; set; }
        public decimal TotalBill { get; set; }


    }
}