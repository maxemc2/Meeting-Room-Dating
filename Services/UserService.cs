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
        /// 查詢使用者清單
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<User> SearchObjList(UserViewModel model)
        {
            try
            {
                //主表單
                var mainObj = from o in _db.User
                              select o;

                #region 查詢條件

                if (!string.IsNullOrEmpty(model.UserName))
                {
                    mainObj = mainObj.Where(o => o.UserName == model.UserName);
                }
                if (!string.IsNullOrEmpty(model.Identity))
                {
                    mainObj = mainObj.Where(o => o.Identity == model.Identity);
                }
                if (!string.IsNullOrEmpty(model.Authority))
                {
                    mainObj = mainObj.Where(o => o.Authority == model.Authority);
                }

                #endregion

                //查詢主表需顯示資料
                var obj = mainObj.ToList();
                return obj;
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }

        /// <summary>
        /// 取得單一使用者內容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public User SearchObj(UserViewModel model)
        {
            try
            {
                var obj = (from o in _db.User
                           where o.UserID == model.UserID
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
        public bool AddOrUpdateObj(User model)
        {
            try
            {
                model.UpdateTime = DateTime.Now;
                if(model.Authority == null)
                {
                    model.Authority = "Normal";
                }
                _db.User.AddOrUpdate(model);
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
        public bool DeleteObj(UserViewModel model)
        {
            try
            {
                if (CheckObjStatus(model))
                {
                    _db.User.RemoveRange(_db.User.Where(o => o.UserID == model.UserID));
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
        /// 確認帳號是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckObjStatus(UserViewModel model)
        {
            try
            {
                //判斷是否有資料
                if (!_db.User.Any(o => o.UserID == model.UserID))
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

        /// <summary>
        /// 確認帳號密碼一致
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public User LoginCheck(UserViewModel model)
        {
            try
            {
                //判斷是否有資料
                if (!_db.User.Any(o => o.UserID == model.UserID && o.Password == model.Password))
                {
                    //DB沒有資料
                    return new User();
                }

                return _db.User.FirstOrDefault(o => o.UserID == model.UserID && o.Password == model.Password);
            }
            catch (Exception ex)
            {
                return new User();
            }
        }
    }
}