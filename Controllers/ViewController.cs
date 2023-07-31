using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Postit.Models;
using Postit.PostService;

namespace Postit.Controllers
{
    public class ViewController : Controller
    {
        private readonly ILogger<ViewController> _logger;
        private readonly IPostService _postService;

        public ViewController(ILogger<ViewController> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        // Get home view
        public async Task<IActionResult> Index()
        {
            var post = await _postService.GetPostsAsync();
            if (post == null)
            {
                ViewData["errorMessage"] = $"Error reading posts from the DB!";
                return View();
            }
            return View(post);
        }

        // Get the Create View
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title", "Message")] Post newpost)
        {
            try
            {
                await _postService.CreatePostAsync(newpost);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["errorMessage"] = $"Error saving message to db. Error message. {ex.Message}";
            }
            return View(newpost);
        }

        // GET Edit view
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewData["errorMEssage"] = "Invlaid post id.";
                return View();
            }
            try
            {
                var queridPost = await _postService.GetPostAsync(id);
                return View(queridPost);
            }
            catch (Exception ex)
            {
                ViewData["errorMessage"] = $"Error retriving post with id {id} from db.";
                return View();
            }
        }

        // Post Edit view
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Post updatedPost)
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewData["errorMessage"] = $"Post id invalid!";
                return View();
            }
            try
            {
                await _postService.UpdatePostAsync(id, updatedPost);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["errorMessage"] = $"Error while saving post to DB.";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}