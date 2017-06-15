namespace QCOnTrack
{
    partial class Sum
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sum));
            this.B_Add = new System.Windows.Forms.Button();
            this.Dgv_Sum = new System.Windows.Forms.DataGridView();
            this.Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Instrument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConnectStatue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hiden = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CloseInstrument = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CB_EnableReg = new System.Windows.Forms.CheckBox();
            this.B_Import = new System.Windows.Forms.Button();
            this.B_Output = new System.Windows.Forms.Button();
            this.B_Clean = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Sum)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Add
            // 
            this.B_Add.Location = new System.Drawing.Point(12, 277);
            this.B_Add.Name = "B_Add";
            this.B_Add.Size = new System.Drawing.Size(20, 23);
            this.B_Add.TabIndex = 0;
            this.B_Add.Text = "+";
            this.B_Add.UseVisualStyleBackColor = true;
            this.B_Add.Click += new System.EventHandler(this.B_Add_Click);
            // 
            // Dgv_Sum
            // 
            this.Dgv_Sum.AllowUserToAddRows = false;
            this.Dgv_Sum.AllowUserToDeleteRows = false;
            this.Dgv_Sum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Sum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enable,
            this.Seq,
            this.Instrument,
            this.ConnectStatue,
            this.Hiden,
            this.CloseInstrument,
            this.Delete});
            this.Dgv_Sum.Location = new System.Drawing.Point(12, 12);
            this.Dgv_Sum.Name = "Dgv_Sum";
            this.Dgv_Sum.RowTemplate.Height = 23;
            this.Dgv_Sum.Size = new System.Drawing.Size(640, 288);
            this.Dgv_Sum.TabIndex = 1;
            this.Dgv_Sum.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Sum_CellClick);
            this.Dgv_Sum.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Sum_CellContentClick);
            this.Dgv_Sum.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Sum_CellMouseEnter);
            // 
            // Enable
            // 
            this.Enable.HeaderText = "Enable";
            this.Enable.Name = "Enable";
            this.Enable.Width = 50;
            // 
            // Seq
            // 
            this.Seq.HeaderText = "Seq";
            this.Seq.Name = "Seq";
            this.Seq.ReadOnly = true;
            this.Seq.Width = 30;
            // 
            // Instrument
            // 
            this.Instrument.HeaderText = "InstrumentName";
            this.Instrument.Name = "Instrument";
            this.Instrument.ReadOnly = true;
            // 
            // ConnectStatue
            // 
            this.ConnectStatue.HeaderText = "Statue";
            this.ConnectStatue.Name = "ConnectStatue";
            this.ConnectStatue.ReadOnly = true;
            // 
            // Hiden
            // 
            this.Hiden.HeaderText = "Hide\\Show";
            this.Hiden.Name = "Hiden";
            this.Hiden.ReadOnly = true;
            // 
            // CloseInstrument
            // 
            this.CloseInstrument.HeaderText = "Close\\Start";
            this.CloseInstrument.Name = "CloseInstrument";
            this.CloseInstrument.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CB_EnableReg
            // 
            this.CB_EnableReg.AutoSize = true;
            this.CB_EnableReg.Location = new System.Drawing.Point(12, 318);
            this.CB_EnableReg.Name = "CB_EnableReg";
            this.CB_EnableReg.Size = new System.Drawing.Size(126, 16);
            this.CB_EnableReg.TabIndex = 2;
            this.CB_EnableReg.Text = "Load Last Setting";
            this.CB_EnableReg.UseVisualStyleBackColor = true;
            this.CB_EnableReg.CheckedChanged += new System.EventHandler(this.CB_EnableReg_CheckedChanged);
            // 
            // B_Import
            // 
            this.B_Import.Location = new System.Drawing.Point(177, 314);
            this.B_Import.Name = "B_Import";
            this.B_Import.Size = new System.Drawing.Size(100, 23);
            this.B_Import.TabIndex = 3;
            this.B_Import.Text = "Import Setting";
            this.B_Import.UseVisualStyleBackColor = true;
            this.B_Import.Click += new System.EventHandler(this.B_Import_Click);
            // 
            // B_Output
            // 
            this.B_Output.Location = new System.Drawing.Point(352, 314);
            this.B_Output.Name = "B_Output";
            this.B_Output.Size = new System.Drawing.Size(121, 23);
            this.B_Output.TabIndex = 4;
            this.B_Output.Text = "Output Setting";
            this.B_Output.UseVisualStyleBackColor = true;
            this.B_Output.Click += new System.EventHandler(this.B_Output_Click);
            // 
            // B_Clean
            // 
            this.B_Clean.Location = new System.Drawing.Point(509, 314);
            this.B_Clean.Name = "B_Clean";
            this.B_Clean.Size = new System.Drawing.Size(105, 23);
            this.B_Clean.TabIndex = 5;
            this.B_Clean.Text = "Clean Regist";
            this.B_Clean.UseVisualStyleBackColor = true;
            this.B_Clean.Click += new System.EventHandler(this.B_Clean_Click);
            // 
            // Sum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 349);
            this.Controls.Add(this.B_Clean);
            this.Controls.Add(this.B_Output);
            this.Controls.Add(this.B_Import);
            this.Controls.Add(this.CB_EnableReg);
            this.Controls.Add(this.B_Add);
            this.Controls.Add(this.Dgv_Sum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sum";
            this.Load += new System.EventHandler(this.Sum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Sum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Add;
        private System.Windows.Forms.DataGridView Dgv_Sum;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn Instrument;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConnectStatue;
        private System.Windows.Forms.DataGridViewButtonColumn Hiden;
        private System.Windows.Forms.DataGridViewButtonColumn CloseInstrument;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox CB_EnableReg;
        private System.Windows.Forms.Button B_Import;
        private System.Windows.Forms.Button B_Output;
        private System.Windows.Forms.Button B_Clean;
    }
}