using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using txtc_241230671.Models;

namespace txtc_241230671.ViewComponents
{
    public class txtcMenuViewComponent : ViewComponent
    {
        private readonly QLNhaSachContext _db;

        public txtcMenuViewComponent(QLNhaSachContext db) => _db = db;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var dsTheLoai = await _db.TheLoais.AsNoTracking().OrderBy(t => t.MaTl).ToListAsync();
            return View(dsTheLoai);
        }
    }
}