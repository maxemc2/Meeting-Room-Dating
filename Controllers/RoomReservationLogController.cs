using Meeting_room_dating.ViewModels;
using Meeting_room_dating.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Meeting_room_dating.Controllers
{
    public class RoomReservationLogController : Controller
    {
        ReservationService _service = new ReservationService();

        // GET: RoomReservationLog
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 預約主表清單
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult ObjListPartialView(ReservationViewModel model)
        {
            try
            {
                var objList = _service.SearchObjList(model);

                return PartialView(objList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 修改預約畫面
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult UpdateObjPartialView(ReservationViewModel model)
        {
            try
            {
                model.StartTime = model.StartTime.ToUniversalTime();
                model.EndTime = model.EndTime.ToUniversalTime();
                var obj = _service.SearchObj(model);

                return PartialView(obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 更改預約
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult InsertObj(Reservation model)
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
        /// 刪除預約
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteObj(ReservationViewModel model)
        {
            try
            {
                var isOK = _service.DeleteObj(model);

                return Json(isOK);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        /// <summary>
        /// 確認預約是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CheckObjExist(ReservationViewModel model)
        {
            try
            {
                var isExist = _service.CheckObjExist(model);

                return Json(isExist);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }
    }
}