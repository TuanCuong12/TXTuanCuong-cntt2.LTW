using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using txtc_241230671_2023.Helpers;
using txtc_241230671_2023.Models;

namespace txtc_241230671_2023.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLHangHoaContext _db;

        public HomeController(QLHangHoaContext db) => _db = db;

        // Câu 3: trang chủ
        public async Task<IActionResult> Index(int? maLoai)
        {
            return View(await BuildViewModelAsync(maLoai));
        }

        public async Task<IActionResult> Loc(int maLoai)
        {
            return PartialView("_txtc_MainContent", await BuildViewModelAsync(maLoai));
        }

        private async Task<HangHoaListViewModel> BuildViewModelAsync(int? maLoai)
        {
            var vm = new HangHoaListViewModel();

            if (maLoai is null or 0)
            {
                vm.Title = AppInfo.HoTen;
                vm.DanhSach = await _db.HangHoas.AsNoTracking()
                    .Where(h => h.Gia != null && h.Gia >= 100)
                    .OrderBy(h => h.MaHang)
                    .ToListAsync();
            }
            else
            {
                var loai = await _db.LoaiHangs.AsNoTracking().FirstOrDefaultAsync(l => l.MaLoai == maLoai);
                vm.Title = loai?.TenLoai ?? "Không tìm thấy loại hàng";
                vm.DanhSach = await _db.HangHoas.AsNoTracking()
                    .Where(h => h.MaLoai == maLoai && h.Gia != null)
                    .OrderBy(h => h.MaHang)
                    .ToListAsync();
            }
            return vm;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadLoaiHangAsync();
            return View(new HangHoa());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoai,TenHang,Gia,Anh")] HangHoa hh)
        {
            ModelState.Remove(nameof(HangHoa.MaLoaiNavigation));

            if (!ModelState.IsValid)
            {
                await LoadLoaiHangAsync(hh.MaLoai);
                return View(hh);
            }

            _db.HangHoas.Add(hh);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadLoaiHangAsync(int? selected = null)
        {
            var ds = await _db.LoaiHangs.AsNoTracking().OrderBy(l => l.MaLoai).ToListAsync();
            ViewBag.MaLoai = new SelectList(ds, "MaLoai", "TenLoai", selected);
        }

        public IActionResult Error() => Content("Đã xảy ra lỗi.");
    }
}