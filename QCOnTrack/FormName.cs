using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Simulator.ClassLib;

namespace QCOnTrack
{
    public partial class FormName : Form
    {
        int Index = 0;
        DataGridView Dgv_sum;
        public FormName()
        {
            InitializeComponent();
        }

        public FormName(int Index)
        {
            this.Index = Index;
            InitializeComponent();
        }

        public FormName(int Index,DataGridView Dgv_s)
        {
            this.Index = Index;
            Dgv_sum = Dgv_s;
            InitializeComponent();
        }

        private void B_OK_Click(object sender, EventArgs e)
        {
            string tmp = Tb_Instrname.Text;
            if (tmp != null && tmp != "")
            {
                GlobalValue.connectvalue[Index].FormName = tmp;
                if (Dgv_sum != null)
                {
                    foreach (DataGridViewRow i in Dgv_sum.Rows)
                    {
                        try
                        {
                            if (i.Cells["Instrument"].Value.ToString() == tmp)
                            {
                                DialogResult result = MessageBox.Show("Duplicate Name", "Warring");
                                return;
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                this.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("Fill the Name", "Warring");
            }
        }

   

        private void FormName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                B_OK_Click(sender,e);
            }
        }
    }
}
