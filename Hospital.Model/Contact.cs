﻿namespace Hospital.Model
{
    public class Contact
    {
        public int id { get; set; }
        public int HospitalId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public HospitalInfo Hospital { get; set; }
    }
}