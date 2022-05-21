using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rangdong_agv
{
    public class TagCommand
    {
        private static readonly Dictionary<byte, string> commands = new Dictionary<byte, string>()
        {
            { 0x00, "Unknown" },
            { 0x01, "Slow" },
            { 0x02, "Fast" },
            { 0x03, "Straight" },
            { 0x04, "Left" },
            { 0x05, "Right" },
            { 0x06, "DeliverLeft" },
            { 0x07, "DeliverRight" },
            { 0x08, "CollectLeft" },
            { 0x09, "CollectRight" },
            { 0x0A, "ReturnLeft" },
            { 0x0B, "ReturnRight" },
            { 0x0C, "Parking" },
            { 0x0D, "Reverse" },
            { 0x0E, "Snail" }
        };

        //public enum Commands : byte
        //{
        //    Slow,
        //    Fast,
        //    Straight,
        //    Left,
        //    Right,
        //    Deliver,
        //    Collect,
        //    Return,
        //    Parking
        //}

        public enum Direction
        {
            Forward,
            Backward
        }

        private byte tagId;
        private byte tagCmd;
        private byte tagNeighbor;
        private int tagNeighborInt;
        private int direction;
        private byte[] idCmdPair;

        public TagCommand()
        {
            idCmdPair = new byte[2];
        }

        public byte TagId { get => tagId; set { tagId = (byte)value;  } }
        public byte TagCmd { get => tagCmd; set { tagCmd = (byte)value; } }

        public byte TagNeighbor { get => tagNeighbor; set => tagNeighbor = value; }
        public int TagNeighborInt { get => tagNeighborInt; set => tagNeighborInt = value; }

        public void setTagCommand (string strCommand)
        {
            //Trace.WriteLine(commands.TryGetValue(tagCommand, out strCommand));
            var myCommandCode = commands.FirstOrDefault(x => x.Value == strCommand).Key;
            tagCmd = (byte)myCommandCode;
        }

        public byte[] getIdCmdPair()
        {
            idCmdPair[0] = tagId;
            idCmdPair[1] = tagCmd;

            return idCmdPair;
        }
    }

    public class DeliveryTrip
    {
        private byte agvParkingTag;
        private byte feedingStationTag;
        private byte deliveryStationTag1;
        private byte deliveryStationTag2;
        //private int tripId;
        private MySqlDAO mySqlDAO;

        public DeliveryTrip()
        {
            mySqlDAO = new MySqlDAO();
        }

        public DeliveryTrip(MySqlDAO _mySqlDAO)
        {
            mySqlDAO = _mySqlDAO;
        }

        private bool isStationTag()
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startId"></param>
        /// <param name="destId"></param>
        /// <param name="direction">indicate which direction of the agv: true -> going forward; false -> going backward</param>
        /// <returns>List of a pair {tag,command} to represent the trip route</returns>
        public List<TagCommand> findRoute(byte startId, byte destId, bool direction)
        {
            List<TagCommand> tagCommandList = new List<TagCommand>();

            // getNeighborIds(byte tagId)
            // if one neigbor add to tagCommandList
            // else if two neighbor choose 1 and add to tagCommandList
            // if no neighber -> end of route no destination go back

            return tagCommandList;
        }

        public List<TagCommand> getRouteTrip(byte agvParkingTag, byte feedingStationTag, byte deliveryStationTag)
        {
            List<TagCommand> tagCommandList = new List<TagCommand>();

            return tagCommandList;
        }

        public List<TagCommand> getRouteTrip(byte agvParkingTag, byte feedingStationTag, byte deliveryStationTag1, byte deliveryStationTag2)
        {
            List<TagCommand> tagCommandList = new List<TagCommand>();

            return tagCommandList;
        }

        public List<TagCommand> getRouteTrip(byte agvParkingTag, byte feedingStationTag1, byte feedingStationTag2, byte deliveryStationTag1, byte deliveryStationTag2)
        {
            List<TagCommand> tagCommandList = new List<TagCommand>();


            return tagCommandList;
        }
    }
}
