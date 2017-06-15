﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Simulator.ClassLib
{
    class ASTM
    {
        public ClassLib.Connect TcpConnect;
        private string SendBuffer = "",ReceiveBuffer = "";
        private int SendBufferCount = 0,Sendindex = 0;
        private string[] SendBufferArray = new string[100];
        private string Receivemsg = "";
        private Thread TransThread;
        Boolean STOP = false;

        string LastRec = "", LastSend = "";
        Boolean BRec = false, BSend = false;

        string ACK = GlobalValue.ACK, ENQ = GlobalValue.ENQ, EOT = GlobalValue.EOT, STX = GlobalValue.STX,
            ETX = GlobalValue.ETX, CR = GlobalValue.CR, LF = GlobalValue.LF, NAK = GlobalValue.NAK,ETB = GlobalValue.ETB,FS = GlobalValue.FS,GS = GlobalValue.GS;
        
        

        public ASTM(ClassLib.Connect connect)
        {
            TcpConnect = connect;
            this.STOP = false;
            this.TransThread = new Thread(new ThreadStart(ASTMThread));
            this.TransThread.IsBackground = true;
            this.TransThread.Start();
        }
        public string sendbuffer
        {
            set
            {
                SendBuffer += value;
            }
        }
        public string receivebuffer
        {
            get
            {
                string temp = "";
                temp = ReceiveBuffer;
                ReceiveBuffer = "";
                return temp;
            }
        }
        public void Stop()
        {
            this.STOP = true;
        }
        private void ASTMThread()
        {
            while (!this.STOP)
            {
                Process();
                Thread.Sleep(10);
            }

        }



        private void Process()
        {
            string recievestr;
            #region process
                Receive();
                if (Receivemsg == "" || Receivemsg == null)
                {
                    //检测无数据传输后是否需要发送数据
                    if (BRec == false && SendBuffer != "" && BSend == false)
                    {
                        if (Receive() == "")
                        {
                            int Startpos, Endpos;
                            string temp, tempd;
                            Send(ENQ);
                            LastSend = ENQ;
                            BSend = true;
                            if (SendBufferCount > 0)
                            {
                                return;
                            }

                            Sendindex = 0;

                            Startpos = SendBuffer.IndexOf(FS);
                            Endpos = SendBuffer.IndexOf(GS);
                            temp = SendBuffer.Substring(Startpos + 1, Endpos - 1);
                            SendBuffer = SendBuffer.Substring(Endpos + 1);
                            Startpos = temp.IndexOf("[");
                            Endpos = temp.IndexOf("]");

                            while (Startpos >= 0 && Endpos >= 0)
                            {
                                tempd = temp.Substring(Startpos + 1, Endpos - 1);
                                temp = temp.Substring(Endpos + 1);
                                //tempd = MakeAstm(tempd);
                                if (tempd != "")
                                {
                                    //添加fn
                                    SendBufferArray[SendBufferCount] = ((SendBufferCount + 1)%8).ToString() + tempd;
                                    //添加计算校验
                                    SendBufferArray[SendBufferCount] = MakeAstm(SendBufferArray[SendBufferCount]) + CR + LF;
                                    SendBufferCount++;

                                }
                                Startpos = temp.IndexOf("[");
                                Endpos = temp.IndexOf("]");
                            }
                            SendBufferArray[SendBufferCount] = EOT;
                            SendBufferCount++;


                        }
                    }
                    return;
                }
                recievestr = Receivemsg.Substring(0, 1);
                //Receivemsg.Substring(0, 1);

                //发送完毕
                if (LastSend == EOT)
                {
                    BSend = false;
                }
                //

                //开始接收
                if (recievestr == ENQ)
                {
                    Send(ACK);
                    LastSend = ACK;
                    Receivemsg = Receivemsg.Substring(1);
                    LastRec = ENQ;
                    BRec = true;
                    return;
                }
                //发送数据
                else if (recievestr == ACK)
                {
                    Receivemsg = Receivemsg.Substring(1);

                    if (SendBufferArray[Sendindex] != "" && SendBufferArray[Sendindex] != null)
                    {
                        Send(SendBufferArray[Sendindex]);
                        LastSend = SendBufferArray[Sendindex];
                        if (SendBufferArray[Sendindex] == EOT)
                        {
                            BSend = false;
                        }
                        Sendindex++;
                        if (LastSend == EOT)
                        {
                            SendBufferCount = 0;
                        }
                        LastRec = ACK;
                    }
                }
                //数据接收完毕
                else if (recievestr == EOT)
                {
                    ReceiveBuffer += GS;
                    LastRec = EOT;
                    BRec = false;
                    Receivemsg = Receivemsg.Substring(1);
                }
                //重新发送数据
                else if (recievestr == NAK)
                {
                    Send(ENQ);
                    LastSend = ENQ;
                    Sendindex = 0;
                    LastRec = NAK;
                    BSend = true;
                    Receivemsg = Receivemsg.Substring(1);
                }
                else
                {
                    //接收数据
                    int Startpos, Endpos;





                    //处理接收到ETB的情况
                    //*[msgETB

                    Startpos = Receivemsg.IndexOf(ETB);
                    if (Startpos >= 0)
                    {
                        Endpos = Receivemsg.IndexOf(STX, Startpos);
                        while (Startpos >= 0 && Endpos > 0 && Endpos > Startpos)
                        {
                            Receivemsg = Receivemsg.Substring(0, Startpos - 1) + Receivemsg.Substring(Endpos + 1);
                            Startpos = Receivemsg.IndexOf(ETB);
                            Endpos = Receivemsg.IndexOf(STX, Startpos);
                        }
                    }

                    //

                    Endpos = Receivemsg.IndexOf(ETX);
                    Startpos = Receivemsg.IndexOf(STX);
                    
                    while (Endpos >= 0 && Startpos >= 0)
                    {
                        
                        if (LastRec == ENQ)
                        {
                            ReceiveBuffer += FS + "[" + Receivemsg.Substring(Startpos + 1, Endpos - 2) + "]";
                        }
                        else
                        {
                            ReceiveBuffer += "[" + Receivemsg.Substring(Startpos + 1, Endpos - 2) + "]";
                        }
                    LastRec = Receivemsg.Substring(Startpos + 1, Endpos - 2);
                        Endpos = Receivemsg.IndexOf(CR + LF);
                        Receivemsg = Receivemsg.Substring(Endpos + 2);
                        Endpos = Receivemsg.IndexOf(ETX);
                        Startpos = Receivemsg.IndexOf(STX);
                    }




                    //处理接收一半的情况
                    if (Endpos < 0 && Startpos >= 0)
                    {

                    }
                    else
                    {
                        Send(ACK);
                        LastSend = ACK;
                    }


                }

                int pos = 0;
                //垃圾数据处理
                if (BSend == true && BRec == false)
                {

                    pos = Receivemsg.IndexOf(ACK);
                    if (pos < 0)
                    {
                        Receivemsg = "";
                    }
                    else if (pos == 0)
                    {

                    }
                    else
                    {
                        Receivemsg.Substring(pos);
                    }
                }
                else if (BRec == true && BSend == false)
                {
                    if (Receivemsg.IndexOf(STX) < 0 && Receivemsg.IndexOf(ETX) < 0 && Receivemsg.IndexOf(LF) < 0 && Receivemsg.IndexOf(CR) < 0 && Receivemsg.IndexOf(EOT) < 0)
                    {
                        Receivemsg = "";
                    }
                    //if (Receivemsg.IndexOf(EOT) >= 0&& Receivemsg.IndexOf(LF) < 0&& Receivemsg.IndexOf(CR) < 0)
                    //{

                    //}
                }
                else
                {
                    pos = Receivemsg.IndexOf(ENQ);
                    if (pos < 0)
                    {
                        Receivemsg = "";
                        return ;
                    }
                }

                #endregion
            
        }
        private void Send(string msg)
        {
            //等待直到退出或可发送
            while (!TcpConnect.Canwrite)
            {
                if (STOP) return;
                Thread.Sleep(10);
            }
            TcpConnect.TcpSend(msg);
            LOG(msg, "S");
            
            

        }
        private string Receive()
        {
            string tmp = "";
            tmp = TcpConnect.TcpRead();
            if (tmp == "" || tmp == null)
            {
                return "";
            }
            Receivemsg += tmp;
            LOG(tmp, "R");
            //LastRec = tmp;
            
            return tmp;
            
        }

        private void LOG(string log,string type)
        {
            TcpConnect.LOG(log, type);
        }

        #region astm checksum 
        private string MakeAstm(string msg)
        {
            string msgtmp;
            msgtmp = msg + ETX;
            string Stemp = msgtmp, C1, C2;
            Int32 len, sum = 0, c1, c2;
            len = Stemp.Length;
            for (int i = 0; i < len; i++)
            {
                sum += ChartoAscii(Stemp[i].ToString());

            }
            sum = sum % 256;
            c1 = sum / 16;
            c2 = Convert.ToInt32((Convert.ToDecimal(sum) / 16 - (sum / 16)) * 16);
            C1 = IntToStr(c1);
            C2 = IntToStr(c2);
            Stemp += C1 + C2;
            Stemp = STX + Stemp;
            return Stemp;
        }


        private int ChartoAscii(string chr)
        {
            if (chr.Length == 1)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                int intAsciiCode = (int)asciiEncoding.GetBytes(chr)[0];
                return (intAsciiCode);
            }
            else
            {
                throw new Exception("Character is not valid.");
            }

            
        }
        private string IntToStr(int oct)
        {
            switch (oct)
            {
                case 10:
                    return "A";

                case 11:
                    return "B";

                case 12:
                    return "C";
                case 13:
                    return "D";
                case 14:
                    return "E";
                case 15:
                    return "F";
            }
            return oct.ToString();

        }
        #endregion




    }
}
