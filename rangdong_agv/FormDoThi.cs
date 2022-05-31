using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using System.Data.SqlClient;
using MySqlConnector;

namespace rangdong_agv
{
    public partial class FormDoThi : Form
    {
        public FormDoThi()
        {
            InitializeComponent();
        }     
        MySqlCommandBuilder command;
        MySqlConnection connection;
        string str = "Server = localhost; Database = agv_update; UId = root; Pwd = 17061999; Pooling= false; Character Set=utf8";
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();
        string query_select = "SELECT * FROM month_active_agv";
        
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
        // Hien thi DataGridView
        public void LoadData()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(str);
            }
            
            if (adapter == null)
            {
                adapter = new MySqlDataAdapter(query_select, connection);
            }
            
            if (command == null)
            {
                command = new MySqlCommandBuilder(adapter);
            }
            
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormDoThi_Load(object sender, EventArgs e)
        {
            LoadData();
            
            connection.Open();

            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar","Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
            });
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "TongThoiGianHoatDong",
                LabelFormatter = value => value.ToString("0")
            });
            cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;
            cartesianChart1.Series.Clear();
            
            SeriesCollection series = new SeriesCollection();

            List<AgvActiveInMonth> items = new List<AgvActiveInMonth>();
            int index = 0;

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                index++;
                if (index < dataGridView1.Rows.Count)
                {
                    items.Add(new AgvActiveInMonth(Convert.ToInt32(dr.Cells[0].Value),
                    Convert.ToInt32(dr.Cells[1].Value), Convert.ToInt32(dr.Cells[2].Value),
                    Convert.ToDateTime(dr.Cells[3].Value)
                    ));
                }
            }

            var AgvID = (from o in items
                         select new { AgvID = o.Agv_id }).Distinct();
            foreach (var agv_id in AgvID)
            {
                List<double> values = new List<double>();
                for (int month = 1; month < 12; month++)
                {
                    double value = 0;
                    var data = from o in items
                               where o.Agv_id.Equals(agv_id.AgvID) && o.time.Month.Equals(month)
                               orderby o.time.Month ascending
                               select new { o.totalActiveHour, o.time.Month };                   
                    data.ToList().ForEach(x => value += x.totalActiveHour);
                    values.Add(value);
                }
                series.Add(new LineSeries() { Title = "AGV" + agv_id.AgvID.ToString(), Values = new ChartValues<double>(values) });
            }
            cartesianChart1.Series = series;

            connection.Close();
        }
    }
}
