using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentityExamples.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreIdentityExamples.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private ProtectedDocument[] docs = new ProtectedDocument[] {
            new ProtectedDocument {Title="Q3 Budget", Author="sunny", Editor="sunny" },
            new ProtectedDocument {Title="Project Plan", Author="bob", Editor="bob" }
        };

        private IAuthorizationService authService;

        public DocumentController(IAuthorizationService auth)
        {
            authService = auth;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(docs);
        }

        public async Task<IActionResult> Edit(string title)
        {
            ProtectedDocument doc = docs.FirstOrDefault(t => t.Title == title);
            bool authorized = await authService.AuthorizeAsync(User, doc, "AuthorsAndEditors");
            if (authorized)
            {
                return View("Index", doc);
            }
            else
            {
                return new ChallengeResult();
            }
        }
    }
}
