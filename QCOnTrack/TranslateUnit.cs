using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulator.ClassLib;

namespace QCOnTrack
{
    
    public partial class TranslateUnit : Form
    {
        public int index = 0;
        public TranslateUnit()
        {
            InitializeComponent();
        }
        public TranslateUnit(int index)
        {
            this.index = index;
            InitializeComponent();
        }

        private void RB_CClient_CheckedChanged(object sender, EventArgs e)
        {
            RB_CServer.Checked = !RB_CClient.Checked;
        }

        private void RB_CServer_CheckedChanged(object sender, EventArgs e)
        {
            RB_CClient.Checked = !RB_CServer.Checked;
        }

        private void RB_IServer_CheckedChanged(object sender, EventArgs e)
        {
            RB_IClient.Checked = !RB_IServer.Checked;
        }

        private void RB_IClient_CheckedChanged(object sender, EventArgs e)
        {
            
            RB_IServer.Checked = !RB_IClient.Checked;
        }

        private void B_NeedReboot_CheckedChanged(object sender, EventArgs e)
        {
            T_Picker.Enabled = B_NeedReboot.Checked;
        }

        private void TranslateUnit_Load(object sender, EventArgs e)
        {
            B_NeedReboot.Checked = false;
            T_Picker.Enabled = false;
            LoadSetting(index);
        }

        private void T_Picker_ValueChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = T_Picker.Value.ToShortTimeString();
            
        }
        public void Start()
        {

        }
        public void LoadSetting(int index)
        {
            GlobalValue.connectvalue[index].LoadConnectParm();
        }
    }
}
