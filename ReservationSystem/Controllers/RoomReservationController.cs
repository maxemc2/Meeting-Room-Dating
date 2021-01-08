using Meeting_room_dating.ViewModels;
using Meeting_room_dating.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Meeting_room_dating.Controllers
{
    public class RoomReservationController : Controller
    {
        ReservationService _service = new ReservationService();

        // GET: RoomReservation
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增預約
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
        /// 確認預約是否衝突到其他預約
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CheckObjStatus(ReservationViewModel model)
        {
            try
            {
                var checkStatus = _service.CheckObjConflict(model);

                return Json(checkStatus);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }
    }
}