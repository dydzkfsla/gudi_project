﻿namespace gudi_project
{
    partial class Employees_Mast
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
            this.codeData1 = new gudi_project.CodeData();
            this.TabControls = new iTalk.iTalk_TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgv_employees_All = new System.Windows.Forms.DataGridView();
            this.cbx_dep_code01 = new System.Windows.Forms.ComboBox();
            this.cbx_mgr_code01 = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_xls_employees = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.codeData1)).BeginInit();
            this.TabControls.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_employees_All)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_xls_employees)).BeginInit();
            this.SuspendLayout();
            // 
            // codeData1
            // 
            this.codeData1.DataSetName = "CodeData";
            this.codeData1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TabControls
            // 
            this.TabControls.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TabControls.Controls.Add(this.tabPage1);
            this.TabControls.Controls.Add(this.tabPage3);
            this.TabControls.Controls.Add(this.tabPage4);
            this.TabControls.Controls.Add(this.tabPage2);
            this.TabControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControls.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.TabControls.ItemSize = new System.Drawing.Size(44, 135);
            this.TabControls.Location = new System.Drawing.Point(0, 0);
            this.TabControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabControls.Multiline = true;
            this.TabControls.Name = "TabControls";
            this.TabControls.SelectedIndex = 0;
            this.TabControls.Size = new System.Drawing.Size(1282, 523);
            this.TabControls.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControls.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(139, 4);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1139, 515);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "직원All";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(4, 5);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgv_employees_All);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cbx_dep_code01);
            this.splitContainer2.Panel2.Controls.Add(this.cbx_mgr_code01);
            this.splitContainer2.Size = new System.Drawing.Size(1131, 505);
            this.splitContainer2.SplitterDistance = 834;
            this.splitContainer2.SplitterWidth = 10;
            this.splitContainer2.TabIndex = 1;
            // 
            // dgv_employees_All
            // 
            this.dgv_employees_All.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_employees_All.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_employees_All.Location = new System.Drawing.Point(0, 0);
            this.dgv_employees_All.Name = "dgv_employees_All";
            this.dgv_employees_All.RowHeadersWidth = 51;
            this.dgv_employees_All.Size = new System.Drawing.Size(834, 505);
            this.dgv_employees_All.TabIndex = 0;
            this.dgv_employees_All.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_employees_All_CellContentClick);
            // 
            // cbx_dep_code01
            // 
            this.cbx_dep_code01.FormattingEnabled = true;
            this.cbx_dep_code01.Location = new System.Drawing.Point(18, 421);
            this.cbx_dep_code01.Name = "cbx_dep_code01";
            this.cbx_dep_code01.Size = new System.Drawing.Size(121, 36);
            this.cbx_dep_code01.TabIndex = 1;
            // 
            // cbx_mgr_code01
            // 
            this.cbx_mgr_code01.FormattingEnabled = true;
            this.cbx_mgr_code01.Location = new System.Drawing.Point(18, 369);
            this.cbx_mgr_code01.Name = "cbx_mgr_code01";
            this.cbx_mgr_code01.Size = new System.Drawing.Size(121, 36);
            this.cbx_mgr_code01.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage3.Controls.Add(this.splitContainer3);
            this.tabPage3.Location = new System.Drawing.Point(139, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1132, 482);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "현직자";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer3.Size = new System.Drawing.Size(1132, 482);
            this.splitContainer3.SplitterDistance = 834;
            this.splitContainer3.SplitterWidth = 10;
            this.splitContainer3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(834, 482);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage4.Controls.Add(this.splitContainer4);
            this.tabPage4.Location = new System.Drawing.Point(139, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1139, 515);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "퇴사자";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dataGridView2);
            this.splitContainer4.Size = new System.Drawing.Size(1139, 515);
            this.splitContainer4.SplitterDistance = 839;
            this.splitContainer4.SplitterWidth = 10;
            this.splitContainer4.TabIndex = 2;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(839, 515);
            this.dataGridView2.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(139, 4);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1132, 482);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "직원 엑셀";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_xls_employees);
            this.splitContainer1.Size = new System.Drawing.Size(1124, 472);
            this.splitContainer1.SplitterDistance = 731;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgv_xls_employees
            // 
            this.dgv_xls_employees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_xls_employees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_xls_employees.Location = new System.Drawing.Point(0, 0);
            this.dgv_xls_employees.Name = "dgv_xls_employees";
            this.dgv_xls_employees.RowHeadersWidth = 51;
            this.dgv_xls_employees.Size = new System.Drawing.Size(731, 472);
            this.dgv_xls_employees.TabIndex = 0;
            // 
            // Employees_Mast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 523);
            this.Controls.Add(this.TabControls);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Employees_Mast";
            this.Text = "Employees_Mast";
            this.Load += new System.EventHandler(this.Employees_Mast_Load);
            ((System.ComponentModel.ISupportInitialize)(this.codeData1)).EndInit();
            this.TabControls.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_employees_All)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_xls_employees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private iTalk.iTalk_TabControl TabControls;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgv_employees_All;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_xls_employees;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private CodeData codeData1;
        private System.Windows.Forms.ComboBox cbx_dep_code01;
        private System.Windows.Forms.ComboBox cbx_mgr_code01;
    }
}