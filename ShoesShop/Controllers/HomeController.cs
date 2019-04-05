using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoesShop.Models;

namespace ShoesShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        ///  This class gets called when the "Privacy" section is selected.
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        ///  This class gets called when the "About" section is selected.
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            return View();
        }
        /// <summary>
        /// This class gets called when the "Men" section is selected.
        /// </summary>
        /// <returns></returns>
        public IActionResult Men()
        {
            return View();
        }
        /// <summary>
        /// This class gets called when the "Women" section is selected.
        /// </summary>
        /// <returns></returns>
        public IActionResult Women()
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
