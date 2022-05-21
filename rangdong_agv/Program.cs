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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rangdong_agv
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new form_login());
            //Application.Run(new FormMain_test());
            Application.Run(new FormMain());
        }
    }
}

