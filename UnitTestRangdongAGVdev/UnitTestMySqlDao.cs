using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using rangdong_agv;

namespace UnitTestRangdongAGVdev
{
    [TestClass]
    public class MySqlDAOTest
    {
        //[TestMethod]
        //public void MySqlDaoGetAllAgvInfo()
        //{
        //    Trace.WriteLine("Get all agv information!");
        //    MySqlDAO mySqlDAO = new MySqlDAO();

        //    List<AgvInfo> agvList = new List<AgvInfo>();
        //    agvList = mySqlDAO.GetAllAgvInfo();
        //    if (agvList.Count > 0)
        //    {
        //        foreach (AgvInfo agvInfo in agvList)
        //        {
        //            string strAgvInfo = "ID: " + agvInfo.ID + " | Agv id: " + agvInfo.AgvID + " | Zone id: " + agvInfo.ZoneId + " | Parking lot: " + agvInfo.ParkingLot;
        //            Trace.WriteLine(strAgvInfo);
        //        }

        //    }
        //    else
        //    {
        //        Trace.WriteLine("No data in agv info");
        //    }
        //}

        [TestMethod]
        public void MySqlDaoGetNeighborTagCommandByTagId()
        {
            Trace.WriteLine("Get getNeighborTagCommandByTagId!");
            MySqlDAO mySqlDAO = new MySqlDAO();

            List<TagCommand> tagCommands = new List<TagCommand>();
            tagCommands = mySqlDAO.getNeighborTagCommandByTagId(12);
            if (tagCommands.Count > 0)
            {
                foreach (TagCommand tagCmd in tagCommands)
                {
                    string strResults = "tag_id: " + tagCmd.TagId.ToString() + " | neighbor: " + tagCmd.TagNeighbor.ToString() + " | command: " + tagCmd.TagCmd.ToString();
                    Trace.WriteLine(strResults);
                }

            }
            else
            {
                Trace.WriteLine("No data on neighor found");
            }
        }

        [TestMethod]
        public void MySqlDaoGetTagNeighborCommandByNeighborId()
        {
            Trace.WriteLine("Get GetTagNeighborCommandByNeighborId!");
            MySqlDAO mySqlDAO = new MySqlDAO();

            List<TagCommand> tagCommands = new List<TagCommand>();
            tagCommands = mySqlDAO.getTagNeighborCommandByNeighborId(246);
            if (tagCommands.Count > 0)
            {
                foreach (TagCommand tagCmd in tagCommands)
                {
                    string strResults = "tag_id: " + tagCmd.TagId.ToString() + " | neighbor: " + tagCmd.TagNeighbor.ToString() + " | command: " + tagCmd.TagCmd.ToString();
                    Trace.WriteLine(strResults);
                }

            }
            else
            {
                Trace.WriteLine("No data on neighor found");
            }
        }
    }
}