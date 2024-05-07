using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoomsController : Controller
    {
        private IRoomServices _RoomServices;

        public RoomsController(IRoomServices RoomServices)
        {
            _RoomServices = RoomServices;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_RoomServices.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _RoomServices.GetRoomById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(RoomViewModel vm)
        {
            _RoomServices.UpdateRoom(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(RoomViewModel vm)
        {
            _RoomServices.InsertRoom(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _RoomServices.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}
