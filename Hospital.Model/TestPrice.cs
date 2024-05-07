namespace Hospital.Model
{
    public class TestPrice
    {
        public int id { get; set; }
        public string TestCode { get; set; }
        public decimal Price { get; set; }
        public Lab Lab { get; set; }
        public Bill bill { get; set; }




    }
}
