using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_Core_Mvc_Code.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Mvc_Code.Controllers
{
    public class KitapController : Controller
    {
        private readonly KutuphaneSabahContext _context;

        public KitapController(KutuphaneSabahContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Kitaplars.ToList());
        }
        public IActionResult Details(string id)
        {
            var kitap = _context.Kitaplars
                    .Include(k => k.Tur)
                    .Include(k => k.YayinEvi)
                    .Include(k => k.Yazar)
                    .First(sk => sk.Isbn == id);
            return View(kitap);
        }
        public IActionResult Edit(string id)
        {
            var kitaplar = _context.Kitaplars.Find(id); //ilgili tablodaki primary key 'i buluyo burada isbn
            ViewData["Tur"] = new SelectList(_context.Turlers, "Id", "TurAd", kitaplar.TurId); //comboboxda türadlarını görücez ama id leri kaydedecek.
            ViewData["Yazar"] = new SelectList(_context.Yazarlars, "Id", "AdSoyad", kitaplar.YazarId); //comboboxda türadlarını görücez ama id leri kaydedecek.
            ViewData["YayinEvi"] = new SelectList(_context.Yayinevleris, "Id", "Ad", kitaplar.YayinEviId); //comboboxda türadlarını görücez ama id leri kaydedecek.
            return View(kitaplar);
        }

        [HttpPost]
        public IActionResult Edit(Kitaplar kitaplar)
        {
            if (ModelState.IsValid)  //true dönüyorsa herşey yolunda
            {
                _context.Update(kitaplar); //Bu satır sadece contextimizi güncelledi.
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kitaplar);
        }

         [HttpPost,ActionName("Delete")]
        public IActionResult Delete(string id)
        {
            var kitaplar = _context.Kitaplars.Find(id);
            ViewData["Tur"] = new SelectList(_context.Turlers, "Id", "TurAd", kitaplar.TurId);
            ViewData["Yazar"] = new SelectList(_context.Yazarlars, "Id", "AdSoyad", kitaplar.YazarId);
            ViewData["YayinEvi"] = new SelectList(_context.Yayinevleris, "Id", "Ad", kitaplar.YayinEviId);
            return View(kitaplar);
        }
        // [HttpPost,ActionName("Delete")]
        // public IActionResult DeleteConfirmed(string id)
        // {
            
        //     _context.Remove(_context.Kitaplars.Find(id));
        //     _context.SaveChanges();
        //     return RedirectToAction("Index");
        // }
    }
}