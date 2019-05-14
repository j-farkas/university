using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {

    [HttpGet("/Stylist")]
    public ActionResult Index()
    {
        List<Stylist> allStylists = Stylist.GetAll();
        return View(allStylists);
    }

    [HttpGet("/Stylist/New")]
    public ActionResult New()
    {
        return View();
    }

    [HttpGet("/Stylist/{id}")]
    public ActionResult Show(int id)
    {
      Stylist theStylist = Stylist.Find(id);
      return View(theStylist);
    }

    [HttpPost("/Stylist")]
    public ActionResult New(string name, string description)
    {
        Stylist addStylist = new Stylist(name, description);
        addStylist.Save();
        return RedirectToAction("Index");
    }

    [HttpPost("/Client")]
    public ActionResult Add(string name, string stylist)
    {
        Client addClient = new Client(name, int.Parse(stylist));
        addClient.Save();
        return RedirectToAction("Index");
    }

  }
}
