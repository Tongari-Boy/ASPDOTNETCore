using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Linq;

namespace SampleMVCApp.Controllers
{
    public class HelloController : Controller
    {
        //public List<string> list;
        //public HelloController()
        //{
        //    list = new List<string>();
        //    list.Add("Japan");
        //    list.Add("USA");
        //    list.Add("UK");
        //}

        [Route("hello/{id?}/{namae?}")]
        public IActionResult Index(int id = 0, string namae = "")
        {
            //ViewData["Message"] = "Hello! this is sample page!!";
            ViewData["message"] = "※セッションのIDとNAMEを保存しました";

            //ViewData["name"] = "";
            //ViewData["mail"] = "";
            //ViewData["tel"] = "";

            //HttpContext.Session.SetInt32("id", id);
            //HttpContext.Session.SetString("name", namae);

            MyData ob = new MyData(id, namae);
            String s = ObjectToString(ob);
            HttpContext.Session.SetString("object", s);
            ViewData["object"] = ob;

            return View();
        }

        //[HttpPost]
        //public IActionResult Form()
        //{
        //    //ViewData["Message"] = Request.Form["msg"];
        //    ViewData["name"] = Request.Form["name"];
        //    ViewData["mail"] = Request.Form["mail"];
        //    ViewData["tel"] = Request.Form["tel"];
        //    ViewData["message"] = ViewData["name"] + "," + ViewData["mail"] + "," + ViewData["tel"];

        //    ViewData["message"] = '"' + Request.Form["list"] + '"' + "selected.";
        //    ViewData["list"] = Request.Form["list"];
        //    ViewData["listdata"] = list;

        //    return View("Index");
        //}

        //[HttpPost]
        //public IActionResult Form(string name,string mail,string tel)
        //{
        //    ViewData["name"] = name;
        //    ViewData["mail"] = mail;
        //    ViewData["tel"] = tel;
        //    ViewData["message"] = ViewData["name"] + "," + ViewData["mail"] + "," + ViewData["tel"];
        //    return View("Index");
        //}

        //[HttpGet]
        //public IActionResult Other()
        //{
        //    ViewData["id"] = HttpContext.Session.GetInt32("id");
        //    ViewData["namae"] = HttpContext.Session.GetString("namae");
        //    ViewData["message"] = "保存されたセッションを表示します";

        //    return View("Index");
        //}

        [HttpGet("Other")]
        public IActionResult Other()
        {
            ViewData["message"] = "保存されたセッションの値を表示します";
            String s = HttpContext.Session.GetString("object") ?? "";
            ViewData["object"] = StringToObject(s);

            return View("Index");
        }

        //convert object to string
        public String ObjectToString(MyData ob)
        {
            return JsonSerializer.Serialize<MyData>(ob);
        }

        //convert string to object
        private MyData? StringToObject(String s)
        {
            MyData? ob;
            try
            {
                ob = JsonSerializer.Deserialize<MyData>(s);
            }
            catch (Exception e)
            {
                ob = new MyData(0, "noname");
            }
            return ob;
        }
    }
}

[Serializable]
public class MyData
{
    public int Id { get; set; }
    public string Namae { get; set; }
    public MyData(int id, string namae)
    {
        Id = id;
        Namae = namae;
    }
    public override string ToString()
    {
        return "<" + Id + ":" + Namae + ">";
    }
}