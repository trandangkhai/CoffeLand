﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoffeLand.Controllers
{
    public class FisrtController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome(string HovaTen, int Tuoi = 1)
        {
            ViewData["Greeting"] = "Xin chao, toi la " + HovaTen + ". Tuoi cua toi la " +
            Tuoi.ToString() + ".";
            return View();
        }
    }
}