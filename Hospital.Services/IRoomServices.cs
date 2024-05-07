using Hospital.Utilities;
using Hospital.ViewModels;

namespace Hospital.Services
{
    public interface IRoomServices
    {
        PagedResult<RoomViewModel> GetAll(int PageNumber, int PageSize);
        RoomViewModel GetRoomById(int RoomId);
        void UpdateRoom(RoomViewModel Room);
        void InsertRoom(RoomViewModel Room);
        void DeleteRoom(int id);





    }
}
