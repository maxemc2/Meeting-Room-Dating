using Meeting_room_dating.Models;
using Meeting_room_dating.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Meeting_room_dating.Services
{
    public class UserService
    {
        ReservationDatabaseEntities _db = new ReservationDatabaseEntities();

        /// <summary>
        /// 查詢使用者整體清單
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Reservation> SearchObjList(RoomSearchingViewModel model)
        {
            try
            {
                //主表單
                var mainObj = from o in _db.Reservations
                              select o;

                #region 查詢條件

                if (!string.IsNullOrEmpty(model.ReservingPersonID))
                {
                    mainObj = mainObj.Where(o => o.ReservingPersonID == model.ReservingPersonID);
                }
                if (!string.IsNullOrEmpty(model.RoomName))
                {
                    mainObj = mainObj.Where(o => o.RoomName == model.RoomName);
                }
                if (model.RservationTime != null && model.RservationTime != new DateTime())
                {
                    mainObj = mainObj.Where(o => o.StartTime.Date == model.RservationTime.Date);
                }

                #endregion

                //查詢主表需顯示資料
                var obj = mainObj.ToList();
                return obj;
            }
            catch (Exception ex)
            {
                return new List<Reservation>();
            }
        }

        /// <summary>
        /// 取得單一使用者內容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Reservation SearchObj(RoomSearchingViewModel model)
        {
            try
            {
                var obj = (from o in _db.Reservations
                           where o.ReservingPersonID == model.ReservingPersonID && o.RoomName == model.RoomName && o.StartTime == model.RservationTime
                           select o).FirstOrDefault();

                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 新增或修改使用者
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddOrUpdateObj(Reservation model)
        {
            try
            {
                _db.Reservations.AddOrUpdate(model);
                _db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteDetailObj(RoomSearchingViewModel model)
        {
            try
            {
                if (CheckObjStatus(model))
                {
                    _db.Reservations.RemoveRange(_db.Reservations.Where(o => o.ReservingPersonID == model.ReservingPersonID && o.RoomName == model.RoomName && o.StartTime == model.RservationTime));
                }
                _db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 確認是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckObjStatus(RoomSearchingViewModel model)
        {
            try
            {
                //判斷是否有資料
                if (!_db.Reservations.Any(o => o.ReservingPersonID == model.ReservingPersonID && o.RoomName == model.RoomName && o.StartTime == model.RservationTime))
                {
                    //DB沒有資料
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}