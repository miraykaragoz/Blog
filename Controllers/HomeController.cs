using BlogOdevMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogOdevMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var posts = new List<Post>();
            using StreamReader reader = new StreamReader("AppData/Posts/index.txt");
            var postsTxt = reader.ReadToEnd();
            var postsLines = postsTxt.Split('\n');
            foreach (var postLine in postsLines)
            {
                var postParts = postLine.Split('|');
                posts.Add(
                    new Post()
                    {
                        Title = postParts[0],
                        Summary = postParts[1],                        
                        Slug = postParts[2]
                    }
                );
            }

            return View(posts);
        }

        public IActionResult Iletisim()
        {
            return View();
        }

        public IActionResult Hakkimda()
        {
            return View();
        }

        public IActionResult Detay(string id)
        {
            using StreamReader reader = new StreamReader($"AppData/posts/{id}.txt");
            var postContent = reader.ReadToEnd();

            var postDetail = new Post();
            postDetail.Title = "Post Detay";
            postDetail.Content = postContent;

            return View(postDetail);
        }
    }
}
