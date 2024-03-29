﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ILogger<GalleryController> _logger;

        public GalleryController(ILogger<GalleryController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
