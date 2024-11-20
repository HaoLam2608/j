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
    public partial class frm_TrangChu : Form
    {
        public frm_TrangChu()
        {
            InitializeComponent();
        }
		private Form currentFormChild;
		private void OpenChildForm(Form childForm)
		{
			if (currentFormChild != null)
			{
				currentFormChild.Close();
			}
			currentFormChild = childForm;
			childForm.TopLevel = false;
			childForm.FormBorderStyle = FormBorderStyle.None;
			childForm.Dock = DockStyle.Fill;
			panel_body.Controls.Add(childForm);
			panel_body.Tag = childForm;
			childForm.BringToFront();
			childForm.Show();
		}

		private void btn_HoaDon_Click(object sender, EventArgs e)
		{
			OpenChildForm(new frm_HoaDon());
		}

		private void btn_KH_Click(object sender, EventArgs e)
		{
			OpenChildForm(new frmThemKH());
		}

		private void btn_DSBAN_Click(object sender, EventArgs e)
		{
			OpenChildForm(new frm_DanhSachBan());
		}

		private void frm_TrangChu_Load(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Maximized;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OpenChildForm(new frm_QLKho());
		}

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
			OpenChildForm(new frm_QuanLyNV());
        }
    }
}
