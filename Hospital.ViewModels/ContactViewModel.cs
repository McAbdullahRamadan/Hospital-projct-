using Hospital.Model;

namespace Hospital.ViewModels
{
    public class ContactViewModel
    {
        public int id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int HospitalInfoId { get; set; }


        public ContactViewModel(Contact model)
        {
            id = model.id;
            Email = model.Email;
            Phone = model.Phone;
            HospitalInfoId = model.HospitalId;

        }

        public ContactViewModel()
        {

        }

        public Contact ConvertViewModel(ContactViewModel model)
        {
            return new Contact
            {
                id = model.id,
                Email = model.Email,
                Phone = model.Phone,
                HospitalId = model.HospitalInfoId,

            };
        }
    }
}
