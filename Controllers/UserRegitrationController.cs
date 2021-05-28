using Meeting_room_dating.ViewModels;
using Meeting_room_dating.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Meeting_room_dating.Controllers
{
    public class UserRegitrationController : Controller
    {
        UserService _service = new UserService();

        // GET: UserRegitration
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult InsertObj(User model)
        {
            try
            {
                var isOK = _service.AddOrUpdateObj(model);

                return Json(isOK);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        /// <summary>
        /// 確認使用者是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CheckObjStatus(UserViewModel model)
        {
            try
            {
                var checkStatus = _service.CheckObjStatus(model);

                return Json(checkStatus);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }
    }
}