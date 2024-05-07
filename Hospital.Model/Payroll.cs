namespace Hospital.Model
{
    public class Payroll
    {
        public int id { get; set; }
        public ApplicationUser IdEmployees { get; set; }
        public decimal Salary { get; set; }
        public decimal NetSalary { get; set; }
        public decimal HourlySalary { get; set; }
        public decimal BonusSalary { get; set; }
        public decimal Compensation { get; set; }
        public string AccountNumber { get; }

    }
}