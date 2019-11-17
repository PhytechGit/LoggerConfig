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
    public partial class AtmelBrnType : Form
    {
        int m_AtmelType;

        public AtmelBrnType()
        {
            InitializeComponent();
        }

        public AtmelBrnType(int type)
        {
            InitializeComponent();
            m_AtmelType = type;
        }

        private void AtmelBrnType_Load(object sender, EventArgs e)
        {
            if (m_AtmelType == 0)
            {
                radioBtnIce.Checked = true;
             
            }
            else
            {            
                radioBtnMk.Checked = true;
            }
        }

        public int GetAtmelType()
        {
            if (radioBtnIce.Checked == true)
                return 0;
            return 1;
        
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
