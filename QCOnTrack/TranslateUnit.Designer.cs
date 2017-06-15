namespace QCOnTrack
{
    partial class TranslateUnit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_CRPORT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_CRIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_CSPORT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RB_CClient = new System.Windows.Forms.RadioButton();
            this.RB_CServer = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TB_IRPORT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_IRIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_ISPORT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RB_IClient = new System.Windows.Forms.RadioButton();
            this.RB_IServer = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Centralink_SampleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Instrument_SampleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SS_Instrument = new System.Windows.Forms.StatusStrip();
            this.SS_Centralink = new System.Windows.Forms.StatusStrip();
            this.T_Picker = new System.Windows.Forms.DateTimePicker();
            this.B_NeedReboot = new System.Windows.Forms.CheckBox();
            this.TSSL_Centralink = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSSL_Instrument = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SS_Instrument.SuspendLayout();
            this.SS_Centralink.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TB_CRPORT);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TB_CRIP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TB_CSPORT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.RB_CClient);
            this.groupBox1.Controls.Add(this.RB_CServer);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Centralink";
            // 
            // TB_CRPORT
            // 
            this.TB_CRPORT.Location = new System.Drawing.Point(101, 117);
            this.TB_CRPORT.Name = "TB_CRPORT";
            this.TB_CRPORT.Size = new System.Drawing.Size(122, 21);
            this.TB_CRPORT.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Remote Port";
            // 
            // TB_CRIP
            // 
            this.TB_CRIP.Location = new System.Drawing.Point(101, 90);
            this.TB_CRIP.Name = "TB_CRIP";
            this.TB_CRIP.Size = new System.Drawing.Size(122, 21);
            this.TB_CRIP.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Remote IP";
            // 
            // TB_CSPORT
            // 
            this.TB_CSPORT.Location = new System.Drawing.Point(101, 63);
            this.TB_CSPORT.Name = "TB_CSPORT";
            this.TB_CSPORT.Size = new System.Drawing.Size(122, 21);
            this.TB_CSPORT.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server Port";
            // 
            // RB_CClient
            // 
            this.RB_CClient.AutoSize = true;
            this.RB_CClient.Location = new System.Drawing.Point(128, 21);
            this.RB_CClient.Name = "RB_CClient";
            this.RB_CClient.Size = new System.Drawing.Size(59, 16);
            this.RB_CClient.TabIndex = 1;
            this.RB_CClient.Text = "Client";
            this.RB_CClient.UseVisualStyleBackColor = true;
            this.RB_CClient.CheckedChanged += new System.EventHandler(this.RB_CClient_CheckedChanged);
            // 
            // RB_CServer
            // 
            this.RB_CServer.AutoSize = true;
            this.RB_CServer.Checked = true;
            this.RB_CServer.Location = new System.Drawing.Point(17, 21);
            this.RB_CServer.Name = "RB_CServer";
            this.RB_CServer.Size = new System.Drawing.Size(59, 16);
            this.RB_CServer.TabIndex = 0;
            this.RB_CServer.TabStop = true;
            this.RB_CServer.Text = "Server";
            this.RB_CServer.UseVisualStyleBackColor = true;
            this.RB_CServer.CheckedChanged += new System.EventHandler(this.RB_CServer_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TB_IRPORT);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TB_IRIP);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TB_ISPORT);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.RB_IClient);
            this.groupBox2.Controls.Add(this.RB_IServer);
            this.groupBox2.Location = new System.Drawing.Point(276, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 163);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Instrument";
            // 
            // TB_IRPORT
            // 
            this.TB_IRPORT.Location = new System.Drawing.Point(101, 117);
            this.TB_IRPORT.Name = "TB_IRPORT";
            this.TB_IRPORT.Size = new System.Drawing.Size(122, 21);
            this.TB_IRPORT.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Remote Port";
            // 
            // TB_IRIP
            // 
            this.TB_IRIP.Location = new System.Drawing.Point(101, 90);
            this.TB_IRIP.Name = "TB_IRIP";
            this.TB_IRIP.Size = new System.Drawing.Size(122, 21);
            this.TB_IRIP.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Remote IP";
            // 
            // TB_ISPORT
            // 
            this.TB_ISPORT.Location = new System.Drawing.Point(101, 63);
            this.TB_ISPORT.Name = "TB_ISPORT";
            this.TB_ISPORT.Size = new System.Drawing.Size(122, 21);
            this.TB_ISPORT.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "Server Port";
            // 
            // RB_IClient
            // 
            this.RB_IClient.AutoSize = true;
            this.RB_IClient.Checked = true;
            this.RB_IClient.Location = new System.Drawing.Point(128, 21);
            this.RB_IClient.Name = "RB_IClient";
            this.RB_IClient.Size = new System.Drawing.Size(59, 16);
            this.RB_IClient.TabIndex = 1;
            this.RB_IClient.TabStop = true;
            this.RB_IClient.Text = "Client";
            this.RB_IClient.UseVisualStyleBackColor = true;
            this.RB_IClient.CheckedChanged += new System.EventHandler(this.RB_IClient_CheckedChanged);
            // 
            // RB_IServer
            // 
            this.RB_IServer.AutoSize = true;
            this.RB_IServer.Location = new System.Drawing.Point(17, 21);
            this.RB_IServer.Name = "RB_IServer";
            this.RB_IServer.Size = new System.Drawing.Size(59, 16);
            this.RB_IServer.TabIndex = 0;
            this.RB_IServer.Text = "Server";
            this.RB_IServer.UseVisualStyleBackColor = true;
            this.RB_IServer.CheckedChanged += new System.EventHandler(this.RB_IServer_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seq,
            this.Centralink_SampleID,
            this.Instrument_SampleID});
            this.dataGridView1.Location = new System.Drawing.Point(529, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(372, 163);
            this.dataGridView1.TabIndex = 9;
            // 
            // Seq
            // 
            this.Seq.HeaderText = "";
            this.Seq.Name = "Seq";
            this.Seq.ReadOnly = true;
            // 
            // Centralink_SampleID
            // 
            this.Centralink_SampleID.HeaderText = "Centralink SampleID";
            this.Centralink_SampleID.Name = "Centralink_SampleID";
            // 
            // Instrument_SampleID
            // 
            this.Instrument_SampleID.HeaderText = "Instrument SampleID";
            this.Instrument_SampleID.Name = "Instrument_SampleID";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(13, 182);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(437, 278);
            this.textBox7.TabIndex = 10;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(463, 182);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(438, 278);
            this.textBox8.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 474);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(493, 474);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(673, 474);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(826, 474);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // SS_Instrument
            // 
            this.SS_Instrument.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSL_Instrument});
            this.SS_Instrument.Location = new System.Drawing.Point(0, 548);
            this.SS_Instrument.Name = "SS_Instrument";
            this.SS_Instrument.Size = new System.Drawing.Size(914, 22);
            this.SS_Instrument.TabIndex = 16;
            this.SS_Instrument.Text = "statusStrip1";
            // 
            // SS_Centralink
            // 
            this.SS_Centralink.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSL_Centralink,
            this.toolStripStatusLabel1});
            this.SS_Centralink.Location = new System.Drawing.Point(0, 526);
            this.SS_Centralink.Name = "SS_Centralink";
            this.SS_Centralink.Size = new System.Drawing.Size(914, 22);
            this.SS_Centralink.TabIndex = 17;
            this.SS_Centralink.Text = "statusStrip2";
            // 
            // T_Picker
            // 
            this.T_Picker.CustomFormat = "HH:mm";
            this.T_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.T_Picker.Location = new System.Drawing.Point(136, 474);
            this.T_Picker.Name = "T_Picker";
            this.T_Picker.ShowUpDown = true;
            this.T_Picker.Size = new System.Drawing.Size(64, 21);
            this.T_Picker.TabIndex = 18;
            this.T_Picker.ValueChanged += new System.EventHandler(this.T_Picker_ValueChanged);
            // 
            // B_NeedReboot
            // 
            this.B_NeedReboot.AutoSize = true;
            this.B_NeedReboot.Location = new System.Drawing.Point(16, 477);
            this.B_NeedReboot.Name = "B_NeedReboot";
            this.B_NeedReboot.Size = new System.Drawing.Size(114, 16);
            this.B_NeedReboot.TabIndex = 19;
            this.B_NeedReboot.Text = "Reboot Schedule";
            this.B_NeedReboot.UseVisualStyleBackColor = true;
            this.B_NeedReboot.CheckedChanged += new System.EventHandler(this.B_NeedReboot_CheckedChanged);
            // 
            // TSSL_Centralink
            // 
            this.TSSL_Centralink.Name = "TSSL_Centralink";
            this.TSSL_Centralink.Size = new System.Drawing.Size(66, 17);
            this.TSSL_Centralink.Text = "Centralink";
            // 
            // TSSL_Instrument
            // 
            this.TSSL_Instrument.Name = "TSSL_Instrument";
            this.TSSL_Instrument.Size = new System.Drawing.Size(70, 17);
            this.TSSL_Instrument.Text = "Instrument";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // TranslateUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 570);
            this.Controls.Add(this.B_NeedReboot);
            this.Controls.Add(this.T_Picker);
            this.Controls.Add(this.SS_Centralink);
            this.Controls.Add(this.SS_Instrument);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TranslateUnit";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TranslateUnit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.SS_Instrument.ResumeLayout(false);
            this.SS_Instrument.PerformLayout();
            this.SS_Centralink.ResumeLayout(false);
            this.SS_Centralink.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RB_CClient;
        private System.Windows.Forms.RadioButton RB_CServer;
        private System.Windows.Forms.TextBox TB_CRPORT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_CRIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_CSPORT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TB_IRPORT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_IRIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_ISPORT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton RB_IClient;
        private System.Windows.Forms.RadioButton RB_IServer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn Centralink_SampleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Instrument_SampleID;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.StatusStrip SS_Instrument;
        private System.Windows.Forms.StatusStrip SS_Centralink;
        private System.Windows.Forms.DateTimePicker T_Picker;
        private System.Windows.Forms.CheckBox B_NeedReboot;
        private System.Windows.Forms.ToolStripStatusLabel TSSL_Instrument;
        private System.Windows.Forms.ToolStripStatusLabel TSSL_Centralink;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

