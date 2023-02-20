using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAuthentication.Models;

namespace UserAuthentication.Controllers
{
    public class PRojectDocumentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: PRojectDocument
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create(int? id)
        {
            var d = db.Projects.Where(x => x.Id == id).SingleOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProjectDocument projectDocument ,HttpPostedFileBase[] Document, int? id)
        {
            if(Document!=null)
            {
                foreach (HttpPostedFileBase file in Document)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var p = db.Projects.Where(x => x.Id == id).SingleOrDefault();
                        ProjectDocument pd = new ProjectDocument();
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/Documents/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        pd.ProjectId = p.Id.ToString();
                        pd.Document = InputFileName;
                        db.ProjectDocument.Add(pd);
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index", "Projects");
        }
        public ActionResult Documents(int? id)
        {
            var d = db.ProjectDocument.Where(x => x.ProjectId == id.ToString()).ToList();
            return View(d.ToList());
        }

    }
}