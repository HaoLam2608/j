using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafeTrungNguyen
{
	public partial class frm_DangKy : Form
	{
		DBConnect db = new DBConnect();
		public frm_DangKy()
		{
			InitializeComponent();
		}

		private void btn_DangKy_Click(object sender, System.EventArgs e)
		{
			var taikhoan = txt_TaiKhoan.Text;
			var mk = txt_mk.Text;
			var sdt = txt_SDT.Text;
			var diachi = txt_DiaChi.Text;
			var manv = "NV00021";

			if (!string.IsNullOrEmpty(taikhoan) && !string.IsNullOrEmpty(mk) && !string.IsNullOrEmpty(sdt) && !string.IsNullOrEmpty(diachi))
			{
				string sql = $"insert into NhanVien values('{taikhoan}', 'AN123',3,'{sdt}' , '{diachi}', 1 ,'NHOM02' , '{mk}')";


				db.ExcuteProc("exec ThemNguoiDung @username , @pass", new object[] { taikhoan.Trim(), mk.Trim() });

				int kq = db.getNonquery(sql);
				if (kq > 0)
				{
					MessageBox.Show("Đăng ký thành công");
				}
				else
				{
					MessageBox.Show("Đăng ký không thành công");
				}
			}
		}
	}
}
