using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting_room_dating.Models
{
    /// <summary>
    /// 會議室資料
    /// </summary>
    public class MeetingRoomModel
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
        /// <summary>
        /// 會議室資訊
        /// </summary>
        public string Information { get; set; }
        /// <summary>
        /// 設備
        /// </summary>
        public string Equipment { get; set; }
    }
}