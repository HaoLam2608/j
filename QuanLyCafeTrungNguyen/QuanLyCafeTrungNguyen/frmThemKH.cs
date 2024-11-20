using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafeTrungNguyen
{
	public partial class frmThemKH : Form
	{
		DBConnect db = new DBConnect();
		public frmThemKH()
		{
			InitializeComponent();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}
		

		private void frmThemKH_Load(object sender, EventArgs e)
		{
			// Hiển thị combobox loại khách hàng
			
			string sqlquery = "select * from LOAIKH";
			DataTable dt = db.getTable(sqlquery);
			cb_loaiKH.DataSource = dt;
			cb_loaiKH.DisplayMember = "TENLOAI";
			cb_loaiKH.ValueMember = "MALOAI";

			// Hiển thị danh sách khách hàng trên datagridview
			string query = "select * from vw_CustomerInfo";
			DataTable dt2 = db.getTable(query);
			dgv_KH.DataSource = dt2;
			dgv_KH.RowHeadersVisible = false;

			btnThem.Enabled=false;
			btnSua.Enabled = false;
			btnXoa.Enabled = false;

		}
		private bool KiemTraTrungMaKH(string maKH)
		{
			
			string query = "SELECT COUNT(*) FROM KHACHHANG WHERE MaKH = '" + maKH + "'";
			DataTable dt = db.getTable(query);

			if (dt.Rows.Count > 0 && int.Parse(dt.Rows[0][0].ToString()) > 0)
			{
				return true; // Mã khách hàng đã tồn tại
			}
			return false; // Mã khách hàng chưa tồn tại
		}
		private void btnThem_Click(object sender, EventArgs e)
		{
			string maKH = db.GenerateMaKH();
			if (string.IsNullOrEmpty(txtMaKH.Text) || string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtSDT.Text))
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin");

			}
			if (KiemTraTrungMaKH(txtMaKH.Text))
			{
				MessageBox.Show("Mã khách hàng đã tồn tại. Vui lòng nhập mã khác.");
				return; // Thoát nếu mã khách hàng đã tồn tại
			}
			else
			{
				DataTable dt = (DataTable)dgv_KH.DataSource;

				
				SqlConnection con = db.con; // Lấy SqlConnection từ lớp DBConnect

				con.InfoMessage += new SqlInfoMessageEventHandler(con_InfoMessage);
				
				string query = "exec ThemKhachHang @MaKH = '" + maKH + "', " +
				   "@TenKH = N'" + txtTenKH.Text + "', " +
				   "@MALOAI = " + cb_loaiKH.SelectedValue + ", " +
				   "@SDT = '" + txtSDT.Text + "', " +
				   "@SoDiemThuong = " + int.Parse(txtDiem.Text);
				int k = db.getNonquery(query);
				if (k != 0)
				{
					
					CapNhatDataGridView();
				}
				else
				{
					MessageBox.Show("Thêm khách hàng thất bại!");
				}
					
			}			
		}
		private void con_InfoMessage(object sender, SqlInfoMessageEventArgs e)
		{
			// Hiển thị thông báo từ lệnh PRINT trong stored procedure
			MessageBox.Show(e.Message);
		}
		private void CapNhatDataGridView()
		{
			
			string query = "select * from vw_CustomerInfo";
			DataTable dt = db.getTable(query);
			
			dgv_KH.DataSource = dt;
		}

		private void txtMaKH_TextChanged(object sender, EventArgs e)
		{
			btnXoa.Enabled = !string.IsNullOrEmpty(txtMaKH.Text);
			btnSua.Enabled = !string.IsNullOrEmpty(txtMaKH.Text);
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtMaKH.Text) || string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtDiem.Text))
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
				return; // Thoát nếu chưa nhập đủ thông tin
			}

			DataTable dt = (DataTable)dgv_KH.DataSource;

			
			SqlConnection con = db.con; // Lấy SqlConnection từ lớp DBConnect

			// Đăng ký sự kiện InfoMessage để nhận thông báo từ lệnh PRINT
			con.InfoMessage += new SqlInfoMessageEventHandler(con_InfoMessage);

			string query = "exec SuaKhachHang @MaKH ='" + txtMaKH.Text + "', " +
						   "@TenKH = N'" + txtTenKH.Text + "', " +
						   "@MALOAI = " + cb_loaiKH.SelectedValue + ", " +
						   "@SDT = '" + txtSDT.Text + "', " +
						   "@SoDiemThuong = " + int.Parse(txtDiem.Text);

			int k = db.getNonquery(query);			

			if (k != 0)
			{
				// Cập nhật lại DataGridView
				CapNhatDataGridView();
			}
			else
			{
				MessageBox.Show("Cập nhật khách hàng thất bại!");
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtMaKH.Text))
			{
				MessageBox.Show("Vui lòng nhập mã khách hàng cần xóa.");
				return;
			}

			// Kiểm tra xem mã khách hàng có tồn tại hay không
			if (!KiemTraTrungMaKH(txtMaKH.Text))
			{
				MessageBox.Show("Mã khách hàng không tồn tại.");
				return; // Thoát nếu mã khách hàng không tồn tại
			}
			// Câu lệnh xóa khách hàng
			
			string query = "exec XoaKhachHang @MaKH = '" + txtMaKH.Text + "'";
			int k = db.getNonquery(query);

			if (k != 0)
			{
				MessageBox.Show("Đã xóa khách hàng thành công.");
				CapNhatDataGridView(); 
			}
			else
			{
				MessageBox.Show("Xóa khách hàng thất bại.");
			}
		}

		private void dgv_KH_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0) // Đảm bảo hàng được chọn là hợp lệ
			{
				DataGridViewRow row = dgv_KH.Rows[e.RowIndex];
				txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
				txtTenKH.Text = row.Cells["TenKH"].Value.ToString();
				txtSDT.Text = row.Cells["SDT"].Value.ToString();
				txtDiem.Text = row.Cells["SoDiemThuong"].Value.ToString();
				cb_loaiKH.SelectedValue = row.Cells["MALOAI"].Value; // Cập nhật combobox loại khách hàng
			}
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			string query = "select * from KHACHHANG where TENKH like N'%"+txtSearch.Text+"%'";
			int k = db.getNonquery(query);

			if (k != 0)
			{
				DataTable dt = db.getTable(query);

				dgv_KH.DataSource = dt;

			}
			else
			{
				MessageBox.Show("Không có khách hàng.");
			}

		}

		private void dgv_KH_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{

		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}
	}
}
