using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using Simulator.ClassLib;

namespace QCOnTrack
{
    public partial class Sum : Form
    {
        int NewIndex = 0, CurrentIndex = 0;
        Boolean EnableReg,StartEnd = false;
        public Sum()
        {
            InitializeComponent();
            GlobalValue.InitialValue();
            timer1.Start();
        }


        private void Dgv_Sum_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_Sum.Columns[e.ColumnIndex] is DataGridViewButtonColumn&& e.RowIndex > -1)
            {
                //打开关闭通讯窗口
                if (e.ColumnIndex == 5)
                {

                    StartStop(e.RowIndex);

                }

                //显示隐藏
                else if (e.ColumnIndex == 4)
                {
                    ShowHiden(e.RowIndex);
                }
                //删除
                else if (e.ColumnIndex == 6)
                {

                    DialogResult result = MessageBox.Show("To confirm to deletion?", "Attention!", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                    DeleteRow(e.RowIndex);

                }
                
            }
            if (Dgv_Sum.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex > -1)
            {
                if (e.ColumnIndex == 0)
                {
                    if (Convert.ToBoolean( Dgv_Sum.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true)
                    {
                        try
                        {

                            StartStop(e.RowIndex);
                            GlobalValue.connectvalue[e.RowIndex].InstrForm.Close();
                        }
                        catch
                        {

                        }
                        GlobalValue.connectvalue[e.RowIndex].FormEnable = false;
                    }
                    else
                    {
                        GlobalValue.connectvalue[e.RowIndex].FormEnable = true;
                    }
                    if (EnableReg == false) return;
                    //GlobalValue.connectvalue[e.RowIndex].SaveSettingInReg(e.RowIndex);
                }
            }
        }
        private void ShowHiden(int index)
        {
            if (GlobalValue.connectvalue[index].InstrForm == null)
            {
                TranslateUnit instr = new TranslateUnit(index);
                instr.Show();
                instr.LoadSetting(index);
                return;
            }
            if (GlobalValue.connectvalue[index].IsHiden == true)
            {
                GlobalValue.connectvalue[index].InstrForm.Show();
                GlobalValue.connectvalue[index].IsHiden = false;
                GlobalValue.connectvalue[index].FormEnable = true;
            }
            else
            {
                GlobalValue.connectvalue[index].InstrForm.Hide();
                GlobalValue.connectvalue[index].IsHiden = true;
            }
        }
        private void DeleteRow(int index)
        {
           

            int TotalCount = 0;
            TotalCount = Dgv_Sum.RowCount;

            Dgv_Sum.Rows.Remove(Dgv_Sum.Rows[index]);

            //关闭要删除的窗口
            if (GlobalValue.connectvalue[index].InstrForm != null)
            {
                GlobalValue.connectvalue[index].InstrForm.Close();
            }
            //元素依次前挪
            for (int i = index; i < TotalCount - 1; i++)
            {

                GlobalValue.connectvalue[i] = GlobalValue.connectvalue[i + 1];
                if (GlobalValue.connectvalue[i].InstrForm != null)
                {
                    //GlobalValue.connectvalue[i].InstrForm.formindex = i;
                }
                if (EnableReg == true)
                {
                    //更新reg
                    //GlobalValue.connectvalue[i].SaveSettingInReg(i);
                }

            }
            //清除最后一个元素
            GlobalValue.connectvalue[TotalCount - 1].Setnull();

            if (EnableReg == true)
            {
                GlobalValue.RegPathDelete("Software\\SiemensSimulator\\",index.ToString());
                UpdateReg(Dgv_Sum.RowCount);
            }
        }
        private void StartStop(int index)
        {
            if (GlobalValue.connectvalue[index].FormEnable == false|| GlobalValue.connectvalue[index].InstrForm==null)
            {
                return;
            }
            if (GlobalValue.connectvalue[index].InstrForm != null)
            {

                //if (GlobalValue.connectvalue[index].InstrForm.ISSTART == true)
                //{
                //    GlobalValue.connectvalue[index].InstrForm.Stop();
                //}
                //else
                //{
                //    GlobalValue.connectvalue[index].InstrForm.Start();
                //}
            }
            //if (GlobalValue.connectvalue[index].InstrForm.ISSTART == true)
            //{
            //    Dgv_Sum.Rows[index].Cells["ConnectStatue"].Style.BackColor = System.Drawing.Color.Green;
            //}
            //else
            //{
            //    Dgv_Sum.Rows[index].Cells["ConnectStatue"].Style.BackColor = System.Drawing.Color.Red;
            //}
        }

        private void B_Add_Click(object sender, EventArgs e)
        {
            NewIndex = Dgv_Sum.Rows.Add();
            FormName MainForm = new FormName(NewIndex, Dgv_Sum);
            MainForm.ShowDialog();
            if (GlobalValue.connectvalue[NewIndex].FormName != "" && GlobalValue.connectvalue[NewIndex].FormName != null)
            {
                Dgv_Sum.Rows[NewIndex].Cells["Instrument"].Value = GlobalValue.connectvalue[NewIndex].FormName;
                TranslateUnit instr = new TranslateUnit(NewIndex);
                GlobalValue.connectvalue[NewIndex].IsHiden = false;
                GlobalValue.connectvalue[NewIndex].ConParm.InitValue();
                instr.Show();
            }
            else
            {
                Dgv_Sum.Rows.Remove(Dgv_Sum.Rows[NewIndex]);
            }
            Add();

            if (EnableReg == true)
            {
                UpdateReg(Dgv_Sum.RowCount);
            }

        }
        public void Add()
        {
            NewIndex = Dgv_Sum.Rows.Add();
            FormName MainForm = new FormName(NewIndex, Dgv_Sum);
            MainForm.ShowDialog();
            if (GlobalValue.connectvalue[NewIndex].FormName != "" && GlobalValue.connectvalue[NewIndex].FormName != null)
            {
                Dgv_Sum.Rows[NewIndex].Cells["Instrument"].Value = GlobalValue.connectvalue[NewIndex].FormName;
                TranslateUnit instr = new TranslateUnit(NewIndex);
                GlobalValue.connectvalue[NewIndex].IsHiden = false;
                GlobalValue.connectvalue[NewIndex].ConParm.InitValue();
                instr.Show();
            }
            else
            {
                Dgv_Sum.Rows.Remove(Dgv_Sum.Rows[NewIndex]);
            }
        } 

        private void timer1_Tick(object sender, EventArgs e)
        {
            Dgv_Sum_StatueRefresh();
        }

        private void Dgv_Sum_StatueRefresh()
        {
            int j = 0;
            foreach (DataGridViewRow i in Dgv_Sum.Rows)
            {
                i.Cells["seq"].Value = j + 1;
                if (GlobalValue.connectvalue[j].InstrForm != null)
                {
                    //if (GlobalValue.connectvalue[j].InstrForm.ISSTART == true)
                    //{
                    //    i.Cells["ConnectStatue"].Style.BackColor = System.Drawing.Color.Green;
                    //    i.Cells["CloseInstrument"].Value = "Stop";
                    //}
                    //else
                    //{
                    //    i.Cells["ConnectStatue"].Style.BackColor = System.Drawing.Color.Red;
                    //    i.Cells["CloseInstrument"].Value = "Start";
                    //}

                }
                else
                {
                    i.Cells["CloseInstrument"].Value = "Unavailable";
                    i.Cells["ConnectStatue"].Style.BackColor = System.Drawing.Color.Red;
                }

                if (GlobalValue.connectvalue[j].IsHiden == true)
                {
                    i.Cells["Hiden"].Value = "Show";
                }
                else
                {
                    i.Cells["Hiden"].Value = "Hide";
                }
                i.Cells["Delete"].Value = "Delete";

                if (GlobalValue.connectvalue[j].FormEnable == true)
                {
                    i.Cells["Enable"].Value = true;
                }
                else
                {
                    i.Cells["Enable"].Value = false;
                }

                

                j++;
            }
        }

        private void Dgv_Sum_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1&&e.ColumnIndex > -1)
            {
                //if (e.ColumnIndex == 2)
                //{
                //    if (GlobalValue.connectvalue[e.RowIndex].connect != null)
                //    {

                //    }
                //    Dgv_Sum.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "2345\r\n234";
                //}
                //else if (e.ColumnIndex == 3)
                //{
                
                    Dgv_Sum.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = GetToolTip(e.RowIndex);
                    
                //}
                
            }
        }

        private string GetToolTip(int index)
        {
            //string S_tooltip;
            //ConnectValue CV_e = GlobalValue.connectvalue[index];
            //S_tooltip = "FormName:" + CV_e.FormName + "\r\n";
            //S_tooltip+= "InstrumentName:" + CV_e.ConParm.InstrName + "\r\n";
            //if (CV_e.ConParm.TCPType == "S")
            //{
            //    S_tooltip += "Type:SERVER" + "\r\n";
            //    if (CV_e.ConParm.SPORT != "")
            //    {
            //        S_tooltip += "Port No.:" + CV_e.ConParm.SPORT + "\r\n";
            //    }
            //    if (CV_e.connect!= null && CV_e.connect.Server != null)
            //    {
            //        if (CV_e.connect.Server.connectinfo != null)
            //        {
            //            S_tooltip += "Statue:" + CV_e.connect.Server.connectinfo + "\r\n";
            //        }
            //    }
            //}
            //else if (CV_e.ConParm.TCPType == "C")
            //{
            //    S_tooltip += "Type:CLIENT" + "\r\n";

            //    if (CV_e.ConParm.CPORT1 != "")
            //    {
            //        S_tooltip += "Port No.:" + CV_e.ConParm.CPORT1 + "\r\n";

            //        if (CV_e.connect != null && CV_e.connect.client_O != null)
            //        {
            //            if (CV_e.connect.client_O.connectinfo != null)
            //            {
            //                S_tooltip += "Statue:" + CV_e.connect.client_O.connectinfo + "\r\n";
            //            }
            //        }
            //    }

            //    if (CV_e.ConParm.CPORT1 != CV_e.ConParm.CPORT2)
            //    {
            //        if (CV_e.ConParm.CPORT2 != "")
            //        {
            //            S_tooltip += "Port No.:" + CV_e.ConParm.CPORT2 + "\r\n";

            //            if (CV_e.connect != null && CV_e.connect.client_R != null)
            //            {
            //                if (CV_e.connect.client_R.connectinfo != null)
            //                {
            //                    S_tooltip += "Statue:" + CV_e.connect.client_R.connectinfo + "\r\n";
            //                }
            //            }
            //        }
            //    }
            //}
            //"2345\r\n234"
            return "";
            //return S_tooltip;
        }

        private void CB_EnableReg_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_EnableReg.Checked)
            {
                B_Import.Visible = true;
                B_Output.Visible = true;
                B_Clean.Visible = true;
            }
            else
            {
                B_Import.Visible = false;
                B_Output.Visible = false;
            }
            if (StartEnd != false)
            {

                UpdateReg(Dgv_Sum.RowCount);
            }
        }

        private void Sum_Load(object sender, EventArgs e)
        {
            EnableReg = GlobalValue.EnableReg;
            CB_EnableReg.Checked = EnableReg;
            B_Import.Visible = EnableReg;
            B_Output.Visible = EnableReg;
            B_Clean.Visible = EnableReg;
            if (EnableReg == false) return;
            if (EnableReg)
            {
                LoadList();
            }

            StartEnd = true;

        }

        //载入列表
        private void LoadList()
        {
            RegistryKey key;
            int TotalCount;
            key = Registry.CurrentUser.OpenSubKey("Software\\SiemensSimulator\\", true);
            if (key == null) return;
            TotalCount = Convert.ToInt32( key.GetValue("Count", 0));
            //清理之前所有行
            foreach(DataGridViewRow i in Dgv_Sum.Rows)
            {
                DeleteRow(i.Index);
            }
            for (int i = 0; i < TotalCount; i++)
            {
                NewIndex = Dgv_Sum.Rows.Add();
                //GlobalValue.connectvalue[NewIndex].LoadSettingFromReg(NewIndex);
                Dgv_Sum.Rows[NewIndex].Cells["Instrument"].Value = GlobalValue.connectvalue[NewIndex].FormName;
                GlobalValue.connectvalue[NewIndex].IsHiden = true;
                //自动开始
                if (GlobalValue.connectvalue[NewIndex].FormEnable == true)
                {
                    TranslateUnit instr = new TranslateUnit(NewIndex);
                    instr.Show();
                    GlobalValue.connectvalue[NewIndex].IsHiden = false;
                    instr.LoadSetting(NewIndex);
                    StartStop(NewIndex);
                }
                
            }
            key.Close();
        }

        private void B_Import_Click(object sender, EventArgs e)
        {
            string filepath;
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Select Reg File";
            file.Filter="Regist(*.reg)|*.reg|All Files(*.*)|*.*";
            if (file.ShowDialog()== DialogResult.OK)
            {
                filepath = file.FileName;
                GlobalValue.RegImport(filepath, "HKEY_CURRENT_USER\\SOFTWARE\\SiemensSimulator\\");
            }
            
        }

        private void B_Output_Click(object sender, EventArgs e)
        {
            string filepath;
            SaveFileDialog file = new SaveFileDialog();
            file.Title = "Enter a file name";
            file.Filter = "Regist(*.reg)|*.reg|All Files(*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                filepath = file.FileName;
                GlobalValue.RegOutPut(filepath, "HKEY_CURRENT_USER\\SOFTWARE\\SiemensSimulator");
            }
        }

        private void B_Clean_Click(object sender, EventArgs e)
        {
            GlobalValue.RegPathDelete("Software\\","SiemensSimulator");
        }

        private void UpdateReg(int count)
        {
            RegistryKey key;
            try
            {
                key = Registry.CurrentUser.OpenSubKey("Software\\SiemensSimulator\\", true);
                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey("Software\\SiemensSimulator\\");

                }
                key.SetValue("Count", count);
                key.SetValue("Enable", CB_EnableReg.Checked);
                key.Close();
                GlobalValue.EnableReg = CB_EnableReg.Checked;
            }
            catch(System.Security.SecurityException )//System.UnauthorizedAccessException)
            {
                //注册表错误，强制关闭此功能
                CB_EnableReg.Checked = false;
                CB_EnableReg.Visible = false;
                GlobalValue.EnableReg = false;
                B_Import.Visible = false;
                B_Output.Visible = false;
                B_Clean.Visible = false;
            }
            catch(System.UnauthorizedAccessException)
            {
                CB_EnableReg.Checked = false;
                CB_EnableReg.Visible = false;
                GlobalValue.EnableReg = false;
                B_Import.Visible = false;
                B_Output.Visible = false;
                B_Clean.Visible = false;
            }
        }

        private void Dgv_Sum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentIndex = e.RowIndex;
        }


        



    }
}
