using Meeting_room_dating.Models;
using Meeting_room_dating.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Meeting_room_dating.Services
{
    public class ReservationService
    {
        ReservationDatabaseEntities _db = new ReservationDatabaseEntities();

        /// <summary>
        /// 查詢預約整體清單
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Reservation> SearchObjList(ReservationViewModel model)
        {
            try
            {
                //主表單
                var mainObj = from o in _db.Reservation
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
                if (!string.IsNullOrEmpty(model.StartTime.ToString()))
                {
                    mainObj = mainObj.Where(o => DbFunctions.DiffDays(o.StartTime, model.StartTime) == 0);
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
        /// 取得單一預約內容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Reservation SearchObj(ReservationViewModel model)
        {
            try
            {
                var obj = (from o in _db.Reservation
                           where o.RoomName == model.RoomName && o.StartTime == model.StartTime && o.EndTime == model.EndTime
                           select o).FirstOrDefault();

                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 新增或修改預約
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddOrUpdateObj(Reservation model)
        {
            try
            {
                model.SubmitTime = DateTime.Now;
                _db.Reservation.AddOrUpdate(model);
                _db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 刪除預約
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteObj(ReservationViewModel model)
        {
            try
            {
                _db.Reservation.Remove(_db.Reservation.First(o => o.RoomName == model.RoomName && o.StartTime == model.StartTime && o.EndTime == model.EndTime));
                
                _db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 確認預約存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckObjExist(ReservationViewModel model)
        {
            try
            {
                var obj = SearchObj(model);

                if(obj != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 確認預約是否衝突
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckObjConflict(ReservationViewModel model)
        {
            try
            {
                var mainObj = from o in _db.Reservation
                              select o;

                #region 查詢條件

                if (!string.IsNullOrEmpty(model.RoomName))
                {
                    mainObj = mainObj.Where(o => o.RoomName == model.RoomName);
                }

                #endregion
                //判斷是否有資料
                if (!_db.Reservation.Any(o => o.StartTime <= model.StartTime && o.EndTime >= model.EndTime))
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