﻿namespace Hospital.Model
{
    public class Room
    {
        public int id { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int HospitalId { get; set; }

        public HospitalInfo Hospital { get; set; }
    }
}