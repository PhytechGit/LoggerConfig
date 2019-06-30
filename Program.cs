using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoggerConfig
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
            Application.Run(new Form1());
        }
    }
}
/*
 * 30/06/2019   first official version:
 *              1. burn atmel & EZR
 *              2. config parameters (according to modem)
 *              3. test radio
 *              4. test modem (if possible)
 *              5. test reset button
 *              6. set ID and send all information to server
 *              #version: 1.0.0.0
 *              
 */ 
