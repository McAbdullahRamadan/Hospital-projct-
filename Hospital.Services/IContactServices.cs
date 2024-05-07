using Hospital.Utilities;
using Hospital.ViewModels;

namespace Hospital.Services
{
    public interface IContactServices
    {
        PagedResult<ContactViewModel> GetAll(int PageNumber, int PageSize);
        ContactViewModel GetContactById(int ContactId);
        void UpdateContact(ContactViewModel Contact);
        void InsertContact(ContactViewModel Contact);
        void DeleteContact(int id);





    }
}
