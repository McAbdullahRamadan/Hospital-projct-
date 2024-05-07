namespace Hospital.Model
{
    public class Appointment
    {
        public int id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }
        public string Discription { get; set; }
        public ApplicationUser Doctor { get; set; }
        public ApplicationUser Patient { get; set; }
    }
}