using leanoteLibrary.Model.User.getSyncState;
using Microsoft.AspNetCore.Mvc;

namespace leanote.API
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        public IActionResult Info(string token, string userId)
        {

            return Content("");
        }
        public IActionResult UpdateUsername()
        {
            return null;
        } 
        public IActionResult UpdateLogo()
        {
            return null;
        }
        //获取最新同步状态
        public JsonResult GetSyncState()
        {
            UserGetSyncStateSuccess userGetSync=UserGetSyncStateSuccess.CreatTest();
       
            return Json(userGetSync);
        }

    }
}