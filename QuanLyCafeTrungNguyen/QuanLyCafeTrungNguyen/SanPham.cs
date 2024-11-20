using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafeTrungNguyen
{
	public class SanPham
	{
		public string Ten { get; set; }
		public decimal Gia { get; set; }
		public int SoLuong { get; set; }
		public decimal TongTien { get; set; }
		
		public string maSP { get; set; }
		

		public override string ToString()
		{
			// Định dạng hiển thị thông tin trong ListBox
			return $"Món: {Ten} - Giá: {Gia:C} - Số lượng: {SoLuong} - Tổng tiền của món: {TongTien:C}";
		}
	}
}
