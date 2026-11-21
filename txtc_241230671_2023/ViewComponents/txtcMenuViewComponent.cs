using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using txtc_241230671_2023.Models;

namespace txtc_241230671_2023.ViewComponents
{
    public class txtcMenuViewComponent : ViewComponent
    {
        private readonly QLHangHoaContext _db;

        public txtcMenuViewComponent(QLHangHoaContext db) => _db = db;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ds = await _db.LoaiHangs.AsNoTracking().OrderBy(l => l.MaLoai).ToListAsync();
            return View(ds);
        }
    }
}