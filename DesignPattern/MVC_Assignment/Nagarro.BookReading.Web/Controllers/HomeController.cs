using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nagarro.BookReading.Data.CustomException;
using Nagarro.BookReading.Web.Interfaces;
using Nagarro.BookReading.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.BookReading.Web.Controllers
{
    [CustomExceptionFilter]
    public class HomeController : Controller
    {
        private readonly IEventPageService _eventPageService;

        public HomeController(IEventPageService eventPageService)
        {
            this._eventPageService = eventPageService;
        }
        [Route("")]
       
        public async Task<IActionResult> Index()
        {
            var eventList = await _eventPageService.GetEvents();
            return View(eventList);
        }

        [Route("Privacy")]
        [CustomExceptionFilter]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("about-us")]
        public IActionResult About()
        {
            return View();
        }

        [Route("customer-support")]
        public IActionResult CustomerSupport()
        {
            return View();
        }



    }
}
