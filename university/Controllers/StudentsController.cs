using Microsoft.AspNetCore.Mvc;
using University.Models;
using System.Collections.Generic;
using System;

namespace University.Controllers
{
  public class StudentsController : Controller
  {
    [HttpGet("/Students/New")]
    public ActionResult New()
    {   List<Student> allStudents = Student.GetAll();
        return View(allStudents);
    }

    [HttpPost("/Students")]
    public ActionResult Add(string name)
    {
        Student addStudent = new Student(name);
        addStudent.Save();
        return RedirectToAction("Index");
    }

    [HttpGet("/Students")]
    public ActionResult Index()
    {   List<Student> allStudents = Student.GetAll();
        return View(allStudents);
    }

    [HttpGet("/Students/{id}")]
    public ActionResult Show(int id)
    {   Student theStudent = Student.Find(id);
        return View(theStudent);
    }

    // [HttpGet("/Stylist/{id}/Replace")]
    // public ActionResult Replace(int id)
    // {
    //     Stylist theStylist = Stylist.Find(id);
    //     return View(theStylist);
    // }
    //
    [HttpPost("/Students/{id}")]
    public ActionResult Change(int id, int courses)
    {
        Student theStudent = Student.Find(id);
        Course theCourse = Course.Find(courses);
        theCourse.AddStudentToCourse(theStudent);
        //theStudent = Student.Find(id);
        return View("Show",theStudent);
    }
    //
    // [HttpPost("/Client/{id}/Cut")]
    // public ActionResult Change(int id)
    // {
    //     Client theClient = Client.Find(id);
    //     theClient.GrowHair();
    //     Stylist theStylist = Stylist.Find(theClient.GetStylist());
    //     int damage = theStylist.GetLevel()+theStylist.GetScissors();
    //     if(damage > theClient.GetHair())
    //     {
    //       //The client has been killed
    //       theStylist.GetDrop();
    //       theClient.Delete();
    //       return View("Replace", theStylist);
    //     }else{
    //       //The client lives on
    //       if(theStylist.GetHair()+damage > theStylist.GetNextLevel())
    //       {
    //         theStylist.Update("level",(theStylist.GetLevel()+1).ToString());
    //         theStylist.Update("hair","0");
    //       }else{
    //         theStylist.Update("hair",(theStylist.GetHair()+damage).ToString());
    //       }
    //       theClient.Update("hair",(theClient.GetHair()-damage).ToString());
    //       theClient = Client.Find(id);
    //       return View("Show",theClient);
    //     }
    //       return View("Show",theClient);
    // }
  }
}
