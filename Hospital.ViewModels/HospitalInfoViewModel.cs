using Hospital.Model;

namespace Hospital.ViewModels
{
    public class HospitalInfoViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }

        public HospitalInfoViewModel(HospitalInfo model)
        {
            id = model.id;
            Name = model.Name;
            Type = model.Type;
            City = model.City;
            PinCode = model.PinCode;
            Country = model.Country;

        }

        public HospitalInfoViewModel()
        {

        }

        public HospitalInfo ConvertViewModel(HospitalInfoViewModel model)
        {
            return new HospitalInfo
            {
                id = model.id,
                Name = model.Name,
                Type = model.Type,
                City = model.City,
                PinCode = model.PinCode,
                Country = model.Country,
            };
        }
    }
}
