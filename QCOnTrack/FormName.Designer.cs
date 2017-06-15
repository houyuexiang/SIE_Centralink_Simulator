namespace QCOnTrack
{
    partial class FormName
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
            this.Tb_Instrname = new System.Windows.Forms.TextBox();
            this.B_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Tb_Instrname
            // 
            this.Tb_Instrname.Location = new System.Drawing.Point(12, 12);
            this.Tb_Instrname.Name = "Tb_Instrname";
            this.Tb_Instrname.Size = new System.Drawing.Size(189, 21);
            this.Tb_Instrname.TabIndex = 0;
            this.Tb_Instrname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormName_KeyDown);
            // 
            // B_OK
            // 
            this.B_OK.Location = new System.Drawing.Point(208, 11);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(75, 23);
            this.B_OK.TabIndex = 1;
            this.B_OK.Text = "OK";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // FormName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 44);
            this.Controls.Add(this.B_OK);
            this.Controls.Add(this.Tb_Instrname);
            this.Name = "FormName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormName";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormName_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Tb_Instrname;
        private System.Windows.Forms.Button B_OK;
    }
}