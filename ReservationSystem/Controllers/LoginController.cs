using Meeting_room_dating.ViewModels;
using Meeting_room_dating.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Meeting_room_dating.Controllers
{
    public class LoginController : Controller
    {
        UserService _service = new UserService();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 確認使用者是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult LoginCheck(UserViewModel model)
        {
            try
            {
                var UserData = _service.LoginCheck(model);

                return Json(UserData);
            }
            catch (Exception ex)
            {
                return Json(new User());
            }
        }
    }
}