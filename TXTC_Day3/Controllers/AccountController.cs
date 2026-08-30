using Microsoft.AspNetCore.Mvc;
using TXTC_Day3.Models;
using System; 
using System.Collections.Generic;

namespace TXTC_Day3.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,
                    Name = "Cuong Tran",
                    Email = "cuongtran@example.com",
                    Phone = "123-456-7890",
                    Avatar = "~/images/Avatar/01.jpg",
                    Address = "123 Main St",
                    Bio = "Software Developer",
                    Gender = "Male",
                    Birthday = new DateTime(1990, 1, 1)
                },
                new Account()
                {
                    Id = 2,
                    Name = "Hoang Anh",
                    Email = "hoanganh@example.com",
                    Phone = "123-456-7890",
                    Avatar = "~/images/Avatar/02.jpg",
                    Address = "456 Oak Ave",
                    Bio = "UX Designer",
                    Gender = "Male",
                    Birthday = new DateTime(1990, 1, 1)
                },
                new Account()
                {
                    Id = 3,
                    Name = "Le Thanh",
                    Email = "lethanh@example.com",
                    Phone = "123-456-7890",
                    Avatar = "~/images/Avatar/03.jpg",
                    Address = "123 Main St",
                    Bio = "Software Developer",
                    Gender = "Male",
                    Birthday = new DateTime(1990, 1, 1)
                },
                new Account()
                {
                    Id = 4,
                    Name = "Thuy Quynh",
                    Email = "thuyquynh@example.com",
                    Phone = "123-456-7890",
                    Avatar = "~/images/Avatar/04.jpg",
                    Address = "789 Pine Rd",
                    Bio = "Product Manager",
                    Gender = "Female",
                    Birthday = new DateTime(1990, 1, 1)
                }
            };
            ViewBag.Accounts = accounts;
            return View();
        }
    }
}
