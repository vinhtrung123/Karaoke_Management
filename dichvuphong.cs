using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace QL_QUANKARAOKE
{
    public partial class dichvuphong : Form
    {

        private string[] imagePaths = { "bia.jpg", "nngot.jpg", "snack.jpg", "ruoutraicay.jpg", "traicay.jpg" };
        SqlConnection con;
        DataSet ds;
        private string selectedRoomNumber;
        public decimal GiaPhong { get; set; }
        public ComboBox Combobox1FromDatPhong { get; set; }
        private string selectedMaBan;
        public DatPhong DatPhongReference { get; set; }

        public string SelectedMaBan
        {
            get { return selectedMaBan; }
            set
            {
                selectedMaBan = value;
                // Bạn có thể thực hiện các hành động bổ sung khi giá trị được thiết lập, nếu cần
                // Ví dụ: cập nhật giao diện người dùng dựa trên selectedMaBan
                txt_IDmaphong.Text = selectedMaBan;
            }
        }
        public dichvuphong()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=KIM-PHUNG\SQLEXPRESS;Initial Catalog=QL_QUANKARAOKE;Integrated Security=True");

        }
        public void SetMaBan(string maBan)
        {
            // Sử dụng giá trị maBan nhận được từ form DatPhong ở đây
            // Ví dụ: hiển thị giá trị trong một textbox hoặc thực hiện các thao tác khác
            txt_IDmaphong.Text = maBan;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dichvuphong_Load(object sender, EventArgs e)
        {
            comboBox2.Items.AddRange(imagePaths);
            load_combobox();
            //loaddata();

        }
        private void SomeMethod()
        {
            // Truy cập giá trị MaBan từ DatPhong form
            string maPhong = ((DatPhong)this.Owner).SelectedMaBan;

            // Sử dụng giá trị maBan theo nhu cầu của bạn
            MessageBox.Show("Selected MaBan: " + maPhong);
        }
        internal void Enabled(bool v)
        {
  
        }
        public string GetMaBanFromComboBox()
        {
            if (Combobox1FromDatPhong != null && Combobox1FromDatPhong.SelectedItem != null)
            {
                return Combobox1FromDatPhong.SelectedItem.ToString();
            }
            return null;
        }

        void load_combobox()
        {
            string sql = "select * from MATHANG";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            adap.Fill(tb);
            comboBox2.DataSource = tb;
            comboBox2.DisplayMember = "TENMATHANG";
            comboBox2.ValueMember = "MAMH";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Update the quantity based on the selected room number
            if (!string.IsNullOrEmpty(selectedRoomNumber))  
            {
                // Implement the logic to update the quantity for the selected room number
                // You might want to use the selectedRoomNumber variable in your SQL query
                // For example:
                 string updateQuery = $"UPDATE MATHANG SET Quantity = Quantity + 1 WHERE RoomNumber = '{selectedRoomNumber}'";
                // Execute the query using SqlCommand and con
            }
            else
            {
                MessageBox.Show("Please select a room first.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Update the quantity based on the selected room number
            if (!string.IsNullOrEmpty(selectedRoomNumber))
            {
                // Implement the logic to update the quantity for the selected room number
                // You might want to use the selectedRoomNumber variable in your SQL query
                // For example:
                // string updateQuery = $"UPDATE YourTableName SET Quantity = Quantity + 1 WHERE RoomNumber = '{selectedRoomNumber}'";
                // Execute the query using SqlCommand and con
            }
            else
            {
                MessageBox.Show("Please select a room first.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Update the quantity based on the selected room number
            if (!string.IsNullOrEmpty(selectedRoomNumber))
            {
                // Implement the logic to update the quantity for the selected room number
                // You might want to use the selectedRoomNumber variable in your SQL query
                // For example:
                // string updateQuery = $"UPDATE YourTableName SET Quantity = Quantity + 1 WHERE RoomNumber = '{selectedRoomNumber}'";
                // Execute the query using SqlCommand and con
            }
            else
            {
                MessageBox.Show("Please select a room first.");
            }
        }

        //void loaddata()
        //{
        //    string sql = "select * from MATHANG";
        //    SqlDataAdapter adap = new SqlDataAdapter(sql, con);
        //    DataTable tb = new DataTable();
        //    adap.Fill(tb);
        //    dataGridView1.DataSource = tb;
        //}
        public void UpdateRoomNumber(string roomNumber)
        {

            // Cập nhật số phòng trong textBox
            txt_IDmaphong.Text = roomNumber;


        }
        private void button7_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem DatPhongReference đã được thiết lập chưa
            if (DatPhongReference != null)
            {
                // Gọi phương thức GetMaBanFromComboBox từ form DatPhong để lấy mã bàn
                string maPH = GetMaBanFromComboBox();

                if (!string.IsNullOrEmpty(maPH))
                {
                    try
                    {
                        // Mở kết nối
                        con.Open();

                        // Truy vấn SQL để kiểm tra trạng thái của bàn
                        string checkStatusQuery = "SELECT Trangthai FROM Phong WHERE MaPH = @MaPH";
                        SqlCommand checkStatusCommand = new SqlCommand(checkStatusQuery, con);
                        checkStatusCommand.Parameters.AddWithValue("@MaPH", maPH);

                        // Kiểm tra trạng thái của bàn
                        int trangThai = (int)checkStatusCommand.ExecuteScalar();

                        if (trangThai == 1)
                        {
                            MessageBox.Show("Phòng đang được mở !!!");
                        }
                        else
                        {
                            // Tạo truy vấn SQL để cập nhật thời gian bắt đầu trong cơ sở dữ liệu
                            string sqlQuery = "UPDATE Phong SET ThoiGianBatDau = @ThoiGianBatDau, Trangthai = 1 WHERE MaPH = @MaPH";

                            // Tạo đối tượng SqlCommand
                            SqlCommand command = new SqlCommand(sqlQuery, con);

                            // Thêm tham số cho truy vấn
                            command.Parameters.AddWithValue("@ThoiGianBatDau", DateTime.Now);
                            command.Parameters.AddWithValue("@MaPH", maPH);

                            // Thực thi truy vấn
                            int rowsAffected = command.ExecuteNonQuery();
                            con.Close();

                            // Kiểm tra xem có bao nhiêu hàng bị ảnh hưởng
                            if (rowsAffected > 0)
                            {
                                dichvuphong_Load(sender, e);
                                MessageBox.Show("Phòng đã được mở thành công.");
                            }
                            else
                            {
                                MessageBox.Show("Không có mã phòng nào được cập nhật.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                    finally
                    {
                        // Đóng kết nối sau khi sử dụng
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một mã phòng từ danh sách.");
                }
            }
            else
            {
                MessageBox.Show("Tham chiếu từ form DatPhong không được thiết lập.");
            }
        }
        private void ExecuteQuery(string query)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nup_gia_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
       public  void loadtextbox()
        {
            string sql="select dongia,trangthai from phong where maph='"+txt_IDmaphong.Text+"'";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            textBox1.Text = dt.Rows[0][0].ToString();
            cbox_trangthai.Text = dt.Rows[0][1].ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imageName = comboBox2.SelectedItem.ToString();
   
            string imagePath = Path.Combine(Application.StartupPath, "D:\\DETAI_DO.NET\\QL_QUANKARAOKE\\QL_QUANKARAOKE\\bin\\Debug\\Icon", imageName); // Thay đổi "Images" thành thư mục chứa hình ảnh của bạn

           

            // Hiển thị hình ảnh trong PictureBox
            if (File.Exists(imagePath))
            {
                Image image = Image.FromFile(imagePath);
                pictureBox1.Image = image;
            }
            else
            {
                // Nếu đường dẫn không hợp lệ, có thể xóa PictureBox hoặc đặt ảnh mặc định
                pictureBox1.Image = null;

            }
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private Image ByteToImage(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            Image image = Image.FromStream(memoryStream);
            return image;
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {

        }
            
        private void txt_IDmaphong_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
