using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting_room_dating.Models
{
    /// <summary>
    /// 使用者資料
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// 使用者ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 身分
        /// </summary>
        public string Identity { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public int Account { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 權限
        /// </summary>
        public string Authority { get; set; }
    }
}