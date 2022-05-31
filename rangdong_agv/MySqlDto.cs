using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rangdong_agv
{
    public class AgvInfo
    {
        private String id; // unique ID include zoneId and agvid
        private int agvId;
        private int zoneId;
        private int parkingLot;
        public int timestamp { get; set; }

        public int timeComplete { get; set; }

        public String ID  {  get => id; set { } }

        public void SetFullId()
        {
            id = zoneId.ToString() + agvId.ToString();
        }

        public int AgvID { get => agvId; set { agvId = value;} }

        public int ZoneId { get => zoneId; set { zoneId = value;} }

        public int ParkingLot { get => parkingLot; set { parkingLot = value; } }
    }
    public class AgvActiveInMonth
    {
       public int id;
       public int agv_id;
        public float totalActiveHour;
        public DateTime time;

        public int Id { get => id; set => id = value; }
        public int Agv_id { get => agv_id; set => agv_id = value; }
        public float TotalActiveHour { get => totalActiveHour; set => totalActiveHour = value; }
        public DateTime Time { get => time; set => time = value; }
        public AgvActiveInMonth(int id, int agv_id, int totalActiveHour, DateTime time)
        {
            this.id = id;
            this.Agv_id = agv_id ;
            this.TotalActiveHour = totalActiveHour;
            this.Time = time;
        }
        public AgvActiveInMonth()
        {
            
        }
    }

    public class AgvParams
    {
        private string strFullAgvId; // fullID
        private string strAgvId; 
        private int zoneId; 
        private int agvId;
        private long timestamp;
        private int state;
        private string strState;  // to interprete the state in to readable text
        private int position_tag_id; // tag ID
        private string strPosition; // to interprete the tag id in to readable text for current agv position
        private int speed; // m/s
        private int battCap; // battery capacity in %
        private int vbatt;
        private string shelf1; // material on shelf 1, "0" if no load, "1" if empty tray
        private string shelf2; // material on shelf 2, "0" if no load, "1" if empty tray

        public string StrAgvId { get => strAgvId; set  => strAgvId = value;} 
        
        public int AgvId { get => agvId; set => agvId = value; }
        public long Timestamp { get => timestamp; set => timestamp = value; }
        public int State { get => state; set => state = value; }
        public int Position { get => position_tag_id; set => position_tag_id = value; }
        public int Speed { get => speed; set => speed = value; }
        public int BattCap { get => battCap; set => battCap = value; }
        public int Vbatt { get => vbatt; set => vbatt = value; }
        public string StrFullAgvId { get => strFullAgvId; set => strFullAgvId = value; }
        public string StrState { get => strState; set => strState = value; }
        public string StrPosition { get => strPosition; set => strPosition = value; }
        public string Shelf1 { get => shelf1; set => shelf1 = value; }
        public string Shelf2 { get => shelf2; set => shelf2 = value; }

        private void updateStrFullAgvId()
        {
            strFullAgvId = zoneId.ToString("000");
            strFullAgvId += agvId.ToString("000");
        }

        public void updateAgvParams(AgvParamPacket agvParamPacket)
        {
            agvId = agvParamPacket.SenderAddr;
            strAgvId = agvId.ToString("000");
            zoneId = agvParamPacket.GroupID;
            updateStrFullAgvId();

            timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();

            state = agvParamPacket.State_agv;
            strState = ""; // to be updated
            
            position_tag_id = agvParamPacket.Postion_agv;
            strPosition = ""; // to be updated

            speed = agvParamPacket.Speed_agv; // m/s
            battCap = agvParamPacket.Batt_percentage_agv;
            vbatt = agvParamPacket.Vbatt_agv;
        }
    }

    public class SystemSummary
    {
        private String agvId;

    }
    public class AgvDailyStatics
    {
        public DateTime date { get; set; }

        public string id { get; set; }

        public float activeHour { get; set; }

        public float inActiveHour { get; set; }

        public double distance { get; set; }

        public int totalLoad { get; set; }

        public int tripQuantity { get; set; }

        public int deliverySuccess { get; set; }

        public int deliveryFails { get; set; }
    }
    public class AgvParamsLatest
    {
      
        public string id { get; set; }

        public string timeStamp { get; set; }

        public string state { get; set; }

        public int speed { get; set; }

        public int vBart{ get; set; }

        public int battCapacity { get; set; }

        public int position { get; set; }

        public string shelf1 { get; set; }

        public string shelf2 { get; set; }

        public int controlMode { get; set; }
    }

}
