using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafeTrungNguyen
{
	public partial class frm_DanhSachBan : Form
	{
		private frm_TrangThanhToan trangThanhToanForm;
		List<SanPham> dssp = new List<SanPham>();
		public Dictionary<int, (List<SanPham> sanPhams, KhachHang khachHang)> danhSachSanPhamCuaCacBan = new Dictionary<int, (List<SanPham>, KhachHang)>();
		public decimal totalAmount = 0; // Biến dùng chung
		public decimal totalDiscount = 0; // Biến giảm giá dùng chung

		public int banHienTai;

		public bool isExit = true;
		public event EventHandler Logout;
		public static string nhom, tendn;
		public frm_DanhSachBan()
		{
			InitializeComponent();
		}

		private void btnDangXuat_Click(object sender, EventArgs e)
		{
			Logout(this, new EventArgs());
		}
		
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			var ptb = sender as PictureBox;
			string tenBan = ptb.Name.Substring(1); // Lấy số bàn từ tên PictureBox
			int soBan;

			if (!int.TryParse(tenBan, out soBan))
			{
				MessageBox.Show("Không thể lấy số bàn từ PictureBox.");
				return;
			}

			// Cập nhật bàn hiện tại
			banHienTai = soBan;

			// Nếu form thanh toán chưa được khởi tạo hoặc đã bị đóng, tạo mới
			if (trangThanhToanForm == null || trangThanhToanForm.IsDisposed)
			{
				trangThanhToanForm = new frm_TrangThanhToan(this, ptb);
				trangThanhToanForm.Owner = this;
			}
			
			// Cập nhật số bàn hiển thị trên form
			trangThanhToanForm.lb_SoBan.Text = tenBan;

			// Xóa danh sách sản phẩm hiện tại trong ListBox
			trangThanhToanForm.lstb_dsSanPhamOrdered.Items.Clear();

			// Kiểm tra xem bàn đã thanh toán chưa
			if (danhSachSanPhamCuaCacBan.ContainsKey(soBan) && danhSachSanPhamCuaCacBan[soBan].sanPhams.Count > 0)
			{
				
				// Thêm sản phẩm của bàn hiện tại vào ListBox
				foreach (var sanPham in danhSachSanPhamCuaCacBan[soBan].sanPhams)
				{
					trangThanhToanForm.lstb_dsSanPhamOrdered.Items.Add($"Món: {sanPham.Ten} - Đơn giá: {sanPham.Gia:C} - Số lượng: {sanPham.SoLuong} - Tổng tiền của món: {sanPham.TongTien:C}");
				}

				// Lấy thông tin khách hàng đã lưu
				var khachHang = danhSachSanPhamCuaCacBan[soBan].khachHang;
				trangThanhToanForm.txt_SDTKH.Text = khachHang.SDT;
				trangThanhToanForm.lb_TenKH.Text = khachHang.TenKH;
				trangThanhToanForm.lb_LoaiKH.Text = khachHang.LoaiKH;
				trangThanhToanForm.lb_GiamGia.Text = $"{khachHang.GiamGia:C}";
				trangThanhToanForm.lb_ThanhTien.Text = $"{khachHang.ThanhTien:C}";
				trangThanhToanForm.txtMaKH.Text = khachHang.MaKH;
				trangThanhToanForm.txt_TongTien.Text = $"{khachHang.TongTien}";
				totalDiscount = khachHang.GiamGia;
			}
			else
			{
				totalAmount = 0;
				totalDiscount = 0;
			}

			trangThanhToanForm.txt_DonGiaSP.Clear();
			trangThanhToanForm.Show();
		}


		

		private void frm_DanhSachBan_Load(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Maximized;

		}


	

		private void btn_AddKH_Click(object sender, EventArgs e)
		{
			frmThemKH f = new frmThemKH();
			f.WindowState = FormWindowState.Maximized;
			f.ShowDialog();
			this.Close();
		}

		private void panel2_Paint_1(object sender, PaintEventArgs e)
		{

		}
	}
}
