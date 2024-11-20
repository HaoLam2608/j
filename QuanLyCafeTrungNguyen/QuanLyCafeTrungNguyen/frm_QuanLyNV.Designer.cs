namespace QuanLyCafeTrungNguyen
{
    partial class frm_QuanLyNV
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
            this.cb_cn = new System.Windows.Forms.ComboBox();
            this.txtMatKhau1 = new System.Windows.Forms.TextBox();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSuaNV = new System.Windows.Forms.Button();
            this.btnThemNV = new System.Windows.Forms.Button();
            this.cb_Chucvu = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_TaoMa = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTennv = new System.Windows.Forms.TextBox();
            this.txtManv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_TIemKiem = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgv_NhanVien = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_cn
            // 
            this.cb_cn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_cn.FormattingEnabled = true;
            this.cb_cn.Location = new System.Drawing.Point(64, 72);
            this.cb_cn.Name = "cb_cn";
            this.cb_cn.Size = new System.Drawing.Size(136, 25);
            this.cb_cn.TabIndex = 24;
            // 
            // txtMatKhau1
            // 
            this.txtMatKhau1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau1.Location = new System.Drawing.Point(326, 433);
            this.txtMatKhau1.Multiline = true;
            this.txtMatKhau1.Name = "txtMatKhau1";
            this.txtMatKhau1.Size = new System.Drawing.Size(162, 31);
            this.txtMatKhau1.TabIndex = 22;
            // 
            // txtTenDN
            // 
            this.txtTenDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDN.Location = new System.Drawing.Point(69, 433);
            this.txtTenDN.Multiline = true;
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(128, 31);
            this.txtTenDN.TabIndex = 21;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.AutoSize = true;
            this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(321, 404);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(75, 20);
            this.txtMatKhau.TabIndex = 20;
            this.txtMatKhau.Text = "Mật khẩu";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(66, 404);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Tài khoản";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(217, 509);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(126, 54);
            this.btnXoa.TabIndex = 18;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSuaNV
            // 
            this.btnSuaNV.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnSuaNV.FlatAppearance.BorderSize = 0;
            this.btnSuaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaNV.Location = new System.Drawing.Point(373, 509);
            this.btnSuaNV.Name = "btnSuaNV";
            this.btnSuaNV.Size = new System.Drawing.Size(115, 54);
            this.btnSuaNV.TabIndex = 17;
            this.btnSuaNV.Text = "Sửa";
            this.btnSuaNV.UseVisualStyleBackColor = false;
            // 
            // btnThemNV
            // 
            this.btnThemNV.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnThemNV.FlatAppearance.BorderSize = 0;
            this.btnThemNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNV.Location = new System.Drawing.Point(63, 509);
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(126, 54);
            this.btnThemNV.TabIndex = 16;
            this.btnThemNV.Text = "Thêm";
            this.btnThemNV.UseVisualStyleBackColor = false;
            this.btnThemNV.Click += new System.EventHandler(this.btnThemNV_Click);
            // 
            // cb_Chucvu
            // 
            this.cb_Chucvu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Chucvu.FormattingEnabled = true;
            this.cb_Chucvu.Location = new System.Drawing.Point(62, 233);
            this.cb_Chucvu.Name = "cb_Chucvu";
            this.cb_Chucvu.Size = new System.Drawing.Size(136, 25);
            this.cb_Chucvu.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.Controls.Add(this.btn_TaoMa);
            this.panel1.Controls.Add(this.cb_cn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtMatKhau1);
            this.panel1.Controls.Add(this.txtTenDN);
            this.panel1.Controls.Add(this.txtMatKhau);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnSuaNV);
            this.panel1.Controls.Add(this.btnThemNV);
            this.panel1.Controls.Add(this.cb_Chucvu);
            this.panel1.Controls.Add(this.txtSDT);
            this.panel1.Controls.Add(this.txtDiaChi);
            this.panel1.Controls.Add(this.txtTennv);
            this.panel1.Controls.Add(this.txtManv);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(787, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 571);
            this.panel1.TabIndex = 13;
            // 
            // btn_TaoMa
            // 
            this.btn_TaoMa.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_TaoMa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_TaoMa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TaoMa.ForeColor = System.Drawing.Color.Transparent;
            this.btn_TaoMa.Location = new System.Drawing.Point(202, 146);
            this.btn_TaoMa.Name = "btn_TaoMa";
            this.btn_TaoMa.Size = new System.Drawing.Size(79, 32);
            this.btn_TaoMa.TabIndex = 25;
            this.btn_TaoMa.Text = "Tạo mã";
            this.btn_TaoMa.UseVisualStyleBackColor = false;
            this.btn_TaoMa.Click += new System.EventHandler(this.btn_TaoMa_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(65, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Chi nhánh";
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(326, 331);
            this.txtSDT.Multiline = true;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(164, 31);
            this.txtSDT.TabIndex = 10;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(64, 331);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(204, 43);
            this.txtDiaChi.TabIndex = 9;
            // 
            // txtTennv
            // 
            this.txtTennv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTennv.Location = new System.Drawing.Point(358, 146);
            this.txtTennv.Multiline = true;
            this.txtTennv.Name = "txtTennv";
            this.txtTennv.Size = new System.Drawing.Size(164, 32);
            this.txtTennv.TabIndex = 8;
            // 
            // txtManv
            // 
            this.txtManv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManv.Location = new System.Drawing.Point(62, 146);
            this.txtManv.Multiline = true;
            this.txtManv.Name = "txtManv";
            this.txtManv.Size = new System.Drawing.Size(134, 32);
            this.txtManv.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(322, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Số điện thoại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Chức vụ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(354, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên nhân viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã nhân viên";
            // 
            // btn_TIemKiem
            // 
            this.btn_TIemKiem.BackColor = System.Drawing.Color.Aqua;
            this.btn_TIemKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TIemKiem.Location = new System.Drawing.Point(787, 97);
            this.btn_TIemKiem.Name = "btn_TIemKiem";
            this.btn_TIemKiem.Size = new System.Drawing.Size(109, 42);
            this.btn_TIemKiem.TabIndex = 12;
            this.btn_TIemKiem.Text = "Search";
            this.btn_TIemKiem.UseVisualStyleBackColor = false;
            this.btn_TIemKiem.Click += new System.EventHandler(this.btn_TIemKiem_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(15, 97);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(751, 42);
            this.txtSearch.TabIndex = 11;
            // 
            // dgv_NhanVien
            // 
            this.dgv_NhanVien.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_NhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NhanVien.Location = new System.Drawing.Point(15, 145);
            this.dgv_NhanVien.Name = "dgv_NhanVien";
            this.dgv_NhanVien.RowHeadersWidth = 51;
            this.dgv_NhanVien.RowTemplate.Height = 24;
            this.dgv_NhanVien.Size = new System.Drawing.Size(750, 550);
            this.dgv_NhanVien.TabIndex = 10;
            this.dgv_NhanVien.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_NhanVien_CellMouseClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(589, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(272, 36);
            this.label8.TabIndex = 14;
            this.label8.Text = "Quản lý nhân viên";
            // 
            // frm_QuanLyNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 736);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_TIemKiem);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgv_NhanVien);
            this.Controls.Add(this.label8);
            this.Name = "frm_QuanLyNV";
            this.Text = "frm_QuanLyNV";
            this.Load += new System.EventHandler(this.frm_QuanLyNV_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_cn;
        private System.Windows.Forms.TextBox txtMatKhau1;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.Label txtMatKhau;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSuaNV;
        private System.Windows.Forms.Button btnThemNV;
        private System.Windows.Forms.ComboBox cb_Chucvu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTennv;
        private System.Windows.Forms.TextBox txtManv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_TIemKiem;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgv_NhanVien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_TaoMa;
    }
}