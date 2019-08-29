using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using GoodApple.Models;

namespace GoodApple.Controllers {
    public class HomeController : Controller {
        private GoodAppleContext dbContext;

        public HomeController(GoodAppleContext context) {
            dbContext = context;
        }

        public IActionResult Index(){
            return View();
        }

        [HttpGet("projects")]
        public IActionResult AllProjects()
        {
            List<Project> AllProjects = dbContext.projects.Include(c => c.Creator).ToList();
            ViewBag.AllProjects = AllProjects;
            return View();
        }
        [HttpGet("projectinfo/{ProjectId}")]
        public IActionResult ProjectInfo(int ProjectId)
        {
            return View();
        }
        
        [HttpGet("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
