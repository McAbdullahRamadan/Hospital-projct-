using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ContactController : Controller
    {
        private IContactServices _ContactServices;

        public ContactController(IContactServices ContactServices)
        {
            _ContactServices = ContactServices;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_ContactServices.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _ContactServices.GetContactById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(ContactViewModel vm)
        {
            _ContactServices.UpdateContact(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(ContactViewModel vm)
        {
            _ContactServices.InsertContact(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _ContactServices.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}
