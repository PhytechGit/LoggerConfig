using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoggerConfig
{
    public partial class SelectConfigForm : Form
    {
        public _ConfigType m_newConfig { get; set; }

        public SelectConfigForm()
        {
            InitializeComponent();
        }

        public SelectConfigForm(_ConfigType ct)
        {
            InitializeComponent();
            switch (ct)
            {
                case _ConfigType.CONFIG_NORMAL:
                    radioButtonLgr.Checked = true;
                    break;
                case _ConfigType.CONFIG_NG:
                    radioButtonNG.Checked = true;
                    break;
                case _ConfigType.CONFIG_GATEWAY:
                    radioButtonGW.Checked = true;
                    break;
            }
        }

        private void SelectConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            if (radioButtonLgr.Checked == true)
                m_newConfig = _ConfigType.CONFIG_NORMAL;
            if (radioButtonNG.Checked == true)
                m_newConfig = _ConfigType.CONFIG_NG;
            if (radioButtonGW.Checked == true)
                m_newConfig = _ConfigType.CONFIG_GATEWAY;
            this.DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
