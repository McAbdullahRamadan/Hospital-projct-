using Hospital.Utilities;
using Hospital.ViewModels;

namespace Hospital.Services
{
    public interface IHospitalInfo
    {
        PagedResult<HospitalInfoViewModel> GetAll(int PageNumber, int PageSize);
        HospitalInfoViewModel GetHospitalById(int HospitalId);
        void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfoView);
        void InsertHospitalInfo(HospitalInfoViewModel hospitalInfoView);
        void DeleteHospitalInfo(int id);





    }
}
