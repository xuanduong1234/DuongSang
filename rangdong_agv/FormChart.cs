using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rangdong_agv
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }
        private float totalActiveHour(int id, int Month)
        {
            MySqlDAO sqlDAO = new MySqlDAO();
            List<AgvActiveInMonth> agvInfos = sqlDAO.getAgvById(id);
            float totalHour = 0;
            for (int i = 0; i < agvInfos.Count; i++)
            {
                int month = agvInfos[i].Time.Month;
                if (month == Month)
                {
                    totalHour += agvInfos[i].TotalActiveHour;
                }
            }
            return totalHour;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            chartHour.ChartAreas["ChartArea1"].AxisX.Title = "Month";
            chartHour.ChartAreas["ChartArea2"].AxisY.Title = "Total Active Hour";
            for (int i = 1; i <= 12; i++ )
            {
                chartHour.Series["AGV 01"].Points.AddXY(i, totalActiveHour(1, i));
                chartHour.Series["AGV 02"].Points.AddXY(i, totalActiveHour(2, i));

            }    

        }

        private void Form2_Load(object sender, EventArgs e)
        {
         
        }
    }


}



