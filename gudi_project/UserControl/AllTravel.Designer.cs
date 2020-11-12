namespace gudi_project
{
    partial class AllTravel
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_from_date = new System.Windows.Forms.DateTimePicker();
            this.dtp_to_date = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 45);
            this.label1.TabIndex = 28;
            this.label1.Text = "상품 리스트";
            // 
            // dtp_from_date
            // 
            this.dtp_from_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_from_date.Location = new System.Drawing.Point(210, 27);
            this.dtp_from_date.MinDate = new System.DateTime(2020, 11, 12, 17, 21, 24, 0);
            this.dtp_from_date.Name = "dtp_from_date";
            this.dtp_from_date.Size = new System.Drawing.Size(171, 21);
            this.dtp_from_date.TabIndex = 29;
            this.dtp_from_date.Value = new System.DateTime(2020, 11, 12, 17, 21, 24, 0);
            // 
            // dtp_to_date
            // 
            this.dtp_to_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_to_date.Location = new System.Drawing.Point(435, 27);
            this.dtp_to_date.MinDate = new System.DateTime(2020, 11, 12, 17, 21, 19, 0);
            this.dtp_to_date.Name = "dtp_to_date";
            this.dtp_to_date.Size = new System.Drawing.Size(171, 21);
            this.dtp_to_date.TabIndex = 30;
            this.dtp_to_date.Value = new System.DateTime(2020, 11, 12, 17, 21, 19, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "~";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(23, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 655);
            this.panel1.TabIndex = 45;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(631, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 45);
            this.button1.TabIndex = 46;
            this.button1.Text = "조회";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(747, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 45);
            this.button2.TabIndex = 47;
            this.button2.Text = "확인";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AllTravel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_to_date);
            this.Controls.Add(this.dtp_from_date);
            this.Controls.Add(this.label1);
            this.Name = "AllTravel";
            this.Size = new System.Drawing.Size(880, 750);
            this.Load += new System.EventHandler(this.AllTravel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_from_date;
        private System.Windows.Forms.DateTimePicker dtp_to_date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
