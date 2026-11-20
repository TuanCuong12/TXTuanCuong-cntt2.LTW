using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using txtc_241230671.Helpers;
using txtc_241230671.Models;

namespace txtc_241230671.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLNhaSachContext _db;

        public HomeController(QLNhaSachContext db) => _db = db;

        public async Task<IActionResult> Index(int? maTL)
        {
            return View(await BuildViewModelAsync(maTL));
        }

        public async Task<IActionResult> Loc(int maTL)
        {
            return PartialView("_txtc_MainContent", await BuildViewModelAsync(maTL));
        }

        private async Task<SachListViewModel> BuildViewModelAsync(int? maTL)
        {
            var vm = new SachListViewModel();

            if (maTL is null or 0)
            {
                vm.Title = AppInfo.HoTen;
                vm.DanhSach = await _db.Saches.AsNoTracking()
                    .Where(s => s.Gia != null && s.Gia >= 100)
                    .OrderBy(s => s.MaSach)
                    .ToListAsync();
            }
            else
            {
                var theLoai = await _db.TheLoais.AsNoTracking().FirstOrDefaultAsync(t => t.MaTl == maTL);
                vm.Title = theLoai?.TenTl ?? "Không tìm thấy thể loại";
                vm.DanhSach = await _db.Saches.AsNoTracking()
                    .Where(s => s.MaTl == maTL && s.Gia != null)
                    .OrderBy(s => s.MaSach)
                    .ToListAsync();
            }
            return vm;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadTheLoaiAsync();
            return View(new Sach());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTl,TenSach,Gia,Anh")] Sach sach)
        {
            ModelState.Remove(nameof(Sach.MaTlNavigation));
            if (!ModelState.IsValid)
            {
                await LoadTheLoaiAsync(sach.MaTl);
                return View(sach);
            }

            _db.Saches.Add(sach);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadTheLoaiAsync(int? selected = null)
        {
            var ds = await _db.TheLoais.AsNoTracking().OrderBy(t => t.MaTl).ToListAsync();
            ViewBag.MaTl = new SelectList(ds, "MaTl", "TenTl", selected);
        }

        public IActionResult Error() => Content("Đã xảy ra lỗi.");
    }
}