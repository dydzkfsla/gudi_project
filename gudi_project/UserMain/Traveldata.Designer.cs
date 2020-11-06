namespace gudi_project
{
    partial class Traveldata
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lbl_trv_name = new System.Windows.Forms.Label();
            this.lbl_trv_addr = new System.Windows.Forms.Label();
            this.tbx_trv_data = new System.Windows.Forms.TextBox();
            this.pcb_trv_img = new System.Windows.Forms.PictureBox();
            this.lbl_trv_tel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_trv_img)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(22, 24);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(18, 16);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(319, 243);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // lbl_trv_name
            // 
            this.lbl_trv_name.AutoSize = true;
            this.lbl_trv_name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_trv_name.Location = new System.Drawing.Point(372, 25);
            this.lbl_trv_name.Name = "lbl_trv_name";
            this.lbl_trv_name.Size = new System.Drawing.Size(52, 21);
            this.lbl_trv_name.TabIndex = 1;
            this.lbl_trv_name.Text = "label1";
            // 
            // lbl_trv_addr
            // 
            this.lbl_trv_addr.AutoSize = true;
            this.lbl_trv_addr.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_trv_addr.Location = new System.Drawing.Point(372, 84);
            this.lbl_trv_addr.Name = "lbl_trv_addr";
            this.lbl_trv_addr.Size = new System.Drawing.Size(52, 21);
            this.lbl_trv_addr.TabIndex = 2;
            this.lbl_trv_addr.Text = "label2";
            // 
            // tbx_trv_data
            // 
            this.tbx_trv_data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_trv_data.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_trv_data.Location = new System.Drawing.Point(363, 280);
            this.tbx_trv_data.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbx_trv_data.Multiline = true;
            this.tbx_trv_data.Name = "tbx_trv_data";
            this.tbx_trv_data.Size = new System.Drawing.Size(324, 286);
            this.tbx_trv_data.TabIndex = 3;
            // 
            // pcb_trv_img
            // 
            this.pcb_trv_img.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcb_trv_img.Location = new System.Drawing.Point(22, 280);
            this.pcb_trv_img.Name = "pcb_trv_img";
            this.pcb_trv_img.Size = new System.Drawing.Size(319, 286);
            this.pcb_trv_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb_trv_img.TabIndex = 4;
            this.pcb_trv_img.TabStop = false;
            // 
            // lbl_trv_tel
            // 
            this.lbl_trv_tel.AutoSize = true;
            this.lbl_trv_tel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_trv_tel.Location = new System.Drawing.Point(372, 143);
            this.lbl_trv_tel.Name = "lbl_trv_tel";
            this.lbl_trv_tel.Size = new System.Drawing.Size(52, 21);
            this.lbl_trv_tel.TabIndex = 5;
            this.lbl_trv_tel.Text = "label2";
            // 
            // Traveldata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(758, 595);
            this.Controls.Add(this.lbl_trv_tel);
            this.Controls.Add(this.pcb_trv_img);
            this.Controls.Add(this.tbx_trv_data);
            this.Controls.Add(this.lbl_trv_addr);
            this.Controls.Add(this.lbl_trv_name);
            this.Controls.Add(this.webBrowser1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Traveldata";
            this.Text = "Travel";
            this.Load += new System.EventHandler(this.Traveldata_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcb_trv_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label lbl_trv_name;
        private System.Windows.Forms.Label lbl_trv_addr;
        private System.Windows.Forms.TextBox tbx_trv_data;
        private System.Windows.Forms.PictureBox pcb_trv_img;
        private System.Windows.Forms.Label lbl_trv_tel;
    }
}