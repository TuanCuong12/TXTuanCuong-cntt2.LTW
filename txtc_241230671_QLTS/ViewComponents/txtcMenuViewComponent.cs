using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using txtc_241230671_QLTS.Models;

namespace txtc_241230671_QLTS.ViewComponents
{
    public class txtcMenuViewComponent : ViewComponent
    {
        private readonly QLTaiSanContext _db;

        public txtcMenuViewComponent(QLTaiSanContext db) => _db = db;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ds = await _db.LoaiTaiSans.AsNoTracking().OrderBy(l => l.MaLoai).ToListAsync();
            return View(ds);
        }
    }
}