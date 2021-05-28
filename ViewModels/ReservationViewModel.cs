using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting_room_dating.ViewModels
{
    public class ReservationViewModel
    {
        /// <summary>
        /// 預約人ID
        /// </summary>
        public string ReservingPersonID { get; set; }
        /// <summary>
        /// 會議室名稱
        /// </summary>
        public string RoomName { get; set; }
        /// <summary>
        /// 開始時間
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}