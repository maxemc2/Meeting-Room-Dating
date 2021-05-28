using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting_room_dating.Models
{
    /// <summary>
    /// 預約紀錄
    /// </summary>
    public class ReservationModel
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
        /// <summary>
        /// 預計使用者人數
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 使用目的
        /// </summary>
        public string Goal { get; set; }
        /// <summary>
        /// 借用設備
        /// </summary>
        public string Equipments { get; set; }
    }
}