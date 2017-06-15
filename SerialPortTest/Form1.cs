using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;
using Microsoft.Win32;
using System.Threading;

namespace SerialPortTest
{
    public partial class Form1 : Form
    {
        Boolean B_Start= false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetComList();
        }


        public enum HardwareEnum
        {
            Win32_Processor, // CPU 处理器
            Win32_PhysicalMemory, // 物理内存条
            Win32_Keyboard, // 键盘
            Win32_PointingDevice, // 点输入设备，包括鼠标。
            Win32_FloppyDrive, // 软盘驱动器
            Win32_DiskDrive, // 硬盘驱动器
            Win32_CDROMDrive, // 光盘驱动器
            Win32_BaseBoard, // 主板
            Win32_BIOS, // BIOS 芯片
            Win32_ParallelPort, // 并口
            Win32_SerialPort, // 串口
            Win32_SerialPortConfiguration, // 串口配置
            Win32_SoundDevice, // 多媒体设置，一般指声卡。
            Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP)
            Win32_USBController, // USB 控制器
            Win32_NetworkAdapter, // 网络适配器
            Win32_NetworkAdapterConfiguration, // 网络适配器设置
            Win32_Printer, // 打印机
            Win32_PrinterConfiguration, // 打印机设置
            Win32_PrintJob, // 打印机任务
            Win32_TCPIPPrinterPort, // 打印机端口
            Win32_POTSModem, // MODEM
            Win32_POTSModemToSerialPort, // MODEM 端口
            Win32_DesktopMonitor, // 显示器
            Win32_DisplayConfiguration, // 显卡
            Win32_DisplayControllerConfiguration, // 显卡设置
            Win32_VideoController, // 显卡细节。
            Win32_VideoSettings, // 显卡支持的显示模式。

            // 操作系统
            Win32_TimeZone, // 时区
            Win32_SystemDriver, // 驱动程序
            Win32_DiskPartition, // 磁盘分区
            Win32_LogicalDisk, // 逻辑磁盘
            Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。
            Win32_LogicalMemoryConfiguration, // 逻辑内存配置
            Win32_PageFile, // 系统页文件信息
            Win32_PageFileSetting, // 页文件设置
            Win32_BootConfiguration, // 系统启动配置
            Win32_ComputerSystem, // 计算机信息简要
            Win32_OperatingSystem, // 操作系统信息
            Win32_StartupCommand, // 系统自动启动程序
            Win32_Service, // 系统安装的服务
            Win32_Group, // 系统管理组
            Win32_GroupUser, // 系统组帐号
            Win32_UserAccount, // 用户帐号
            Win32_Process, // 系统进程
            Win32_Thread, // 系统线程
            Win32_Share, // 共享
            Win32_NetworkClient, // 已安装的网络客户端
            Win32_NetworkProtocol, // 已安装的网络协议
            Win32_PnPEntity,//
        }



        private string[] MulGetHardwareInfo(HardwareEnum hardType, string propKey)
        {
            List<string> strs = new List<string>();
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + hardType))
                {
                    var hardInfos = searcher.Get();
                    foreach (var hardInfo in hardInfos)
                    {
                        if (hardInfo.Properties[propKey].Value != null)
                        {
                            if (hardInfo.Properties[propKey].Value.ToString().Contains("COM"))
                            {
                                strs.Add(hardInfo.Properties[propKey].Value.ToString());
                            }
                        }


                    }
                    searcher.Dispose();
                }
                return strs.ToArray();
            }
            catch
            {
                return null;
            }
            finally
            { strs = null; }
        }



        public void GetComList()
        {
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                COMB_PortList.Items.Clear();
                foreach (string sName in sSubKeys)
                {
                    string sValue = (string)keyCom.GetValue(sName);
                    this.COMB_PortList.Items.Add(sValue);
                }
                if (sSubKeys.Length > 0)
                {
                    this.COMB_PortList.Text = (string)keyCom.GetValue(sSubKeys[0]);
                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            GetComList();
            SerialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceived);

            timer1.Start();
        }

        private void TB_send_TextChanged(object sender, EventArgs e)
        {
            //
        }
        

        private void TB_recieve_TextChanged(object sender, EventArgs e)
        {
            ScroToLastRow(TB_recieve);
        }
        private void ScroToLastRow(TextBox tb)
        {
            tb.SelectionStart = tb.Text.Length;
            tb.SelectionLength = 0;
            tb.ScrollToCaret();
        }

        private void B_Connect_Click(object sender, EventArgs e)
        {
            if (B_Start)
            {
                Stop();
            }
            else
            {
                Start();
            }
        }

        private void Start()
        {
            if (COMB_PortList.Text == "")
            {
                MessageBox.Show("Please select the serial port ");
                return;
            }
            SerialPort1.PortName = COMB_PortList.Text;
            SerialPort1.BaudRate = Convert.ToInt16(COMB_Baud.Text);
            switch (COMB_Dpaity.Text.ToUpper())
            {
                case "NONE":
                    SerialPort1.Parity = System.IO.Ports.Parity.None;
                    break;
                case "ODD":
                    SerialPort1.Parity = System.IO.Ports.Parity.Odd;
                    break;
                case "EVEN":
                    SerialPort1.Parity = System.IO.Ports.Parity.Even;
                    break;
                case "MARK":
                    SerialPort1.Parity = System.IO.Ports.Parity.Mark;
                    break;
                case "SPACE":
                    SerialPort1.Parity = System.IO.Ports.Parity.Space;
                    break;
            }
            SerialPort1.DataBits = Convert.ToInt16(COMB_DataB.Text);

            switch (COMB_StopB.Text.ToUpper())
            {
                case "1":
                    SerialPort1.StopBits = System.IO.Ports.StopBits.One;
                    break;
                case "1.5":
                    SerialPort1.StopBits = System.IO.Ports.StopBits.OnePointFive;
                    break;
                case "2":
                    SerialPort1.StopBits = System.IO.Ports.StopBits.Two;
                    break;
            }

            try
            {
                SerialPort1.Open();

                StatusChange(false);
                
            }
            catch(Exception e)
            {
                toolStripStatusLabel1.Text = e.Message;
            }
           
            

        }
        private void Stop()
        {
            if (B_Start == true)
            {
                StatusChange(true);
                SerialPort1.Close(); 
            }
        }

        private void StatusChange(Boolean status)
        {
            B_Start = !status;
            COMB_PortList.Enabled = status;
            COMB_Dpaity.Enabled = status;
            COMB_Baud.Enabled = status;
            COMB_DataB.Enabled = status;
            COMB_StopB.Enabled = status;
            if (SerialPort1.IsOpen)
            {
                toolStripStatusLabel1.Text = "Port Opened";
            }
            else
            {
                toolStripStatusLabel1.Text = "Port Closed";
            }
            if (!status)
            {
                B_Connect.Text = "Close";
            }
            else
            {
                B_Connect.Text = "Open";
            }
        }

        
        private void DateTransThread()
        {
            while (B_Start)
            {

                Thread.Sleep(10);
            }
            
        }


     

        private void timer1_Tick(object sender, EventArgs e)
        {
            //RefreshRecieve();
        }

        private void SerialPort1_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
            toolStripStatusLabel2.Text = "Recieve Error";
        }

        

        private  void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (SerialPort1.IsOpen)     //此处可能没有必要判断是否打开串口，但为了严谨性，我还是加上了  
            {
                //等待硬件传输完所有消息
                Thread.Sleep(10);
                //byte[] byteRead = new byte[SerialPort1.BytesToRead];    //BytesToRead:sp1接收的字符个数  
                //if (CB_RHEX.Checked==false)                          //'发送字符串'单选按钮  
                //{
                //    try
                //    {
                //        Byte[] receivedData = new Byte[SerialPort1.BytesToRead];        //创建接收字节数组  
                //        SerialPort1.Read(receivedData, 0, receivedData.Length);
                //        string strRcv = null;
                        
                //        strRcv = Encoding.Default.GetString(receivedData);
                //        TB_recieve.AppendText(string.Format("{0:HH:mm:ss:ffff}", DateTime.Now) + " :  " +  strRcv + "\r\n");

                //        //TB_recieve.Text += SerialPort1.ReadLine() + "\r\n"; //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果  
                //        //SerialPort1.DiscardInBuffer();                      //清空SerialPort控件的Buffer   
                //    }
                //    catch(Exception ex)
                //    {
                //        MessageBox.Show(ex.Message, "出错提示");
                //    }
                //}
                //else                                            //'发送16进制按钮'  
                //{
                    try
                    {
                        Byte[] receivedData = new Byte[SerialPort1.BytesToRead];        //创建接收字节数组  
                        SerialPort1.Read(receivedData, 0, receivedData.Length);         //读取数据                         
                        SerialPort1.DiscardInBuffer();                                  //清空SerialPort控件的Buffer  
                        string strRcv = null;

                        strRcv = Encoding.Default.GetString(receivedData);
                        TB_recieve.AppendText(string.Format("{0:HH:mm:ss:ffff}", DateTime.Now) + " :  " + strRcv + "\r\n");

                        //TB_Recieve_HEX.Text += SerialPort1.ReadLine() + "\r\n";

                        strRcv = null;
                        for (int i = 0; i < receivedData.Length; i++) //窗体显示  
                        {

                            strRcv += " " +  receivedData[i].ToString("X2");  //16进制显示  
                        }
                        TB_Recieve_HEX.AppendText(string.Format("{0:HH:mm:ss:ffff}", DateTime.Now) + "(HEX) :  " + strRcv + "\r\n");
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "出错提示");
                        
                    }
                //}
            }
            else
            {
                MessageBox.Show("请打开某个串口", "错误提示");
            }
        }

        private void B_clear_Click(object sender, EventArgs e)
        {
            TB_recieve.Text = "";
        }

        private string chr(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                return (strCharacter);
            }
            else
            {
                throw new Exception("ASCII Code is not valid.");
            }

        }

        private void B_Send_Click(object sender, EventArgs e)
        {
            string text;
            string[] line = null;
            char[] returnchar = { '\r', '\n' };
            text = TB_send.Text;
            line = text.Split(returnchar);
            if (line[0]!= "")
            {
                SendText(line[0]);
            }
            if (line.Length == 1)
            {
                TB_send.Text = "";
            }
            else
            {
                List<string> t =  line.ToList<string>();
                t.RemoveAt(0);
                string tmp = "";
                foreach(string i in t)
                {
                    if (i == "" || i == null) continue;
                    tmp += i + "\r\n";
                    
                }
                TB_send.Text = tmp;

            }


            
        }

        private void SendText(string text)
        {
            if (!SerialPort1.IsOpen) //如果没打开   
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            String strSend = text;
            if (CB_SHEX.Checked == true) //“16进制发送” 按钮   
            {
                //处理数字转换，目的是将输入的字符按空格、“，”等分组，以便发送数据时的方便（此处转的比较麻烦，有高见者，请指点！）   
                string sendBuf = strSend; string sendnoNull = sendBuf.Trim();
                string sendNOComma = sendnoNull.Replace(',', ' '); //去掉英文逗号 
                string sendNOComma1 = sendNOComma.Replace('，', ' '); //去掉中文逗号   
                string strSendNoComma2 = sendNOComma1.Replace("0x", ""); //去掉0x   
                strSendNoComma2 = strSendNoComma2.Replace("0X", ""); //去掉0X   
                //string[] tmp = strSendNoComma2.Split(' ');
                //strSendNoComma2 = "";
                //foreach ( string i in tmp)
                //{
                //    if (i.Length >2)
                //    {

                //    }
                //    strSendNoComma2 += 
                //}

                string[] strArray = strSendNoComma2.Split(' ');  //strArray数组中会出现“”空字符的情况，影响下面的赋值操作，故将byteBufferLength相应减小 
                
                  
                int byteBufferLength = strArray.Length;
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] == "")
                    {
                        byteBufferLength--;
                    }
                }
                byte[] byteBuffer = new byte[byteBufferLength];
                int ii = 0; //用于给byteBuffer赋值 >  
                for (int i = 0; i < strArray.Length; i++)        //对获取的字符做相加运算
                {

                    Byte[] bytesOfStr = Encoding.Default.GetBytes(strArray[i]);

                    int decNum = 0;
                    if (strArray[i] == "")
                    {
                        //ii--;     //加上此句是错误的，下面的continue以延缓了一个ii，不与i同步
                        continue;
                    }
                    else
                    {
                        decNum = Convert.ToInt32(strArray[i], 16); //atrArray[i] == 12时，temp == 18 
                    }

                    try    //防止输错，使其只能输入一个字节的字符
                    {
                        byteBuffer[ii] = Convert.ToByte(decNum);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                        return;
                    }

                    ii++;
                }
                SerialPort1.Write(byteBuffer, 0, byteBuffer.Length);
            }
            else		//以字符串形式发送时 
            {
                SerialPort1.WriteLine(text);    //写入数据
            }
        }
        
        private void TB_Recieve_HEX_TextChanged(object sender, EventArgs e)
        {
            ScroToLastRow(TB_Recieve_HEX);
        }
    }
}
