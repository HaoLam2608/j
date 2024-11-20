namespace QuanLyCafeTrungNguyen
{
    partial class frm_DangNhap
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txt_tk = new System.Windows.Forms.TextBox();
			this.txt_mk = new System.Windows.Forms.TextBox();
			this.btn_dn = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.link_DangKy = new System.Windows.Forms.LinkLabel();
			this.label5 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(132, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(257, 53);
			this.label1.TabIndex = 1;
			this.label1.Text = "Đăng nhập ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(35, 114);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(126, 33);
			this.label2.TabIndex = 2;
			this.label2.Text = "Tài khoản";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(35, 187);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 33);
			this.label3.TabIndex = 2;
			this.label3.Text = "Mật khẩu";
			// 
			// txt_tk
			// 
			this.txt_tk.Location = new System.Drawing.Point(167, 114);
			this.txt_tk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txt_tk.Multiline = true;
			this.txt_tk.Name = "txt_tk";
			this.txt_tk.Size = new System.Drawing.Size(336, 35);
			this.txt_tk.TabIndex = 3;
			// 
			// txt_mk
			// 
			this.txt_mk.Location = new System.Drawing.Point(167, 180);
			this.txt_mk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txt_mk.Multiline = true;
			this.txt_mk.Name = "txt_mk";
			this.txt_mk.Size = new System.Drawing.Size(336, 37);
			this.txt_mk.TabIndex = 3;
			// 
			// btn_dn
			// 
			this.btn_dn.BackColor = System.Drawing.Color.DarkSeaGreen;
			this.btn_dn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_dn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_dn.Location = new System.Drawing.Point(84, 304);
			this.btn_dn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btn_dn.Name = "btn_dn";
			this.btn_dn.Size = new System.Drawing.Size(141, 38);
			this.btn_dn.TabIndex = 4;
			this.btn_dn.Text = "Đăng Nhập";
			this.btn_dn.UseVisualStyleBackColor = false;
			this.btn_dn.Click += new System.EventHandler(this.btn_dn_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Firebrick;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(317, 304);
			this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(141, 38);
			this.button2.TabIndex = 4;
			this.button2.Text = "Thoát";
			this.button2.UseVisualStyleBackColor = false;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.RosyBrown;
			this.panel1.Controls.Add(this.link_DangKy);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.btn_dn);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.txt_mk);
			this.panel1.Controls.Add(this.txt_tk);
			this.panel1.Location = new System.Drawing.Point(28, 11);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(559, 394);
			this.panel1.TabIndex = 5;
			// 
			// link_DangKy
			// 
			this.link_DangKy.Location = new System.Drawing.Point(280, 357);
			this.link_DangKy.Name = "link_DangKy";
			this.link_DangKy.Size = new System.Drawing.Size(69, 23);
			this.link_DangKy.TabIndex = 8;
			this.link_DangKy.TabStop = true;
			this.link_DangKy.Text = "Đăng ký";
			this.link_DangKy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(107, 357);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(179, 23);
			this.label5.TabIndex = 7;
			this.label5.Text = "Bạn không có tài khoản?";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Image = global::QuanLyCafeTrungNguyen.Properties.Resources.anh_login;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(1015, 432);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// frm_DangNhap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(1015, 432);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pictureBox1);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "frm_DangNhap";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.frm_DangNhap_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.LinkLabel link_DangKy;

		private System.Windows.Forms.Label label5;

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txt_tk;
		private System.Windows.Forms.TextBox txt_mk;
		private System.Windows.Forms.Button btn_dn;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Panel panel1;
	}

}