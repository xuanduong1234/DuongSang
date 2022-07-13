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
    public partial class UserControl1 : UserControl
    {
        
        public UserControl1()
        {
            InitializeComponent();
        }
        public void AddStation(Station s)
        {
            groupBoxStation1.Text = "Trạm nhận " + s.id.ToString();
            labelStn1Line.Text = "Line: " + s.line.ToString();
            labelStnId1.Text = "ID: " + s.id.ToString();
            labelStnMaterialCode1.Text = "Mã vật tư: " + s.material_code;
            labelStnMaterialQuantity1.Text = "Số lượng: " + s.quantity.ToString();
            
        }
    }
}
