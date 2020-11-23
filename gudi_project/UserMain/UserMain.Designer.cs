namespace gudi_project
{
    partial class UserMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.내정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정보수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ㄴ9ㅇToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.상품정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.상품리스트ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.대표여행지ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_info_start_date = new System.Windows.Forms.Label();
            this.lbl_info_tel = new System.Windows.Forms.Label();
            this.lbl_info_name = new System.Windows.Forms.Label();
            this.lbl_info_price = new System.Windows.Forms.Label();
            this.tbc_MainTrInfo = new System.Windows.Forms.TabControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.내정보ToolStripMenuItem,
            this.상품정보ToolStripMenuItem,
            this.cToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(884, 29);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 내정보ToolStripMenuItem
            // 
            this.내정보ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.정보수정ToolStripMenuItem,
            this.ㄴ9ㅇToolStripMenuItem});
            this.내정보ToolStripMenuItem.Name = "내정보ToolStripMenuItem";
            this.내정보ToolStripMenuItem.Size = new System.Drawing.Size(59, 19);
            this.내정보ToolStripMenuItem.Text = "내 정보";
            // 
            // 정보수정ToolStripMenuItem
            // 
            this.정보수정ToolStripMenuItem.Name = "정보수정ToolStripMenuItem";
            this.정보수정ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.정보수정ToolStripMenuItem.Text = "정보 수정";
            this.정보수정ToolStripMenuItem.Click += new System.EventHandler(this.정보수정ToolStripMenuItem_Click);
            // 
            // ㄴ9ㅇToolStripMenuItem
            // 
            this.ㄴ9ㅇToolStripMenuItem.Name = "ㄴ9ㅇToolStripMenuItem";
            this.ㄴ9ㅇToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ㄴ9ㅇToolStripMenuItem.Text = "예약 정보";
            this.ㄴ9ㅇToolStripMenuItem.Click += new System.EventHandler(this.ㄴ9ㅇToolStripMenuItem_Click);
            // 
            // 상품정보ToolStripMenuItem
            // 
            this.상품정보ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.상품리스트ToolStripMenuItem,
            this.대표여행지ToolStripMenuItem1});
            this.상품정보ToolStripMenuItem.Name = "상품정보ToolStripMenuItem";
            this.상품정보ToolStripMenuItem.Size = new System.Drawing.Size(75, 19);
            this.상품정보ToolStripMenuItem.Text = "상품 정보 ";
            // 
            // 상품리스트ToolStripMenuItem
            // 
            this.상품리스트ToolStripMenuItem.Name = "상품리스트ToolStripMenuItem";
            this.상품리스트ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.상품리스트ToolStripMenuItem.Text = "상품 리스트";
            this.상품리스트ToolStripMenuItem.Click += new System.EventHandler(this.상품리스트ToolStripMenuItem_Click);
            // 
            // 대표여행지ToolStripMenuItem1
            // 
            this.대표여행지ToolStripMenuItem1.Name = "대표여행지ToolStripMenuItem1";
            this.대표여행지ToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.대표여행지ToolStripMenuItem1.Text = "대표 여행지";
            this.대표여행지ToolStripMenuItem1.Click += new System.EventHandler(this.대표여행지ToolStripMenuItem1_Click);
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(67, 19);
            this.cToolStripMenuItem.Text = "로그아웃";
            this.cToolStripMenuItem.Click += new System.EventHandler(this.cToolStripMenuItem_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(370, 47);
            this.label9.TabIndex = 9;
            this.label9.Text = "국내여행, 떠나볼까요?";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_info_start_date);
            this.groupBox1.Controls.Add(this.lbl_info_tel);
            this.groupBox1.Controls.Add(this.lbl_info_name);
            this.groupBox1.Controls.Add(this.lbl_info_price);
            this.groupBox1.Location = new System.Drawing.Point(518, 227);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(328, 532);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "여행지 정보";
            // 
            // lbl_info_start_date
            // 
            this.lbl_info_start_date.AutoSize = true;
            this.lbl_info_start_date.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_info_start_date.Location = new System.Drawing.Point(6, 280);
            this.lbl_info_start_date.Name = "lbl_info_start_date";
            this.lbl_info_start_date.Size = new System.Drawing.Size(87, 32);
            this.lbl_info_start_date.TabIndex = 7;
            this.lbl_info_start_date.Text = "출발일";
            // 
            // lbl_info_tel
            // 
            this.lbl_info_tel.AutoSize = true;
            this.lbl_info_tel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_info_tel.Location = new System.Drawing.Point(6, 171);
            this.lbl_info_tel.Name = "lbl_info_tel";
            this.lbl_info_tel.Size = new System.Drawing.Size(142, 32);
            this.lbl_info_tel.TabIndex = 5;
            this.lbl_info_tel.Text = "여행지 이름";
            // 
            // lbl_info_name
            // 
            this.lbl_info_name.AutoSize = true;
            this.lbl_info_name.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_info_name.Location = new System.Drawing.Point(6, 56);
            this.lbl_info_name.Name = "lbl_info_name";
            this.lbl_info_name.Size = new System.Drawing.Size(166, 32);
            this.lbl_info_name.TabIndex = 4;
            this.lbl_info_name.Text = "여행테마 이름";
            // 
            // lbl_info_price
            // 
            this.lbl_info_price.AutoSize = true;
            this.lbl_info_price.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_info_price.Location = new System.Drawing.Point(6, 395);
            this.lbl_info_price.Name = "lbl_info_price";
            this.lbl_info_price.Size = new System.Drawing.Size(95, 32);
            this.lbl_info_price.TabIndex = 0;
            this.lbl_info_price.Text = "5700원";
            // 
            // tbc_MainTrInfo
            // 
            this.tbc_MainTrInfo.Location = new System.Drawing.Point(12, 227);
            this.tbc_MainTrInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbc_MainTrInfo.Name = "tbc_MainTrInfo";
            this.tbc_MainTrInfo.SelectedIndex = 0;
            this.tbc_MainTrInfo.Size = new System.Drawing.Size(500, 530);
            this.tbc_MainTrInfo.TabIndex = 7;
            this.tbc_MainTrInfo.SelectedIndexChanged += new System.EventHandler(this.tbc_MainTrInfo_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 119);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(833, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UserMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(884, 781);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbc_MainTrInfo);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserMainFrom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserMain_FormClosed);
            this.Load += new System.EventHandler(this.UserMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 내정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정보수정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ㄴ9ㅇToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 상품정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 상품리스트ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 대표여행지ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_info_start_date;
        private System.Windows.Forms.Label lbl_info_tel;
        private System.Windows.Forms.Label lbl_info_name;
        private System.Windows.Forms.Label lbl_info_price;
        private System.Windows.Forms.TabControl tbc_MainTrInfo;
        private System.Windows.Forms.Timer timer1;
    }
}