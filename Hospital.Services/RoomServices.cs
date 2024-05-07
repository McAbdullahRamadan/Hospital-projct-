using Hospital.Model;
using Hospital.Repositories.Interface;
using Hospital.Utilities;
using Hospital.ViewModels;

namespace Hospital.Services
{
    public class RoomServices : IRoomServices
    {
        private IUnitOfWork _unitOfWork;

        public RoomServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteRoom(int id)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(id);
            _unitOfWork.GenericRepository<Room>().Delete(model);
            _unitOfWork.Save();

        }

        public RoomViewModel GetRoomById(int HospitalId)
        {

            var model = _unitOfWork.GenericRepository<Room>().GetById(HospitalId);
            var vm = new RoomViewModel(model);
            return vm;
        }


        public void UpdateRoom(RoomViewModel RooViewmodel)
        {

            var model = new RoomViewModel().ConvertViewModel(RooViewmodel);
            var ModelByid = _unitOfWork.GenericRepository<Room>().GetById(model.id);
            ModelByid.RoomNumber = RooViewmodel.RoomNumber;
            ModelByid.Type = RooViewmodel.Type;
            ModelByid.HospitalId = RooViewmodel.HospitalInfoId;
            _unitOfWork.GenericRepository<Room>().Update(ModelByid);
            _unitOfWork.Save();






        }


        private List<RoomViewModel> ConvertModelToViewModelList(List<Room> modellist)
        {
            return modellist.Select(x => new RoomViewModel(x)).ToList();

        }

        PagedResult<RoomViewModel> IRoomServices.GetAll(int PageNumber, int PageSize)
        {
            var vm = new RoomViewModel();
            int totalcount;
            List<RoomViewModel> vmlist = new List<RoomViewModel>();
            try
            {
                int ExcludeRedcords = (PageSize * PageNumber) - PageSize;

                var modellist = _unitOfWork.GenericRepository<Room>().GetAll(InCludeProperties: "Hospital")
                  .Skip(ExcludeRedcords).Take(PageSize).ToList();

                totalcount = _unitOfWork.GenericRepository<Room>().GetAll().ToList().Count;

                vmlist = ConvertModelToViewModelList(modellist);


            }
            catch (Exception)
            {

                throw;
            }
            var result = new PagedResult<RoomViewModel>
            {
                Data = vmlist,
                TotalItem = totalcount,
                PageNumber = PageNumber,
                PageSize = PageSize


            };
            return result;
        }

        public void InsertRoom(RoomViewModel Room)
        {
            var model = new RoomViewModel().ConvertViewModel(Room);
            _unitOfWork.GenericRepository<Room>().Add(model);
            _unitOfWork.Save();

        }
    }
}
