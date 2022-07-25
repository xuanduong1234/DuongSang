using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rangdong_agv
{
    [Serializable]
    public class PlanData
    {
        private List<PlanItem> listJob;

        public List<PlanItem> ListJob
        {
            get { return listJob; }
            set { listJob = value; }
        }


    }
}