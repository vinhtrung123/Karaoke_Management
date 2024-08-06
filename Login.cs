using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_QUANKARAOKE
{
    public partial class Login : Form
    {
        SqlConnection con;
        public Login()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=KIM-PHUNG\SQLEXPRESS;Initial Catalog=QL_QUANKARAOKE;Integrated Security=True");

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
            // xử lí kiểm tra xem dữ liệu ở textbox có trùng với users nào trong csdl không, nếu trùng kiểm tra tiếp dữ liệu ở textbox2 có trùng với passwords của user đã trùng không;
            string username = textBox2.Text;
            string password = textBox1.Text;

            try
            {
                con.Open();

                // Kiểm tra xem tên người dùng tồn tại trong cơ sở dữ liệu không
                string userCheckQuery = "SELECT COUNT(*) FROM NHANVIEN WHERE TAIKHOAN = @Username";
                SqlCommand userCheckCmd = new SqlCommand(userCheckQuery, con);
                userCheckCmd.Parameters.AddWithValue("@Username", username);

                int userCount = (int)userCheckCmd.ExecuteScalar();
             
                if (userCount > 0)
                {
                    // Tên người dùng tồn tại, kiểm tra mật khẩu
                    string passwordCheckQuery = "SELECT * FROM NHANVIEN WHERE TAIKHOAN = @Username AND MATKHAU = @Password";
                    SqlCommand passwordCheckCmd = new SqlCommand(passwordCheckQuery, con);
                    passwordCheckCmd.Parameters.AddWithValue("@Username", username);
                    passwordCheckCmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = passwordCheckCmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // Người dùng đã đăng nhập thành công, thực hiện các hành động tương ứng ở đây.
                        MessageBox.Show("Đăng nhập thành công!");
                        //con.Close();
                        //con.Open();
                        //string accessLevel = reader["AccessLevel"].ToString();
                        // xử lí chuyển from sang form khác
                        Main mainForm = new Main();
                        mainForm.Show(); // hoặc mainForm.ShowDialog() nếu bạn muốn chặn ứng dụng cho đến khi MainForm được đóng
       
                        // TẠO 1 BIẾN ĐỂ LƯU ACCESSLEVEL CỦA USER  TRONG CSDL 
                       
                        // Đóng Login form nếu bạn muốn
                        this.Hide();
                    }
                    else
                    {
                        // Người dùng không tồn tại hoặc thông tin đăng nhập không chính xác.
                        MessageBox.Show("Mật khẩu không đúng. Vui lòng thử lại!");
                    }
                }
                else
                {
                    // Người dùng không tồn tại.
                    MessageBox.Show("Tên đăng nhập không tồn tại. Vui lòng thử lại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
            string password = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
