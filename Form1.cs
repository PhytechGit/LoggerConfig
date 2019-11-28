using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Net;
using System.Timers;
using System.Collections.Specialized;
using System.Threading;



namespace LoggerConfig
{
    public enum _FileType
    {
        TYPE_ATMEL_BL,
        TYPE_ATMEL_APP,
        TYPE_ATMEL_EEP,
        TYPE_EZR_BL,
        TYPE_EZR_APP,
        TYPE_CNT,
    };

    public struct APN_Types
    {
        public _ModemType m_mdmType;
        public string m_ICCID;
        public string m_APN;
        public int m_canConnect;
    };

    public enum _ModemType
    {
        MODEM_NONE = 0,
        MODEM_GE = 1,
        MODEM_SVL = 2,        
    };

    public enum _AtmelType
    {
        ATMEL_ICE = 0,
        ATMEL_MK2 = 1,
    };

    public enum _ProcessStages
    {
        STAGE_1_BURN_EZR,
        STAGE_2_BURN_ATMEL,
        STAGE_3_BEFORE_CONNECT,
        STAGE_4_FIRST_CONNECT,
        STAGE_5_TEST_RF,
        STAGE_6_SERVER_CONNECT,
        STAGE_TEST_RESET_BTN,
        STAGE_7_SET_ID,
        STAGE_8_END,        
    };

    public enum _TASK
    {
        TASK_DO_SOMETHING,
        TASK_WAIT,
    };

    public partial class Form1 : Form
    {
        string[]    files2Burn;
        bool        m_bStopProcess;
        string      m_sFactory;
        bool        m_testEzr;
        private static System.Timers.Timer m_myTimer;
        byte[]      m_buffer = new byte[1000];
        byte[]      m_byteID = new byte[4] { 0, 0, 0, 0 };
        string      m_sID;
        int         length;
        int         m_buferLen;
        byte        m_Param;
        byte        m_GetOrSet;
        byte[]      m_RomVer = new byte[4] { 0, 0, 0, 0 };
        bool        m_bConnected2Logger;
        bool        m_bDataReceived;
        bool        m_bCnctOK;
        long        m_nAllocID;
        byte[]      beep = new byte[8] { 0x42, 0x45, 0x45, 0x50, 0x42, 0x45, 0x45, 0x50 }; // "BEEPBEEP"
        byte[] CONNECT = new byte[7] { 0x43, 0x4f, 0x4e, 0x4e, 0x45, 0x43, 0x54 }; // "CONNECT"
        List<APN_Types> APNArray;
        string      m_sAtmelVer;
        string      m_sEzrVer;
        string      m_sAPN;
        bool        m_bAPN_OK;
        string      m_sAtmelOfficialVer;
        string      m_sEZROfficialVer;
        string      m_sBtr;
        int         m_nSeconds;
        byte[]      m_iccid = new byte[20];
        string      m_strICCID;
        int         m_nEventCnt;
        bool        m_bSecondConnect;
        bool        m_bReqOK;
        int         m_nError;
        bool        m_bCanConnect;
        _ModemType   m_nModemModel;
        _ProcessStages m_curStage;
        _TASK       m_curTask;
        _AtmelType m_atmelBrnType;
        string m_sBurnType;

        public Form1()
        {
            InitializeComponent();
            m_bConnected2Logger = false;
            m_nModemModel = _ModemType.MODEM_NONE;
            m_atmelBrnType = _AtmelType.ATMEL_ICE;           
        }

        private void LoadPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            if (ports.GetLength(0) > 0)
            {
                for (int i = 0; i < ports.GetLength(0); i++)
                {
                    comboPortAtml.Items.Insert(i, ports[i]);
                    comboPortsEzr.Items.Insert(i, ports[i]);
                }
                comboPortAtml.SelectedIndex = 0;
                comboPortsEzr.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Can't find any PORT to connect with");
            }
        }

        private void LoadFilesName()
        {
            StreamReader sr = File.OpenText("FilesDef.txt");
            //            eFileType = _FileType.TYPE_CNT;
            files2Burn = new string[(int)_FileType.TYPE_CNT];
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] sarr = line.Split(',');
                int i = Convert.ToInt16(sarr[0]);
                files2Burn[i] = sarr[1];
            }
        }

        private void LoadAPN()
        {
            StreamReader sr = File.OpenText("ApnDef.txt");

            APNArray = new List<APN_Types>();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] sarr = line.Split(',');
                APNArray.Add(new APN_Types { m_mdmType = (_ModemType)Convert.ToInt16(sarr[0]), m_ICCID = sarr[1], m_APN = sarr[2], m_canConnect = Convert.ToInt16(sarr[3]) });
            }
        }

        private void LoadFactory()
        {
            // The name of the key must include a valid root.
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\PhytechProduction";
            const string keyName = userRoot + "\\" + subkey;

            m_sFactory = (string)Registry.GetValue(keyName, "FactoryName", "Empty");
        }

        //get SW latest version from staging server
        private void LoadVersions()
        {
            string uriAtmelStagingString = @"http://plantbeat.phytech.com/activeadmin/hardware_versions/latest_version?hardware_type=LOGGER&api_token=FrAnazu5rt67";
            string uriEZRStagingString = @"http://plantbeat.phytech.com/activeadmin/hardware_versions/latest_version?hardware_type=EZR&api_token=FrAnazu5rt67";
            //https://phytoweb-staging.herokuapp.com/activeadmin/sensor_versions/latest_version?user_id=1091&api_token=FrAnazu5rt67";
            //string uriString = @"http://plantbeat.phytech.com/activeadmin/sensor_versions/latest_version?user_id=1091&api_token=FrAnazu5rt67";            
            try
            {
                WebClient client = new WebClient();
                // Optionally specify an encoding for uploading and downloading strings.
                client.Encoding = System.Text.Encoding.UTF8;
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                //if (DbgMode == 1)
                //    s = client.DownloadString(uriStagingString);
                //else
                m_sAtmelOfficialVer = client.DownloadString(/*uriString*/uriAtmelStagingString);//  .UploadValues(uriString, myNameValueCollection);
                m_sEZROfficialVer = client.DownloadString(/*uriString*/uriEZRStagingString);
                AddText(richTextBox1, "Atmel Official" + m_sAtmelOfficialVer);
                AddText(richTextBox1, "EZR Official" + uriEZRStagingString);
                //m_sSWVer = s;
                //      txtOficialVer.Text = m_sSWVer;
            }
            catch (WebException we)
            {
                MessageBox.Show(we.Message);
            }
}

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(807, 228);
            LoadPorts();
            LoadFilesName();
            LoadFactory();
            if (m_sFactory == "")
            {
                MessageBox.Show("Undefined Producer!\r\nClosing Application...");
                this.Close();                
            }
            LoadAPN();
            LoadVersions();
            StageLbl.Text = "";
            m_sBurnType = "atmelice";
        }

        delegate void AddTextCallback(RichTextBox c, string text);

        private void AddText(RichTextBox c, string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            //if (this.textID.InvokeRequired)
            try
            {
                if (c.InvokeRequired)
                {
                    AddTextCallback d = new AddTextCallback(AddText);
                    this.Invoke(d, new object[] { c, text });
                }
                else
                {
                    c.AppendText(text);
                    c.AppendText("\r\n");
                    //c.Text += text;
                    c.SelectionStart = c.Text.Length;
                    c.ScrollToCaret();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);                
            }
        }

        delegate void AddLineCallback(Label c, string text, bool bNewLine);

        private void AddLine(Label c, string text, bool bNewLine)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            //if (this.textID.InvokeRequired)
            try
            {
                if (c.InvokeRequired)
                {
                    AddLineCallback d = new AddLineCallback(AddLine);
                    this.Invoke(d, new object[] { c, text, bNewLine });
                }
                else
                {
                    string s = c.Text;
                    if (bNewLine)//(s != "")
                        s += "\r\n";
                    s += text;
                    c.Text = s;                  
                }
            }
            catch (Exception e)
            {
                AddText(richTextBox1, "AddLine Error:" + e.Message);
            }
        }

        delegate void SetTextCallback(Label c, string text);

        private void SetText(Label c, string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            //if (this.textID.InvokeRequired)
            try
            {
                if (c.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { c, text });
                }
                else
                {
                    c.Text = text;
                }
            }
            catch (Exception e)
            {
                AddText(richTextBox1, "SetText Error:" + e.Message);
            }
        }

        void Wait4Beep()
        {
            while (((m_bConnected2Logger == false) && (m_bCnctOK == false)) && (m_nSeconds > 0)) ;
            AddText(richTextBox1, "finish wait");
            if ((m_bConnected2Logger == false) && (m_bCnctOK == false))
            {                
                m_bStopProcess = true;
                m_nError = 20;
                return;
            }
            if (m_bCnctOK)
            {
                AddText(richTextBox1, "wait logger will disconnect");
                Thread.Sleep(10000);
                //m_curStage = _ProcessStages.STAGE_3_BEFORE_CONNECT;
                //m_bSecondConnect = true;
            }
            //else
            m_curStage++;
            m_curTask = _TASK.TASK_DO_SOMETHING;
        }

        void RunEzrBurning()
        {
            if (BurnEZR() == false)
                m_bStopProcess = true;
            else
            {
                m_curStage++;
                m_curTask = _TASK.TASK_DO_SOMETHING;
            }
        }

        void RunAtmelBurning()
        {
            if (BurnAtmel() != 0)
                m_bStopProcess = true;
            else
            {
                m_curStage++;
                m_curTask = _TASK.TASK_DO_SOMETHING;
            }
        }

        void InitAll()
        {
            progressBar1.Value = 0;
            m_nError = 0;
            m_bSecondConnect = false;
            m_bStopProcess = false;
            m_bAPN_OK = false;
            m_bCnctOK = false;
            m_bConnected2Logger = false;
            m_bCanConnect = true;
            m_sID = "";
            m_sAPN = "";
            StageLbl.Text = "";
            m_curTask = _TASK.TASK_DO_SOMETHING;
            // to do - add init array:
            //m_byteID[0] = 0;
            m_curStage = _ProcessStages.STAGE_1_BURN_EZR;//STAGE_3_BEFORE_CONNECT
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBoxLgr.Clear();
            pictureOK1.Visible = false;
            pictureOK2.Visible = false;
            pictureOK3.Visible = false;
            pictureOK4.Visible = false;
            pictureOK5.Visible = false;
            pictureOK6.Visible = false;
            pictureOK7.Visible = false;
        }

        private void ShowOKIcon(PictureBox pb, bool ok)
        {
            if (ok)
                pb.Image = Properties.Resources.OK_img;
            else
                pb.Image = Properties.Resources.not_OK_img;
            pb.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            try
            {
                InitAll();

                if (!AtmelPort.IsOpen)
                {
                    MessageBox.Show("Atmel PORT is closed!");
                    //AddText(richTextBox1, "Atmel PORT is closed!");
                    return;
                }
                if (!EzrPort.IsOpen)
                {
                    MessageBox.Show("EZR PORT is closed!");
                    //AddText(richTextBox1, "EZR PORT is closed!");
                    return;
                }
                if (dontGenerateNewToolStripMenuItem.Checked)
                {
                    try
                    {
                        int x = Convert.ToInt32(textBoxID.Text);
                        if (x < 500000)
                        {
                            MessageBox.Show("You must insert legal ID");
                            return;
                        }
                    }
                    catch (Exception )
                    {
                        MessageBox.Show("You must insert legal ID");
                        return;
                    }                    
                }
                button1.Enabled = false;

                do
                {
                    this.Invalidate();
                    Application.DoEvents();
                    if (m_curTask == _TASK.TASK_WAIT)
                        continue;

                    if (m_curTask == _TASK.TASK_DO_SOMETHING)
                    {
                        progressBar1.Value++;
                        int x = (progressBar1.Value * 100) / progressBar1.Maximum;
                        SetText(percentageLbl, x.ToString() + "%");
                        switch (m_curStage)
                        {
                            case _ProcessStages.STAGE_1_BURN_EZR:
                                AddLine(StageLbl, "Burnning EZR", false);
                                m_curTask = _TASK.TASK_WAIT;
                                Thread thBrn1 = new Thread(new ThreadStart(RunEzrBurning));
                                thBrn1.Start();
                                break;
                            case _ProcessStages.STAGE_2_BURN_ATMEL:
                                ShowOKIcon(pictureOK1, true);
                                AddLine(StageLbl, "Burnning ATMEL", true);
                                m_curTask = _TASK.TASK_WAIT;
                                Thread thBrn2 = new Thread(new ThreadStart(RunAtmelBurning));
                                thBrn2.Start();
                                break;
                            case _ProcessStages.STAGE_3_BEFORE_CONNECT:
                                ShowOKIcon(pictureOK2, true);
                                m_curTask = _TASK.TASK_WAIT;
                                if (!m_bSecondConnect)
                                    //{
                                    //    MessageBox.Show("Please Press the Reset Button on the logger!");
                                    //    m_bConnected2Logger = false;
                                    //    m_bCnctOK = false;
                                    //    AddText(richTextBox1, "Test the reset button");
                                    //}
                                    //else
                                    AddLine(StageLbl, "Configuring logger properties", true);
                                AtmelPort.DiscardInBuffer();
                                AddRemoveEvent('+');
                                //AtmelPort.DataReceived += new SerialDataReceivedEventHandler(AtmelPort_DataReceived);
                                ClearReadBuf();
                                AddText(richTextBox1, "Wait for logger to connect");
                                m_nSeconds = 60;
                                SetTimer(1000);
                                Thread thWait1 = new Thread(new ThreadStart(Wait4Beep));
                                thWait1.Start();
                                break;
                            case _ProcessStages.STAGE_4_FIRST_CONNECT:
                                m_curTask = _TASK.TASK_WAIT;
                                Thread th2 = new Thread(new ThreadStart(HelloLogger));
                                th2.Start();
                                break;
                            case _ProcessStages.STAGE_5_TEST_RF:
                                ShowOKIcon(pictureOK3, true);
                                AddLine(StageLbl, "Testing RF", true);
                                //AddRemoveEvent('-');

                                m_curTask = _TASK.TASK_WAIT;
                                m_nSeconds = 40;
                                SetTimer(1000);
                                Thread thRF = new Thread(new ThreadStart(TestRf));
                                thRF.Start();
                                break;
                            case _ProcessStages.STAGE_6_SERVER_CONNECT:
                                ShowOKIcon(pictureOK4, true);
                                //AddRemoveEvent('+'); //after close in prev stage
                                if (/*m_nModemModel == _ModemType.MODEM_SVL*/!m_bCanConnect)
                                {
                                    m_curStage = _ProcessStages.STAGE_TEST_RESET_BTN; //.STAGE_3_BEFORE_CONNECT;
                                                                                      //m_bSecondConnect = true;                                
                                    break;
                                }
                                m_curTask = _TASK.TASK_WAIT;
                                AddLine(StageLbl, "Testing cellular connection to server (" + m_nModemModel.ToString() + ")", true);
                                AddText(richTextBox1, "Wait logger to connect server");
                                m_bConnected2Logger = false;
                                // wait max 10 minutes
                                m_nSeconds = 150;
                                SetTimer(1000);
                                Thread thWait2 = new Thread(new ThreadStart(Wait4Beep));
                                thWait2.Start();
                                break;
                            case _ProcessStages.STAGE_TEST_RESET_BTN:
                                if (m_nModemModel == _ModemType.MODEM_GE)
                                {
                                    ShowOKIcon(pictureOK5, true);
                                }
                                AddLine(StageLbl, "Testing Reset Button", true);
                                m_curStage = _ProcessStages.STAGE_3_BEFORE_CONNECT;
                                m_bSecondConnect = true;
                                MessageBox.Show("Please Press the Reset Button on the logger!");
                                m_bConnected2Logger = false;
                                m_bCnctOK = false;
                                AddText(richTextBox1, "Test Reset button");
                                break;
                            case _ProcessStages.STAGE_7_SET_ID:
                                if (/*m_nModemModel == _ModemType.MODEM_SVL*/!m_bCanConnect)
                                    ShowOKIcon(pictureOK5, true);
                                else
                                    ShowOKIcon(pictureOK6, true);
                                AddLine(StageLbl, "Setting ID ", true);
                                m_curTask = _TASK.TASK_WAIT;
                                Thread th4 = new Thread(new ThreadStart(FinalSteps));
                                th4.Start();
                                break;
                            case _ProcessStages.STAGE_8_END:
                                if (/*m_nModemModel == _ModemType.MODEM_SVL*/!m_bCanConnect)
                                    ShowOKIcon(pictureOK6, true);
                                else
                                    ShowOKIcon(pictureOK7, true);
                                bOk = true;
                                m_bStopProcess = true;
                                break;
                        }
                    }

                } while (m_bStopProcess != true);

                if (bOk)
                    MessageBox.Show("Process completed successfully!", "Logger " + m_sID, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                //if (progressBar1.Value < progressBar1.Maximum)
                {
                    progressBar1.Value = 0;
                    progressBar1.Refresh();
                    AddText(richTextBox1, "Process failed");
                    string sErrorText = "";
                    switch (m_curStage)
                    {
                        case _ProcessStages.STAGE_1_BURN_EZR:
                            sErrorText = "Burn EZR failed";
                            ShowOKIcon(pictureOK1, false);
                            break;
                        case _ProcessStages.STAGE_2_BURN_ATMEL:
                            ShowOKIcon(pictureOK2, false);
                            sErrorText = "Burn ATMEL failed";
                            break;
                        case _ProcessStages.STAGE_3_BEFORE_CONNECT:
                        case _ProcessStages.STAGE_TEST_RESET_BTN:                            
                            if ((!m_bSecondConnect) && (m_curStage != _ProcessStages.STAGE_TEST_RESET_BTN))
                            {
                                ShowOKIcon(pictureOK3, false);
                                sErrorText = "Could not get logger parameters (low battery?)";
                                break;
                            }
                            // if failed because test reset
                            if (/*m_nModemModel == _ModemType.MODEM_SVL*/!m_bCanConnect)
                                ShowOKIcon(pictureOK5, false);
                            else
                                ShowOKIcon(pictureOK6, false);
                            sErrorText = "Failed testing the reset button";                            
                            break;
                        case _ProcessStages.STAGE_4_FIRST_CONNECT:
                            if (!m_bSecondConnect)
                            {
                                ShowOKIcon(pictureOK3, false);
                                sErrorText = "Error during configuring logger";
                                break;
                            }
                            if (/*m_nModemModel == _ModemType.MODEM_SVL*/!m_bCanConnect)
                                ShowOKIcon(pictureOK5, false);
                            else
                                ShowOKIcon(pictureOK6, false);
                            sErrorText = "Failed testing the reset button";
                            break;
                        case _ProcessStages.STAGE_5_TEST_RF:
                            ShowOKIcon(pictureOK4, false);
                            sErrorText = "Test RF failed";
                            break;
                        case _ProcessStages.STAGE_6_SERVER_CONNECT:
                            ShowOKIcon(pictureOK5, false);
                            sErrorText = "Failed connecting to server";
                            break;                                                 
                        case _ProcessStages.STAGE_7_SET_ID:
                            if (/*m_nModemModel == _ModemType.MODEM_SVL*/!m_bCanConnect)
                                ShowOKIcon(pictureOK6, false);
                            else
                                ShowOKIcon(pictureOK7, false);
                            sErrorText = "Failed setting the ID";
                            break;
                        default:
                            sErrorText = "Process failed...";
                            break;
                    }
                    MessageBox.Show(sErrorText + " (" + m_nError + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                // after finish:
                AddRemoveEvent('-');
                //AtmelPort.DataReceived -= new SerialDataReceivedEventHandler(AtmelPort_DataReceived);
                //EzrPort.DataReceived -= new SerialDataReceivedEventHandler(EzrPort_DataReceived);
                button1.Enabled = true;
                m_bConnected2Logger = false;
                for (int i = 0; i < 4; i++)
                    m_byteID[i] = 0;
            }
            catch (Exception er)
            {
                AddText(richTextBox1, "Main Loop Error:" + er.Message);
            }
        }

        private int RunProcess(Process p, string arg)
        {
            string line;
            int exitCode = 1;

            p.StartInfo.Arguments = arg;
            p.Start();
            try
            {
                while ((!p.StandardOutput.EndOfStream) || (!p.StandardError.EndOfStream))
                {
                    while ((line = p.StandardOutput.ReadLine()) != null)
                    //line = p.StandardOutput.ReadLine();
                    //if (line != null)
                    {
                        AddText(richTextBox1, line);
                        //AddText(richTextBox1, "\r\n");
                    }
                    line = p.StandardError.ReadLine();
                    if (line != null)
                    {
                        AddText(richTextBox1, line);
                        //AddText(richTextBox1, "\r\n");
                    }
                }

                p.WaitForExit();
                exitCode = p.ExitCode;
            }
            catch (Exception e)
            {
                AddText(richTextBox1, "RunProcess Error: " + e.Message);
            }
            return exitCode;
        }

        //use atprogram.exe
        private int BurnAtmel()
        {
            // The name of the key must include a valid root.
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\Atmel\\AtmelStudio\\7.0_Config";
            const string keyName = userRoot + "\\" + subkey;

            string path = (string)Registry.GetValue(keyName, "InstallDir", "Empty");

            try
            {
                // writing flash logger...
                Process p = new Process();

                //writing atmega flash & eeprom...
                p.StartInfo.FileName = path + "\\atbackend\\atprogram.exe";//filePath of the application                 
                                                                           //p.StartInfo.Arguments =  "-p m644p -c avrispmkII -P usb -U hfuse:w:0xDF:m -U lfuse:w:0xDF:m";
                                                                           //                 p.StartInfo.Arguments = string.Format("-f -t avrispmk2 -i isp -d atmega644pa -cl 500khz write -fs --values EFDFFF --verify program -fl -f {0} --format hex --verify -c program -ee -f {1} --format hex --verify", loggerFile2Burn.Text, LoggerEep2Burn.Text);
                                                                           //p.StartInfo.Arguments = string.Format("-f -t avrispmk2 -i isp -d atmega644pa -cl 125khz write -fs --values EFDFFF --verify program -fl -f {0} --format hex --verify -c program -ee -f {1} --format hex --verify", loggerFile2Burn.Text, LoggerEep2Burn.Text);

                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.EnableRaisingEvents = true;

                AddText(richTextBox1, "Erase:");
                //sCommand = string.Format("-t %s -i isp -d atmega644pa chiperase", m_sBurnType);
                if (RunProcess(p, string.Format("-t {0} -i isp -d atmega644pa chiperase", m_sBurnType)) == 0) //avrispmk2
                {
                    AddText(richTextBox1, "Program Fuse:");
                    if (RunProcess(p, string.Format("-t {0} -i isp -d atmega644pa -cl 125khz write -fs --values EFD8FF --verify", m_sBurnType)) == 0) //avrispmk2
                    {
                        AddText(richTextBox1, "Program Bootloader:");
                        if (RunProcess(p, string.Format("-t {0} -i isp -d atmega644pa -cl 125khz program -fl -f {1} --format elf --verify ", m_sBurnType, files2Burn[(int)_FileType.TYPE_ATMEL_BL])) == 0)
                        {
                            AddText(richTextBox1, "Program Flash:");
                            if (RunProcess(p, string.Format("-t {0} -i isp -d atmega644pa -cl 125khz program -fl -f {1} --format bin --verify ", m_sBurnType, files2Burn[(int)_FileType.TYPE_ATMEL_APP])) == 0)
                            {
                                AddText(richTextBox1, "Program EEprom:");
                                int b = RunProcess(p, string.Format("-t {0} -i isp -d atmega644pa -cl 125khz program -ee -f {1} --format hex --verify", m_sBurnType, files2Burn[(int)_FileType.TYPE_ATMEL_EEP]));
                                if (b != 0)
                                    m_nError = 13;
                                else
                                {
                                    if (m_atmelBrnType == _AtmelType.ATMEL_ICE)
                                    {
                                        Thread.Sleep(250);
                                        if (RunProcess(p, string.Format("-t {0} -i isp -d atmega644pa -cl 125khz reset ", m_sBurnType)) == 0)
                                            AddText(richTextBox1, "make reset");
                                    }
                                }
                                return b;
                            }
                            else
                                m_nError = 12;
                        }
                        else
                            m_nError = 11;
                    }
                    else
                        m_nError = 10;
                }
                else
                    m_nError = 10;
            }
            catch (Exception e)
            {
                AddText(richTextBox1, "BurnAtmel Error: "+ e.Message);
                m_nError = 14;
            }
            return 1;
        }

        private bool IsDigit(char c)
        {
            if ((c >= '0') && (c <= '9'))
                return true;
            return false;
        }

        private bool BurnEZR()
        {
            int n;
            //brnEzrBtn.BackColor = Color.Orange;
            // programs path
            string ezr32commanderpath = "C:\\phytechburn\\SimplicityCommander\\Simplicity Commander\\";
            try
            {
                // writing flash radio transreceiver...
                Process p = new Process();

                p.StartInfo.FileName = ezr32commanderpath + "Commander.exe";//filePath of the application
                p.StartInfo.Arguments = "adapter probe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                string s1 = p.StandardOutput.ReadToEnd();
                AddText(richTextBox1, s1);
                p.WaitForExit();
                string s = "";

                if (s1.Contains("J-Link Serial"))//J-Link Serial   : 440064012
                {
                    int i = s1.IndexOf("J-Link Serial");
                    if (i >= 0)
                    {
                        i += 13;
                        while (!IsDigit(s1[i++])) ;
                        i--;
                        do
                        {
                            s += s1[i];
                            i++;
                        }
                        while (IsDigit(s1[i]));
                    }
                }
                else
                {
                    AddText(richTextBox1, "Cant find J-Link Serial. \nPlease make sure it connected to your PC");
                    m_nError = 1;
                    return false;
                }
                //textEZRno.Text = s;
                p.StartInfo.Arguments = "device masserase -d EZR32HG320F64R68";
                p.Start();
                AddText(richTextBox1, p.StandardOutput.ReadToEnd());
                p.WaitForExit();
                p.StartInfo.Arguments = "flash " + files2Burn[(int)_FileType.TYPE_EZR_BL] + " " + files2Burn[(int)_FileType.TYPE_EZR_APP] + " --address 0x4000 -d EZR32HG320F64R68 -s " + s;// textEZRno.Text;
                                                                                                                                                                                            //p.StartInfo.Arguments = "flash " + RcvrFile2Burn.Text + " -d EZR32HG320F64R68 -s " + s;// textEZRno.Text;
                p.Start();
                s1 = p.StandardOutput.ReadToEnd();
                AddText(richTextBox1, s1);
                p.WaitForExit();
                n = p.ExitCode;
                if (n == 0)//(!s1.Contains("ERROR"))//if got this message means succeedded
                {
                    return true;
                    //brnEzrBtn.BackColor = Color.Green;
                    //brnEzrBtn.Text = "PASS";
                    //brnEzrBtn.ForeColor = Color.White;
                }
                else
                    m_nError = 3;
            }
            catch (Exception e)
            {
                m_nError = 2;
                AddText(richTextBox1, e.Message);
            }
            return false;
        }

        private int OpenPort(SerialPort port, ComboBox combo, Button btn)
        {
            int res = 0;
            if (combo.Text == "")
            {
                MessageBox.Show("No selected Port");
                return -1;
            }
            if (btn.Text.CompareTo("Open") == 0)
            {
                port.PortName = combo.Text;

                try
                {
                    port.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Open PORT");
                }
                if (port.IsOpen)                
                {
                    btn.Text = "Close";
                    res = 1;
                }
            }
            else
            {
                try
                {                    
                    port.Close();
                    btn.Text = "Open";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Close PORT");
                }
            }
            return res;
        }

        private void openAtmelComBtn_Click(object sender, EventArgs e)
        {
            int i = OpenPort(AtmelPort, comboPortAtml, openAtmelComBtn);
            if (i == 1)
                AtmelPort.DataReceived -= new SerialDataReceivedEventHandler(AtmelPort_DataReceived);
            m_nEventCnt = 0;
            //if (i == 1)
            //    AtmelPort.DataReceived += new SerialDataReceivedEventHandler(AtmelPort_DataReceived);

        }

        private void AtmelPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100);
            length = AtmelPort.BytesToRead;
            if (length > 0)
                m_buferLen = length;
            if (length > 1000)
                length = 1000;
            AtmelPort.Read(m_buffer, 0, length);
            AddText(richTextBoxLgr, Buff2Log(true, length));
            if (m_curStage == _ProcessStages.STAGE_3_BEFORE_CONNECT)
            {
                if (CheckBuf(length, beep, 8))
                {
                    m_bConnected2Logger = true;
                }
                return;
            }
            else
                if ((m_curStage == _ProcessStages.STAGE_4_FIRST_CONNECT) || (m_curStage == _ProcessStages.STAGE_7_SET_ID))
            {
                if (length > 0)
                    UnpackBuffer();
            }
            else
                    if (m_curStage == _ProcessStages.STAGE_6_SERVER_CONNECT)
                if (CheckBuf(length, CONNECT, 7))
                {
                    //m_curStage = _ProcessStages.STATUS_SECOND_CONNECT;
                    m_bCnctOK = true;
                }
        }

        private void openEzrComBtn_Click(object sender, EventArgs e)
        {
            int i = OpenPort(EzrPort, comboPortsEzr, openEzrComBtn);
            if (i == 1)
                EzrPort.DataReceived -= new SerialDataReceivedEventHandler(EzrPort_DataReceived);

        }

        private void EzrPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Thread.Sleep(50);
            byte[] buf = new byte[20];
            int l;
            string s = "";
            try
            {
                Thread.Sleep(50);
                l = EzrPort.BytesToRead;
//                AddText(richTextBox2, "Got data");
                if (l > 20)
                    return;
                EzrPort.DataReceived -= new SerialDataReceivedEventHandler(EzrPort_DataReceived);
                EzrPort.Read(buf, 0, l);
                for (int i = 0; i < l; i++)
                        s += Convert.ToChar(buf[i]);

                 AddText(richTextBox2, s);

                 if (m_curStage == _ProcessStages.STAGE_5_TEST_RF)
                    m_testEzr = ParseData(ref buf);
                 if (!m_testEzr)
                    EzrPort.DataReceived += new SerialDataReceivedEventHandler(EzrPort_DataReceived);
            }
            catch (Exception ex)
            {
                AddText(richTextBox1, "EzrPort_DataReceived Error: " + ex.Message);
            }
        }

        private void AddRemoveEvent(char c)
        {
            if ((c == '+') && (m_nEventCnt == 0))
            {
                AtmelPort.DataReceived += new SerialDataReceivedEventHandler(AtmelPort_DataReceived);
                m_nEventCnt++;
            }
            if ((c == '-') && (m_nEventCnt == 1))
            {
                AtmelPort.DataReceived -= new SerialDataReceivedEventHandler(AtmelPort_DataReceived);
                m_nEventCnt--;
            }
        }

        bool ParseData(ref byte[] buf)
        {
            AddText(richTextBox2, "ParseData");
            string S;
            int n1, n2, gap;
            if ((buf[0] == 'G') && (buf[1] == 'E'))
            {
                n1 = Convert.ToInt16(buf[6]);
                n1 = (n1 - 260) / 2;
                S = "pIn in Receiver: " + n1.ToString() + "  (RSSI: " + Convert.ToString(buf[6]) + ")";
                AddText(richTextBox2, S);
                n2 = Convert.ToInt16(buf[11]);
                n2 = (n2 - 260) / 2;
                S = "\r\npIn in check point: " + n2.ToString() + "  (RSSI: " + Convert.ToString(buf[11]) + ")";
                AddText(richTextBox2, S);
                m_sEzrVer = Convert.ToChar(buf[7]) + "." + Convert.ToInt16(buf[8]) + "." + Convert.ToInt16(buf[9]) + "." + Convert.ToInt16(buf[10]);
                S = "\r\nReceiver version: " + m_sEzrVer;
                if (m_sEZROfficialVer != m_sEzrVer)
                {
                    AddText(richTextBox2, "EZR wrong version");
                    return false;
                }

                //S += "\r\n";
                AddText(richTextBox2, S);
                if ((n1 < -7) || (n2 < -7))
                {
                    AddText(richTextBox2, "Too low...");
                    return false;
                }
                gap = n1 - n2;
                gap = Math.Abs(gap);
                if (gap <= 2)
                    return true;
            }
            //AddText(richTextBox2, "Too low...");
            return false;
            //return true;
        }

        private string Buff2Log(bool Rx, int len)
        {
            string s;
            //char[] tmp = new char[45];
            if (Rx)
            {
               // if (configCheck.Checked == false)
                    s = new string('>', 2);
                //else
                //    s = new string('-', 1);
            }
            else
                s = new string('<', 2);

            for (int i = 0; i < len; i++)
            {
                 if (m_bConnected2Logger == false)
                //{
                    s += Convert.ToChar(m_buffer[i]);
                //}
                else
                {
                    s += Convert.ToString(m_buffer[i]);
                    s += ',';
                }
            }
            //if (configCheck.Checked == false)
            s += '\n';

            return s;
        }

        private void TestRf()
        {
            EzrPort.DiscardInBuffer();
            EzrPort.DataReceived += new SerialDataReceivedEventHandler(EzrPort_DataReceived);
            AddText(richTextBox2, "add data Received Event");
            m_testEzr = false;
            byte[] tmp = new byte[7] { 0x54, 0x45, 0x53 ,0x54, 0x45, 0x5a, 0x52 }; // "TESTEZR"
            //int n = 0;
            do
            {
                    Thread.Sleep(3000);
                    AddText(richTextBox2, "Test RF");
                    EzrPort.Write(tmp, 0, 7);
//                n++;
            }
            while ((!m_testEzr) && (m_nSeconds > 0));
            m_myTimer.Enabled = false;
            if (!m_testEzr)
            {
                //EzrPort.DataReceived += new SerialDataReceivedEventHandler(EzrPort_DataReceived);
                EzrPort.DataReceived -= new SerialDataReceivedEventHandler(EzrPort_DataReceived);
                AddText(richTextBox2, "delete data Received Event");
            }
            // to-do - put back
            if (!m_testEzr)
            {
                m_nError = 30;
                m_bStopProcess = true;
                return;
            }
            m_curStage++;
            m_curTask = _TASK.TASK_DO_SOMETHING;
        }

        private void SetTimer(double ms)
        {
            // Create a timer with a two second interval.
            m_myTimer = new System.Timers.Timer(ms);
            // Hook up the Elapsed event for the timer. 
            m_myTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedAckEvent);
            //ElapsedEventHandler(OnTimedEvent);// timerEndProc_Tick;//OnTimedEvent;
            m_myTimer.AutoReset = true;
            m_myTimer.Enabled = true;
        }

        private void OnTimedAckEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            //if (m_bConnected2Logger == false)
                AddText(richTextBox1, m_nSeconds.ToString() + " OnTimedAckEvent");

            m_nSeconds--;
            if (m_nSeconds <= 0)
            { 
                m_myTimer.Enabled = false;
                m_myTimer.Dispose();
            }

            //AddText(richTextBox1, "settimer\r\n");
        }

        private bool CheckBuf(int l, byte[] bArr, int numBytes2Check)
        {
            int n = 0;
            int i = 0;
            do
            {
                if (m_buffer[i].Equals(bArr[n]))
                    n++;
                else
                    n = 0;
                i++;
            }
            while ((n < numBytes2Check) && (i < l));
            // new connection recognized:
            if (n == numBytes2Check)
            {
                m_bConnected2Logger = true;
                m_myTimer.Enabled = false;
                return true;
            }
            return false;
        }

        private void HelloLogger()
        {
            try
            {
                AddText(richTextBox1, "Connect to Logger");
                if (Talk2Logger(0, 0))
                {
                    if (m_bSecondConnect)
                    {
                        Talk2Logger(43, 0);
                        
                        if (m_bAPN_OK)                            
                        {
                            AddText(richTextBox1, "APN is OK");
                            m_curTask = _TASK.TASK_DO_SOMETHING;
                            m_curStage = _ProcessStages.STAGE_7_SET_ID;                            
                        }
                        else
                        {
                            AddText(richTextBox1, "Wrong APN was set");                        
                            //disconnect from logger
                            Talk2Logger(61, 1);
                            m_bStopProcess = true;
                            m_nError = 22;                            
                        }
                        return;               
                    }

                    AddText(richTextBox1, "Get SW version");
                    Talk2Logger(58, 0);       //get software version
                    if (m_sAtmelVer == m_sAtmelOfficialVer)                        
                    {
                        AddText(richTextBox1, "Get Battery");
                        Talk2Logger(55, 0);       //get battery
                        AddText(richTextBox1, "Get ICCID");
                        Talk2Logger(65, 0);         // iccid
                        AddText(richTextBox1, "Get Modem type");
                        Talk2Logger(66, 0);         //modem type
                        AddText(richTextBox1, "Set different APN");
                        // set new APN
                        if (Talk2Logger(43, 1))
                        {
                            if (m_bReqOK)
                            {
                                if (/*m_nModemModel != _ModemType.MODEM_SVL*/m_bCanConnect)
                                {
                                    // send to logger Task of connecting to server 
                                    Talk2Logger(67, 1);
                                    m_bConnected2Logger = false;
                                }
                                m_curTask = _TASK.TASK_DO_SOMETHING;
                                m_curStage++;
                            }
                        }
                        else
                            AddText(richTextBox1, "failed set the APN");
                    }
                    else
                        AddText(richTextBox1, "Wrong Version");
                }//if ()  
                if (m_curTask != _TASK.TASK_DO_SOMETHING)
                {
                    //disconnect from logger
                    Talk2Logger(61, 1);
                    m_bStopProcess = true;
                    m_nError = 21;
                    return;
                }
            }
            finally
            {

            }
            
        }
       
        private void ClearReadBuf()
        {
            for (int i = 0; i < 100; i++)
                m_buffer[i] = 0;
        }

        private byte GetCheckSum(int len)
        {
            byte check_sum = 0;

            for (int i = 0; i < len; i++)
            {
                check_sum += m_buffer[i];// *buff++;                
            }
            return (check_sum);
            //return 1;
        }

        private bool UnpackBuffer()
        {
            //AddText(richTextBox1, Buff2Log(true, length));
            if (m_buffer[0] != 0xFF)
                return false;
            if (m_buffer[1] != 0xFF)
                return false;
            // if length less than what written in length byte
            if (m_buferLen < m_buffer[2])
            {
                AddText(richTextBox1, "too short longth = " + length.ToString());
                return false;
            }
            // check id - only if not asking for id
            if (m_Param != 0) //&& (m_Param != 60))
                for (int i = 0; i < 4; i++)
                    if (m_buffer[i + 3] != m_byteID[i])
                    {
                        AddText(richTextBox1, "wrong ID");
                        return false;
                    }
            if (m_buffer[7] != m_Param)
            //if request is anything but id request
            {
                AddText(richTextBox1, "wrong parameter");
                //if (m_Param >= 10)
                return false;
            }
            length = m_buffer[2];
            // check sum
            if (GetCheckSum(length) != m_buffer[length])
                return false;

            m_bDataReceived = true;

            if (m_GetOrSet == 0)    //if get was sent
            {
                Int16 value;

                switch (m_Param)
                {
                    case 0:    //ID
                        Buffer.BlockCopy(m_buffer, 3, m_byteID, 0, 4);
                        long lID = BitConverter.ToInt32(m_buffer, 8);
                        AddText(richTextBox1, "logger ID = " + lID.ToString());
                        //SetText(textBoxLgrID, lID.ToString());
                        break;
                    case 43:    //apn
                        string s = "";
                        for (int i = 0; i < m_sAPN.Length; i++)
                            s += Convert.ToChar(m_buffer[8 + i]);
                        //if
                        //    m_bAPN_OK = false;
                        //else
                            m_bAPN_OK = (s == m_sAPN);// true;
                            //SetText(textAPN, Bytes2Str(32));
                            //textAPN.Text = Bytes2Str(32);                        
                            break;
                    case 55:    //battery
                        value = BitConverter.ToInt16(m_buffer, 8);
                        m_sBtr = value.ToString();
                        AddText(richTextBox1, "battery value is: " + m_sBtr);
                        //textBat.Text = value.ToString();
//                        SetText(textBat, value.ToString());
                        break;
                    case 56:    //RSSI
                        value = Convert.ToInt16(m_buffer[8]);
                        
                        //textRssi.Text = value.ToString();
                        //SetText(textRssi, value.ToString());
                        break;
                    case 58:    //Rom Version
                        m_sAtmelVer = ParseVersion();
                        AddText(richTextBox1, "version of application is: " + m_sAtmelVer);
                        break;
                    case 65:
                        Buffer.BlockCopy(m_buffer, 8, m_iccid, 0, 20);
                        m_strICCID = "";
                        for (int i = 0; i < 20; i++)
                            m_strICCID += Convert.ToChar(m_buffer[8+i]);
                        AddText(richTextBox1, "ICCID is: " + m_strICCID);
                        break;
                    case 66:
                        m_nModemModel = (_ModemType)m_buffer[8];
                        AddText(richTextBox1, "modem type is: " + m_nModemModel.ToString());
                        break;
                }//switch

                return true;
            }  //if get command
               //if update sensor id:
            if (m_GetOrSet == 1)
            {
                if (m_buffer[8] != 1)
                {
                    AddText(richTextBox1, "Set Property to logger failed");
                    return false;
                }
                if (m_Param == 0)
                {
                    long lID = BitConverter.ToInt32(m_buffer, 3);
                    if (lID == Convert.ToInt32(m_sID))
                        AddText(richTextBox1, "ID updated OK");
                }
                m_bReqOK = true;
            }
            return true;
        }  // func

        private string ParseVersion()
        {
            // save rom version
            for (int i = 0; i < 4; i++)
                m_RomVer[i] = m_buffer[8 + i];
            string sVer = new string((char)m_RomVer[0], 1);
            sVer += '.';
            sVer += Convert.ToString(m_RomVer[1]);
            sVer += '.';
            sVer += Convert.ToString(m_RomVer[2]);
            sVer += '.';
            sVer += Convert.ToString(m_RomVer[3]);
            return sVer;
//            SetText(textVersion, sVer);
//            SetText(stSWVer, sVer);    // also put it in order info
        }

        private bool Talk2Logger(byte prmIndex, byte getOrSet)
        {
            byte size = 0;
            int n;
            m_Param = prmIndex;
            m_GetOrSet = getOrSet;  //get = 0, set = 1
            m_bReqOK = false;

            m_buffer[0] = 0xFF;
            m_buffer[1] = 0xFF;
            for (int i = 0; i < 4; i++)
                m_buffer[3 + i] = m_byteID[i];
            m_buffer[7] = m_GetOrSet;
            m_buffer[8] = m_Param;
            if (m_GetOrSet == 1)  //if set command
            {
                switch (m_Param)
                {
                    case 0:
                        Buffer.BlockCopy(BitConverter.GetBytes(Convert.ToInt32(m_sID)), 0, m_buffer, 9, 4);
                        size = 4;
                        break;
                    //case 41:    //IP
                    //    Buffer.BlockCopy(StrtoBytes(textIP.Text, 32), 0, m_buffer, 9, 32);
                    //    size = 32;
                    //    break;
                    //case 42:    //port  
                    //    Buffer.BlockCopy(StrtoBytes(textPort.Text, 4), 0, m_buffer, 9, 4);
                    //    size = 4;
                    //    break;
                    case 43:    //apn
                        bool bMatchIccid = false;
                        foreach (APN_Types apn in APNArray)
                            if (apn.m_mdmType == m_nModemModel)
                            {
                                AddText(richTextBox1, "found modem model "+ m_nModemModel);
                                AddText(richTextBox1, "check if " + apn.m_ICCID + " is the begining of:  " + m_strICCID);
                                if (m_strICCID.StartsWith(apn.m_ICCID))
                                {
                                    Buffer.BlockCopy(StrtoBytes(apn.m_APN, 32), 0, m_buffer, 9, 32);
                                    m_sAPN = apn.m_APN + '#';
                                    bMatchIccid = true;
                                    m_bCanConnect = (apn.m_canConnect == 1);
                                }
                            }
                        if (bMatchIccid == false)
                        {
                            AddText(richTextBox1, "Wrong ICCID");
                            return false;
                        }
                        size = 32;
                        break;
                }
            }

            n = size + 9;
            m_buffer[2] = (byte)n;
            m_buffer[n] = GetCheckSum(n);
            try
            {
                m_bDataReceived = false;
                AtmelPort.Write(m_buffer, 0, n + 1);
                AddText(richTextBox1, Buff2Log(false, n + 1));
                
            }
            catch (Exception x)
            {
                AddText(richTextBox1, "Exception: " + x.Message);
            }
            //for disconnecting - no need to wait for answer
            if (m_Param == 61)
                return true;
            Thread.Sleep(500);
            return m_bDataReceived;
        }

        private byte[] StrtoBytes(string str, int len)
        {
            byte[] myBytes = new byte[len];
            int i, n = str.Length;
            if (len < n)
                n = len;
            for (i = 0; i < n; i++)
                myBytes[i] = Convert.ToByte(str[i]);
            if (n < len)
            {
                myBytes[n] = (byte)'#';
                for (i = n + 1; i < len; i++)
                    myBytes[i] = 0;
            }
            return myBytes;
        }

        private void FinalSteps()
        {
            AddText(richTextBox1, "Final steps");
            if (GenerateID())
            {
                SendLoggerInfo();
                Print();
                SaveData2File();
                m_curStage++;
                m_curTask = _TASK.TASK_DO_SOMETHING;
            }
            m_bStopProcess = true;
        }

        public void SendLoggerInfo()
        {
            /*
            * "factory":"reuven"
            * "worker_identifier":"shluki"
            * "software_version":"r234"
            * "hardware_version":"shalom"
            * "sensor_type":23
            * "measuring_value":3.0
            * "battery_value":3.0
            * "rssi_value":3.0
            * "hardware_type":"Sensor"
            * */
            string strAddress = String.Format(@"http://plantbeat.phytech.com/activeadmin/sensors_allocations/{0}.json?user_id=1091&api_token=FrAnazu5rt67", m_nAllocID);
            String strLine;// = "authtoken=4b8873e7a46d5cf77a027bda4feb3fe4&scope=crmapi&wfTrigger=true&xmlData=<Products><row no=\"1\">";
            strLine = String.Format("&factory={0}&worker_identifier={1}&software_version={2}&hardware_version={3}", m_sFactory, m_nModemModel.ToString(), m_sAtmelVer, m_sEzrVer);
            strLine += String.Format("&battery_value={0}&hardware_type=RemoteLogger&sensor_type={1}&measuring_value={2}", m_sBtr, (int)m_nModemModel, m_strICCID);
            //strLine += String.Format("rssi_value={3}", textPin.Text);

            AddText(richTextBox1, "Sending Logger parameter to server...");
            try
            {
                WebRequest request = WebRequest.Create(strAddress);
                request.Method = "PATCH";
                byte[] byteArray = Encoding.UTF8.GetBytes(strLine);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();

                //return responseFromServer;
                if (responseFromServer.Contains("true") == true)
                    AddText(richTextBox1, "Logger Information was sent successfully");
                else
                    AddText(richTextBox1, "Failed to send Logger Information");
            }
            catch (Exception ex)
            {
                AddText(richTextBox1, "SendLoggerInfo Error: " +ex.Message);
                m_nError = 53;
            }
        }

        private void Print(/*object sender, EventArgs e*/)
        {
            new Print(m_sID, m_nModemModel.ToString(), LoggerConfig.Properties.Resources.BnWLogo);
            AddText(richTextBox1, "Sticker Printed");
        }

        private bool GenerateID()
        {
            if (dontGenerateNewToolStripMenuItem.Checked)
            {
                m_sID = textBoxID.Text;
                return true;
            }
            bool b = false;

            //            string uriString = "http://46.101.79.233:3001/activeadmin/sensors_allocations.json?user_id=1580&api_token=nz-nLBTpvQL4N-3GTZBz";
            string uriString = @"http://plantbeat.phytech.com/activeadmin/sensors_allocations.json?user_id=1091&api_token=FrAnazu5rt67";
            try
            {
                WebClient client = new WebClient();
                // Optionally specify an encoding for uploading and downloading strings.
                client.Encoding = System.Text.Encoding.UTF8;
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                //uriString = urifirstPart + textID.Text.ToString() + urilastPart;
                // Create a new NameValueCollection instance to hold some  parameters to be posted to the URL.
                NameValueCollection myNameValueCollection = new NameValueCollection();

                // Add necessary parameter/value pairs to the name/value container.
                //                myNameValueCollection.Add("utf8", "%E2%9C%93");
                myNameValueCollection.Add("sensors_allocation[allocations_number]", "1");   
                myNameValueCollection.Add("sensors_allocation[wireless]", "1");
                myNameValueCollection.Add("commit", "Create Sensors allocation");

                // 'The Upload(String,NameValueCollection)' implicitly method sets HTTP POST as the request method.             
                byte[] responseArray = client.UploadValues(uriString, myNameValueCollection);
                string reply = Encoding.UTF8.GetString(responseArray, 0, responseArray.Length);
                // Upload the data.
                //string[] separators = { ",", "[", "]" }; //, "?", ";", ":", " " };
                //string[] IDs = reply.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                ///////////////////////////////////////////////////
                string[] separators = { ",", "[", "]", ":", "{", "}" }; //, "?", ";", ":", " " };
                string[] IDs = reply.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                int n1, n2;
                if (int.TryParse(IDs[3], out n1) && int.TryParse(IDs[1], out n2))
                {
                    m_sID = IDs[3];
                    AddText(richTextBox1, "new ID is " + m_sID);
                    AddLine(StageLbl, m_sID, false);
                    //m_byteID = BitConverter.GetBytes(Convert.ToInt32(IDs[3]));
                    m_nAllocID = n2;
                    //textID.Text = IDs[0];
                }
                else
                {
                    m_nError = 50;
                    return false;
                }
                ///////////////////////////////////////////////////////
                // send the ID
                int n = 0;
                do
                {
                    Thread.Sleep(1000);
                    b = Talk2Logger(0, 1);
                    n++;
                }
                while ((n <= 3) && (!b));

                Talk2Logger(61, 1);
                AddRemoveEvent('-');
                // Disply the server's response.
                //MessageBox.Show(responseArray.ToString());
                //.WriteLine(reply);
            }
            catch (WebException we)
            {
                AddText(richTextBox1, "GenerateID Error: "+ we.Message);
                m_nError = 51;
            }
            if (!b)
                m_nError = 52;
            return b;
        }

        void SaveData2File()
        {
            try
            {
                string fileName = string.Format(@"C:\phytech\Loggers_{0}.txt", m_sID);
                string line = string.Format("{0}/{1}/{2}: Logger ID: {3}  ICCID: {4}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, m_sID, m_strICCID);
                StreamWriter tw = new StreamWriter(fileName, true);
                tw.WriteLine(line);
                tw.Close();
            }
            catch (Exception e)
            { 
                AddText(richTextBox1, "Save Data 2 file failed. Exception: " + e.Message);
            }
       }

        private void button2_Click(object sender, EventArgs e)
        {
            //Talk2Logger(Convert.ToByte(textID.Text), 0);
            m_nSeconds = 60;
            SetTimer(1000);
            EzrPort.DiscardInBuffer();
            m_curStage = _ProcessStages.STAGE_5_TEST_RF;
            Thread thRF = new Thread(new ThreadStart(TestRf));
            thRF.Start();
            //GenerateID();
            //new Print("123456", m_nModemModel.ToString(), LoggerConfig.Properties.Resources.BnWLogo);
            //AddText(richTextBox1, "Sticker Printed");
        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showLogToolStripMenuItem.Checked)
                this.Size = new Size(807, 374);
            else
                this.Size = new Size(807, 228);
        }

        private void cleareLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBoxLgr.Clear();
        }

        private void showOfficialVersionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Atmel Official Version: " + m_sAtmelOfficialVer + Environment.NewLine + "EZR Official Version: " + m_sEZROfficialVer, "SW Versions", MessageBoxButtons.OK);
        }

        private void factoryNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(m_sFactory, "Factory Name",  MessageBoxButtons.OK);
        }

        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = "Atmel BL: " + files2Burn[(int)_FileType.TYPE_ATMEL_BL] + Environment.NewLine;
            s += "Atmel APP: " + files2Burn[(int)_FileType.TYPE_ATMEL_APP] + Environment.NewLine;
            s += "Atmel EEP: " + files2Burn[(int)_FileType.TYPE_ATMEL_EEP]+ Environment.NewLine;
            s += "Ezr BL: " + files2Burn[(int)_FileType.TYPE_EZR_BL] + Environment.NewLine;
            s += "Ezr App: " + files2Burn[(int)_FileType.TYPE_EZR_APP] + Environment.NewLine;
            
            MessageBox.Show(s, "File to Burn", MessageBoxButtons.OK);

        }

        private void dontGenerateNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool b = dontGenerateNewToolStripMenuItem.Checked;
            labelID.Visible = b;
            textBoxID.Visible = b;
        }

        private void amelBurnerTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtmelBrnType Tmpform = new AtmelBrnType((int)m_atmelBrnType);
            if (Tmpform.ShowDialog() == DialogResult.OK)
            {
                m_atmelBrnType = (_AtmelType)Tmpform.GetAtmelType();
                if (m_atmelBrnType == _AtmelType.ATMEL_ICE)
                    m_sBurnType = "atmelice";
                if (m_atmelBrnType == _AtmelType.ATMEL_MK2)
                    m_sBurnType = "avrispmk2";
            }
        }
    }
}
