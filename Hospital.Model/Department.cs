namespace Hospital.Model
{
    public class Department
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Descreption { get; set; }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ICollection<ApplicationUser> Employees { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
