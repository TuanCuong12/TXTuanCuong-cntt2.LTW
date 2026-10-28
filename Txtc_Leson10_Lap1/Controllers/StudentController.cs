using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Txtc_Leson10_Lap1.Models;
namespace Txtc_Leson10_Lap1.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> ListStudents = new List<Student>();
        public StudentController()
        {
            ListStudents = new List<Student>()
            {
                new Student() { ID = "S001", Name = "Nguyen Van An", Branch=Branch.IT,Gender=Gender.Male,IsRegular=true, Address="A1-2018",Email="an@g.com" },
                new Student() { ID = "S002", Name = "Nguyen Minh Tu", Branch=Branch.BE,Gender=Gender.Male,IsRegular=false, Address="A1-2019",Email="tu@g.com" },
                new Student() { ID = "S003", Name = "Nguyen Thi Lan", Branch=Branch.CE,Gender=Gender.Female,IsRegular=true, Address="A1-2020",Email="lan@g.com" },
                new Student() { ID = "S004", Name = "Hoang Phong", Branch=Branch.EE,Gender=Gender.Male,IsRegular=false, Address="A1-2021",Email="phong@g.com" }
            };
        }

        public IActionResult Index()
        {
            return View(ListStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //Lấy giá trị Gender để hiển thị trên radio button
            ViewBag.AllGender = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            //Lấy danh sách giá trị Branch để hiển thị select option
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem {Text= "IT", Value="1"},
                new SelectListItem {Text="BE", Value="2"},
                new SelectListItem {Text="CE", Value="3"},
                new SelectListItem {Text="EE", Value="4"}

            };
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student s)
        {
            s.ID = ListStudents.Last<Student>().ID + 1;
            ListStudents.Add(s);
            return View("Index", ListStudents);
        }

    }
}