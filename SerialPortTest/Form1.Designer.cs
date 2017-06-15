namespace SerialPortTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SerialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.COMB_PortList = new System.Windows.Forms.ComboBox();
            this.COMB_Baud = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.COMB_Dpaity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.COMB_DataB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.COMB_StopB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CB_SHEX = new System.Windows.Forms.CheckBox();
            this.CB_RHEX = new System.Windows.Forms.CheckBox();
            this.B_Connect = new System.Windows.Forms.Button();
            this.TB_recieve = new System.Windows.Forms.TextBox();
            this.B_Send = new System.Windows.Forms.Button();
            this.TB_send = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.B_clear = new System.Windows.Forms.Button();
            this.TB_Recieve_HEX = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SerialPort1
            // 
            this.SerialPort1.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.SerialPort1_ErrorReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "PortNum";
            // 
            // COMB_PortList
            // 
            this.COMB_PortList.FormattingEnabled = true;
            this.COMB_PortList.Location = new System.Drawing.Point(59, 12);
            this.COMB_PortList.Name = "COMB_PortList";
            this.COMB_PortList.Size = new System.Drawing.Size(90, 20);
            this.COMB_PortList.TabIndex = 1;
            // 
            // COMB_Baud
            // 
            this.COMB_Baud.FormattingEnabled = true;
            this.COMB_Baud.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.COMB_Baud.Location = new System.Drawing.Point(58, 40);
            this.COMB_Baud.Name = "COMB_Baud";
            this.COMB_Baud.Size = new System.Drawing.Size(121, 20);
            this.COMB_Baud.TabIndex = 3;
            this.COMB_Baud.Text = "9600";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "BaudR";
            // 
            // COMB_Dpaity
            // 
            this.COMB_Dpaity.FormattingEnabled = true;
            this.COMB_Dpaity.Items.AddRange(new object[] {
            "NONE",
            "ODD",
            "EVEN",
            "MARK",
            "SPACE"});
            this.COMB_Dpaity.Location = new System.Drawing.Point(58, 66);
            this.COMB_Dpaity.Name = "COMB_Dpaity";
            this.COMB_Dpaity.Size = new System.Drawing.Size(121, 20);
            this.COMB_Dpaity.TabIndex = 5;
            this.COMB_Dpaity.Text = "NONE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "DPaity";
            // 
            // COMB_DataB
            // 
            this.COMB_DataB.FormattingEnabled = true;
            this.COMB_DataB.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.COMB_DataB.Location = new System.Drawing.Point(58, 92);
            this.COMB_DataB.Name = "COMB_DataB";
            this.COMB_DataB.Size = new System.Drawing.Size(121, 20);
            this.COMB_DataB.TabIndex = 7;
            this.COMB_DataB.Text = "8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "DataB";
            // 
            // COMB_StopB
            // 
            this.COMB_StopB.FormattingEnabled = true;
            this.COMB_StopB.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.COMB_StopB.Location = new System.Drawing.Point(58, 118);
            this.COMB_StopB.Name = "COMB_StopB";
            this.COMB_StopB.Size = new System.Drawing.Size(121, 20);
            this.COMB_StopB.TabIndex = 9;
            this.COMB_StopB.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "StopB";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_SHEX);
            this.groupBox1.Controls.Add(this.CB_RHEX);
            this.groupBox1.Location = new System.Drawing.Point(15, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 73);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option";
            // 
            // CB_SHEX
            // 
            this.CB_SHEX.AutoSize = true;
            this.CB_SHEX.Location = new System.Drawing.Point(6, 21);
            this.CB_SHEX.Name = "CB_SHEX";
            this.CB_SHEX.Size = new System.Drawing.Size(90, 16);
            this.CB_SHEX.TabIndex = 1;
            this.CB_SHEX.Text = "Send AS HEX";
            this.CB_SHEX.UseVisualStyleBackColor = true;
            // 
            // CB_RHEX
            // 
            this.CB_RHEX.AutoSize = true;
            this.CB_RHEX.Location = new System.Drawing.Point(6, 43);
            this.CB_RHEX.Name = "CB_RHEX";
            this.CB_RHEX.Size = new System.Drawing.Size(108, 16);
            this.CB_RHEX.TabIndex = 0;
            this.CB_RHEX.Text = "Recieve AS HEX";
            this.CB_RHEX.UseVisualStyleBackColor = true;
            this.CB_RHEX.Visible = false;
            // 
            // B_Connect
            // 
            this.B_Connect.Location = new System.Drawing.Point(14, 144);
            this.B_Connect.Name = "B_Connect";
            this.B_Connect.Size = new System.Drawing.Size(167, 80);
            this.B_Connect.TabIndex = 11;
            this.B_Connect.Text = "Open";
            this.B_Connect.UseVisualStyleBackColor = true;
            this.B_Connect.Click += new System.EventHandler(this.B_Connect_Click);
            // 
            // TB_recieve
            // 
            this.TB_recieve.Location = new System.Drawing.Point(187, 5);
            this.TB_recieve.Multiline = true;
            this.TB_recieve.Name = "TB_recieve";
            this.TB_recieve.ReadOnly = true;
            this.TB_recieve.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_recieve.Size = new System.Drawing.Size(377, 262);
            this.TB_recieve.TabIndex = 12;
            this.TB_recieve.TextChanged += new System.EventHandler(this.TB_recieve_TextChanged);
            // 
            // B_Send
            // 
            this.B_Send.Location = new System.Drawing.Point(570, 551);
            this.B_Send.Name = "B_Send";
            this.B_Send.Size = new System.Drawing.Size(377, 23);
            this.B_Send.TabIndex = 13;
            this.B_Send.Text = "Send";
            this.B_Send.UseVisualStyleBackColor = true;
            this.B_Send.Click += new System.EventHandler(this.B_Send_Click);
            // 
            // TB_send
            // 
            this.TB_send.AcceptsReturn = true;
            this.TB_send.AcceptsTab = true;
            this.TB_send.Location = new System.Drawing.Point(570, 5);
            this.TB_send.Multiline = true;
            this.TB_send.Name = "TB_send";
            this.TB_send.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_send.Size = new System.Drawing.Size(377, 540);
            this.TB_send.TabIndex = 14;
            this.TB_send.TextChanged += new System.EventHandler(this.TB_send_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "L";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 582);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(953, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // B_clear
            // 
            this.B_clear.Location = new System.Drawing.Point(187, 551);
            this.B_clear.Name = "B_clear";
            this.B_clear.Size = new System.Drawing.Size(75, 23);
            this.B_clear.TabIndex = 17;
            this.B_clear.Text = "Clear";
            this.B_clear.UseVisualStyleBackColor = true;
            this.B_clear.Click += new System.EventHandler(this.B_clear_Click);
            // 
            // TB_Recieve_HEX
            // 
            this.TB_Recieve_HEX.Location = new System.Drawing.Point(187, 273);
            this.TB_Recieve_HEX.Multiline = true;
            this.TB_Recieve_HEX.Name = "TB_Recieve_HEX";
            this.TB_Recieve_HEX.ReadOnly = true;
            this.TB_Recieve_HEX.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_Recieve_HEX.Size = new System.Drawing.Size(377, 272);
            this.TB_Recieve_HEX.TabIndex = 18;
            this.TB_Recieve_HEX.TextChanged += new System.EventHandler(this.TB_Recieve_HEX_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 604);
            this.Controls.Add(this.TB_Recieve_HEX);
            this.Controls.Add(this.B_clear);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TB_send);
            this.Controls.Add(this.B_Send);
            this.Controls.Add(this.TB_recieve);
            this.Controls.Add(this.B_Connect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.COMB_StopB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.COMB_DataB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.COMB_Dpaity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.COMB_Baud);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.COMB_PortList);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort SerialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox COMB_PortList;
        private System.Windows.Forms.ComboBox COMB_Baud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox COMB_Dpaity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox COMB_DataB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox COMB_StopB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CB_SHEX;
        private System.Windows.Forms.CheckBox CB_RHEX;
        private System.Windows.Forms.Button B_Connect;
        private System.Windows.Forms.TextBox TB_recieve;
        private System.Windows.Forms.Button B_Send;
        private System.Windows.Forms.TextBox TB_send;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button B_clear;
        private System.Windows.Forms.TextBox TB_Recieve_HEX;
    }
}

