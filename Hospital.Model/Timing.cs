namespace Hospital.Model
{
    public class Timing
    {
        public int Id { get; set; }
        public ApplicationUser DoctorId { get; set; }
        public int MorinigStartTime { get; set; }
        public int MorinigEndTime { get; set; }
        public int AfternoonstartTime { get; set; }
        public int AfternoonEndTime { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
    }
}

namespace Hospital.Model
{
    public enum Status
    {
        Avilabl, pending, Confirm
    }
}