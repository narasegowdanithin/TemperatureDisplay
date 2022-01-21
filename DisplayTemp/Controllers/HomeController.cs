using DisplayTemp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DisplayTemp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<TempDetailsModel> Det = new List<TempDetailsModel>();
            FileStream fileStream = new FileStream(@"D:\test.txt", FileMode.Open);
            List<int> temprature = new List<int>();
            List<DateTime> timeStamp = new List<DateTime>();
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string temp = line.Substring(14, 2);
                    string dT = line.Substring(31, 17);
                    
                    Det.Add(new TempDetailsModel { temp= Int32.Parse(temp),timeStamp = DateTime.ParseExact(dT, "MM-dd-yy HH:mm:ss", CultureInfo.InvariantCulture) });
                    //timeStamp.Add(DateTime.ParseExact(dT, "MM-dd-yy HH:mm:ss", CultureInfo.InvariantCulture));

                }
            }
            
            return View(Det);
        }

        public IActionResult Graph()
        {
            List<TempDetailsModel> Det = new List<TempDetailsModel>();
            FileStream fileStream = new FileStream(@"D:\test.txt", FileMode.Open);
            List<int> temprature = new List<int>();
            List<DateTime> timeStamp = new List<DateTime>();
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string temp = line.Substring(14, 2);
                    string dT = line.Substring(31, 17);

                    Det.Add(new TempDetailsModel { temp = Int32.Parse(temp), timeStamp = DateTime.ParseExact(dT, "MM-dd-yy HH:mm:ss", CultureInfo.InvariantCulture) });
                    //timeStamp.Add(DateTime.ParseExact(dT, "MM-dd-yy HH:mm:ss", CultureInfo.InvariantCulture));

                }
            }

            return View(Det);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
