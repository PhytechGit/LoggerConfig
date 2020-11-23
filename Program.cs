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
        static void Main(string[] args)
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
 * 27/10/2019   EzrPort_DataReceived - while parsing data received - remove DataReceived event.
 * 29/10/2019   add option to select the atmel burn unit type. ICE or MK2.
 *              1.0.0.5
 * 06/11/2019   print to daily file every new logger ID + ICCID
 *              1.0.0.6
 * 14/11/2019   1. add try+catch to the saving in file (version 1.0.0.6)
 *              2. set default value to var of atmel burner type m_sBurnType - "atmelice"
 *              1.0.0.7
 * 19/11/2019   remove the printing of second stickers. only 1 pair of stickers.
 *              1.0.0.7
 * 28/11/2019   after burn atmel - make reset (only for ICE burner). need to be checked
 *          1.0.0.8
 * 15/12/2019   If app got argument "STAGE" - should take apps versions from staging server, instead of production.
 *              1.0.0.9
 * 22/04/2020   GenerateID: try max 3 time to get ID from server. if failedafter 3 times - quit.
 *              1.0.0.10 
 * 26/10/2020   for valve gateway:
 *              add menu item - Config valve gateway - whenever it checked the config type changed and the program
 *              reload the Versions and files fit to this type (valvesGateWayToolStripMenuItem_CheckedChanged). 
 * 22/11/2020   for gateway - after configure properties - ask logger to operate pump in order to test it.
 *              if got result ok - continue to rf test and all other...
 *              1.0.1.0 
 *              
  */
