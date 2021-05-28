using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting_room_dating.ViewModels
{
    public class MeetingRoomViewModel
    {
        /// <summary>
        /// 會議室名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 容納人數
        /// </summary>
        public int LoadNumber { get; set; }
        /// <summary>
        /// 當前狀況
        /// </summary>
        public string Status { get; set; }
    }
}