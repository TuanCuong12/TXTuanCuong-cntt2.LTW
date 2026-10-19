using Microsoft.AspNetCore.Mvc;
using Txtc_lap3.Models;

namespace Txtc_lap3.Controllers
{
    public class TxtcAccountController : Controller
    {
        public IActionResult Index()
        {
            List<TxtcAccount> accounts = new List<TxtcAccount>()
            {
                new TxtcAccount()
                {
                    Id = 1,
                    Name = "James Anderson",
                    Email = "james.anderson@gmail.com",
                    Phone = "0912345678",
                    Avatar = Url.Content("~/TxtcAvatar/4.jpg"),
                    Address = "12 Láng Hạ, Đống Đa, Hà Nội",
                    Bio = "Tập gym 3 năm, mục tiêu tăng cơ giảm mỡ.",
                    Gender = 1,
                    Birthday = new DateTime(1995, 3, 12)
                },
                new TxtcAccount()
                {
                    Id = 2,
                    Name = "Sarah Johnson",
                    Email = "sarah.johnson@gmail.com",
                    Phone = "0987654321",
                    Avatar = Url.Content("~/TxtcAvatar/5.jpg"),
                    Address = "456 Lê Duẩn, Quận 5, TP. HCM",
                    Bio = "Yoga và Pilates, yêu thích các môn thể thao ngoài trời.",
                    Gender = 2,
                    Birthday = new DateTime(1990, 7, 22)
                },
                new TxtcAccount()
                {
                    Id = 3,
                    Name = "Michael Smith",
                    Email = "michael.smith@gmail.com",
                    Phone = "0901234567",
                    Avatar = Url.Content("~/TxtcAvatar/6.jpg"),
                    Address = "789 Trần Hưng Đạo, Quận 5, TP. HCM",
                    Bio = "Yêu thích bóng đá và các môn thể thao mang tính đối kháng.",
                    Gender = 1,
                    Birthday = new DateTime(1988, 11, 5)
                }
            };
            ViewBag.Accounts = accounts;
            return View();
        }

        [Route("ho-so-cua-toi",Name = "MyProfile")]
        public IActionResult Profile(int id)
        {
            List<TxtcAccount> accounts = new List<TxtcAccount>()
            {
                new TxtcAccount()
                {
                    Id = 1,
                    Name = "James Anderson",
                    Email = "james.anderson@gmail.com",
                    Phone = "0912345678",
                    Avatar = Url.Content("~/TxtcAvatar/4.jpg"),
                    Address = "12 Láng Hạ, Đống Đa, Hà Nội",
                    Bio = "Tập gym 3 năm, mục tiêu tăng cơ giảm mỡ.",
                    Gender = 1,
                    Birthday = new DateTime(1995, 3, 12)
                },

                new TxtcAccount()
                {
                    Id = 2,
                    Name = "Sarah Johnson",
                    Email = "sarah.johnson@gmail.com",
                    Phone = "0987654321",
                    Avatar = Url.Content("~/TxtcAvatar/5.jpg"),
                    Address = "456 Lê Duẩn, Quận 5, TP. HCM",
                    Bio = "Yoga và Pilates, yêu thích các môn thể thao ngoài trời.",
                    Gender = 2,
                    Birthday = new DateTime(1990, 7, 22)
                },

                new TxtcAccount()
                {
                    Id = 3,
                    Name = "Michael Smith",
                    Email = "michael.smith@gmail.com",
                    Phone = "0901234567",
                    Avatar = Url.Content("~/TxtcAvatar/6.jpg"),
                    Address = "789 Trần Hưng Đạo, Quận 5, TP. HCM",
                    Bio = "Yêu thích bóng đá và các môn thể thao mang tính đối kháng.",
                    Gender = 1,
                    Birthday = new DateTime(1988, 11, 5)
                }
                
            };
            TxtcAccount account = accounts.FirstOrDefault(a => a.Id == id);
            ViewBag.Account = accounts;
            return View();
        }
                
    }
}
