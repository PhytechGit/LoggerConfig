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
 * 30/06/2019   after official:
 *              1. BurnEZR: return ExitCode of process, do not look for "ERROR" word.             
 *              2. BurnAtmel: set error code if failed eeprom burning, not opposite.
 * 04/07/2019   enlarge time of waiting the logger to connect server from 120 sec to 150.
 *              1.0.0.1
 * 18/08/2019   for viaero: add another SIM type works with GE modem. this SIM can not connect from Israel. so add to APNTypes another
 *              parameter for each APN - whether can connect or no. and whole process of connection starts only for those who can.
 *              1.0.0.2
 * 18/09/2019   1. change the atmel burner tool name to atmelice
 *              2. add chiperase command at the begunung of atmel burning, delete the erase during bootloader burn.
 *              1.0.0.3
 * 24/09/2019   print on sticker the modem type.
 *              1.0.0.4
  */
