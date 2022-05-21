using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rangdong_agv;

namespace UnitTestRangdongAGVdev
{
    [TestClass]
    public class LoraGenericPacketTest
    {
        [TestMethod]
        public void LoraGenericPacketOutputPacket()
        {
            Trace.WriteLine("Testing lora packet!");
            LoraGenericPacket loraGenericPacket = new LoraGenericPacket();
            //loraGenericPacket.getOutputPacket();            
            // Console.WriteLine("Testing!");            
            string message = System.Text.Encoding.Default.GetString(loraGenericPacket.OutputPacket, 0, loraGenericPacket.OutputPacket.Length);
            // message = BitConverter.ToString(outputPacket, 0, outputPacket.Length).Replace("-", string.Empty);
            message = BitConverter.ToString(loraGenericPacket.OutputPacket, 0, loraGenericPacket.OutputPacket.Length).Replace("-", " ");
            // Console.WriteLine(message);
            Trace.WriteLine(message);
        }
    }

    [TestClass]
    public class RoutePacketTest
    {
        [TestMethod]
        public void RouterPacketSetPayloadAndReceiverTest()
        {
            Trace.WriteLine("Test set new payload and receiver");
            RoutePacket routePacket = new RoutePacket();
            byte[] payload_temp = new byte[] {0x03, 0x01, 0x02};
            routePacket.setTripRouteAndReceiver(0x05,payload_temp);
            // string message = System.Text.Encoding.Default.GetString(routePacket.OutputPacket, 0, routePacket.OutputPacket.Length);
            string message = BitConverter.ToString(routePacket.OutputPacket, 0, routePacket.OutputPacket.Length).Replace("-", " ");
            Trace.WriteLine(message);
        }
    }

    [TestClass]
    public class AgvCallPacketTest
    {
        [TestMethod]
        public void AgvCallPacketSetPayloadAndReceiverTest()
        {
            Trace.WriteLine("Test AGV Call");
            AgvCallPacket callPacket = new AgvCallPacket();
            callPacket.setReceiver(0xA5);
            //callPacket.setPayloadAndReceiver(0xA5);
            // string message = System.Text.Encoding.Default.GetString(routePacket.OutputPacket, 0, routePacket.OutputPacket.Length);
            string message = BitConverter.ToString(callPacket.OutputPacket, 0, callPacket.OutputPacket.Length).Replace("-", " ");
            Trace.WriteLine(message);
        }
    }

    [TestClass]
    public class AgvMaterialPacketTest
    {
        [TestMethod]
        public void setMaterialAndReceiverTest()
        {
            Trace.WriteLine("Test AGV 1 material");
            AgvMaterialPacket materialPacket = new AgvMaterialPacket();
            byte[] material_code = new byte[] { 0x02, 0xB1, 0xB3 };
            materialPacket.setMaterialAndReceiver(0xA4, 0xC6, material_code);
            // string message = System.Text.Encoding.Default.GetString(routePacket.OutputPacket, 0, routePacket.OutputPacket.Length);
            string message = BitConverter.ToString(materialPacket.OutputPacket, 0, materialPacket.OutputPacket.Length).Replace("-", " ");
            Trace.WriteLine(message);
        }

        [TestMethod]
        public void setMaterialAndReceiverTest2() // 2 material
        {
            Trace.WriteLine("Test AGV 2 material");
            AgvMaterialPacket materialPacket = new AgvMaterialPacket();
            byte[] material_code1 = new byte[] { 0x02, 0xB1, 0xB3 };
            byte[] material_code2 = new byte[] { 0xF2, 0xB4, 0xC6, 0x69 };
            materialPacket.setMaterialAndReceiver(0xA4, 0xC2, material_code1, 0xC3, material_code2);
            // string message = System.Text.Encoding.Default.GetString(routePacket.OutputPacket, 0, routePacket.OutputPacket.Length);
            string message = BitConverter.ToString(materialPacket.OutputPacket, 0, materialPacket.OutputPacket.Length).Replace("-", " ");
            Trace.WriteLine(message);
        }
    }

    [TestClass]
    public class TagCommandTest
    {
        [TestMethod]
        public void setTagCommandTest()
        {
            Trace.WriteLine("Test set tag command");
            TagCommand tagCommand = new TagCommand();
            tagCommand.setTagCommand("Slow");
            Trace.WriteLine(tagCommand.TagCmd);
        }
    }
}