using Microsoft.AspNetCore.Mvc;
using Txtc_Demo_lesson3.Models;

namespace Txtc_Demo_lesson3.Controllers
{
    public class txtcProductController : Controller
    {
        public IActionResult Index()
        {
            //Tạo một sản phầm
            var Product = new TxtcProduct()
            {
                idProduct = "SP001",
                nameProduct = "Creatine Ostrovit",
                quantityProduct = 100,
                priceProduct = 29.99m
            };
            ViewBag.ProductVB = Product;
            ViewData["ProductVD"] = Product;

            return View();
        }

        public IActionResult GetAllProduct()
        {
            //Tạo mock data
            List<TxtcProduct> products = new List<TxtcProduct>()
            {
                new TxtcProduct { idProduct = "SP001", nameProduct = "Whey Protein Gold Standard 5lbs", quantityProduct = 25, priceProduct = 1850000m },
                new TxtcProduct { idProduct = "SP002", nameProduct = "Whey Protein Isolate ISO100 2lbs", quantityProduct = 18, priceProduct = 1450000m },
                new TxtcProduct { idProduct = "SP003", nameProduct = "Mass Gainer Serious Mass 12lbs", quantityProduct = 12, priceProduct = 1650000m },
                new TxtcProduct { idProduct = "SP004", nameProduct = "Creatine Monohydrate 300g", quantityProduct = 40, priceProduct = 550000m },
                new TxtcProduct { idProduct = "SP005", nameProduct = "BCAA 2:1:1 Xtend 30 servings", quantityProduct = 30, priceProduct = 720000m },
                new TxtcProduct { idProduct = "SP006", nameProduct = "Pre-Workout C4 Original 30 servings", quantityProduct = 22, priceProduct = 780000m },
                new TxtcProduct { idProduct = "SP007", nameProduct = "EAA Essential Amino Acids 30 servings", quantityProduct = 15, priceProduct = 690000m },
                new TxtcProduct { idProduct = "SP008", nameProduct = "Glutamine 300g", quantityProduct = 20, priceProduct = 480000m },
                new TxtcProduct { idProduct = "SP009", nameProduct = "Fish Oil Omega-3 100 viên", quantityProduct = 35, priceProduct = 420000m },
                new TxtcProduct { idProduct = "SP010", nameProduct = "Multivitamin Opti-Men 90 viên", quantityProduct = 28, priceProduct = 650000m }
            };

            // Lưu vào đối tượng viewdata để truyền dữ liệu sang view
            ViewData["Products"] = products;
            return View("ProductList");
        }
    }
}
