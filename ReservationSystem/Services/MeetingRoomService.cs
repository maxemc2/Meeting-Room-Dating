using Meeting_room_dating.Models;
using Meeting_room_dating.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Meeting_room_dating.Services
{
    public class MeetingRoomService
    {
        ReservationDatabaseEntities _db = new ReservationDatabaseEntities();

        /// <summary>
        /// 查詢會議室清單
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<MeetingRoom> SearchObjList(MeetingRoomViewModel model)
        {
            try
            {
                //主表單
                var mainObj = from o in _db.MeetingRoom
                              select o;

                #region 查詢條件

                if (!string.IsNullOrEmpty(model.Name))
                {
                    mainObj = mainObj.Where(o => o.Name == model.Name);
                }
                if (!string.IsNullOrEmpty(model.Position))
                {
                    mainObj = mainObj.Where(o => o.Position == model.Position);
                }
                if (model.LoadNumber >= 1)
                {
                    mainObj = mainObj.Where(o => o.LoadNumber >= model.LoadNumber);
                }
                if (!string.IsNullOrEmpty(model.Status))
                {
                    mainObj = mainObj.Where(o => o.Status == model.Status);
                }

                #endregion

                //查詢主表需顯示資料
                var obj = mainObj.ToList();
                return obj;
            }
            catch (Exception ex)
            {
                return new List<MeetingRoom>();
            }
        }

        /// <summary>
        /// 取得單一會議室內容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MeetingRoom SearchObj(MeetingRoomViewModel model)
        {
            try
            {
                var obj = (from o in _db.MeetingRoom
                           where o.Name == model.Name
                           select o).FirstOrDefault();

                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 新增或修改會議室
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddOrUpdateObj(MeetingRoom model)
        {
            try
            {
                model.UpdateTime = DateTime.Now;
                _db.MeetingRoom.AddOrUpdate(model);
                _db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 刪除會議室
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteObj(MeetingRoomViewModel model)
        {
            try
            {
                if (CheckObjStatus(model))
                {
                    _db.MeetingRoom.RemoveRange(_db.MeetingRoom.Where(o => o.Name == model.Name));
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
        public bool CheckObjStatus(MeetingRoomViewModel model)
        {
            try
            {
                //判斷是否有資料
                if (!_db.MeetingRoom.Any(o => o.Name == model.Name))
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