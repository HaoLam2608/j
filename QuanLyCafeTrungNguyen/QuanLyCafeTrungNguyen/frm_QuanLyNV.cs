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
    public partial class frm_QuanLyNV : Form
    {
        public int seletedIndex = -1;
        public frm_QuanLyNV()
        {
            InitializeComponent();
        }
        public void LoadNV()
        {
            string sql = "select * from XEMDSNV";
            dgv_NhanVien.DataSource = DBConnect.Instance.getTable(sql);
            string sql1 = "select * from CHUCVU where TENCHUCVU != N'Nhân Viên Thu Ngân'";
            cb_Chucvu.DataSource = DBConnect.Instance.getTable(sql1);
            cb_Chucvu.DisplayMember = "TENCHUCVU";
            cb_Chucvu.ValueMember = "MACV";
            string sql2 = "select * from ChiNhanh";
            cb_cn.DataSource = DBConnect.Instance.getTable(sql2);
            cb_cn.ValueMember = "MaChiNhanh";
            cb_cn.DisplayMember = "TenChiNhanh";
        }
        private void frm_QuanLyNV_Load(object sender, EventArgs e)
        {
            LoadNV();
        }

        private void dgv_NhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataTable dt = (DataTable)dgv_NhanVien.DataSource;
            txtManv.Text = dt.Rows[e.RowIndex]["MaNhanVien"].ToString().Trim();
            txtTennv.Text = dt.Rows[e.RowIndex]["TenNhanVien"].ToString().Trim();
            txtDiaChi.Text = dt.Rows[e.RowIndex]["DIACHI"].ToString().Trim();
            txtSDT.Text = dt.Rows[e.RowIndex]["SoDienThoai"].ToString().Trim();
            cb_Chucvu.Text = dt.Rows[e.RowIndex]["TENCHUCVU"].ToString();
            txtTenDN.Text = dt.Rows[e.RowIndex]["TaiKhoan"].ToString().Trim();
            txtMatKhau1.Text = dt.Rows[e.RowIndex]["PASSWORD"].ToString().Trim();
            seletedIndex = e.RowIndex;
        }

        private void btn_TIemKiem_Click(object sender, EventArgs e)
        {
            string sql = $"Select * from NhanVien where TenNhanVien like '%{txtSearch.Text}%'";
            DataTable dt = DBConnect.Instance.getTable(sql);
            dgv_NhanVien.DataSource = dt;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataTable dt = dgv_NhanVien.DataSource as DataTable;
            if (dt != null && dt.Rows.Count > 0)
            {
                string maNhanVien = dt.Rows[seletedIndex]["MaNhanVien"].ToString();

                string sqlLuong = "DELETE FROM LUONG WHERE MaNhanVien = '" + maNhanVien + "'";
                DBConnect.Instance.getNonquery(sqlLuong);

                string sqlNhanVien = "DELETE FROM NhanVien WHERE MaNhanVien = '" + maNhanVien + "'";
                int kq = DBConnect.Instance.getNonquery(sqlNhanVien);

                if (kq != 0)
                {
                    MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNV();
                }
                else
                {
                    MessageBox.Show("Không xóa được nhân viên này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Chọn một nhân viên để xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool KiemTraTrungMaNV(string maNV)
        {

            string query = "SELECT COUNT(*) FROM NhanVien WHERE MaNhanVien = '" + maNV + "'";
            DataTable dt = DBConnect.Instance.getTable(query);

            if (dt.Rows.Count > 0 && int.Parse(dt.Rows[0][0].ToString()) > 0)
            {
                return true;
            }
            return false;
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (KiemTraTrungMaNV(txtManv.Text))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác.");
                return;
            }
            else
            {
                string NhomQuyen = String.Empty;
                if (cb_Chucvu.SelectedText == "Quản lý")
                {
                    NhomQuyen = "NHOM01";
                }
                else if (cb_Chucvu.SelectedText == "Nhân Viên Kho")
                {
                    NhomQuyen = "NHOM03";
                }
                else if (cb_Chucvu.SelectedText == "Nhân Viên Thu Ngân")
                {
                    NhomQuyen = "NHOM02";
                }
                else
                {
                    NhomQuyen = "NHOM04";
                }
                //string Ngay = dateTimePicker1.Value.ToString("dd-MM-yyyy");


                string query = "insert into NhanVien values('" + txtManv.Text + "',N'" + txtTennv.Text + "','" + cb_Chucvu.SelectedValue + "','" + txtSDT.Text + "',N'" + txtDiaChi.Text + "','" + cb_cn.SelectedValue + "','" + NhomQuyen + "','" + txtMatKhau1.Text + "','" + txtTenDN.Text + "')";

                int k = DBConnect.Instance.getNonquery(query);
                if (k != 0)
                {
                    MessageBox.Show("Thêm thành công");
                    LoadNV();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!");
                }
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTennv.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtTenDN.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            DataTable dt = (DataTable)dgv_NhanVien.DataSource;


            SqlConnection con = DBConnect.Instance.con;

            //string Ngay = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            string query = "update NhanVien set TenNhanVien =N'" + txtTennv.Text + "', " +
                           "MaNhanVien = N'" + txtManv.Text + "', " +
                           "SoDienThoai = '" + txtSDT.Text + "', " +
                           "DIACHI = N'" + txtDiaChi.Text + "', " +
                           "TaiKhoan = '" + txtTenDN.Text + "', " +
                           "PASSWORD = '" + txtMatKhau1.Text + "', " +
                           "MACV = '" + cb_Chucvu.SelectedValue + "' where MaNhanVien ='" + txtManv.Text + "'";

            int k = DBConnect.Instance.getNonquery(query);

            if (k != 0)
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thành công");
                LoadNV();

                txtManv.Clear();
                txtTennv.Clear();
                cb_Chucvu.SelectedIndex = -1;
                txtSDT.Clear();
                txtDiaChi.Clear();
                txtTenDN.Clear();
                txtMatKhau1.Clear();
                //dateTimePicker1.Value = DateTime.Today; 

            }
            else
            {
                MessageBox.Show("Cập nhật khách hàng thất bại!");
            }
        }

        private void btn_TaoMa_Click(object sender, EventArgs e)
        {
            string MaNV = DBConnect.Instance.TaoManv();
            if (MaNV != null)
            {
                btn_TaoMa.Enabled = false;
            }
            txtManv.Text = MaNV;
        }
    }
}
