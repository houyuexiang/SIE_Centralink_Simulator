using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;


namespace Simulator.ClassLib
{

    static class GlobalValue
    {
        public static ConnectValue[] connectvalue = new ConnectValue[100];

        public static string ENQ = chr(5), ACK = chr(6), STX = chr(2), ETX = chr(3), EOT = chr(4), LF = chr(10), CR = chr(13), NAK = chr(21), ETB = chr(23), FS = chr(28), GS = chr(29);
        private static string[] ASCII = new string[9] { ENQ, ACK, STX, ETX, ETB, LF, CR, EOT, NAK };
        private static List<string> list = ASCII.ToList();
        public static string LogPath = System.Environment.CurrentDirectory + "\\LOG\\";
        public static string NewFormName;
        public static Boolean EnableReg;
        public static DataBaseSQLite DatabaseConnect;


        private static string chr(int asciiCode)
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
        public static int CreateFolder(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            if (info.Exists)
            {
                return 0;
            }
            else
            {
                try
                {
                    info.Create();
                    return 0;
                }
                catch
                {
                    return -1;
                }
            }
        }
        public static void WriteLog(string log, string logfile)
        {

            StreamWriter sw = new StreamWriter(logfile, true);
            sw.WriteLine(log);
            sw.Close();
        }
        public static string ReplaceASCII(string msg)
        {
            string Stemp, Sreplace;
            int pos;
            Stemp = msg;
            foreach (string a in list)
            {
                pos = msg.IndexOf(a);
                if (pos > 0)
                {
                    Sreplace = TransASCII(a);
                    Stemp = Stemp.Replace(a, Sreplace);
                }
            }
            return Stemp;

        }
        private static string TransASCII(string ascii)
        {
            string Sreturn = "";
            if (ascii == ENQ)
            {
                Sreturn = "<ENQ>";
            }
            else if (ascii == ACK)
            {
                Sreturn = "<ACK>";
            }
            else if (ascii == STX)
            {
                Sreturn = "<STX>";
            }
            else if (ascii == ETX)
            {
                Sreturn = "<ETX>";
            }
            else if (ascii == ETB)
            {
                Sreturn = "<ETB>";
            }
            else if (ascii == LF)
            {
                Sreturn = "<LF>";
            }
            else if (ascii == CR)
            {
                Sreturn = "<CR>";
            }
            else if (ascii == EOT)
            {
                Sreturn = "<EOT>";
            }
            else if (ascii == NAK)
            {
                Sreturn = "<NAK>";
            }
            return Sreturn;
        }

        public static void InitialValue()
        {
            string Databasepath;
            Databasepath = Directory.GetCurrentDirectory() + "\\QCOnTrack.DB";
            DatabaseConnect = new DataBaseSQLite(Databasepath);
        }

        #region 注册表操作
        public static void RegOutPut(string FileName, string RegPath)
        {
            if (File.Exists(FileName))
            {
                DialogResult result = MessageBox.Show("The file already exists,do you want to replace?", "Attention!", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel) return;
            }
            Process.Start("regedit", " /E " + FileName + " " + RegPath);

        }
        public static void RegImport(string FileName, string RegPath)
        {
            if (File.Exists(FileName) == false)
            {
                DialogResult result = MessageBox.Show("The file dosn't exists", "Attention!");
                return;
            }
            Process.Start("regedit", " /C " + FileName + " " + RegPath);
            //Process.Start("regedit", string.Format(" /C {0} {1}", FileName, RegPath));
        }
        public static void RegPathDelete(string Regpath, string dkeys)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(Regpath, true);
                key.DeleteSubKeyTree(dkeys);
                key.Close();
            }
            catch
            {
                return;
            }
        }
        #endregion



    }
    struct ConnectValue
    {
        public Int32 Index;
        public ClassLib.TCPConnect connect;
        public QCOnTrack.TranslateUnit InstrForm;
        public string FormName;
        public Boolean FormEnable, IsHiden;
        public ConnectParm ConParm;
        
        public void Setnull()
        {
            Index = 0;
            connect = null;
            InstrForm = null;
            FormName = null;
            FormEnable = false;
            IsHiden = false;
        }
        public void LoadConnectParm()
        {
            string sql;
            if (GlobalValue.DatabaseConnect != null)
            {

                string p = GlobalValue.DatabaseConnect.GetValue("setup", "indexs", "indexs = " + Index);



            }
        }

        


    }
    public struct ConnectParm
    {
        public string CTCPType,ITCPType, CCIPaddress, CCPORT, CSPORT, ICCIPaddress, ICPORT, ISPORT,RebootTime;
        public Boolean IsNeedReboot;
        public void InitValue()
        {
            
            CTCPType = "";
            ITCPType = "";
            CCIPaddress = "";
            CCPORT = "";
            CSPORT = "";
            ICCIPaddress = "";
            ICPORT = "";
            ISPORT = "";
            RebootTime = "00:00";
            IsNeedReboot = false;
        }
    }
}

