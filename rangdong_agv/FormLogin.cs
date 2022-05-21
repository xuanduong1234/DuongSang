/* 
 * Copyright (C) Hanoi University of Science and Technology - All Rights Reserved
 * This file is written as part of Automated Guided Vehicles (AGV) Management System project. 
 * The project is developed and managed by the team in Department of Industrial Automation (DIA), 
 * School of Electrical and Computer Engineering (SEE), 
 * Hanoi University of Science and Technology (HUST).
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Hoang Duc Chinh <dc.hoang.vn@gmail.com>, 2020 November
 */
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (textBox_user.Text == "guest" && textBox_password.Text == "guest")
            {
                // MessageBox.Show("Username and password are correct!");
                FormMain_test formMain = new FormMain_test();
                formMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username and password are incorrect!");
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
