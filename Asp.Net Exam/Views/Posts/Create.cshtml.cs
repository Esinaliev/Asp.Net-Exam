using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace testAsp.Pages.Posts
{
    public class CreateModel : PageModel
    {
        public Post post = new Post();
        //B@exam.com
        //Aa_123
        public CreateModel()
        {

        }

        /*[HttpPost]
        public IActionResult Post(string title, string description)
        {
            string authData = $"Login: {title}   Password: {description}";
            Console.WriteLine(title);
            return Content(authData);
        }*/
        [HttpPost]
        public int Post()
        {
            

            Console.WriteLine("===============================");
            Console.WriteLine(Request.Form["title"]);
            Console.WriteLine(Request.Form["image"]);
            Console.WriteLine("===============================");
            return 200;
        }
    }
    public class formPost
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public Image? image { get; set; }
    }
}
