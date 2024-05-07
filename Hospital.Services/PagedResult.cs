using Hospital.Model;
using Hospital.ViewModels;

namespace Hospital.Services
{
    internal class PageResult<T> : Utilities.PagedResult<HospitalInfo>
    {
        public List<HospitalInfoViewModel> Data { get; set; }
        public int TotalItem { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}