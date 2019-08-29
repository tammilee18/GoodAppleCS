using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using GoodApple.Models;
using Microsoft.AspNetCore.Identity;

namespace GoodApple.Controllers
{
    public class TeacherController : Controller
    {
        private GoodAppleContext dbContext;

        public int? InSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set { HttpContext.Session.SetInt32("UserId", (int)value); }
        }

        public TeacherController(GoodAppleContext context) {
            dbContext = context;
        }

        //All things regarding teachers
        [HttpGet("newteacher")]
        public IActionResult NewTeacher()
        {
            return View("TeacherReg");
        }

        [HttpPost("newteacher")]
        public IActionResult Create(Teacher newTeacher)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.users.Any(user => user.Email == newTeacher.Email))
                {
                    ModelState.AddModelError("Email", "Email is already in use!");
                    return View("TeacherReg");
                }
                // Initializing a PasswordHasher object, providing our User class as its
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                string hashedPw = hasher.HashPassword(newTeacher, newTeacher.Password);
                newTeacher.Password = hashedPw;
                //Save your user object to the database
                dbContext.users.Add(newTeacher);
                dbContext.SaveChanges();
                InSession = newTeacher.UserId;
                return RedirectToAction("TeachDashboard", new {TeacherId = newTeacher.UserId});
            }
            return View("TeacherReg");
        }

        public IActionResult TeacherLogin(LoginUser existingTeacher){
            if(ModelState.IsValid){
                User userInDB = dbContext.users.FirstOrDefault(u => u.Email == existingTeacher.Email);
                if(userInDB == null){
                    ModelState.AddModelError("Email", "Invalid email or password");
                    return View("Index", "Home");
                } else {
                    var hasher = new PasswordHasher<LoginUser>();
                    var result = hasher.VerifyHashedPassword(existingTeacher, userInDB.Password, existingTeacher.Password);
                    if(result == 0){
                        ModelState.AddModelError("Password", "Invalid email or password");
                        return RedirectToAction("Index", "Home");
                    }
                    if(HttpContext.Session.GetInt32("UserId") == null){
                        HttpContext.Session.SetInt32("UserId", userInDB.UserId);
                    }
                    return RedirectToAction("TeachDashboard", new{TeacherId = userInDB.UserId});
                }
            } else {
                return View("Index", "Home");
            }
        }

        [HttpGet("dashboard/{TeacherId}")]
        public IActionResult TeachDashboard(int TeacherId){
            TeacherId = (int)InSession;
            // if(InSession == null){
            //     return View("Index", "Home");
            // }
            WrapperModel newModel = new WrapperModel();
            newModel.LoggedInUser = dbContext.users.SingleOrDefault(u => u.UserId == TeacherId);
            newModel.AllProjects = dbContext.projects.Include(p => p.Donations).ToList();
            return View(newModel);
        }

        [HttpPost("newproject")]
        public IActionResult NewProject(Project newProject)
        {
            int CurrentTeacher = (int)InSession;
            if(ModelState.IsValid){
                newProject.CreatorId = CurrentTeacher;
                dbContext.projects.Add(newProject);
                dbContext.SaveChanges();
                return RedirectToAction("TeachDashboard", new{TeacherId = CurrentTeacher});
            }
            WrapperModel newModel = new WrapperModel();
            newModel.LoggedInUser = dbContext.users.SingleOrDefault(u => u.UserId == CurrentTeacher);
            newModel.AllProjects = dbContext.projects.ToList();
            return View("TeachDashboard", newModel);
        }

    }

}