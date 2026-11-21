using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using txtc_241230671_QLTS_DE2.Helpers;
using txtc_241230671_QLTS_DE2.Models;

namespace txtc_241230671_QLTS_DE2.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLTaiSanContext _db;

        public HomeController(QLTaiSanContext db) => _db = db;

        // Câu 3: trang chủ
        public async Task<IActionResult> Index(int? maLoai)
        {
            return View(await BuildViewModelAsync(maLoai));
        }

        // Câu 4: AJAX, chỉ trả về phần nội dung chính
        public async Task<IActionResult> Loc(int maLoai)
        {
            return PartialView("_txtc_MainContent", await BuildViewModelAsync(maLoai));
        }

        private async Task<TaiSanListViewModel> BuildViewModelAsync(int? maLoai)
        {
            var vm = new TaiSanListViewModel();

            if (maLoai is null or 0)
            {
                vm.Title = AppInfo.HoTen;
                vm.DanhSach = await _db.TaiSans.AsNoTracking()
                    .Where(t => t.NguyenGia != null && t.NguyenGia >= 20)
                    .OrderBy(t => t.MaTs)
                    .ToListAsync();
            }
            else
            {
                var loai = await _db.LoaiTaiSans.AsNoTracking().FirstOrDefaultAsync(l => l.MaLoai == maLoai);
                vm.Title = loai?.TenLoai ?? "Không tìm thấy loại tài sản";
                vm.DanhSach = await _db.TaiSans.AsNoTracking()
                    .Where(t => t.MaLoai == maLoai && t.NguyenGia != null)
                    .OrderBy(t => t.MaTs)
                    .ToListAsync();
            }
            return vm;
        }

        private async Task LoadLoaiAsync(int? selected = null)
        {
            var ds = await _db.LoaiTaiSans.AsNoTracking().OrderBy(l => l.MaLoai).ToListAsync();
            ViewBag.MaLoai = new SelectList(ds, "MaLoai", "TenLoai", selected);
        }

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var ts = await _db.TaiSans.AsNoTracking().FirstOrDefaultAsync(t => t.MaTs == id);
			if (ts == null) return NotFound();

			await LoadLoaiAsync(ts.MaLoai);
			return View(ts);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("MaLoai,TenTs,NguyenGia,Anh")] TaiSan ts)
		{
			ModelState.Remove(nameof(TaiSan.MaLoaiNavigation));
			ts.MaTs = id;   // giữ lại mã để form (khi báo lỗi) vẫn gửi đúng về Edit/{id}

			if (!ModelState.IsValid)
			{
				await LoadLoaiAsync(ts.MaLoai);
				return View(ts);
			}

			var entity = await _db.TaiSans.FindAsync(id);
			if (entity == null) return NotFound();

			entity.MaLoai = ts.MaLoai;
			entity.TenTs = ts.TenTs;
			entity.NguyenGia = ts.NguyenGia;
			entity.Anh = ts.Anh;

			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Error() => Content("Đã xảy ra lỗi.");
    }
}