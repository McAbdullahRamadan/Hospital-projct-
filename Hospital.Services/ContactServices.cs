using Hospital.Model;
using Hospital.Repositories.Interface;
using Hospital.Utilities;
using Hospital.ViewModels;

namespace Hospital.Services
{
    public class ContactServices : IContactServices
    {
        private IUnitOfWork _unitOfWork;

        public ContactServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteContact(int id)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(id);
            _unitOfWork.GenericRepository<Contact>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<ContactViewModel> GetAll(int PageNumber, int PageSize)
        {
            var vm = new ContactViewModel();
            int totalcount;
            List<ContactViewModel> vmlist = new List<ContactViewModel>();
            try
            {
                int ExcludeRedcords = (PageSize * PageNumber) - PageSize;

                var modellist = _unitOfWork.GenericRepository<Contact>().GetAll(InCludeProperties: "Hospital")
                  .Skip(ExcludeRedcords).Take(PageSize).ToList();

                totalcount = _unitOfWork.GenericRepository<Contact>().GetAll().ToList().Count;

                vmlist = ConvertModelToViewModelList(modellist);


            }
            catch (Exception)
            {

                throw;
            }
            var result = new PagedResult<ContactViewModel>
            {
                Data = vmlist,
                TotalItem = totalcount,
                PageNumber = PageNumber,
                PageSize = PageSize


            };
            return result;
        }

        public ContactViewModel GetContactById(int ContactId)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(ContactId);
            var vm = new ContactViewModel(model);
            return vm;
        }

        //public ContactViewModel GetContactById(int ContactId)
        //{

        //    var model = _unitOfWork.GenericRepository<Contact>().GetById(ContactId);
        //    var vm = new ContactViewModel(model);
        //    return vm;
        //}

        public void InsertContact(ContactViewModel Contact)
        {
            var model = new ContactViewModel().ConvertViewModel(Contact);
            _unitOfWork.GenericRepository<Contact>().Add(model);
            _unitOfWork.Save();

        }

        public void UpdateContact(ContactViewModel Contact)
        {
            var model = new ContactViewModel().ConvertViewModel(Contact);
            var ModelByid = _unitOfWork.GenericRepository<Contact>().GetById(model.id);
            ModelByid.Email = Contact.Email;
            ModelByid.Phone = Contact.Phone;
            ModelByid.HospitalId = Contact.HospitalInfoId;
            _unitOfWork.GenericRepository<Contact>().Update(ModelByid);
            _unitOfWork.Save();
        }
        private List<ContactViewModel> ConvertModelToViewModelList(List<Contact> modellist)
        {
            return modellist.Select(x => new ContactViewModel(x)).ToList();

        }


    }
}
