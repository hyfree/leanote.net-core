
using leanoteLibrary.Model.Auth.login;
using Microsoft.AspNetCore.Mvc;

namespace leanote.API
{
    [Route("api/[controller]/[action]")]
   
    public class AuthController : Controller
    {

        [HttpPost]
        public JsonResult Login(string email, string pwd)
        {
           
            AuthLoginSuccess als=new AuthLoginSuccess(true, "token123", "user123", "123@qq.com", "hyfree");
            //JsonConvert.SerializeObject(als)
            return Json(als);
        }
        public IActionResult Logout()
        {
            return null;
        }
        public IActionResult Register()
        {
            return null;
        }

    }
}