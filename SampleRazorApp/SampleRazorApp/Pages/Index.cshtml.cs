using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace SampleRazorApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //[ViewData]
        //public string Message { get; set; } = "sample message!";

        public string Message { get; set; } = "no message.";

        //private string Name = "No-Name";
        //private string Mail = "No-Mail";

        //private string[][] data = new string[][]
        //{
        //    new string[] {"Taro","taro@yamada"},
        //    new string[] {"Hanako","hanako@flower"},
        //    new string[] {"Jiro","sachiko@happy"}
        //};

        //[BindProperty(SupportsGet = true)]
        //public int id { get; set; }

        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Num { get; set; }


        public void OnGet()
        {
            //ViewData["message"] = "This is a sample massage!";
            //Message = "これは新たに追加されたメッセージです!!";
            Message = "入力してください。";
        }

        //public string getData(int id)
        //{
        //    /return "[名前:" + Name  + "、メール:" + Mail + "]";
        //    string[] target = data[id];
        //    return"[名前:" + target[0] + "、メール:" + target[1] + "]";
        //}

        public void OnPost(string name,string password,string mail,string tel)
        {
            //Message = "you typed: " + Request.Form["msg"];
            Message = "[name:" + name + ",password:(" + password.Length + "),mail:" + mail + "<" + tel + ">";
        }
    }
}
