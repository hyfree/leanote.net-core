using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leanote.API
{
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        public IActionResult Info(string token, string userId)
        {

            return Content("");
        }
        public IActionResult updateUsername()
        {
            return null;
        } 
        public IActionResult updateLogo()
        {
            return null;
        }
        public IActionResult getSyncState()
        {
            return null;
        }

    }
}