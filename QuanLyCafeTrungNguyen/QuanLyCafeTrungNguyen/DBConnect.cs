using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafeTrungNguyen
{
	public class DBConnect
	{
		private SqlTransaction transaction;
		private static DBConnect instance;
		public static DBConnect Instance { get { if (instance == null) instance = new DBConnect(); return DBConnect.instance; } set => DBConnect.instance = value; }
		public string strcn = "Data Source=DESKTOP-1P0AMFP; Initial Catalog= QLCF; Integrated Security=true;";
		public SqlConnection con = new SqlConnection();
		public DBConnect()
		{
			con = new SqlConnection(strcn);
		}
		public DataTable getTable(string query)
		{
			
				DataTable dt = new DataTable();
				using (SqlDataAdapter sa = new SqlDataAdapter(query, con))
				{
					sa.SelectCommand.Transaction = transaction;
					sa.Fill(dt);
				}

				return dt;
			
			
		}
		public int updateTable(DataTable dtnew, string query)
		{
			SqlDataAdapter da = new SqlDataAdapter(query, con);
			SqlCommandBuilder cd = new SqlCommandBuilder(da);
			int kq = da.Update(dtnew);
			return kq;
		}
		public void Open()
		{
			if (con.State == ConnectionState.Closed)
				con.Open();
		}

		public void Close()
		{
			if (con.State == ConnectionState.Open)
				con.Close();
		}

		public int getNonquery(string strQuery)
		{
			Open();
			SqlCommand cmd = new SqlCommand(strQuery, con, transaction);
			int kq = cmd.ExecuteNonQuery();
			return kq;
		}
		public (string customerName, string customerType,string customerID) GetCustomerInfoByPhoneUsingStoredProcedure(string phoneNumber)
		{
			string customerName = string.Empty;
			string customerType = string.Empty;
			string customerID = string.Empty;

			try
			{
				Open();
				SqlCommand cmd = new SqlCommand("sp_GetCustomerInfoByPhone", con);
				cmd.CommandType = CommandType.StoredProcedure;

				// Thêm tham số cho thủ tục lưu trữ
				cmd.Parameters.AddWithValue("@SDT", phoneNumber);

				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					customerName = reader["TenKH"].ToString(); // Lấy tên khách hàng
					customerType = reader["TenLoai"].ToString(); // Lấy tên loại khách hàng
					customerID = reader["MaKH"].ToString();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Close();
			}

			return (customerName, customerType,customerID);
		}
		public string GenerateMaHoaDon()
		{
			string query = "SELECT MAX(CAST(SUBSTRING(MaHoaDon, 3, LEN(MaHoaDon) - 2) AS INT)) FROM HoaDon";
			int maxNumber = 0;

			using (SqlConnection connection = new SqlConnection(strcn))
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();
				var result = command.ExecuteScalar();
				if (result != DBNull.Value)
				{
					maxNumber = (int)result;
				}
			}

			int nextNumber = maxNumber + 1;
			return $"HD{nextNumber:D4}";  // HD000n
		}
		public string GenerateMaKH()
		{
			string query = "SELECT MAX(CAST(SUBSTRING(MaKH, 3, LEN(MaHoaDon) - 2) AS INT)) FROM KHACHHANG";
			int maxNumber = 0;

			using (SqlConnection connection = new SqlConnection(strcn))
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();
				var result = command.ExecuteScalar();
				if (result != DBNull.Value)
				{
					maxNumber = (int)result;
				}
			}

			int nextNumber = maxNumber + 1;
			return $"KH{nextNumber:D4}";  // HD000n
		}
		public void OpenConnectionWithLogin(string username)
		{
			Open();
				transaction = con.BeginTransaction();

				using (SqlCommand cmd = new SqlCommand("EXEC AS LOGIN = @username", con, transaction))
				{
					cmd.Parameters.AddWithValue("@username", username);
					cmd.ExecuteNonQuery();
				}
		}
		public void RevertConnection()
		{
			if (con.State == ConnectionState.Open && transaction != null)
			{
				using (SqlCommand cmd = new SqlCommand("REVERT", con, transaction))
				{
					cmd.ExecuteNonQuery();
				}
				transaction.Commit();
			}
		}
		public void ExcuteProc(string sql, object[] parameter = null)
		{
			string result = String.Empty;

			using (SqlCommand cmd = new SqlCommand(sql, con))
			{
				Open();

				if (parameter != null)
				{
					string[] lst = sql.Split(' ');
					foreach (var item in lst)
					{
						if (item.Contains("@"))
						{
							int i = 0;
							cmd.Parameters.AddWithValue(item, parameter[i]);
							i++;

						}
					}
				}

				//using (SqlDataReader reader = cmd.ExecuteReader())
				//{
				//    if (reader.Read())  
				//    {
				//        result = reader["TongLuong"].ToString();  
				//    }
				//    else
				//    {
				//        result = "No data found";  
				//    }
				//}

				//result = cmd.ExecuteScalar().ToString();

				//SqlParameter returnValueParam = new SqlParameter("@ReturnValue", SqlDbType.Float)
				//{
				//    Direction = ParameterDirection.Output
				//};
				//cmd.Parameters.Add(returnValueParam);

				//SqlDataReader rd = cmd.ExecuteReader();
				//if (rd.Read())
				//{
				//    result = rd[0].ToString();
				//}
				cmd.ExecuteNonQuery();
			}
			Close();
			//return result;
		}

		public object ExecuteFunc(string query, object[] parameters = null, string[] items = null, bool istable = false)
		{
			string result;

			try
			{
				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					Open();

					if (parameters != null)
					{
						for (int i = 0; i < items.Length; i++)
						{

							cmd.Parameters.AddWithValue(items[i], parameters[i] ?? DBNull.Value);

						}
					}

					if (!(istable))
					{

						object scalarResult = cmd.ExecuteScalar();
						Close();
						return scalarResult.ToString();
					}
					else
					{
						DataTable resulttable = new DataTable();
						SqlDataReader rd = cmd.ExecuteReader();
						resulttable.Load(rd);
						Close();
						return resulttable;
					}

					//result =cmd.ExecuteScalar().ToString(); 
				}
			}
			catch (Exception ex) { MessageBox.Show("Không thực hiện được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }


			//return result; 
		}
		public string TaoManv()
		{
			string result = String.Empty;


			string sql = "TAOMANV";
			using (SqlCommand cmd = new SqlCommand(sql, con, transaction))
			{
				Open();
                cmd.CommandType = CommandType.StoredProcedure;
				SqlParameter sqlParameter = new SqlParameter("@MANV", SqlDbType.NVarChar, 7)
				{
					Direction = ParameterDirection.Output
				};
				cmd.Parameters.Add(sqlParameter);

				cmd.ExecuteNonQuery();
                try
                {
                    cmd.ExecuteNonQuery();
                    result = sqlParameter.Value.ToString();
                }
                catch (Exception ex)
                {
                  
                    result = "Lỗi: " + ex.Message;
                }
                
            }
			return result;

		}
	}
}
