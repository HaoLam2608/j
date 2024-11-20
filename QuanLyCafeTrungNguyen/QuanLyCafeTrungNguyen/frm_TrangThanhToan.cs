using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCafeTrungNguyen
{
	public partial class frm_TrangThanhToan : Form
	{

		private frm_DanhSachBan frmDanhSachBan;
		private PictureBox targetPictureBox;
		DBConnect db = new DBConnect();
		private frm_DanhSachBan formDanhSachBan; // Tham chiếu đến frmDanhSachBan
		string selectedProductName = "";
		decimal selectedProductPrice = 0;
		string selectedIDProduct = "";

		public frm_TrangThanhToan(frm_DanhSachBan frmDanhSach, PictureBox pictureBox)
		{
			InitializeComponent();
			this.formDanhSachBan = frmDanhSach;
			targetPictureBox = pictureBox;

		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (targetPictureBox != null)
			{
				// Thay đổi màu của PictureBox đã nhấn
				targetPictureBox.BackColor = Color.LightCoral;
			}
			UpdateFinalAmount();
		}
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void btn_ThemHD_Click(object sender, EventArgs e)
		{
			string formattedDate = DateTime.Now.ToString("yyyy-MM-dd");
			string maHoadon = db.GenerateMaHoaDon();
			float giamGia = float.Parse(lb_GiamGia.Text.Replace("$", "").Trim());
			decimal TongTien = decimal.Parse(txt_TongTien.Text.Replace("$","").Trim());
			float thanhTien = float.Parse(lb_ThanhTien.Text.Replace("$", "").Trim());
			string MAKH = txtMaKH.Text.Trim();

			if(MAKH == "KHVL")
			{
				var danhSachSanPham = ((frm_DanhSachBan)this.Owner).danhSachSanPhamCuaCacBan[((frm_DanhSachBan)this.Owner).banHienTai].sanPhams;
				string query = "insert into HoaDon values('" + maHoadon + "','" + formattedDate + "','" + giamGia + "','" + TongTien + "','" + thanhTien + "','" + 1 + "','" + "KHVL" + "')";
				int k = db.getNonquery(query);
				int q;
				foreach (var sanPham in danhSachSanPham)
				{
					string query1 = "insert into ChiTietHoaDon values('" + maHoadon + "','" + sanPham.maSP + "','" + sanPham.SoLuong + "','" + sanPham.Gia + "')";
					q = db.getNonquery(query1);
					
				}
			}
			else
			{
				var danhSachSanPham = ((frm_DanhSachBan)this.Owner).danhSachSanPhamCuaCacBan[((frm_DanhSachBan)this.Owner).banHienTai].sanPhams;
				string query = "insert into HoaDon values('" + maHoadon + "','" + formattedDate + "','" + giamGia + "','" + TongTien + "','" + thanhTien + "','" + 1 + "','" + MAKH + "')";
				int k = db.getNonquery(query);
				int q;
				foreach (var sanPham in danhSachSanPham)
				{
					string query1 = "insert into ChiTietHoaDon values('" + maHoadon + "','" + sanPham.maSP + "','" + sanPham.SoLuong + "','" + sanPham.Gia + "')";
					q = db.getNonquery(query1);
				}
			}
			
			if (targetPictureBox != null)
			{
				// Thay đổi màu của PictureBox đã nhấn
				targetPictureBox.BackColor = Color.FromArgb(128, 255, 128);
				MessageBox.Show("Đã thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

				// Xóa dữ liệu trong ListBox và các trường thông tin
				lstb_dsSanPhamOrdered.Items.Clear();
				txt_SDTKH.Clear();
				lb_TenKH.Text = string.Empty;
				lb_LoaiKH.Text = string.Empty;
				txt_DonGiaSP.Clear();
				txt_TongTien.Clear();

				// Xóa thông tin của bàn hiện tại trong frm_DanhSachBan
				var danhSachBan = (frm_DanhSachBan)this.Owner;
				if (danhSachBan.danhSachSanPhamCuaCacBan.ContainsKey(danhSachBan.banHienTai))
				{
					danhSachBan.danhSachSanPhamCuaCacBan[danhSachBan.banHienTai] = (new List<SanPham>(), new KhachHang()); // Đặt lại dữ liệu cho bàn
				}
				((frm_DanhSachBan)this.Owner).totalAmount = 0;
				((frm_DanhSachBan)this.Owner).totalDiscount = 0;


				this.Close();

			}
		}
	

		private void LoadDataToListBox()
		{
			string query = "SELECT TenSanPham, DonGia,MaSanPham FROM SanPham";
			DataTable dt = db.getTable(query);
			dgv_SANPHAM.DataSource = dt;
			dgv_SANPHAM.RowHeadersVisible = false;
			dgv_SANPHAM.Columns["MaSanPham"].Visible = false;
			// Chỉnh font chữ cho toàn bộ DataGridView
			dgv_SANPHAM.Font = new Font("Arial", 12, FontStyle.Regular);

		}
		private void frm_TrangThanhToan_Load(object sender, EventArgs e)
		{
			LoadDataToListBox();
			txtMaKH.Visible = false;

		}

		private void btn_LoaiCf_Click(object sender, EventArgs e)
		{
			string query = "select TenSanPham,DonGia from SanPham where MALOAI = '1' ";
			int k = db.getNonquery(query);

			if (k != 0)
			{
				DataTable dt = db.getTable(query);

				dgv_SANPHAM.DataSource = dt;

			}

		}

		private void btn_LoaiTraTraiCay_Click(object sender, EventArgs e)
		{
			string query = "select TenSanPham,DonGia from SanPham where MALOAI = '2' ";
			int k = db.getNonquery(query);

			if (k != 0)
			{
				DataTable dt = db.getTable(query);

				dgv_SANPHAM.DataSource = dt;

			}
		}



		private void btn_LoaiMatcha_Click(object sender, EventArgs e)
		{
			string query = "select TenSanPham,DonGia from SanPham where MALOAI = '3' ";
			int k = db.getNonquery(query);

			if (k != 0)
			{
				DataTable dt = db.getTable(query);

				dgv_SANPHAM.DataSource = dt;

			}
		}

		private void btn_LoaiBanh_Click(object sender, EventArgs e)
		{
			string query = "select TenSanPham,DonGia from SanPham where MALOAI = '4' ";
			int k = db.getNonquery(query);

			if (k != 0)
			{
				DataTable dt = db.getTable(query);

				dgv_SANPHAM.DataSource = dt;

			}
		}

		private void dgv_SANPHAM_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

			if (e.RowIndex >= 0) // Kiểm tra chỉ số hàng hợp lệ
			{
				DataGridViewRow row = dgv_SANPHAM.Rows[e.RowIndex];
				txt_DonGiaSP.Text = row.Cells["DonGia"].Value.ToString();
				selectedProductName = row.Cells["TenSanPham"].Value.ToString();
				selectedProductPrice = Convert.ToDecimal(row.Cells["DonGia"].Value);
				selectedIDProduct = row.Cells["MaSanPham"].Value.ToString();
			}
		}



		private void btn_AddSanPham_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_SoLuongMon.Text))
			{
				MessageBox.Show("Vui lòng nhập số lượng ");
			}
			else
			{
				if (!string.IsNullOrEmpty(selectedProductName))
				{
					int soLuong = int.Parse(txt_SoLuongMon.Text);
					decimal tongTien = soLuong * selectedProductPrice;

					// Cập nhật tổng tiền
					((frm_DanhSachBan)this.Owner).totalAmount += tongTien;
					txt_TongTien.Text = ((frm_DanhSachBan)this.Owner).totalAmount.ToString("C");

					// Tính giảm giá cho món hàng
					decimal discountRate = CalculateDiscount(lb_LoaiKH.Text);
					decimal discountAmount = tongTien * discountRate; // Tính giảm giá cho món hiện tại

					// Cập nhật tổng giảm giá
					((frm_DanhSachBan)this.Owner).totalDiscount += discountAmount; // Cộng dồn giảm giá
					lb_GiamGia.Text = $"{((frm_DanhSachBan)this.Owner).totalDiscount:C}"; // Hiển thị tổng giảm giá

					decimal finalAmount = ((frm_DanhSachBan)this.Owner).totalAmount - ((frm_DanhSachBan)this.Owner).totalDiscount;


					// Thêm sản phẩm vào ListBox
					lstb_dsSanPhamOrdered.Items.Add($"Món: {selectedProductName} - Đơn giá: {selectedProductPrice:C} - Số lượng: {soLuong} - Tổng tiền của món: {tongTien:C}");

					var sanPham = new SanPham
					{
						Ten = selectedProductName,
						Gia = selectedProductPrice,
						SoLuong = soLuong,
						TongTien = tongTien,
						maSP=selectedIDProduct,

					};

					// Kiểm tra nếu bàn chưa có danh sách sản phẩm
					if (!((frm_DanhSachBan)this.Owner).danhSachSanPhamCuaCacBan.ContainsKey(((frm_DanhSachBan)this.Owner).banHienTai))
					{
						// Nếu bàn chưa có, khởi tạo danh sách sản phẩm và thông tin khách hàng
						((frm_DanhSachBan)this.Owner).danhSachSanPhamCuaCacBan[((frm_DanhSachBan)this.Owner).banHienTai] = (new List<SanPham>(), new KhachHang());
					}

					// Lấy thông tin khách hàng hiện tại
					var khachHang = ((frm_DanhSachBan)this.Owner).danhSachSanPhamCuaCacBan[((frm_DanhSachBan)this.Owner).banHienTai].khachHang;

					// Cập nhật thông tin khách hàng
					khachHang.SDT = txt_SDTKH.Text;
					khachHang.TenKH = lb_TenKH.Text;
					khachHang.LoaiKH = lb_LoaiKH.Text;
					khachHang.GiamGia = ((frm_DanhSachBan)this.Owner).totalDiscount; // Cập nhật tổng giảm giá
					khachHang.ThanhTien = finalAmount;
					khachHang.MaKH= txtMaKH.Text;
					khachHang.TongTien= txt_TongTien.Text;

					// Thêm sản phẩm vào danh sách của bàn hiện tại
					((frm_DanhSachBan)this.Owner).danhSachSanPhamCuaCacBan[((frm_DanhSachBan)this.Owner).banHienTai].sanPhams.Add(sanPham);

					// Xóa số lượng đã nhập
					txt_SoLuongMon.Clear();


				}
				else
				{
					MessageBox.Show("Vui lòng chọn sản phẩm trước khi thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

		}

		// Hàm cập nhật thành tiền
		private void UpdateFinalAmount()
		{
			// Chuyển đổi tổng tiền từ textbox và cộng dồn với tổng cũ
			if (decimal.TryParse(txt_TongTien.Text.Replace("$", "").Trim(), out decimal currentTotalAmount))
			{
				// Lấy giảm giá từ KhachHang của bàn hiện tại
				var frmDanhSachBan = (frm_DanhSachBan)this.Owner;
				var khachHang = ((frm_DanhSachBan)this.Owner).danhSachSanPhamCuaCacBan[((frm_DanhSachBan)this.Owner).banHienTai].khachHang;

				// Lấy giá trị giảm giá từ khách hàng đã lưu

				lb_GiamGia.Text = $"{((frm_DanhSachBan)this.Owner).totalDiscount:C}";
				txt_TongTien.Text = $"{((frm_DanhSachBan)this.Owner).totalAmount:C}";
				// Tính thành tiền sau khi trừ giảm giá
				decimal finalAmount = ((frm_DanhSachBan)this.Owner).totalAmount - ((frm_DanhSachBan)this.Owner).totalDiscount;

				lb_ThanhTien.Text = $"{finalAmount:C}"; // Hiển thị thành tiền

				khachHang.ThanhTien = finalAmount;

				
			}
			else
			{
				MessageBox.Show("Có lỗi trong việc tính tổng tiền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		// Hàm tính giảm giá
		private decimal CalculateDiscount(string customerType)
		{
			switch (customerType)
			{
				case "VIP":
					return 0.30m; // Giảm 30%
				case "Thân thiết":
					return 0.20m; // Giảm 20%
				case "Thành viên":
					return 0.10m; // Giảm 10%
				default:
					return 0; // Không giảm
			}
		}


		private void btn_DelSP_Click(object sender, EventArgs e)
		{
			// Kiểm tra xem có món nào được chọn và số lượng cần hủy là hợp lệ
			if (lstb_dsSanPhamOrdered.SelectedItem != null && int.TryParse(txt_SoLuongMon.Text, out int soLuongHuy) && soLuongHuy > 0)
			{
				// Lấy chuỗi món được chọn
				string selectedItem = lstb_dsSanPhamOrdered.SelectedItem.ToString();

				// Tách chuỗi để lấy thông tin
				string[] parts = selectedItem.Split(new string[] { " - " }, StringSplitOptions.None);
				if (parts.Length <= 5) // Đảm bảo đúng định dạng chuỗi
				{
					// Lấy số lượng hiện tại và tổng tiền của món
					string soLuongStr = parts[2].Replace("Số lượng: ", "").Trim();
					string tongTienStr = parts[3].Replace("Tổng tiền của món: ", "").Replace("$", "").Trim();

					if (int.TryParse(soLuongStr, out int soLuongHienTai))
					{
						// Kiểm tra số lượng hủy không được vượt quá số lượng hiện tại
						if (soLuongHuy > soLuongHienTai)
						{
							MessageBox.Show("Số lượng hủy không được vượt quá số lượng hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							txt_SoLuongMon.Clear();
							return; // Kết thúc phương thức nếu số lượng hủy không hợp lệ
						}

						// Tính tổng tiền của món hiện tại
						if (decimal.TryParse(tongTienStr, out decimal tongTienHienTai))
						{
							// Tính đơn giá dựa trên tổng tiền hiện tại và số lượng hiện tại
							decimal donGia = tongTienHienTai / soLuongHienTai;

							// Tính lại tổng tiền sau khi hủy
							int soLuongMoi = soLuongHienTai - soLuongHuy;
							decimal tongTienMoi = soLuongMoi * donGia;

							// Giảm tổng tiền cộng dồn
							decimal tienGiam = soLuongHuy * donGia;
							((frm_DanhSachBan)this.Owner).totalAmount -= tienGiam;
							txt_TongTien.Text = ((frm_DanhSachBan)this.Owner).totalAmount.ToString("C");

							// Cập nhật thông tin giảm giá
							decimal discountRate = CalculateDiscount(lb_LoaiKH.Text);
							decimal discountAmount = tongTienHienTai * discountRate; // Giảm giá cho món hiện tại
							((frm_DanhSachBan)this.Owner).totalDiscount -= discountAmount * (soLuongHuy / (decimal)soLuongHienTai); // Cập nhật tổng giảm giá
							lb_GiamGia.Text = $"{((frm_DanhSachBan)this.Owner).totalDiscount:C}"; // Hiển thị tổng giảm giá

							if (soLuongMoi > 0)
							{
								// Cập nhật lại món trong ListBox nếu số lượng mới > 0
								lstb_dsSanPhamOrdered.Items[lstb_dsSanPhamOrdered.SelectedIndex] =
									$"Món: {parts[0].Replace("Món: ", "").Trim()} - Đơn giá: {donGia:C} - Số lượng: {soLuongMoi} - Tổng tiền của món: {tongTienMoi:C} - Giảm giá: {discountAmount:C}";
							}
							else if (soLuongMoi == 0)
							{
								// Xóa món khỏi ListBox nếu số lượng mới = 0
								lstb_dsSanPhamOrdered.Items.RemoveAt(lstb_dsSanPhamOrdered.SelectedIndex);
							}

							// Cập nhật lại thông tin khách hàng
							var khachHang = ((frm_DanhSachBan)this.Owner).danhSachSanPhamCuaCacBan[((frm_DanhSachBan)this.Owner).banHienTai].khachHang;
							khachHang.GiamGia = ((frm_DanhSachBan)this.Owner).totalDiscount; // Cập nhật tổng giảm giá
							khachHang.ThanhTien = ((frm_DanhSachBan)this.Owner).totalAmount; // Cập nhật thành tiền
							var currentBan = ((frm_DanhSachBan)this.Owner).banHienTai;
							((frm_DanhSachBan)this.Owner).danhSachSanPhamCuaCacBan[currentBan].sanPhams.RemoveAll(sp => sp.Ten == parts[0].Replace("Món: ", "").Trim() && sp.SoLuong == soLuongHienTai);

							// Xóa số lượng trên txt_SoLuongMon và vô hiệu hóa nút Hủy
							txt_SoLuongMon.Clear();

						}
					}
				}
			}
			else
			{
				MessageBox.Show("Vui lòng nhập số lượng hợp lệ để hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}




		private void lstb_dsSanPhamOrdered_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstb_dsSanPhamOrdered.SelectedItem != null)
			{
				// Lấy chuỗi món được chọn
				string selectedItem = lstb_dsSanPhamOrdered.SelectedItem.ToString();

				// Tách chuỗi để lấy thông tin số lượng
				string[] parts = selectedItem.Split(new string[] { " - " }, StringSplitOptions.None);
				if (parts.Length == 4) // Đảm bảo đúng định dạng chuỗi
				{
					// Tách chuỗi để lấy phần số lượng
					string soLuongStr = parts[2].Replace("Số lượng: ", "").Trim();
					txt_SoLuongMon.Text = soLuongStr;

					// Kích hoạt nút Hủy khi chọn một món

				}
			}
			else
			{
				// Nếu không chọn món nào, vô hiệu hóa nút Hủy

				txt_SoLuongMon.Clear();
			}
		}


		private void txt_SDTKH_TextChanged(object sender, EventArgs e)
		{
			string phoneNumber = txt_SDTKH.Text.Trim(); // Lấy số điện thoại từ TextBox

			if (string.IsNullOrEmpty(phoneNumber))
			{
				lb_LoaiKH.Text = ""; // Xóa nội dung Label nếu không có số điện thoại
				lb_TenKH.Text = ""; // Xóa nội dung Label tên khách hàng
				return;
			}

			var (customerName, customerType, customerID) = db.GetCustomerInfoByPhoneUsingStoredProcedure(phoneNumber);

			if (string.IsNullOrEmpty(customerName) && string.IsNullOrEmpty(customerType))
			{
				lb_LoaiKH.Text = "Không tìm thấy thông tin khách hàng với số điện thoại này.";
				lb_TenKH.Text = ""; // Xóa nội dung Label tên khách hàng
			}
			else
			{
				lb_LoaiKH.Text = $"{customerType}"; // Hiển thị loại khách hàng
				lb_TenKH.Text = $"{customerName}"; // Hiển thị tên khách hàng
				txtMaKH.Text = $"{customerID}";

			}

		}

		private void label2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ck_KVL_CheckedChanged(object sender, EventArgs e)
		{
			txtMaKH.Text = "KHVL";
		}

		
	}
}
