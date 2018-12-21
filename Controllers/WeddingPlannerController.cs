using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
using System.Linq;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private weddingcontext dbContext;
        public WeddingController(weddingcontext context)
        {
            dbContext = context;
        }
        [HttpGet]
        [Route("allweddings")]
        public IActionResult Allweddings()
        {
            List<Wedding> weddings = dbContext.Weddings.ToList();
            if(HttpContext.Session.GetInt32("Uid") == null)
            {
                return RedirectToAction("Register", "LoginReg");
            }
            return View(weddings);
        }
        [HttpGet]
        [Route("addwedding")]
        public IActionResult Addwedding()
        {
            var check = HttpContext.Session.GetInt32("Uid");
            if( check == null)
            {
                return RedirectToAction("Register", "LoginReg");
            }
            @ViewBag.uid = check;
            return View();
        }
        [HttpPost]
        [Route("processwedding")]
        public IActionResult Processwedding(Wedding newwedding)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newwedding);
                dbContext.SaveChanges();
                return RedirectToAction("Allweddings");
            }
            return RedirectToAction("Addwedding");
        }
        [HttpGet]
        [Route("rsvp/{weddingid}")]
        public IActionResult Rsvp(int weddingid)
        { 
            RSVP rsvp = new RSVP();
            var userid = HttpContext.Session.GetInt32("Uid");
            Wedding weddingobj = dbContext.Weddings.FirstOrDefault(i => i.weddingId == weddingid);
            User userobj = dbContext.Users.FirstOrDefault(i => i.userid == userid);
            rsvp.userid = (int)userid;
            rsvp.weddingId = weddingid;
            rsvp.wedding = weddingobj;
            rsvp.user = userobj;
            dbContext.Add(rsvp);
            dbContext.SaveChanges();
            return RedirectToAction("Allweddings");
        }
        [HttpGet]
        [Route("viewwedding/{weddingId}")]
        public IActionResult Viewwedding(int weddingId)
        {
            Wedding viewwedding = dbContext.Weddings.FirstOrDefault(i => i.weddingId == weddingId);
            var usersattending = dbContext.Weddings.Include( wedding => wedding.RSVPS).ThenInclude(rsvp => rsvp.user).FirstOrDefault(wedding => wedding.weddingId == weddingId);
            ViewBag.wedding = viewwedding;
            return View(usersattending);
        }
    }
}
