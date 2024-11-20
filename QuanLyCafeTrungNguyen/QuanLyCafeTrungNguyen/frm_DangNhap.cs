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
    public partial class frm_DangNhap : Form
    {
		public static SqlTransaction transaction;
		public frm_DangNhap()
		{
			InitializeComponent();
		}

		private void label5_Click(object sender, EventArgs e)
		{
			throw new System.NotImplementedException();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{

		}

		private void btn_dn_Click(object sender, EventArgs e)
		{
			var ma = txt_tk.Text;
			var mk = txt_mk.Text;
			string query = $"SELECT * FROM NhanVien,NHOMQUYEN WHERE NhanVien.MaNhanVien = '{ma}' AND NhanVien.PASSWORD = {mk} and NhanVien.MANHOM = NHOMQUYEN.MANHOM";
			DataTable dt = DBConnect.Instance.getTable(query);
			if (dt.Rows.Count > 0)
			{
				var nhomquyen = dt.Rows[0]["TENNHOM"].ToString();
				if (nhomquyen == "ThuNgan")
				{
					DBConnect.Instance.OpenConnectionWithLogin(ma);
					MessageBox.Show("Đăng nhập thành công với quyền Thu ngân.");
					frm_TrangChu f = new frm_TrangChu();
					f.ShowDialog();
					DBConnect.Instance.RevertConnection();
				}
				else if (nhomquyen == "Quanly")
				{
					DBConnect.Instance.OpenConnectionWithLogin(ma);
					MessageBox.Show("Chào Quản lý.");
					frm_TrangChu f = new frm_TrangChu();
					f.ShowDialog();
					DBConnect.Instance.RevertConnection();
				}
				else
				{
					MessageBox.Show("Lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			
		}

		private void frm_DangNhap_Load(object sender, EventArgs e)
		{

		}
	}
}
