namespace gudi_project
{
    partial class Master_Mainfrm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.busMastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeMastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesMastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.travelMastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesMastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.busMastToolStripMenuItem,
            this.codeMastToolStripMenuItem,
            this.employeesMastToolStripMenuItem,
            this.travelMastToolStripMenuItem,
            this.salesMastToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1118, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // busMastToolStripMenuItem
            // 
            this.busMastToolStripMenuItem.Name = "busMastToolStripMenuItem";
            this.busMastToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.busMastToolStripMenuItem.Text = "Bus_Mast";
            this.busMastToolStripMenuItem.Click += new System.EventHandler(this.busMastToolStripMenuItem_Click);
            // 
            // codeMastToolStripMenuItem
            // 
            this.codeMastToolStripMenuItem.Name = "codeMastToolStripMenuItem";
            this.codeMastToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.codeMastToolStripMenuItem.Text = "Code_Mast";
            this.codeMastToolStripMenuItem.Click += new System.EventHandler(this.codeMastToolStripMenuItem_Click);
            // 
            // employeesMastToolStripMenuItem
            // 
            this.employeesMastToolStripMenuItem.Name = "employeesMastToolStripMenuItem";
            this.employeesMastToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.employeesMastToolStripMenuItem.Text = "Employees_Mast";
            this.employeesMastToolStripMenuItem.Click += new System.EventHandler(this.employeesMastToolStripMenuItem_Click);
            // 
            // travelMastToolStripMenuItem
            // 
            this.travelMastToolStripMenuItem.Name = "travelMastToolStripMenuItem";
            this.travelMastToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.travelMastToolStripMenuItem.Text = "Travel_Mast";
            this.travelMastToolStripMenuItem.Click += new System.EventHandler(this.travelMastToolStripMenuItem_Click);
            // 
            // salesMastToolStripMenuItem
            // 
            this.salesMastToolStripMenuItem.Name = "salesMastToolStripMenuItem";
            this.salesMastToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.salesMastToolStripMenuItem.Text = "sales_Mast";
            this.salesMastToolStripMenuItem.Click += new System.EventHandler(this.salesMastToolStripMenuItem_Click);
            // 
            // Master_Mainfrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1118, 730);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "Master_Mainfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iTalk_ThemeContainer1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Master_Mainfrm_FormClosing);
            this.Load += new System.EventHandler(this.Master_Mainfrm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem busMastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeMastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesMastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem travelMastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesMastToolStripMenuItem;
    }
}