using System.Diagnostics;
using System.Security.Claims;
using dk.lashout.LARPay.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dk.lashout.LARPay.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Start()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }

        public IActionResult Transfer()
        {
            return View();
        }

        public IActionResult CreditLimit()
        {
            return View();
        }
    }
}
