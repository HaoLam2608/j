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
	public partial class frm_HoaDon : Form
	{
		DBConnect db = new DBConnect();
		public frm_HoaDon()
		{
			InitializeComponent();
		}

		private void frm_HoaDon_Load(object sender, EventArgs e)
		{
			string sql = "SELECT * FROM dbo.fn_ViewAllInvoices();";
			dgv_dsHoaDon.DataSource = db.getTable(sql);
			cb_Machinhanh.DataSource = db.getTable("select * from ChiNhanh");
			cb_Machinhanh.DisplayMember = "TenChiNhanh";
			cb_Machinhanh.ValueMember = "MaChiNhanh";
		}

		private void btn_LocHoaDon_Click(object sender, EventArgs e)
		{
			string sql = $"select * from HoaDon, ChiTietHoaDon where HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon" +
			 $"{(!String.IsNullOrEmpty(txt_Mahoadon.Text) ? $" and ChiTietHoaDon.MaHoaDon = '{txt_Mahoadon.Text}'" : "")}" + $"{(!String.IsNullOrEmpty(cb_Machinhanh.Text) ? $" and HoaDon.MaChiNhanh = '{cb_Machinhanh.SelectedValue.ToString()}'" : "")}";
			cb_Machinhanh.Text = "";
			dgv_dsHoaDon.DataSource = db.getTable(sql);
		}

		private void btn_Tongdoanhthu_Click(object sender, EventArgs e)
		{
			int? thang = String.IsNullOrEmpty(txt_Thang.Text) ? (int?)null : int.Parse(txt_Thang.Text);
			int? nam = String.IsNullOrEmpty(txt_Nam.Text) ? (int?)null : int.Parse(txt_Nam.Text);

			string[] bien = { "Thang", "Nam" };

			DataTable kq = (DataTable)db.ExecuteFunc("select * from dbo.TINHTONGDOANHTHU(@Thang , @Nam)", new object[] { thang, nam }, bien, true);

			dgv_dsHoaDon.DataSource = kq;
		}

		private void label3_Click(object sender, EventArgs e)
		{
			throw new System.NotImplementedException();
		}

	}
}
