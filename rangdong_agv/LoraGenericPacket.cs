using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rangdong_agv
{
    public class LoraGenericPacket
    {
        protected static readonly byte MAX_PACKET_LENGTH = 255;

        public static readonly byte START_BYTE = 0x7A;
        public static readonly byte END_BYTE = 0x7F;
        protected static readonly byte CONTROL_CENTRE_PC_ADDRESS = 0xFE;

        public static readonly byte ROUTE_PACKET_TYPE = 0x01;
        public static readonly byte AGV_MATERIAL_PACKET_TYPE = 0x02;
        public static readonly byte AGV_CALL_PACKET_TYPE = 0x05;
        public static readonly int PARAM_PACKET_TYPE = 0x10;
        public static readonly byte REPLY_AGV_CALL_PACKET_TYPE = 0x14;
        public static readonly byte AGV_FEEDING_STATUS_TYPE = 0x15;
        public static readonly byte AGV_DELIVERY_STATUS_TYPE = 0x16;
        public static readonly byte AGV_EMPTY_TRAY_COLLECT_TYPE = 0x17;
        public static readonly byte AGV_EMPTY_TRAY_RETURN_TYPE = 0x18;
        public static readonly byte DELIVERY_STATION_REQUEST_MATERIAL_TYPE = 0x19;

        protected static readonly int startByteOffset = 0;
        protected byte startByte;
        protected byte endByte;

        protected byte frameLength;

        protected static readonly int frameLengthOffset = 1;

        protected byte groupID;
        protected static readonly int groupIDOffset = 2;

        protected byte receiverAddr;
        protected static readonly int receverAddrOffset = 3;

        protected byte senderAddr;
        protected static readonly int senderAddrOffset = 4;

        protected ushort messageCount;
        protected static readonly int messageCountOffset = 5;

        protected byte messageType;
        protected static readonly int messageTypeOffset = 7;

        protected byte[] outputPacket;

        protected byte[] header;

        protected byte[] payload;
        protected static readonly int payloadOffset = 8;

        public byte ReceiverAddress
        {
            get => receiverAddr;
            set
            {
                int temp_value = 0;
                if (0 <= value & value <= 255)
                    temp_value = value;
                else
                    temp_value = 0;
                receiverAddr = value;
                header[receverAddrOffset] = receiverAddr;
            }
        }

        public ushort MessageCount
        {
            get => messageCount;
            set
            {
                int temp_value = 0;
                if (0 <= value & value < 65535)
                    temp_value = value;
                else
                    temp_value = 0;

                messageCount = (ushort)temp_value;
                Buffer.BlockCopy(getMessageCountInByteArray(), 0, header, messageCountOffset, 2);
            }
        }

        public byte getMessageType(byte[] inputPacket)
        {
            byte type = 0;

            if (inputPacket.Length > 0)
            {
                this.parsePacketHeader(inputPacket);
                type = this.messageType;
            }

            return type;
        }


        public byte[] OutputPacket { get => outputPacket; } //set => _outputPacket[]; 
        public byte FrameLength { get => frameLength; set => frameLength = value; }
        public byte GroupID { get => groupID; set => groupID = value; }
        public byte ReceiverAddr { get => receiverAddr; set => receiverAddr = value; }
        public byte SenderAddr { get => senderAddr; set => senderAddr = value; }
        public byte MessageType { get => messageType; set => messageType = value; }
        public byte[] Payload { get => payload; set => payload = value; }

        public LoraGenericPacket()
        {
            startByte = START_BYTE;
            endByte = END_BYTE;
            frameLength = 9;
            groupID = 0x01;
            receiverAddr = 0;
            senderAddr = 0; // 
            messageCount = 0;
            messageType = 0;
            byte[] messageCountByteArray = this.getMessageCountInByteArray();
            header = new byte[8] { startByte, frameLength, groupID, receiverAddr, senderAddr, messageCountByteArray[0], messageCountByteArray[1], messageType };

            payload = new byte[1];
            payload[0] = 1;

            // outputPacket = new byte[MAX_PACKET_LENGTH];
            this.setOutputPacket(); // to be revised
        }

        public LoraGenericPacket(byte[] inputPacket)
        {
            startByte = START_BYTE;
            endByte = END_BYTE;
            frameLength = 9;
            groupID = 0x01;
            receiverAddr = 0;
            senderAddr = 0; // 
            messageCount = 0;
            messageType = 0;
            byte[] messageCountByteArray = this.getMessageCountInByteArray();
            header = new byte[8] { startByte, frameLength, groupID, receiverAddr, senderAddr, messageCountByteArray[0], messageCountByteArray[1], messageType };

            payload = new byte[1];
            payload[0] = 1;

            // outputPacket = new byte[MAX_PACKET_LENGTH];
            this.parsePacketHeader(inputPacket);
            this.setOutputPacket(); // to be revised
        }

        protected byte[] getMessageCountInByteArray()
        {
            byte[] outputByteArray = new byte[2];
            outputByteArray[1] = (byte)(this.messageCount & 0xff);
            outputByteArray[0] = (byte)((this.messageCount >> 8) & 0xff);

            return outputByteArray;
        }

        //public virtual byte[] setOutputPacket()
        protected void setOutputPacket()
        {
            if (this.payload.Length > 0)
            {
                frameLength = (byte)(header.Length + payload.Length + 1);
                outputPacket = new byte[frameLength];
                header[frameLengthOffset] = frameLength;

                Buffer.BlockCopy(header, 0, this.outputPacket, 0, header.Length);
                Buffer.BlockCopy(payload, 0, this.outputPacket, header.Length, payload.Length);
                this.outputPacket[frameLength - 1] = endByte;
            }
        }

        protected void parsePacketHeader(byte[] inputPacket)
        {
            if (inputPacket.Length < 3)
                return;

            if (inputPacket[startByteOffset] != START_BYTE)
                return;

            this.frameLength = inputPacket[frameLengthOffset];

            if (inputPacket.Length < this.frameLength)
                return;

            this.groupID = inputPacket[groupIDOffset];
            this.receiverAddr = inputPacket[receverAddrOffset];
            this.senderAddr = inputPacket[senderAddrOffset];
            byte[] _messageCount = new byte[2];
            Buffer.BlockCopy(inputPacket, messageCountOffset, _messageCount, 0, 2);
            this.messageCount = BitConverter.ToUInt16(_messageCount, 0);
            this.messageType = inputPacket[messageTypeOffset];

            this.payload = new byte[inputPacket[payloadOffset]];
            Buffer.BlockCopy(inputPacket, payloadOffset, this.payload, 0, inputPacket[payloadOffset]);

            int endByteOffset = payloadOffset + inputPacket[payloadOffset];

            if (inputPacket[endByteOffset] == END_BYTE)
            {
                Console.WriteLine("Valid packet!");
                Trace.WriteLine("Valid packet!");
            }
        }

    }

    /**
     * RoutePacket class represent the packet containing guidelines for agv to track the route
     * It is sent by central server to AGV
     */
    public class RoutePacket : LoraGenericPacket
    {
        private byte payload_length;
        private byte trip_id;
        private byte[] trip_route;

        public byte Trip_id { get => trip_id; set => trip_id = value; }

        public RoutePacket()
        {
            senderAddr = CONTROL_CENTRE_PC_ADDRESS;
            messageType = ROUTE_PACKET_TYPE;
            header[senderAddrOffset] = senderAddr;
            header[messageTypeOffset] = messageType;
            payload_length = 1;
        }

        public RoutePacket(byte _payload_length)
        {
            senderAddr = CONTROL_CENTRE_PC_ADDRESS;
            messageType = ROUTE_PACKET_TYPE;
            header[senderAddrOffset] = senderAddr;
            header[messageTypeOffset] = messageType;

            if (_payload_length > 1)
            {
                payload_length = _payload_length;
                trip_route = new byte[payload_length - 1];
            }
        }

        protected void setPayload()
        {
            payload = new byte[payload_length];
            payload[0] = payload_length;
            payload[1] = trip_id;
            Buffer.BlockCopy(trip_route, 0, payload, 2, trip_route.Length);
        }

        //public void setPayload(byte _payload_length, byte[] _payload_data)
        //{
        //    if (_payload_length > 0)
        //    {
        //        payload_length = _payload_length;
        //        payload_data = new byte[payload_length];
        //        Buffer.BlockCopy(_payload_data, 0, payload_data, 0, _payload_data.Length);
        //        setPayload();

        //        setOutputPacket();
        //    }
        //}

        public void setPayload(byte[] _trip_route)
        {
            if (_trip_route.Length > 0)
            {
                payload_length = (byte)(_trip_route.Length + 2);
                // need to calculate trip_id here
                trip_route = new byte[_trip_route.Length];
                Buffer.BlockCopy(_trip_route, 0, trip_route, 0, _trip_route.Length);
                setPayload();

                setOutputPacket();
            }
        }

        public void setTripRouteAndReceiver(byte _receiverAddr, byte _trip_id, byte[] _payload_data)
        {
            if (_payload_data.Length > 0 && _receiverAddr != CONTROL_CENTRE_PC_ADDRESS)
            {
                ReceiverAddress = _receiverAddr;
                payload_length = (byte)(_payload_data.Length + 2);
                trip_id = _trip_id;
                trip_route = new byte[_payload_data.Length];
                Buffer.BlockCopy(_payload_data, 0, trip_route, 0, _payload_data.Length);
                setPayload();

                setOutputPacket();
            }
        }

        public void setTripRouteAndReceiver(byte _receiverAddr, byte[] _routeData)
        {
            if (_routeData.Length > 0 && _receiverAddr != CONTROL_CENTRE_PC_ADDRESS)
            {
                ReceiverAddress = _receiverAddr;
                payload_length = (byte)(_routeData.Length + 1);
                trip_route = new byte[_routeData.Length];
                Buffer.BlockCopy(_routeData, 0, trip_route, 0, _routeData.Length);

                setPayload();
                //String message = BitConverter.ToString(payload, 0, payload.Length).Replace("-", " ");
                //Trace.WriteLine("Payload of Route packet: " + message);
                setOutputPacket();
            }
        }
    }

    /**
     * AgvCallPacket is used to call the AGV
     * Sent by central server to AGV
     */
    public class AgvCallPacket : LoraGenericPacket
    {
        private byte payload_length;
        private byte command; // call the agv to start an operation

        public AgvCallPacket()
        {
            senderAddr = CONTROL_CENTRE_PC_ADDRESS;
            messageType = AGV_CALL_PACKET_TYPE;
            header[senderAddrOffset] = senderAddr;
            header[messageTypeOffset] = messageType;
            payload_length = 2;
            command = 0x01;
        }

        public void setReceiver(byte _receiverAddr)
        {
            ReceiverAddress = _receiverAddr;
            payload = new byte[2];
            payload[0] = payload_length;
            payload[1] = command;

            setOutputPacket();
        }

        public void setReceiverAndCommand(byte _receiverAddr, byte _command)
        {
            ReceiverAddress = _receiverAddr;
            this.command = _command;

            payload = new byte[2];
            payload[0] = payload_length;
            payload[1] = command;

            setOutputPacket();
        }
    }

    /**
     * AgvMaterialPacket is used to asked which material to collect
     */
    public class AgvMaterialPacket : LoraGenericPacket
    {
        private byte payload_length;
        private byte payload_data; // call the agv to start an operation

        public AgvMaterialPacket()
        {
            senderAddr = CONTROL_CENTRE_PC_ADDRESS;
            messageType = AGV_MATERIAL_PACKET_TYPE;
            header[senderAddrOffset] = senderAddr;
            header[messageTypeOffset] = messageType;
        }

        public void setMaterialAndReceiver(byte _receiverAddr, byte _delivery_addr, byte[] _material_code)
        {
            ReceiverAddress = _receiverAddr;
            payload_length = (byte)(3 + _material_code.Length);
            payload = new byte[payload_length];
            payload[0] = payload_length;
            payload[1] = 0x01; // deliver to 1 station 
            payload[2] = _delivery_addr;
            Buffer.BlockCopy(_material_code, 0, payload, 3, _material_code.Length);

            setOutputPacket();
        }

        public void setMaterialAndReceiver(byte _receiverAddr, byte _delivery_addr1, byte[] _material_code1, byte _delivery_addr2, byte[] _material_code2)
        {
            ReceiverAddress = _receiverAddr;
            //payload_length = 3;
            payload_length = (byte)(4 + _material_code1.Length + _material_code2.Length);
            payload = new byte[payload_length];
            payload[0] = payload_length;
            payload[1] = 0x02; // deliver to 2 station
            payload[2] = _delivery_addr1;
            Buffer.BlockCopy(_material_code1, 0, payload, 3, _material_code1.Length);
            payload[3 + _material_code1.Length] = _delivery_addr2;
            Buffer.BlockCopy(_material_code2, 0, payload, 4 + _material_code1.Length, _material_code2.Length);

            setOutputPacket();
        }
    }

    /**
     * AgvParamPacket is sent by AGV to inform central server the current paramters of the AGV
     */
    public class AgvParamPacket : LoraGenericPacket
    {
        private byte payload_length;

        private byte state_agv; // 1 byte 
        private static readonly int state_agv_payload_offset = 1;

        private byte trip_id; // 1 byte 
        private static readonly int trip_id_payload_offset = 2;

        private byte postion_agv; // 1 byte the current tag_id
        private static readonly int postion_agv_payload_offset = 3;

        private ushort speed_agv; // 1 byte in mm/s
        private byte[] speed_agv_byte;
        private static readonly int speed_agv_payload_offset = 4;

        private byte batt_percentage_agv; // 1 byte, in percentage: 0-100%
        private static readonly int batt_percentage_agv_payload_offset = 6;

        private ushort vbatt_agv; // 1 byte, in 10V unit, eg. 244 [10V] =  24.4V
        private byte[] vbatt_agv_byte;
        private static readonly int vbatt_agv_payload_offset = 7;

        public byte State_agv { get => state_agv; set => state_agv = value; }

        public byte Postion_agv { get => postion_agv; set => postion_agv = value; }

        public ushort Speed_agv { get => speed_agv; set => speed_agv = value; }

        public byte Batt_percentage_agv { get => batt_percentage_agv; set => batt_percentage_agv = value; }

        public ushort Vbatt_agv { get => vbatt_agv; set => vbatt_agv = value; }

        public bool isAgvParamPacket(byte[] inputpacket)
        {
            this.parsePacketHeader(inputpacket);

            if (this.messageType != PARAM_PACKET_TYPE)
            {
                return false;
            }

            return true;
        }

        public void parsePacket(byte[] inputpacket)
        {
            if (!this.isAgvParamPacket(inputpacket))
            {
                Console.WriteLine("Not param message!");
                return;
            }

            if (this.payload.Length != this.payload[payload_length])
            {
                Console.WriteLine("Wrong length of param message!");
                return;
            }

            this.state_agv = payload[state_agv_payload_offset];

            this.trip_id = payload[trip_id_payload_offset];

            this.postion_agv = payload[postion_agv_payload_offset];

            this.speed_agv_byte = new byte[2];
            Buffer.BlockCopy(this.payload, speed_agv_payload_offset, speed_agv_byte, 0, 2);

            this.speed_agv = this.convert2ByteToNumber(this.speed_agv_byte);

            this.batt_percentage_agv = payload[batt_percentage_agv_payload_offset];

            this.vbatt_agv_byte = new byte[2];
            Buffer.BlockCopy(this.payload, vbatt_agv_payload_offset, vbatt_agv_byte, 0, 2);

            this.vbatt_agv = this.convert2ByteToNumber(this.vbatt_agv_byte);

        }

        private ushort convert2ByteToNumber(byte[] inputByteArray)
        {
            ushort result = 0;
            if (inputByteArray.Length == 2)
            {
                result = (ushort)(inputByteArray[0] * 16 * 16 + inputByteArray[1]);
            }
            return result;
        }

        public string getPayloadString(byte[] inputpacket)
        {
            string _packetString = "";

            this.parsePacket(inputpacket);

            _packetString += "Sent by AGV: " + this.senderAddr.ToString() + "\r\n";
            _packetString += "Message type: " + this.messageType.ToString() + "\r\n";
            _packetString += "Payload: " + BitConverter.ToString(this.payload, 0, this.payload.Length).Replace("-", " ") + "\r\n";
            //_packetString += "AGV state: " + this.state_agv.ToString() + " | " + payload[state_agv_payload_offset].ToString() + "\n";
            _packetString += "AGV state: " + this.state_agv.ToString() + "\r\n";
            _packetString += "Trip ID: " + this.trip_id.ToString() + "\r\n";
            _packetString += "AGV position: " + this.postion_agv.ToString() + "\r\n";
            _packetString += "AGV speed: " + this.speed_agv.ToString() + "\r\n";
            _packetString += "AGV speed raw: " + BitConverter.ToString(this.speed_agv_byte) + "\r\n";
            _packetString += "Remaining battery: " + this.batt_percentage_agv.ToString() + "\r\n";
            _packetString += "Battery voltage: " + this.vbatt_agv.ToString() + "\r\n";

            if (_packetString.Length == 0)
                _packetString = "Wrong message";

            return _packetString;
        }
    }

    public class ReplyAgvCall : LoraGenericPacket
    {
        private byte payload_length;

        private byte answer_agv;
        private static readonly int answer_agv_offset = 1;

        private byte state_agv;
        private static readonly int state_agv_offset = 2;

        public bool isReplyAgvCall(byte[] inputpacket)
        {
            this.parsePacketHeader(inputpacket);

            if (this.messageType != REPLY_AGV_CALL_PACKET_TYPE)
            {
                return false;
            }

            return true;
        }

        public void parsePacket(byte[] inputpacket)
        {
            if (!this.isReplyAgvCall(inputpacket))
            {
                Console.WriteLine("Not reply message!");
                return;
            }

            if (this.payload.Length != this.payload[payload_length])
            {
                Console.WriteLine("Wrong length of reply message!");
                return;
            }

            this.answer_agv = payload[answer_agv_offset];
            this.state_agv = payload[state_agv_offset];
        }

        public string getPayloadString(byte[] inputpacket)
        {
            string _packetString = "";

            this.parsePacket(inputpacket);

            _packetString += "Sent by AGV: " + this.senderAddr.ToString() + "\r\n";
            _packetString += "Message type: " + this.messageType.ToString() + "\r\n";
            _packetString += "Payload: " + BitConverter.ToString(this.payload, 0, this.payload.Length).Replace("-", " ") + "\r\n";
            _packetString += "AGV state: " + this.state_agv.ToString() + "\r\n";
            _packetString += "Answer AGV: " + this.answer_agv.ToString() + "\r\n";

            if (_packetString.Length == 0)
                _packetString = "Wrong message";

            return _packetString;
        }
    }

    public class AgvFeedingStatus : LoraGenericPacket
    {

        private byte payload_length;

        private byte position_agv;
        private static readonly int position_agv_offset = 1;

        private byte shelf_code1;
        private static readonly int shelf_code1_offset = 2;


        private byte[] material_code1_byte;
        private static readonly int material_code1_offset = 3;

        private byte shelf_code2;
        private static readonly int shelf_code2_offset = 13;


        private byte[] material_code2_byte;
        private static readonly int material_code2_offset = 14;

        public byte Position_agv { get => position_agv; set => position_agv = value; }
        public byte Shelf_code1 { get => shelf_code1; set => shelf_code1 = value; }

        public byte Shelf_code2 { get => shelf_code2; set => shelf_code2 = value; }

        public bool isAgvFeedingStatus(byte[] inputpacket)
        {
            this.parsePacketHeader(inputpacket);

            if (this.messageType != AGV_FEEDING_STATUS_TYPE)
            {
                return false;
            }

            return true;
        }

        public void parsePacket(byte[] inputpacket)
        {
            if (!this.isAgvFeedingStatus(inputpacket))
            {
                Console.WriteLine("Not agv feeding status message!");
                return;
            }


            if (this.payload.Length != this.payload[payload_length])
            {
                Console.WriteLine("Wrong length of agv feeding status message!");
                return;
            }

            this.position_agv = payload[position_agv_offset];

            if (this.payload.Length == 13)
            {
                this.shelf_code1 = payload[shelf_code1_offset];
                this.material_code1_byte = new byte[10];
                Buffer.BlockCopy(this.payload, material_code1_offset, material_code1_byte, 0, 10);
            }

            if (this.payload.Length == 24)
            {
                this.shelf_code1 = payload[shelf_code1_offset];
                this.material_code1_byte = new byte[10];
                Buffer.BlockCopy(this.payload, material_code1_offset, material_code1_byte, 0, 10);

                this.shelf_code2 = payload[shelf_code2_offset];
                this.material_code2_byte = new byte[10];
                Buffer.BlockCopy(this.payload, material_code2_offset, material_code2_byte, 0, 10);
            }
        }

        public string getPayloadString(byte[] inputpacket)
        {
            string _packetString = "";

            this.parsePacket(inputpacket);

            _packetString += "Sent by AGV: " + this.senderAddr.ToString() + "\r\n";
            _packetString += "Message type: " + this.messageType.ToString() + "\r\n";
            _packetString += "Payload: " + BitConverter.ToString(this.payload, 0, this.payload.Length).Replace("-", " ") + "\r\n";
            _packetString += "Position: " + this.position_agv.ToString() + "\r\n";

            if (this.payload.Length == 13)
            {
                _packetString += "Shelf: " + this.shelf_code1.ToString() + "\r\n";
                _packetString += "Material code: " + BitConverter.ToString(this.material_code1_byte, 0, this.material_code1_byte.Length).Replace("-", " ") + "\r\n";
            }

            if (this.payload.Length == 24)
            {
                _packetString += "Shelf: " + this.shelf_code1.ToString() + "\r\n";
                _packetString += "Material code: " + BitConverter.ToString(this.material_code1_byte, 0, this.material_code1_byte.Length).Replace("-", " ") + "\r\n";

                _packetString += "Shelf: " + this.shelf_code2.ToString() + "\r\n";
                _packetString += "Material code: " + BitConverter.ToString(this.material_code2_byte, 0, this.material_code2_byte.Length).Replace("-", " ") + "\r\n";
            }

            if (_packetString.Length == 0)
                _packetString = "Wrong message";

            return _packetString;
        }

    }

    public class AgvDeliveryStatus : LoraGenericPacket
    {
        private byte payload_length;

        private byte position_agv;
        private static readonly int position_agv_offset = 1;

        private byte shelf;
        private static readonly int shelf_offset = 2;

        private byte[] material_code_byte;
        private static readonly int material_code_offset = 3;

        public byte Shelf { get => shelf; set => shelf = value; }

        public byte Position_agv { get => position_agv; set => position_agv = value; }

        public bool isAgvDeliveryStatus(byte[] inputpacket)
        {
            this.parsePacketHeader(inputpacket);

            if (this.messageType != AGV_DELIVERY_STATUS_TYPE)
            {
                return false;
            }

            return true;
        }


        public void parsePacket(byte[] inputpacket)
        {
            if (!this.isAgvDeliveryStatus(inputpacket))
            {
                Console.WriteLine("Not delivery status message!");
                return;
            }


            if (this.payload.Length != this.payload[payload_length])
            {
                Console.WriteLine("Wrong length of delivery status message!");
                return;
            }

            this.position_agv = payload[position_agv_offset];
            this.shelf = payload[shelf_offset];
            this.material_code_byte = new byte[10];
            Buffer.BlockCopy(this.payload, material_code_offset, material_code_byte, 0, 10);
        }

        public string getPayloadString(byte[] inputpacket)
        {
            string _packetString = "";

            this.parsePacket(inputpacket);

            _packetString += "Sent by AGV: " + this.senderAddr.ToString() + "\r\n";
            _packetString += "Message type: " + this.messageType.ToString() + "\r\n";
            _packetString += "Payload: " + BitConverter.ToString(this.payload, 0, this.payload.Length).Replace("-", " ") + "\r\n";
            _packetString += "Position: " + this.position_agv.ToString() + "\r\n";
            _packetString += "Shelf: " + this.shelf.ToString() + "\r\n";
            _packetString += "Material code: " + BitConverter.ToString(this.material_code_byte, 0, this.material_code_byte.Length).Replace("-", " ") + "\r\n";

            if (_packetString.Length == 0)
                _packetString = "Wrong message";

            return _packetString;
        }

    }

    public class AgvEmptyTrayCollect : LoraGenericPacket
    {
        private byte payload_length;

        private byte position_agv;
        private static readonly int position_agv_offset = 1;

        private byte shelf;
        private static readonly int shelf_offset = 2;

        public byte Position_agv { get => position_agv; set => position_agv = value; }
        public byte Shelf { get => shelf; set => shelf = value; }

        public bool isAgvEmptyTrayCollect(byte[] inputpacket)
        {
            this.parsePacketHeader(inputpacket);

            if (this.messageType != AGV_EMPTY_TRAY_COLLECT_TYPE)
            {
                return false;
            }

            return true;
        }


        public void parsePacket(byte[] inputpacket)
        {
            if (!this.isAgvEmptyTrayCollect(inputpacket))
            {
                Console.WriteLine("Not Empty Tray Collect message!");
                return;
            }

            if (this.payload.Length != this.payload[payload_length])
            {
                Console.WriteLine("Wrong length of Empty Tray Collect message!");
                return;
            }

            this.position_agv = payload[position_agv_offset];
            this.shelf = payload[shelf_offset];

        }

        public string getPayloadString(byte[] inputpacket)
        {
            string _packetString = "";

            this.parsePacket(inputpacket);

            _packetString += "Sent by AGV: " + this.senderAddr.ToString() + "\r\n";
            _packetString += "Message type: " + this.messageType.ToString() + "\r\n";
            _packetString += "Payload: " + BitConverter.ToString(this.payload, 0, this.payload.Length).Replace("-", " ") + "\r\n";
            _packetString += "Position: " + this.position_agv.ToString() + "\r\n";
            _packetString += "Shelf: " + this.shelf.ToString() + "\r\n";

            if (_packetString.Length == 0)
                _packetString = "Wrong message";

            return _packetString;
        }
    }

    public class AgvEmptyTrayReturn : LoraGenericPacket
    {
        private byte payload_length;

        private byte position_agv;
        private static readonly int position_agv_offset = 1;

        private byte shelf_code1;
        private static readonly int shelf_code1_offset = 2;

        private byte shelf_code2;
        private static readonly int shelf_code2_offset = 3;

        public byte Position_agv { get => position_agv; set => position_agv = value; }
        public byte Shelf_code1 { get => shelf_code1; set => shelf_code1 = value; }
        public byte Shelf_code2 { get => shelf_code2; set => shelf_code2 = value; }

        public bool isAgvEmptyTrayReturn(byte[] inputpacket)
        {
            this.parsePacketHeader(inputpacket);

            if (this.messageType != AGV_EMPTY_TRAY_RETURN_TYPE)
            {
                return false;
            }

            return true;
        }

        public void parsePacket(byte[] inputpacket)
        {
            if (!this.isAgvEmptyTrayReturn(inputpacket))
            {
                Console.WriteLine("Not Empty Tray Return message!");
                return;
            }

            if (this.payload.Length != this.payload[payload_length])
            {
                Console.WriteLine("Wrong length of Empty Tray Return message!");
                return;
            }

            if (this.payload.Length == 3)
            {
                this.position_agv = payload[position_agv_offset];
                this.shelf_code1 = payload[shelf_code1_offset];
            }

            if (this.payload.Length == 4)
            {
                this.position_agv = payload[position_agv_offset];
                this.shelf_code1 = payload[shelf_code1_offset];
                this.shelf_code2 = payload[shelf_code2_offset];
            }
        }

        public string getPayloadString(byte[] inputpacket)
        {
            string _packetString = "";

            this.parsePacket(inputpacket);

            _packetString += "Sent by AGV: " + this.senderAddr.ToString() + "\r\n";
            _packetString += "Message type: " + this.messageType.ToString() + "\r\n";
            _packetString += "Payload: " + BitConverter.ToString(this.payload, 0, this.payload.Length).Replace("-", " ") + "\r\n";
            _packetString += "Position: " + this.position_agv.ToString() + "\r\n";

            if (this.payload.Length == 3)
            {
                _packetString += "Shelf: " + this.shelf_code1.ToString() + "\r\n";
            }

            if (this.payload.Length == 4)
            {
                _packetString += "Shelf: " + this.shelf_code1.ToString() + "\r\n";
                _packetString += "Shelf: " + this.shelf_code2.ToString() + "\r\n";
            }

            if (_packetString.Length == 0)
                _packetString = "Wrong message";

            return _packetString;
        }
    }

    public class DeliveryStationRequestMaterial : LoraGenericPacket
    {
        private byte payload_length;

        private byte state_agv;
        private static readonly int state_agv_offset = 1;

        public bool isDeliveryStationRequestMaterial(byte[] inputpacket)
        {
            this.parsePacketHeader(inputpacket);

            if (this.messageType != DELIVERY_STATION_REQUEST_MATERIAL_TYPE)
            {
                return false;
            }

            return true;
        }

        public void parsePacket(byte[] inputpacket)
        {
            if (!this.isDeliveryStationRequestMaterial(inputpacket))
            {
                Console.WriteLine("Not reply message!");
                return;
            }

            if (this.payload.Length != this.payload[payload_length])
            {
                Console.WriteLine("Wrong length of reply message!");
                return;
            }
            this.state_agv = payload[state_agv_offset];
        }

        public string getPayloadString(byte[] inputpacket)
        {
            string _packetString = "";

            this.parsePacket(inputpacket);

            _packetString += "Sent by AGV: " + this.senderAddr.ToString() + "\r\n";
            _packetString += "Message type: " + this.messageType.ToString() + "\r\n";
            _packetString += "Payload: " + BitConverter.ToString(this.payload, 0, this.payload.Length).Replace("-", " ") + "\r\n";
            _packetString += "AGV state: " + this.state_agv.ToString() + "\r\n";

            if (_packetString.Length == 0)
                _packetString = "Wrong message";

            return _packetString;
        }
    }
}