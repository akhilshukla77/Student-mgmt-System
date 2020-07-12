using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StudentMgmtSystem.Helper;
using StudentMgmtSystem.Models;

namespace StudentMgmtSystem.Controllers
{
    public class HomeController : Controller
    {
        StudentMgmtApi _api = new StudentMgmtApi();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Students> students = new List<Students>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Students/GetAllStudents");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<Students>>(results);
            }
            return View(students);
        }

        public async Task<IActionResult> FilterStudents(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;

            List<Students> students = new List<Students>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Students/GetAllStudents/"+ Convert.ToInt32(SearchString));
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<Students>>(results);
            }
            return View(students);
        } 

        public async Task<IActionResult> Enrollments()
        {
            List<StudentEnrolled> students = new List<StudentEnrolled>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Students/GetAllStudentEnrolledList");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<StudentEnrolled>>(results);
            }
            return View(students);
        }

        public async Task<IActionResult> FilterEnrollments(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;

            List<StudentEnrolled> students = new List<StudentEnrolled>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Students/GetAllStudentEnrolledList/" + Convert.ToInt32(SearchString));
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<StudentEnrolled>>(results);
            }
            return View(students);
        }

        
        public async Task<IActionResult> StudentServices()
        {
            List<StudentServices> students = new List<StudentServices>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Students/GetAllStudentServices");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<StudentServices>>(results);
            }
            return View(students);
        }

        public async Task<IActionResult> FilterStudentServices(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;

            List<StudentServices> students = new List<StudentServices>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Students/GetAllStudentServices/" + Convert.ToInt32(SearchString));
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<StudentServices>>(results);
            }
            return View(students);
        }
       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
