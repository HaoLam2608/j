namespace QuanLyCafeTrungNguyen
{
	partial class frmThemKH
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cb_loaiKH = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtDiem = new System.Windows.Forms.TextBox();
			this.txtSDT = new System.Windows.Forms.TextBox();
			this.txtTenKH = new System.Windows.Forms.TextBox();
			this.txtMaKH = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.btnTimKiem = new System.Windows.Forms.Button();
			this.btnThem = new System.Windows.Forms.Button();
			this.btnSua = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dgv_KH = new System.Windows.Forms.DataGridView();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_KH)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox1.Controls.Add(this.cb_loaiKH);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtDiem);
			this.groupBox1.Controls.Add(this.txtSDT);
			this.groupBox1.Controls.Add(this.txtTenKH);
			this.groupBox1.Controls.Add(this.txtMaKH);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(139, 87);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(456, 401);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Khách hàng";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// cb_loaiKH
			// 
			this.cb_loaiKH.FormattingEnabled = true;
			this.cb_loaiKH.Location = new System.Drawing.Point(190, 299);
			this.cb_loaiKH.Name = "cb_loaiKH";
			this.cb_loaiKH.Size = new System.Drawing.Size(226, 33);
			this.cb_loaiKH.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(17, 303);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(156, 25);
			this.label7.TabIndex = 8;
			this.label7.Text = "Loại khách hàng";
			// 
			// txtDiem
			// 
			this.txtDiem.Location = new System.Drawing.Point(190, 243);
			this.txtDiem.Name = "txtDiem";
			this.txtDiem.Size = new System.Drawing.Size(226, 30);
			this.txtDiem.TabIndex = 7;
			// 
			// txtSDT
			// 
			this.txtSDT.Location = new System.Drawing.Point(190, 186);
			this.txtSDT.Name = "txtSDT";
			this.txtSDT.Size = new System.Drawing.Size(226, 30);
			this.txtSDT.TabIndex = 6;
			// 
			// txtTenKH
			// 
			this.txtTenKH.Location = new System.Drawing.Point(190, 132);
			this.txtTenKH.Name = "txtTenKH";
			this.txtTenKH.Size = new System.Drawing.Size(226, 30);
			this.txtTenKH.TabIndex = 5;
			// 
			// txtMaKH
			// 
			this.txtMaKH.Location = new System.Drawing.Point(190, 79);
			this.txtMaKH.Name = "txtMaKH";
			this.txtMaKH.Size = new System.Drawing.Size(226, 30);
			this.txtMaKH.TabIndex = 4;
			this.txtMaKH.TextChanged += new System.EventHandler(this.txtMaKH_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(17, 246);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(122, 25);
			this.label6.TabIndex = 3;
			this.label6.Text = "Điểm thưởng";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(17, 189);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(126, 25);
			this.label5.TabIndex = 2;
			this.label5.Text = "Số điện thoại";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(17, 135);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(154, 25);
			this.label4.TabIndex = 1;
			this.label4.Text = "Tên khách hàng";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(17, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(147, 25);
			this.label3.TabIndex = 0;
			this.label3.Text = "Mã khách hàng";
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtSearch.Location = new System.Drawing.Point(604, 105);
			this.txtSearch.Multiline = true;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(626, 40);
			this.txtSearch.TabIndex = 6;
			this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
			// 
			// btnTimKiem
			// 
			this.btnTimKiem.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnTimKiem.BackColor = System.Drawing.Color.Cyan;
			this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTimKiem.Location = new System.Drawing.Point(1236, 104);
			this.btnTimKiem.Name = "btnTimKiem";
			this.btnTimKiem.Size = new System.Drawing.Size(152, 41);
			this.btnTimKiem.TabIndex = 7;
			this.btnTimKiem.Text = "Tìm kiếm";
			this.btnTimKiem.UseVisualStyleBackColor = false;
			this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
			// 
			// btnThem
			// 
			this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnThem.BackColor = System.Drawing.Color.Cyan;
			this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThem.Location = new System.Drawing.Point(139, 494);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(148, 44);
			this.btnThem.TabIndex = 9;
			this.btnThem.Text = "Thêm ";
			this.btnThem.UseVisualStyleBackColor = false;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// btnSua
			// 
			this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSua.BackColor = System.Drawing.Color.Lime;
			this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSua.Location = new System.Drawing.Point(293, 494);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new System.Drawing.Size(148, 44);
			this.btnSua.TabIndex = 10;
			this.btnSua.Text = "Sửa";
			this.btnSua.UseVisualStyleBackColor = false;
			this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
			// 
			// btnXoa
			// 
			this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnXoa.BackColor = System.Drawing.Color.Red;
			this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXoa.Location = new System.Drawing.Point(447, 494);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(148, 45);
			this.btnXoa.TabIndex = 11;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.UseVisualStyleBackColor = false;
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox2.Controls.Add(this.dgv_KH);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(604, 151);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(784, 388);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Danh sách khách hàng";
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// dgv_KH
			// 
			this.dgv_KH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv_KH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_KH.Location = new System.Drawing.Point(6, 27);
			this.dgv_KH.Name = "dgv_KH";
			this.dgv_KH.RowHeadersWidth = 51;
			this.dgv_KH.RowTemplate.Height = 24;
			this.dgv_KH.Size = new System.Drawing.Size(772, 355);
			this.dgv_KH.TabIndex = 0;
			this.dgv_KH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_KH_CellClick);
			this.dgv_KH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_KH_CellContentClick);
			// 
			// frmThemKH
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1598, 714);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnXoa);
			this.Controls.Add(this.btnSua);
			this.Controls.Add(this.btnThem);
			this.Controls.Add(this.btnTimKiem);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmThemKH";
			this.Text = "frmThemKH";
			this.Load += new System.EventHandler(this.frmThemKH_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv_KH)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDiem;
		private System.Windows.Forms.TextBox txtSDT;
		private System.Windows.Forms.TextBox txtTenKH;
		private System.Windows.Forms.TextBox txtMaKH;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Button btnTimKiem;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.ComboBox cb_loaiKH;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGridView dgv_KH;
	}
}