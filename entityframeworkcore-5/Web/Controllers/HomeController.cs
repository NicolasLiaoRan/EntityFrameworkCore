using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web
{
    public class HomeController : Controller
    {
        private readonly MyContext _myContext;
        private readonly MyContext _transientContext;

        public HomeController(MyContext myContext,MyContext transientContext)
        {
            this._myContext = myContext;
            this._transientContext = transientContext;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
