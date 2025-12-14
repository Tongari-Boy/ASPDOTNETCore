using Microsoft.AspNetCore.Mvc;

namespace SampleMVCApp.Controllers
{
    public class HelloController : Controller
    {
        public List<string> list;

        public HelloController()
        {
            list = new List<string>();
            list.Add("Japan");
            list.Add("USA");
            list.Add("UK");
        }
        public IActionResult Index()
        {
            //ViewData["Message"] = "Hello! this is sample page!!";
            ViewData["message"] = "Input your data:";
            ViewData["name"] = "";
            ViewData["mail"] = "";
            ViewData["tel"] = "";

            ViewData["message"] = "Select item";
            ViewData["list"] = "";
            ViewData["listdata"] = list;

            return View();
        }

        [HttpPost]
        public IActionResult Form()
        {
            //ViewData["Message"] = Request.Form["msg"];
            ViewData["name"] = Request.Form["name"];
            ViewData["mail"] = Request.Form["mail"];
            ViewData["tel"] = Request.Form["tel"];
            ViewData["message"] = ViewData["name"] + "," + ViewData["mail"] + "," + ViewData["tel"];

            ViewData["message"] = '"' + Request.Form["list"] + '"' + "selected.";
            ViewData["list"] = Request.Form["list"];
            ViewData["listdata"] = list;

            return View("Index");
        }

        //[HttpPost]
        //public IActionResult Form(string name,string mail,string tel)
        //{
        //    ViewData["name"] = name;
        //    ViewData["mail"] = mail;
        //    ViewData["tel"] = tel;
        //    ViewData["message"] = ViewData["name"] + "," + ViewData["mail"] + "," + ViewData["tel"];
        //    return View("Index");
        //}
    }
}
