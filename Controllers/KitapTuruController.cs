using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUygulamaProje1.Entity;
using WebUygulamaProje1.Models;
using WebUygulamaProje1.Utility;

namespace WebUygulamaProje1.Controllers
{
    
    public class KitapTuruController : Controller
    {
        private readonly IKitapTuruRepository _kitapTuruRepository;

        public KitapTuruController(IKitapTuruRepository context)
        {
            _kitapTuruRepository = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var objKitapTuruList = _kitapTuruRepository.GetAll().ToList();
            return View(objKitapTuruList);
        }


        [HttpGet]

        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Ekle(int? id)
        {
            if (id == null || id == 0)
            {
                return View();
            }
            KitapTuru? kitapTuruVt = _kitapTuruRepository.Get(u => u.Id == id);
            if (kitapTuruVt == null)
            {
                return NotFound();
            }

            return View(kitapTuruVt);

        }

        [HttpPost]

        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Ekle(KitapTuru kitapTuru)
        {
            if (ModelState.IsValid)
            {
                _kitapTuruRepository.Ekle(kitapTuru);
                _kitapTuruRepository.Kaydet();  //SaveChanges yapılmazsa bilgiler veritabanına eklenmez
                TempData["basarili"] = "Ekleme İşlemi Başarıyla Gerçekleştirildi";
                return RedirectToAction("Index", "KitapTuru");
            }
            return View();
        }

        [HttpGet]

        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            KitapTuru? kitapTuruVt = _kitapTuruRepository.Get(u => u.Id == id); //Expression<Func<T, bool>> filtre
            if (kitapTuruVt == null)
            {
                return NotFound();
            }

            return View(kitapTuruVt);
          
        }

        [HttpPost]

        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Guncelle(KitapTuru kitapTuru)
        {
            if (ModelState.IsValid)
            {
                _kitapTuruRepository.Guncelle(kitapTuru);
                _kitapTuruRepository.Kaydet();  //SaveChanges yapılmazsa bilgiler veritabanına eklenmez
                TempData["basarili"] = "Güncelleme İşlemi Başarıyla Gerçekleştirildi";
                return RedirectToAction("Index", "KitapTuru");
            }
            return View();
        }

        [HttpGet]

        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            KitapTuru? kitapTuruVt = _kitapTuruRepository.Get(u => u.Id == id);
            if (kitapTuruVt == null)
            {
                return NotFound();
            }

            return View(kitapTuruVt);

        }

        [HttpPost, ActionName("Sil")]

        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult SİLPOST(int? id)
        {
            KitapTuru? kitapTuru = _kitapTuruRepository.Get(u => u.Id == id);
            if (kitapTuru == null)
            {
                return NotFound();
            }
            _kitapTuruRepository.Sil(kitapTuru);
            _kitapTuruRepository.Kaydet();
            TempData["basarili"] = "Silme İşlemi Başarıyla Gerçekleştirildi";
            return RedirectToAction("Index", "KitapTuru");
        }
    }
}
