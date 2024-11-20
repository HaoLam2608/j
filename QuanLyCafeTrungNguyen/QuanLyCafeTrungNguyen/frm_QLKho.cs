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
	public partial class frm_QLKho : Form
	{
		DataTable dtDSNL = new DataTable();
		DataTable dtDSNL_Xuat = new DataTable();
		private int selectedRowIndex = -1; //chỉ số dòng được chọn trong tab nhập kho
		int selectedRowIndex_Xuat = -1; //dòng được chọn trong tab xuất kho
		public frm_QLKho()
		{
			InitializeComponent();
		}

		#region Xử lý sự kiện

		//Load các dữ liệu ban đầu + ẩn một số nút khi chưa đủ điều kiện
		private void frm_QLKho_Load(object sender, EventArgs e)
		{
			try
			{
				DataTable dtLoaiNL = DBConnect.Instance.getTable("select * from LOAINL");
				//Load loại nguyên liệu cho tab Nguyên liệu
				cmb_LoaiNL.DataSource = dtLoaiNL;
				cmb_LoaiNL.DisplayMember = "TENLOAI";
				cmb_LoaiNL.ValueMember = "MALOAI";

				//Load loại nguyên liệu cho tab XUẤT kho
				cmb_LoaiNguyenLieu_Xuat.DataSource = dtLoaiNL;
				cmb_LoaiNguyenLieu_Xuat.DisplayMember = "TENLOAI";
				cmb_LoaiNguyenLieu_Xuat.ValueMember = "MALOAI";

				//Load loại nguyên liệu cho tab NHẬP kho
				cmb_LoaiNL_Nhap.DataSource = dtLoaiNL;
				cmb_LoaiNL_Nhap.DisplayMember = "TENLOAI";
				cmb_LoaiNL_Nhap.ValueMember = "MALOAI";


				DataTable dtNhaCC = DBConnect.Instance.getTable("select * from NhaCungCap");
				//Load nhà cung cấp cho tab  Nguyên liệu
				cmb_Nhacc.DataSource = dtNhaCC;
				cmb_Nhacc.DisplayMember = "TenNhaCungCap";
				cmb_Nhacc.ValueMember = "MaNhaCungCap";

				//Load nhà cung cấp cho tab nhập kho
				cmb_NhaCC_Nhap.DataSource = dtNhaCC;
				cmb_NhaCC_Nhap.DisplayMember = "TenNhaCungCap";
				cmb_NhaCC_Nhap.ValueMember = "MaNhaCungCap";


				DataTable dt_ChiNhanh = DBConnect.Instance.getTable("select * from ChiNhanh");
				//Load chi nhánh cho tab  Nhập kho
				cmb_ChiNhanh.DataSource = dt_ChiNhanh;
				cmb_ChiNhanh.DisplayMember = "TenChiNhanh";
				cmb_ChiNhanh.ValueMember = "MaChiNhanh";

				//Load chi nhánh cho tab xuất kho
				cmb_ChiNhanh_Xuat.DataSource = dt_ChiNhanh;
				cmb_ChiNhanh_Xuat.DisplayMember = "TenChiNhanh";
				cmb_ChiNhanh_Xuat.ValueMember = "MaChiNhanh";

				string query =
					"select MaNguyenLieu, TENLOAI, TenNguyenLieu, SOLUONGTON, TENDVT, TenNhaCungCap from DSNGUYENLIEU";
				DataTable dtNguyenLieu = DBConnect.Instance.getTable(query);
				dtgv_dsNguyenLieu.DataSource = dtNguyenLieu; //Load ds nguyên liệu cho tab nguyên liệu

				DataTable dt_dsNL = DBConnect.Instance.getTable("select * from NguyenLieu");
				//Load dữ liệu cho comboBox ds các nguyên liệu đã có trong tab NHẬP kho
				cmb_NguyenLieu.DataSource = dt_dsNL;
				cmb_NguyenLieu.DisplayMember = "TenNguyenLieu";
				cmb_NguyenLieu.ValueMember = "MaNguyenLieu";

				//hiện ngày nhập hàng và ngày xuất hàng
				lb_NgayNhap.Text = lb_NgayXuat.Text = DateTime.Now.ToString("yyyy-MM-dd");

				//Load dữ liệu lên bảng ds các nguyên liệu để xuất trong tab xuất kho
				string querygetItemXuat = "select MaNguyenLieu, TenNguyenLieu from NguyenLieu";
				DataTable dt_dsXuat = DBConnect.Instance.getTable(querygetItemXuat);
				dtgv_dsNLDeXuat.DataSource = dt_dsXuat;

				dtgv_dsNLNhap.DataSource = dtDSNL;
				dtgv_dsNLXuat.DataSource = dtDSNL_Xuat;

				btn_AddNL.Enabled = false;
				btn_XoaNL.Enabled = false;
				btn_InsertPN.Enabled = false;

				btn_ThemNL_Xuat.Enabled = false;
				btn_XoaNL_Xuat.Enabled = false;
				btn_LuuPX.Enabled = false;

				dtDSNL.Columns.Add("MaNL");
				dtDSNL.Columns.Add("LoaiNL");
				dtDSNL.Columns.Add("TenNL");
				dtDSNL.Columns.Add("SoLuong");
				dtDSNL.Columns.Add("GiaNhap");

				dtDSNL_Xuat.Columns.Add("MaNLXuat");
				dtDSNL_Xuat.Columns.Add("TenNLXuat");
				dtDSNL_Xuat.Columns.Add("SoLuongXuat");
			}
			catch(Exception ex)
			{
				MessageBox.Show("Không có quyền truy cập","Lỗi" , MessageBoxButtons.OK , MessageBoxIcon.Error);
			}
			

		}

		#region Tab Nguyên Liệu

		// Xử lý sự kiện lọc nguyên liệu
		private void btn_Loc_Click(object sender, EventArgs e)
		{
			try
			{
				string query =
					"Select MaNguyenLieu, TENLOAI, TenNguyenLieu, SOLUONGTON, TENDVT, TenNhaCungCap from DSNGUYENLIEU ";
				string loaiNL;
				string maNHACC;
				if (cmb_LoaiNL.SelectedValue != null)
				{
					loaiNL = cmb_LoaiNL.SelectedValue.ToString();
					query +=
						"where MALOAI = '" + loaiNL + "'";

					if (cmb_Nhacc.SelectedValue != null)
					{
						maNHACC = cmb_Nhacc.SelectedValue.ToString();
						query += " and MaNhaCungCap = '" + maNHACC + "' ";
					}

					if (string.IsNullOrEmpty(txt_SoLuongTon.Text) == false)
					{
						query += " and SOLUONGTON >= " + txt_SoLuongTon.Text;
					}
				}
				else
				{
					if (cmb_Nhacc.SelectedValue != null)
					{
						maNHACC = cmb_Nhacc.SelectedValue.ToString();
						query += " where MaNhaCungCap = '" + maNHACC + "' ";
					}

					if (string.IsNullOrEmpty(txt_SoLuongTon.Text) == false)
					{
						if (query.Contains("where") == true)
							query += " and SOLUONGTON >= " + txt_SoLuongTon.Text;
						else
							query += " where SOLUONGTON >= " + txt_SoLuongTon.Text;
					}
				}

				DataTable dt = DBConnect.Instance.getTable(query);
				dtgv_dsNguyenLieu.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không có quyền truy cập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}
		//Reload dữ liệu cho bảng nguyên liệu
		private void btn_Reload_Click(object sender, EventArgs e)
		{
			HienThiDSNL();
		}
		#endregion

		#region Tab Nhập kho
		//Thêm vào bảng tạm chứa ds các nguyên liệu cần nhập
		private void btn_AddNL_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow dr = dtDSNL.NewRow();
				string maNL = cmb_NguyenLieu.SelectedValue.ToString().Trim();
				if (dtDSNL.Rows.Count != 0)
				{
					foreach (DataGridViewRow row in dtgv_dsNLNhap.Rows)
					{
						if (string.Compare(maNL, row.Cells["MaNL"].FormattedValue.ToString()) == 0)
						{
							row.Cells["SoLuong"].Value = txt_SoLuongNhap.Text;
							row.Cells["GiaNhap"].Value = txt_GiaNhap.Text;
							return;
						}
					}

				}
				dr["MaNL"] = maNL;
				dr["LoaiNL"] = cmb_LoaiNL_Nhap.Text;
				dr["TenNL"] = cmb_NguyenLieu.Text;
				dr["SoLuong"] = txt_SoLuongNhap.Text;
				dr["GiaNhap"] = txt_GiaNhap.Text;

				dtDSNL.Rows.Add(dr);

				btn_XoaNL.Enabled = true;
				btn_InsertPN.Enabled = IsEnableBtnAddPN();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không có quyền truy cập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		//Sự kiện thay đổi ds loại và nguyên liệu mà nhà cung cấp đó có cung ứng
		private void cmb_NhaCC_Nhap_SelectionChangeCommitted(object sender, EventArgs e)
		{
			DataTable dt = updateLoaiNLvaLoai(cmb_NhaCC_Nhap.SelectedValue.ToString());
			cmb_LoaiNL_Nhap.DataSource = dt;
			cmb_LoaiNL_Nhap.DisplayMember = "TENLOAI";
			cmb_LoaiNL_Nhap.ValueMember = "MALOAI";

		}

		//Cập nhật lại ds nguyên liệu theo mã loại
		private void cmb_LoaiNL_Nhap_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{

			string query = "select * from NguyenLieu where MALOAI = '" + cmb_LoaiNL_Nhap.SelectedValue.ToString() + "'";
			DataTable dt = DBConnect.Instance.getTable(query);
			if (dt != null)
			{
				cmb_NguyenLieu.DataSource = dt;
				cmb_NguyenLieu.DisplayMember = "TenNguyenLieu";
				cmb_NguyenLieu.ValueMember = "MaNguyenLieu";
			}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không có quyền truy cập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// Hiện tên nhà cung cấp khi thay đổi lựa chọn trên combobox
		private void cmb_NhaCC_Nhap_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataRowView selectedRow = (DataRowView)cmb_NhaCC_Nhap.SelectedItem;
			lb_TenNhaCC.Text = selectedRow["TenNhaCungCap"].ToString();
		}

		//Tạo mã phiếu nhập
		private void btn_TaoMaPN_Click(object sender, EventArgs e)
		{
			try
			{

			string mapn = "PN";
			mapn += DateTime.Now.ToString("ddMMyyyy");
			string query = "select MAPHIEUNHAP from PHIEUNHAP where MAPHIEUNHAP like '" + mapn + "%' order by MAPHIEUNHAP desc";
			DataTable dt = DBConnect.Instance.getTable(query);
			if (dt.Rows.Count == 0) //Nhập cho ngày mới;
			{
				mapn += "001";
			}
			else
			{
				int stt = int.Parse(dt.Rows[0][0].ToString().Substring(12));
				stt++;
				if (stt.ToString().Length == 1)
				{
					mapn += "00" + stt.ToString();
				}
				else if (stt.ToString().Length == 2)
					mapn += "0" + stt.ToString();
				else
					mapn += stt.ToString();
			}

			lb_MaPhieuNhap.Text = mapn;
			btn_InsertPN.Enabled = IsEnableBtnAddPN();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không có quyền truy cập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		//Tính lại tổng tiền khi thêm 1 sản phẩm mới vào dtgv
		private void dtgv_dsNLNhap_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			double tongTien = tinhTongTien();
			lb_TongTien.Text = tongTien.ToString() + " VND";
		}

		//Tính lại tổng tiền khi thayy đổi giá trị 1 ô số lượng hoặc đơn giá trong dtgv
		private void dtgv_dsNLNhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
			{
				double tongTien = tinhTongTien();
				lb_TongTien.Text = tongTien.ToString() + " VND";
			}
		}

		//hiện tên chi nhánh khi thay đổi lựa chọn
		private void cmb_ChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataRowView selectedRow = (DataRowView)cmb_ChiNhanh.SelectedItem;
			lb_TenChiNhanh.Text = selectedRow["TenChiNhanh"].ToString();
		}

		//Xóa 1 dòng trong ds các sản phẩm sẽ được nhập
		private void btn_XoaNL_Click(object sender, EventArgs e)
		{
			DialogResult r = new DialogResult();
			r = MessageBox.Show("Bạn có muốn xóa dòng này không!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (r == DialogResult.Yes)
			{
				if (selectedRowIndex != -1 && selectedRowIndex < dtgv_dsNLNhap.Rows.Count)
				{
					// Lấy dòng được chọn
					DataGridViewRow row = dtgv_dsNLNhap.Rows[selectedRowIndex];

					//Lấy ra chỉ số dòng được chọn
					int index = row.Index;

					dtDSNL = (DataTable)dtgv_dsNLNhap.DataSource;

					// Xóa dòng tương ứng trong DataTable
					dtDSNL.Rows[index].Delete();

					// Cập nhật lại DataGridView
					dtDSNL.AcceptChanges();
					dtgv_dsNLNhap.Refresh();
					lb_TongTien.Text = tinhTongTien().ToString(); //Tính lại tổng tiền sau khi xóa
					if (dtDSNL.Rows.Count <= 0)
						btn_InsertPN.Enabled = IsEnableBtnAddPN(); //Nếu ds không có item nào thì ẩn nút lưu phiếu nhập
				}
				else
				{
					MessageBox.Show("Vui lòng chọn một dòng để xóa.");
				}
			}

		}

		//Thêm vào csdl bảng phiếu nhập và chi tiết phiếu nhập
		private void btn_InsertPN_Click(object sender, EventArgs e)
		{
			string tongTien = lb_TongTien.Text.Split(' ')[0];
			string macn = cmb_ChiNhanh.SelectedValue.ToString().Trim();
			string mancc = cmb_NhaCC_Nhap.SelectedValue.ToString().Trim();
			string query =
				"insert into PhieuNhap values('" + lb_MaPhieuNhap.Text + "', '" + mancc + "', '" + lb_NgayNhap.Text + " ', " + tongTien + ", '" + macn + "')";
			int r = DBConnect.Instance.getNonquery(query); // Thêm 1 dòng vào bảng phiếu nhập
			if (r == 1)
			{//thêm nhiều dòng vào bảng chi tiết phiếu nhập
				foreach (DataRow dr in dtDSNL.Rows)
				{
					string maNL = dr["MaNL"].ToString();
					int sl = int.Parse(dr["SoLuong"].ToString());
					double donGia = double.Parse(dr["SoLuong"].ToString());

					string query_ct =
						"insert into CHITIETPHIEUNHAP values ('" + lb_MaPhieuNhap.Text + "','" + maNL + "'," + sl + "," + donGia + ")";
					int k = DBConnect.Instance.getNonquery(query_ct);
					if (k == 0)
					{
						MessageBox.Show("Lưu chi tiết phiếu nhập không thành công");
						return;
					}
				}
				MessageBox.Show("Lưu thành công!");
				txt_SoLuongNhap.Clear();
				txt_GiaNhap.Clear();
				dtDSNL.Clear();

				HienThiDSNL();
			}
			else
			{
				MessageBox.Show("Lưu phiếu nhập không thành công!!");
				return;
			}
		}

		//Lưu lại dòng chứa ô vừa chọn
		private void dtgv_dsNLNhap_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			selectedRowIndex = e.RowIndex;
		}
		#endregion

		#region Tab Xuất Kho
		//Tạo mã phiếu xuất
		private void btn_TaoMaPX_Click(object sender, EventArgs e)
		{
			string mapx = "PN";
			mapx += DateTime.Now.ToString("ddMMyyyy");
			string query = "select MAPX from PHIEUXUAT where MAPX like '" + mapx + "%' order by MAPX desc";
			DataTable dt = DBConnect.Instance.getTable(query);
			if (dt.Rows.Count == 0) //Nhập cho ngày mới;
			{
				mapx += "001";
			}
			else
			{
				int stt = int.Parse(dt.Rows[0][0].ToString().Substring(12));
				stt++;
				if (stt.ToString().Length == 1)
				{
					mapx += "00" + stt.ToString();
				}
				else if (stt.ToString().Length == 2)
					mapx += "0" + stt.ToString();
				else
					mapx += stt.ToString();
			}

			lb_MaPX.Text = mapx;
			btn_LuuPX.Enabled = IsEnalbleLuuPX();
		}

		private void btn_ThemNL_Xuat_Click(object sender, EventArgs e)
		{
			DataTable dt = (DataTable)dtgv_dsNLDeXuat.DataSource;
			DataRow dr = dtDSNL_Xuat.NewRow();

			string maNL = dt.Rows[selectedRowIndex_Xuat]["MaNguyenLieu"].ToString().Trim();
			if (dtDSNL_Xuat.Rows.Count != 0)
			{
				foreach (DataGridViewRow row in dtgv_dsNLXuat.Rows)
				{
					if (string.Compare(maNL, row.Cells["maNLXuat"].FormattedValue.ToString().Trim()) == 0)
					{
						row.Cells["soLuongXuat"].Value = txt_SoLuongXuat.Text;
						return;
					}
				}

			}
			dr["MaNLXuat"] = dt.Rows[selectedRowIndex_Xuat]["MaNguyenLieu"].ToString();
			dr["TenNLXuat"] = dt.Rows[selectedRowIndex_Xuat]["TenNguyenLieu"].ToString();
			dr["SoLuongXuat"] = txt_SoLuongXuat.Text;

			dtDSNL_Xuat.Rows.Add(dr);

			//btn_XoaNL.Enabled = true;
			btn_LuuPX.Enabled = IsEnalbleLuuPX();
		}

		//Tìm kiếm tên nguyên liệu
		private void txt_ThanhSearch_TextChanged(object sender, EventArgs e)
		{
			string query = "select * from  DBConnect.Instanceo.TIMKIEMNL('" + txt_ThanhSearch.Text + "')";//Dùng function trong csdl
			DataTable dt = DBConnect.Instance.getTable(query);
			dtgv_dsNLDeXuat.DataSource = dt;
		}

		//Lọc theo loại nguyên liệu
		private void cmb_LoaiNguyenLieu_Xuat_SelectionChangeCommitted(object sender, EventArgs e)
		{
			string query =
				"select MaNguyenLieu, TenNguyenLieu from NguyenLieu where MaLoai = '" + cmb_LoaiNguyenLieu_Xuat.SelectedValue.ToString() + "'";
			DataTable dt = DBConnect.Instance.getTable(query);

			dtgv_dsNLDeXuat.DataSource = dt;
		}

		private void txt_ThanhSearch_Enter(object sender, EventArgs e)
		{
			txt_ThanhSearch.Text = "";//Xóa placeholder
		}

		private void dtgv_dsNLDeXuat_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			selectedRowIndex_Xuat = e.RowIndex;
		}

		//Lưu phiếu xuất và chi tiết phiếu xuất vào csdl
		private void btn_LuuPX_Click(object sender, EventArgs e)
		{
			string mapx = lb_MaPX.Text;
			int macn = int.Parse(cmb_ChiNhanh_Xuat.SelectedValue.ToString());
			string ngaytaopx = lb_NgayXuat.Text;
			string ghichu = txt_GhiChu.Text;

			//Thêm vào một dòng trong bảng phiếu xuất
			string query = "EXEC INSERTPX '" + mapx + "' ,NULL ," + macn + " ,'" + ngaytaopx + "', 'N" + ghichu + "'";
			int k = DBConnect.Instance.getNonquery(query);
			if (k == 1)
			{
				foreach (DataRow item in dtDSNL_Xuat.Rows)
				{
					string manl = item["MaNLXuat"].ToString();
					int soLuongXuat = int.Parse(item["SoLuongXuat"].ToString());

					string queryctpx = "EXEC INSERTCTPX '" + mapx + "', '" + manl + "', " + soLuongXuat;
					int r = DBConnect.Instance.getNonquery(queryctpx);
					if (r == 0)
					{
						MessageBox.Show("Lưu không thành công");
						return;
					}
				}
				MessageBox.Show("Lưu thành công");
			}
			else
				MessageBox.Show("Lưu không thành công");
		}
		#endregion

		#endregion


		#region Ràng buộc dữ liệu
		private void cmb_NguyenLieu_SelectionChangeCommitted(object sender, EventArgs e)
		{
			btn_AddNL.Enabled = IsEnableBtnAddNL();
		}
		private void txt_TenNL_Leave(object sender, EventArgs e)
		{
			TextBox txt = (TextBox)sender;
			if (string.IsNullOrEmpty(txt.Text))
			{
				errorProvider1.SetError(txt, "Không được bỏ trống!");
			}
			else
			{
				errorProvider1.Clear();
			}

			btn_AddNL.Enabled = IsEnableBtnAddNL();
		}

		private void txt_GiaNhap_TextChanged(object sender, EventArgs e)
		{
			TextBox txt = (TextBox)sender;
			if (txt.Text.Length > 0 && txt.Text.All(char.IsDigit) == false)
			{
				errorProvider1.SetError(txt, "Chỉ chứa các kí tự số");
			}
			else
			{
				errorProvider1.Clear();
			}
		}

		private void txt_TenNL_TextChanged(object sender, EventArgs e)
		{
			TextBox txt = (TextBox)sender;
			if (txt.Text.Length > 0 && txt.Text.All(char.IsDigit) == true)
			{
				errorProvider1.SetError(txt, "Không được chứa các kí tự số");
			}
			else
			{
				errorProvider1.Clear();
			}
		}

		private bool IsEnableBtnAddNL()
		{
			List<ComboBox> lstComboBox = this.Controls.OfType<ComboBox>().ToList();
			List<TextBox> lstTextBox = grb_In4NguyenLieuNhap.Controls.OfType<TextBox>().ToList();
			foreach (ComboBox comboBox in lstComboBox)
			{
				if (comboBox.SelectedValue == null)
				{
					return false;
				}
			}

			foreach (TextBox txt in lstTextBox)
			{
				if (string.IsNullOrEmpty(txt.Text) == true)
					return false;
			}

			return true;
		}

		public bool IsEnableBtnAddPN()
		{
			if (dtDSNL.Rows.Count > 0 && lb_MaPhieuNhap.Text != "")
				return true;
			else
				return false;
		}

		private bool IsEnalbleThemNLXuat()
		{
			if (selectedRowIndex_Xuat < 0)
				return false;
			if (string.IsNullOrEmpty(txt_SoLuongXuat.Text))
				return false;
			return true;
		}

		private bool IsEnalbleLuuPX()
		{
			if (dtDSNL_Xuat.Rows.Count <= 0)
				return false;
			if (cmb_ChiNhanh_Xuat.SelectedItem == null)
				return false;
			if (string.IsNullOrEmpty(lb_MaPX.Text))
				return false;
			return true;
		}
		private void txt_GiaNhap_MouseLeave(object sender, EventArgs e)
		{
			btn_AddNL.Enabled = IsEnableBtnAddNL();
			btn_ThemNL_Xuat.Enabled = IsEnalbleThemNLXuat();
		}

		#endregion

		#region Function tự định nghĩa

		private DataTable updateLoaiNLvaLoai(string maNhaCC)
		{
			DataTable dt = new DataTable();
			string queryLayLoaiNLTheoNhaCC = "SELECT * FROM DBConnect.Instanceo.LAYLOAITHEONHACC('" + maNhaCC + "')";
			dt = DBConnect.Instance.getTable(queryLayLoaiNLTheoNhaCC);
			return dt;
		}

		private double tinhTongTien()
		{
			double tongTien = 0;
			foreach (DataRow dr in dtDSNL.Rows)
			{
				tongTien += double.Parse(dr["SoLuong"].ToString()) * double.Parse(dr["GiaNhap"].ToString());
			}

			return tongTien;
		}

		public void HienThiDSNL()
		{
			string query =
				"select MaNguyenLieu, TENLOAI, TenNguyenLieu, SOLUONGTON, TENDVT, TenNhaCungCap from DSNGUYENLIEU";
			DataTable dtNguyenLieu = DBConnect.Instance.getTable(query);
			dtgv_dsNguyenLieu.DataSource = dtNguyenLieu;
		}



		#endregion


	}
}
