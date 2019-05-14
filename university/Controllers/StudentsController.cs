using Microsoft.AspNetCore.Mvc;
using University.Models;
using System.Collections.Generic;
using System;

namespace University.Controllers
{
  public class ClientController : Controller
  {
    [HttpGet("/Client/New")]
    public ActionResult New()
    {   List<Stylist> allStylists = Stylist.GetAll();
        return View(allStylists);
    }

    [HttpGet("/Client/{id}")]
    public ActionResult Show(int id)
    {   Client theClient = Client.Find(id);
        return View(theClient);
    }

    [HttpGet("/Stylist/{id}/Replace")]
    public ActionResult Replace(int id)
    {
        Stylist theStylist = Stylist.Find(id);
        return View(theStylist);
    }

    [HttpPost("/Client/{id}")]
    public ActionResult Change(int id, string stylist)
    {
        Client theClient = Client.Find(id);
        theClient.Update("stylist", stylist);
        theClient = Client.Find(id);
        return View("Show",theClient);
    }

    [HttpPost("/Client/{id}/Cut")]
    public ActionResult Change(int id)
    {
        Client theClient = Client.Find(id);
        theClient.GrowHair();
        Stylist theStylist = Stylist.Find(theClient.GetStylist());
        int damage = theStylist.GetLevel()+theStylist.GetScissors();
        if(damage > theClient.GetHair())
        {
          //The client has been killed
          theStylist.GetDrop();
          theClient.Delete();
          return View("Replace", theStylist);
        }else{
          //The client lives on
          if(theStylist.GetHair()+damage > theStylist.GetNextLevel())
          {
            theStylist.Update("level",(theStylist.GetLevel()+1).ToString());
            theStylist.Update("hair","0");
          }else{
            theStylist.Update("hair",(theStylist.GetHair()+damage).ToString());
          }
          theClient.Update("hair",(theClient.GetHair()-damage).ToString());
          theClient = Client.Find(id);
          return View("Show",theClient);
        }
          return View("Show",theClient);
    }
  }
}
