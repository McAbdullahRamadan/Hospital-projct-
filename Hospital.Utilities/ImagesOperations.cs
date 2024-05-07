using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Hospital.Utilities
{
    public class ImagesOperations
    {
        IWebHostEnvironment _ev;
        public ImagesOperations(IWebHostEnvironment ev)
        {
            _ev = ev;
        }
        public string UploadImage(IFormFile file)
        {
            string filName = null;
            if (file != null)
            {
                string filDicvery = Path.Combine(_ev.WebRootPath, "Images");
                filName = Guid.NewGuid() + "_" + file.FileName;
                string filPaths = Path.Combine(filDicvery, filName);
                using (FileStream fs = new FileStream(filPaths, FileMode.Create))
                {
                    file.CopyToAsync(fs);
                }

            }
            return filName;
        }

    }
}
