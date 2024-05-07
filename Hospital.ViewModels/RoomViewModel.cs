using Hospital.Model;

namespace Hospital.ViewModels
{
    public class RoomViewModel
    {
        public int id { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public string Statues { get; set; }
        public int HospitalInfoId { get; set; }
        public HospitalInfo hospitalInfo { get; set; }


        public RoomViewModel(Room model)
        {
            id = model.id;
            RoomNumber = model.RoomNumber;
            Type = model.Type;
            Statues = model.Status;
            HospitalInfoId = model.HospitalId;
            hospitalInfo = model.Hospital;



        }

        public RoomViewModel()
        {

        }

        public Room ConvertViewModel(RoomViewModel model)
        {
            return new Room
            {
                id = model.id,
                RoomNumber = model.RoomNumber,
                Type = model.Type,
                Status = model.Statues,

                HospitalId = model.HospitalInfoId,
                Hospital = model.hospitalInfo,
            };
        }
    }
}
