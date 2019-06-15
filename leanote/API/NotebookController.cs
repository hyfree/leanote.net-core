using leanoteLibrary.Type;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace leanote.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotebookController : Controller
    {
        [HttpPost]
        public JsonResult GetNotebooks(string email, string pwd)
        {

            List<Notebook> list=new List<Notebook>();
            return Json(list);
        }

    }
}