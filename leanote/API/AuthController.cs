using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using leanote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace leanote.API
{
    [Route("api/[controller]/[action]")]
   
    public class AuthController : Controller
    {

        [HttpPost]
        public JsonResult Login(string email, string pwd)
        {
           
            AuthLoginSuccess als=new AuthLoginSuccess(true, "5cee995cab64416715003707", "5b8217f5ab64414f2f0005a3", "1757696115@qq.com", "hyfree");
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