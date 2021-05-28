using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting_room_dating.ViewModels
{
    public class UserViewModel
    {
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 使用者密碼
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 身分
        /// </summary>
        public string Identity { get; set; }
        /// <summary>
        /// 權限
        /// </summary>
        public string Authority { get; set; }        
    }
}