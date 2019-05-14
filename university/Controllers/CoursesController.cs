using Microsoft.AspNetCore.Mvc;
using University.Models;
using System.Collections.Generic;
using System;

namespace University.Controllers
{
  public class CoursesController : Controller
  {

    [HttpGet("/Courses")]
    public ActionResult Index()
    {
      List<Course> allCourses = Course.GetAll();
      return View(allCourses);
    }

    [HttpGet("/Courses/New")]
    public ActionResult New()
    {
        return View();
    }

    // [HttpGet("/Stylist/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Stylist theStylist = Stylist.Find(id);
    //   return View(theStylist);
    // }
    //
    [HttpPost("/Courses")]
    public ActionResult New(string name, string description)
    {
        Course addCourse = new Course(name, int.Parse(description));
        addCourse.Save();
        return RedirectToAction("Index");
    }



  }
}
