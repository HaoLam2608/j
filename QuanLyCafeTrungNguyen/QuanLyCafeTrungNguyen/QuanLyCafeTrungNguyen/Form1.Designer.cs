namespace QuanLyCafeTrungNguyen
{
    partial class frm_TrangChu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pic_logo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_username = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_DoangThu = new System.Windows.Forms.TabPage();
            this.tab_NhanVien = new System.Windows.Forms.TabPage();
            this.tab_HD = new System.Windows.Forms.TabPage();
            this.tab_SanPham = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lb_username);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pic_logo);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 630);
            this.panel1.TabIndex = 0;
            // 
            // pic_logo
            // 
            this.pic_logo.Image = global::QuanLyCafeTrungNguyen.Properties.Resources.snapedit_1727063748782;
            this.pic_logo.InitialImage = null;
            this.pic_logo.Location = new System.Drawing.Point(25, 22);
            this.pic_logo.Name = "pic_logo";
            this.pic_logo.Size = new System.Drawing.Size(198, 100);
            this.pic_logo.TabIndex = 0;
            this.pic_logo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(23, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Trang quản lý";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username: ";
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.Location = new System.Drawing.Point(114, 183);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(56, 20);
            this.lb_username.TabIndex = 3;
            this.lb_username.Text = "Admin";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 562);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 57);
            this.button1.TabIndex = 4;
            this.button1.Text = "Đăng xuất";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_DoangThu);
            this.tabControl1.Controls.Add(this.tab_NhanVien);
            this.tabControl1.Controls.Add(this.tab_HD);
            this.tabControl1.Controls.Add(this.tab_SanPham);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(254, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(810, 630);
            this.tabControl1.TabIndex = 1;
            // 
            // tab_DoangThu
            // 
            this.tab_DoangThu.Location = new System.Drawing.Point(4, 31);
            this.tab_DoangThu.Name = "tab_DoangThu";
            this.tab_DoangThu.Padding = new System.Windows.Forms.Padding(3);
            this.tab_DoangThu.Size = new System.Drawing.Size(802, 595);
            this.tab_DoangThu.TabIndex = 0;
            this.tab_DoangThu.Text = "Doanh thu";
            this.tab_DoangThu.UseVisualStyleBackColor = true;
            // 
            // tab_NhanVien
            // 
            this.tab_NhanVien.Location = new System.Drawing.Point(4, 31);
            this.tab_NhanVien.Name = "tab_NhanVien";
            this.tab_NhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.tab_NhanVien.Size = new System.Drawing.Size(802, 595);
            this.tab_NhanVien.TabIndex = 1;
            this.tab_NhanVien.Text = "Nhân viên";
            this.tab_NhanVien.UseVisualStyleBackColor = true;
            // 
            // tab_HD
            // 
            this.tab_HD.Location = new System.Drawing.Point(4, 31);
            this.tab_HD.Name = "tab_HD";
            this.tab_HD.Padding = new System.Windows.Forms.Padding(3);
            this.tab_HD.Size = new System.Drawing.Size(802, 595);
            this.tab_HD.TabIndex = 2;
            this.tab_HD.Text = "Hóa đơn";
            this.tab_HD.UseVisualStyleBackColor = true;
            // 
            // tab_SanPham
            // 
            this.tab_SanPham.Location = new System.Drawing.Point(4, 31);
            this.tab_SanPham.Name = "tab_SanPham";
            this.tab_SanPham.Size = new System.Drawing.Size(802, 595);
            this.tab_SanPham.TabIndex = 3;
            this.tab_SanPham.Text = "Sản phẩm";
            this.tab_SanPham.UseVisualStyleBackColor = true;
            // 
            // frm_TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 630);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "frm_TrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pic_logo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_DoangThu;
        private System.Windows.Forms.TabPage tab_NhanVien;
        private System.Windows.Forms.TabPage tab_HD;
        private System.Windows.Forms.TabPage tab_SanPham;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmb_ChiNhanh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_NgayTao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Loc;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
    }
}

