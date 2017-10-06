using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentityExamples.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreIdentityExamples.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;

        public AdminController(UserManager<AppUser> userMgr)
        {
            userManager = userMgr;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(userManager.Users);
        }


        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if(ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email
                    
                };

                //UserManager为我们准备了添加用户的异步方法，但秘密不是放在AppUser中的，而是放在添加方法CreateAsync中的
                //用户添加的结果就是IdentityResult
                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                //根据IdentityResult来判断是否添加用户成功
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }else
                {
                    //如果IdentitResult不成功，就可以获取IdentityError这个类型
                    foreach(IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }else
                {
                    AddErrorsFromResult(result);
                }

            } else
            {
                ModelState.AddModelError("", "User not found");
            }
            return View("Index", userManager.Users);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach(IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
