namespace QuanLyCafeTrungNguyen
{
	partial class frm_HoaDon
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
			this.dgv_dsHoaDon = new System.Windows.Forms.DataGridView();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txt_Mahoadon = new System.Windows.Forms.TextBox();
			this.cb_Machinhanh = new System.Windows.Forms.ComboBox();
			this.dtp_Ngaytao = new System.Windows.Forms.DateTimePicker();
			this.btn_LocHoaDon = new System.Windows.Forms.Button();
			this.btn_Tongdoanhthu = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txt_Nam = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txt_Thang = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dgv_dsHoaDon)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgv_dsHoaDon
			// 
			this.dgv_dsHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv_dsHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_dsHoaDon.Location = new System.Drawing.Point(31, 350);
			this.dgv_dsHoaDon.Margin = new System.Windows.Forms.Padding(4);
			this.dgv_dsHoaDon.Name = "dgv_dsHoaDon";
			this.dgv_dsHoaDon.RowHeadersWidth = 51;
			this.dgv_dsHoaDon.Size = new System.Drawing.Size(1271, 436);
			this.dgv_dsHoaDon.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(86, 30);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(146, 31);
			this.label3.TabIndex = 4;
			this.label3.Text = "Mã hóa đơn";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(86, 119);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 31);
			this.label4.TabIndex = 4;
			this.label4.Text = "Chi nhánh";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(86, 188);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(111, 31);
			this.label5.TabIndex = 4;
			this.label5.Text = "Ngày tạo";
			// 
			// txt_Mahoadon
			// 
			this.txt_Mahoadon.Location = new System.Drawing.Point(253, 30);
			this.txt_Mahoadon.Margin = new System.Windows.Forms.Padding(4);
			this.txt_Mahoadon.Multiline = true;
			this.txt_Mahoadon.Name = "txt_Mahoadon";
			this.txt_Mahoadon.Size = new System.Drawing.Size(177, 27);
			this.txt_Mahoadon.TabIndex = 5;
			// 
			// cb_Machinhanh
			// 
			this.cb_Machinhanh.FormattingEnabled = true;
			this.cb_Machinhanh.Location = new System.Drawing.Point(253, 119);
			this.cb_Machinhanh.Margin = new System.Windows.Forms.Padding(4);
			this.cb_Machinhanh.Name = "cb_Machinhanh";
			this.cb_Machinhanh.Size = new System.Drawing.Size(160, 24);
			this.cb_Machinhanh.TabIndex = 6;
			// 
			// dtp_Ngaytao
			// 
			this.dtp_Ngaytao.Location = new System.Drawing.Point(253, 192);
			this.dtp_Ngaytao.Margin = new System.Windows.Forms.Padding(4);
			this.dtp_Ngaytao.Name = "dtp_Ngaytao";
			this.dtp_Ngaytao.Size = new System.Drawing.Size(177, 22);
			this.dtp_Ngaytao.TabIndex = 7;
			// 
			// btn_LocHoaDon
			// 
			this.btn_LocHoaDon.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btn_LocHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_LocHoaDon.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_LocHoaDon.ForeColor = System.Drawing.Color.Black;
			this.btn_LocHoaDon.Location = new System.Drawing.Point(181, 268);
			this.btn_LocHoaDon.Margin = new System.Windows.Forms.Padding(4);
			this.btn_LocHoaDon.Name = "btn_LocHoaDon";
			this.btn_LocHoaDon.Size = new System.Drawing.Size(100, 38);
			this.btn_LocHoaDon.TabIndex = 8;
			this.btn_LocHoaDon.Text = "Lọc";
			this.btn_LocHoaDon.UseVisualStyleBackColor = false;
			this.btn_LocHoaDon.Click += new System.EventHandler(this.btn_LocHoaDon_Click);
			// 
			// btn_Tongdoanhthu
			// 
			this.btn_Tongdoanhthu.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btn_Tongdoanhthu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Tongdoanhthu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_Tongdoanhthu.ForeColor = System.Drawing.Color.Black;
			this.btn_Tongdoanhthu.Location = new System.Drawing.Point(136, 254);
			this.btn_Tongdoanhthu.Margin = new System.Windows.Forms.Padding(4);
			this.btn_Tongdoanhthu.Name = "btn_Tongdoanhthu";
			this.btn_Tongdoanhthu.Size = new System.Drawing.Size(280, 38);
			this.btn_Tongdoanhthu.TabIndex = 8;
			this.btn_Tongdoanhthu.Text = "Tính tổng doanh thu";
			this.btn_Tongdoanhthu.UseVisualStyleBackColor = false;
			this.btn_Tongdoanhthu.Click += new System.EventHandler(this.btn_Tongdoanhthu_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txt_Nam);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txt_Thang);
			this.groupBox1.Controls.Add(this.btn_Tongdoanhthu);
			this.groupBox1.Location = new System.Drawing.Point(569, 33);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(587, 299);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Doanh thu";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(41, 132);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(65, 31);
			this.label7.TabIndex = 12;
			this.label7.Text = "Năm";
			// 
			// txt_Nam
			// 
			this.txt_Nam.Location = new System.Drawing.Point(171, 135);
			this.txt_Nam.Margin = new System.Windows.Forms.Padding(4);
			this.txt_Nam.Name = "txt_Nam";
			this.txt_Nam.Size = new System.Drawing.Size(132, 22);
			this.txt_Nam.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(41, 71);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(82, 31);
			this.label6.TabIndex = 10;
			this.label6.Text = "Tháng";
			// 
			// txt_Thang
			// 
			this.txt_Thang.Location = new System.Drawing.Point(171, 75);
			this.txt_Thang.Margin = new System.Windows.Forms.Padding(4);
			this.txt_Thang.Name = "txt_Thang";
			this.txt_Thang.Size = new System.Drawing.Size(132, 22);
			this.txt_Thang.TabIndex = 9;
			// 
			// frm_HoaDon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1586, 768);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btn_LocHoaDon);
			this.Controls.Add(this.dtp_Ngaytao);
			this.Controls.Add(this.cb_Machinhanh);
			this.Controls.Add(this.txt_Mahoadon);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dgv_dsHoaDon);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frm_HoaDon";
			this.Text = "frm_HoaDon";
			this.Load += new System.EventHandler(this.frm_HoaDon_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv_dsHoaDon)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.DataGridView dgv_dsHoaDon;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txt_Mahoadon;
		private System.Windows.Forms.ComboBox cb_Machinhanh;
		private System.Windows.Forms.DateTimePicker dtp_Ngaytao;
		private System.Windows.Forms.Button btn_LocHoaDon;
		private System.Windows.Forms.Button btn_Tongdoanhthu;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txt_Nam;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txt_Thang;
	}
}