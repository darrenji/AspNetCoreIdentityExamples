using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreIdentityExamples.Controllers
{
    public class ClaimsController : Controller
    {
       

        // GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {
            //User哪里来？
            //这里的User属性是ControlerBase中的User属性
            //User还可以从HttpContext.User中获得

            //Claim哪里来？
            //User?Claims,即一个用户有多个Claim

            //Claim是什么？
            //Claim.Issuer
            //Claim.Subject是ClaimsIdentity类型

            //ClaimsIdentity是什么？
            //实现IIdentity接口
            //IIdentity.AuthenticationType
            //IIdentity.Claims的类型是IEnumerable<Claim>,所有IIdentity与Claim是1对多关系，一个IIdentity有多个Claim
            //IIdentity.Name
            //HttpContext.User.Identity的类型也是IIdentity


            //ClaimsPrincipal是什么？
            //实现IPrincipal接口
            //属性IEnumerable<Claim> Claims { get; }
            //属性IEnumerable<ClaimsIdentity> Identities { get; }
            //属性IIdentity Identity { get; }


            return View(User?.Claims);
        }
    }
}
