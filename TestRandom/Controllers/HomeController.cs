using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestRandom.Controllers
{
    public class HomeController : Controller
    {
        MSSQLRANDOMTESTContext _context = new MSSQLRANDOMTESTContext();
        public ActionResult Index()
        {
            var listofdata = _context.Posts.ToList();
            return View(listofdata);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post model)
        {
            _context.Posts.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Saved Succefuly";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Posts.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Post Model)
        {
            var data = _context.Posts.Where(x => x.Id == Model.Id).FirstOrDefault();
            if(data != null)
            {
                data.Title = Model.Title;
                data.ImageURL = Model.ImageURL;
                data.CreatedTime = Model.CreatedTime;
                data.AuthorName = Model.AuthorName;
                data.TotalLikes = Model.TotalLikes;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }

        public ActionResult Detail(int id)
        {
            var data = _context.Posts.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var data = _context.Posts.Where(x => x.Id == id).FirstOrDefault();
            _context.Posts.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Data Deleted Succefuly";
            return RedirectToAction("index");
        }
    }
}