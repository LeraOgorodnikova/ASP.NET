using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hierarchy.Models;

namespace Hierarchy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult MyTree()
        {
            Folder folder1 = new Folder("app", new DateTime(), 0, null, null); ///

            File file1 = new File("dask", new DateTime(), 144);
            File file2 = new File("fold", new DateTime(), 74);
            List<File> files1 = new List<File>();
            files1.Add(file1);
            files1.Add(file2);
            Folder folder2 = new Folder("content", new DateTime(), 2, files1, null); ///


            File file3 = new File("connection", new DateTime(), 10);
            File file4 = new File("classes", new DateTime(), 745);
            List<File> files2 = new List<File>();
            files2.Add(file3);
            files2.Add(file4);
            Folder folder3 = new Folder("daring", new DateTime(), 2, files2, null);
            List<Folder> folders1 = new List<Folder>();
            folders1.Add(folder3);
            Folder folder4 = new Folder("functions", new DateTime(), 3, null, folders1);////


            File file5 = new File("sunday", new DateTime(), 422);
            List<File> files3 = new List<File>();
            files3.Add(file5);
            Folder folder5 = new Folder("days", new DateTime(), 1, files3, null);
            File file6 = new File("primary", new DateTime(), 42);
            File file7 = new File("sunny", new DateTime(), 44);
            File file8 = new File("cats", new DateTime(), 166);
            List<File> files4 = new List<File>();
            files4.Add(file6);
            files4.Add(file7);
            files4.Add(file8);
            List<Folder> folders2 = new List<Folder>();
            folders2.Add(folder5);
            Folder folder6 = new Folder("pike", new DateTime(), 5, files4, folders2);
            Folder folder7 = new Folder("cornery", new DateTime(), 0, null, null);
            Folder folder8 = new Folder("issue", new DateTime(), 0, null, null);

            List<Folder> folders3 = new List<Folder>();
            folders3.Add(folder8);
            folders3.Add(folder7);
            folders3.Add(folder6);

            Folder folder10 = new Folder("mail", new DateTime(), 8, null, folders3);////
            List<Folder> files = new List<Folder>();
            files.Add(folder1);
            files.Add(folder10);
            files.Add(folder2);
            files.Add(folder4);

            Folder folder = new Folder("main_app", new DateTime(), 17, null, files);
            return View(folder);
        }
    }
}