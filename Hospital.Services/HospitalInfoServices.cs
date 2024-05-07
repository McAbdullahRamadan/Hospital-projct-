using Hospital.Model;
using Hospital.Repositories.Interface;
using Hospital.Utilities;
using Hospital.ViewModels;

namespace Hospital.Services
{
    public class HospitalInfoServices : IHospitalInfo
    {
        private IUnitOfWork _unitOfWork;

        public HospitalInfoServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteHospitalInfo(int id)
        {
            var model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(id);
            _unitOfWork.GenericRepository<HospitalInfo>().Delete(model);
            _unitOfWork.Save();

        }

        //public PageResult<HospitalInfo> GetAll(int PageNumber, int PageSize)
        //{
        //var vm = new HospitalInfoViewModel();
        //int totalcount;
        //List<HospitalInfoViewModel> vmlist = new List<HospitalInfoViewModel>();
        //try
        //{
        //    int ExcludeRedcords = (PageSize * PageNumber) - PageSize;

        //    var Modellist = _unitOfWork.GenericRepository<HospitalInfo>().GetAll()
        //      .Skip(ExcludeRedcords).Take(PageSize).ToList();

        //    totalcount = _unitOfWork.GenericRepository<HospitalInfo>().GetAll().ToList().Count;

        //    vmlist = ConvertModelToViewModelList(Modellist);


        //}
        //catch (Exception)
        //{

        //    throw;
        //}
        //var result = new PagedResult<HospitalInfoViewModel>
        //{
        //    Data = vmlist,
        //    TotalItem = totalcount,
        //    PageNumber = PageNumber,
        //    PageSize = PageSize


        //};
        //return result;

        //}

        public HospitalInfoViewModel GetHospitalById(int HospitalId)
        {

            var model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(HospitalId);
            var vm = new HospitalInfoViewModel(model);
            return vm;
        }

        public void InsertHospitalInfo(HospitalInfoViewModel hospitalInfo)
        {
            var model = new HospitalInfoViewModel().ConvertViewModel(hospitalInfo);
            _unitOfWork.GenericRepository<HospitalInfo>().Add(model);
            _unitOfWork.Save();



        }

        public void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfoView)
        {

            var model = new HospitalInfoViewModel().ConvertViewModel(hospitalInfoView);
            var ModelByid = _unitOfWork.GenericRepository<HospitalInfo>().GetById(model.id);
            ModelByid.Name = hospitalInfoView.Name;
            ModelByid.City = hospitalInfoView.City;
            ModelByid.PinCode = hospitalInfoView.PinCode;
            ModelByid.Country = hospitalInfoView.Country;
            _unitOfWork.GenericRepository<HospitalInfo>().Update(ModelByid);
            _unitOfWork.Save();






        }



        PagedResult<HospitalInfoViewModel> IHospitalInfo.GetAll(int pageNumber, int pageSize)
        {
            var vm = new HospitalInfoViewModel();
            int totalcount;
            List<HospitalInfoViewModel> vmlist = new List<HospitalInfoViewModel>();
            try
            {
                int ExcludeRedcords = (pageSize * pageNumber) - pageSize;

                var modellist = _unitOfWork.GenericRepository<HospitalInfo>().GetAll()
                  .Skip(ExcludeRedcords).Take(pageSize).ToList();

                totalcount = _unitOfWork.GenericRepository<HospitalInfo>().GetAll().ToList().Count;

                vmlist = ConvertModelToViewModelList(modellist);


            }
            catch (Exception)
            {

                throw;
            }
            var result = new PagedResult<HospitalInfoViewModel>
            {
                Data = vmlist,
                TotalItem = totalcount,
                PageNumber = pageNumber,
                PageSize = pageSize


            };
            return result;

        }
        private List<HospitalInfoViewModel> ConvertModelToViewModelList(List<HospitalInfo> modellist)
        {
            return modellist.Select(x => new HospitalInfoViewModel(x)).ToList();

        }
    }
}
