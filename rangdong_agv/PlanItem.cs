using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace rangdong_agv
{
     public class PlanItem
    {
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private string job;

        public string Job
        {
            get { return job; }
            set { job = value; }
        }
        private Point fromTime;

        public Point FromTime
        {
            get { return fromTime; }
            set { fromTime = value; }
        }
        private Point toTime;

        public Point ToTime
        {
            get { return toTime; }
            set { toTime = value; }
        }
        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }


     


        public static List<string> list = new List<string>(){"Done","Doing","Coming","Missed"};


        
    }
    public enum ePlanItem
    {
        Done,
        Doing,
        Coming,
        Missed
    }

}
