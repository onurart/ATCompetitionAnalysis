using CompetitionAnalysis.Core.Features.CompanyFeatures.GetAllProductCustomerRelationship.Commands;
using CompetitionAnalysis.Core.Services.CompanyService;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.RegularExpressions;

namespace CompetitionAnalysis.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IntelligengeController : Controller
    {
        private readonly IIntelligengeService _service;

        public IntelligengeController(IIntelligengeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Route("Admin/CreateIntelligenge")]
        [HttpGet]
        public IActionResult CreateIntelligenge()
        {
            return View();
        }
        [HttpPost]
        [Route("Admin/UploadImage")]
        public IActionResult UploadImage(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Resmi kaydetmek için gerekli işlemleri yapın
                var originalFileName = imageFile.FileName;
                var safeFileName = MakeFileNameSafe(originalFileName); // Güvenli dosya adını oluşturun
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/adminfoto", "bran");

                // Dizin kontrolü ve oluşturma
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                var imagePath = Path.Combine(directoryPath, safeFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                return Ok(safeFileName); // Güvenli dosya adını geri dön
            }
            else
            {
                return BadRequest("Dosya yüklenemedi.");
            }
        }

        // Dosya adında bulunan boşlukları, özel karakterleri ve Türkçe karakterleri kaldıran fonksiyon
        private string MakeFileNameSafe(string fileName)
        {
            // Dosya adındaki özel karakterleri, boşlukları ve Türkçe karakterleri kaldırın
            var safeFileName = Path.GetFileNameWithoutExtension(fileName); // Dosya adını al
            safeFileName = Regex.Replace(safeFileName, @"[^\w\d]", ""); // Özel karakterleri ve boşlukları kaldır
            safeFileName = string.Concat(safeFileName.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)); // Türkçe karakterleri kaldır
            var extension = Path.GetExtension(fileName); // Dosya uzantısını al
            return $"{safeFileName}{extension}";
        }

        [HttpPost]
        [Route("Admin/CreateIntelligenge")]
        public async Task<IActionResult> CreateIntelligenge(CreateProductCustomerRelationshipCommand request)
        {
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            var token = User.Claims.FirstOrDefault(x => x.Type == "token")?.Value;
            request.CompanyId = companyId;
            var result = await _service.CreateIntelligenge(request, token);

            if (Request.Form.Files.Count > 0) // Formdan dosya gelip gelmediğini kontrol edin
            {
                var imageFile = Request.Form.Files["ImageUrl"]; // "ImageUrl" alanı adı altında dosyayı alın

                if (imageFile != null && imageFile.Length > 0)
                {
                    // Resmi kaydetmek için gerekli işlemleri yapın
                    var imageName = Path.GetFileName(imageFile.FileName); // Orijinal dosya adını alın
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", "bran", imageName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Controller'a resim yolunu göndermek için ImageUrl'i ayarlayın
                    request.ImageUrl = imageName;
                }
            }

            return RedirectToAction("AnalysisGrid", "Admin");
        }


        //[HttpPost]
        //[Route("Admin/CreateIntelligenge")]
        //public async Task<IActionResult> CreateIntelligenge(CreateProductCustomerRelationshipCommand request)
        //{
        //    string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
        //    var token = User.Claims.FirstOrDefault(x => x.Type == "token")?.Value;
        //    request.CompanyId = companyId;
        //    var result = await _service.CreateIntelligenge(request, token);

        //    if (Request.Form.Files.Count > 0) // Formdan dosya gelip gelmediğini kontrol edin
        //    {
        //        var imageFile = Request.Form.Files[0]; // İlk dosyayı alın

        //        if (imageFile != null && imageFile.Length > 0)
        //        {
        //            // Resmi kaydetmek için gerekli işlemleri yapın
        //            var imageName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
        //            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", "bran", imageName);

        //            using (var stream = new FileStream(imagePath, FileMode.Create))
        //            {
        //                await imageFile.CopyToAsync(stream);
        //            }

        //            // Controller'a resim yolunu göndermek için ImageUrl'i ayarlayın
        //            request.ImageUrl = imageName;

        //        }
        //    }

        //    return RedirectToAction("AnalysisGrid", "Admin");
        //}


    }
}

