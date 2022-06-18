using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySqlConnector;

namespace rangdong_agv
{
    public partial class FormError : Form
    {
        public FormError()
        {
            InitializeComponent();

            FormError_Load();
        }
        MySqlConnection conn = null;
        string strConn = "Server = localhost; Database = agv_update; UId = root; Pwd = 17061999; Pooling= false; Character Set=utf8";

        private void FormError_Load()
        {
            if (conn == null)
                conn = new MySqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM danhmucloi ";
            command.Connection = conn;
            listBoxDanhMucLoi.Items.Clear();
            MySqlDataReader raeder = command.ExecuteReader();
            while (raeder.Read())
            {
                string line = raeder.GetInt32(0) + "-" + raeder.GetString(1);
                listBoxDanhMucLoi.Items.Add(line);
            }
            raeder.Close();
        }

        private void listBoxDanhMucLoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDanhMucLoi.SelectedIndex == -1)
                return;
            string line = listBoxDanhMucLoi.SelectedItem.ToString();
            string[] arr = line.Split('-');
            int madm = int.Parse(arr[0]);

            if (conn == null)
                conn = new MySqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM tenloi WHERE MaDanhMucLoi = @madm ";
            command.Connection = conn;

            MySqlParameter parMaDanhMuc = new MySqlParameter("@madm", MySqlDbType.Int32);
            parMaDanhMuc.Value = madm;
            command.Parameters.Add(parMaDanhMuc);

            lvTenLoi.Items.Clear();
            MySqlDataReader raeder = command.ExecuteReader();
            while (raeder.Read())
            {
                int ma = raeder.GetInt32(0);
                DateTime time = raeder.GetDateTime(2);
                string tenLoi = raeder.GetString(1);
                ListViewItem lvi = new ListViewItem(ma + "");
                lvi.SubItems.Add(time + "");
                lvi.SubItems.Add(tenLoi);

                lvTenLoi.Items.Add(lvi);
            }
            raeder.Close();


        }
    }
}
