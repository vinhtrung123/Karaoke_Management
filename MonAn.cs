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
    public partial class MonAn : Form
    {
        SqlConnection con;
        DataSet ds;
        SqlCommand cmd;
        SqlDataAdapter adap;
        DataTable tb;
        public MonAn()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=KIM-PHUNG\SQLEXPRESS;Initial Catalog=QL_QUANKARAOKE;Integrated Security=True");

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MonAn_Load(object sender, EventArgs e)
        {
     
            //dataGridView1.ReadOnly = true;
            //dataGridView1.AllowUserToAddRows = false;
            btn_xoa.Enabled = btn_sua.Enabled = btn_luu.Enabled = false;
            txt_IDsanpham.Enabled = txt_tensp.Enabled = txtgia.Enabled = txt_soluong.Enabled = textBox1.Enabled = cbox_loaisp.Enabled = false;
            load_combobox();
            loaddata();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void load_combobox()
        {
            string sql = "select * from MATHANG";
            adap = new SqlDataAdapter(sql, con);
            tb = new DataTable();
            adap.Fill(tb);
            cbox_loaisp.DataSource = tb;
            cbox_loaisp.DisplayMember = "LOAI";
            cbox_loaisp.ValueMember = "MAMH";
        }
        void loaddata()
        {
            string sql = "select * from MATHANG";
            adap = new SqlDataAdapter(sql, con);
            tb = new DataTable();
            adap.Fill(tb);
            dataGridView1.DataSource = tb;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string image;
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                btn_sua.Enabled = btn_xoa.Enabled = true;
                txt_IDsanpham.Enabled = false;
                txt_tensp.Enabled = false;
                cbox_loaisp.Enabled = false;
                txt_soluong.Enabled = false;
                txtgia.Enabled = false;
                textBox1.Enabled = false;

                txt_IDsanpham.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                txt_tensp.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                txtgia.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                txt_soluong.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                cbox_loaisp.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
                string s = dataGridView1.Rows[index].Cells[5].Value.ToString();
                textBox1.Text = s;
                if (File.Exists(s))
                {
                    Image img = Image.FromFile(s);
                    pictureBox1.Image = img;
                }
                else
                {
                    // Nếu đường dẫn không hợp lệ, có thể xóa PictureBox hoặc đặt ảnh mặc định
                    pictureBox1.Image = null;
                }
                //txt_IDsanpham.Enabled = false;
                //txt_tensp.Enabled = false;
                //cbox_loaisp.Enabled = false;
                //nup_soluong.Enabled = false;
                //txtgia.Enabled = false;

            }
        }
        private Image ByteToImage(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            Image image = Image.FromStream(memoryStream);
            return image;
        }

        private void btn_chon_Click(object sender, EventArgs e)
        {

        }

        private void txt_IDsanpham_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_tensp_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btn_luu.Enabled = true;
            txt_tensp.Enabled = true;
            txt_soluong.Enabled = true;
            txtgia.Enabled = true;
            cbox_loaisp.Enabled = true;
            textBox1.Enabled = true;
        }

        private void nup_soluong_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            btn_luu.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled = false;
            txt_tensp.Enabled = true;
            txt_soluong.Enabled = true;
            txtgia.Enabled = true;
            cbox_loaisp.Enabled = true;
            txt_IDsanpham.Enabled = true;
            textBox1.Enabled = true;
            //dataGridView1.AllowUserToAddRows = true;
            //dataGridView1.ReadOnly = false;
            btn_luu.Enabled = true;
            txt_IDsanpham.Clear();
            txt_IDsanpham.Focus();
            txt_tensp.Clear();
            txt_soluong.Clear();
            txtgia.Clear();
            textBox1.Clear();           
            pictureBox1.Image = null;
            //string maSP = txt_IDsanpham.Text;
            //string loaiSP = cbox_loaisp.SelectedItem?.ToString();
            //string tenSP = txt_tensp.Text;
            //int soLuong = (int)nup_soluong.Value;
            //string gia = txtgia.Text;
            //dataGridView1.AllowUserToAddRows = true;
            //dataGridView1.ReadOnly = false;
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //// Thiết lập các thuộc tính của hộp thoại mở tệp
            //openFileDialog1.Filter = "Image files (*.jpg) | *.jpg";
            //openFileDialog1.FileOk += OpenFileDialog1_FileOk;
            //// Kiểm tra xem mã sản phẩm đã tồn tại chưa
            //if (KiemTraTonTaiMaSP(maSP))
            //{
            //    MessageBox.Show("Mã sản phẩm đã tồn tại. Vui lòng chọn mã sản phẩm khác.");
            //    return;
            //}
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    // Lấy đường dẫn của tệp đã chọn và hiển thị hình ảnh trong PictureBox
            //    string selectedImagePath = openFileDialog1.FileName;
            //    pictureBox1.Image = Image.FromFile(selectedImagePath);

            //    // Lưu đường dẫn của hình ảnh vào cơ sở dữ liệu
            //    LuuDuongDanHinhAnhVaoDatabase(maSP, selectedImagePath);
            //}

            //// Constructing the SQL query for inserting a new record
            //string sql = "INSERT INTO MATHANG (MAMH, TENMATHANG, SOLUONG, LOAI, DONGIABAN) " +
            //             "VALUES (@maSP, @tenSP, @soLuong, @loaiSP, @gia)";
            //SqlCommand cmd = new SqlCommand(sql, con);

            //// Thay thế các tham số trong câu truy vấn
            //cmd.Parameters.AddWithValue("@maSP", maSP);
            //cmd.Parameters.AddWithValue("@tenSP", tenSP);
            //cmd.Parameters.AddWithValue("@soLuong", soLuong);
            //cmd.Parameters.AddWithValue("@loaiSP", loaiSP);
            //cmd.Parameters.AddWithValue("@gia", gia);

            //try
            //{
            //    con.Open();
            //    int rowsAffected = cmd.ExecuteNonQuery();

            //    if (rowsAffected > 0)
            //    {
            //        // Record inserted successfully
            //        MessageBox.Show("Thêm Dữ Liệu Thành Công.");
            //        // Reload data in the DataGridView after inserting the new record
            //        loaddata();
            //    }
            //    else
            //    {
            //        // Insert operation failed
            //        MessageBox.Show("Không Thể Thêm Dữ Liệu.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Handle exceptions (e.g., display error message, log the error)
            //    MessageBox.Show("Error occurred: " + ex.Message);
            //}
            //finally
            //{
            //    con.Close();
            //}
        }
        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //OpenFileDialog openFileDialog = (OpenFileDialog)sender;

            //// Lấy đường dẫn của tệp đã chọn và hiển thị hình ảnh trong PictureBox
            //string selectedImagePath = openFileDialog.FileName;
            //pictureBox1.Image = Image.FromFile(selectedImagePath);

            //// Lưu đường dẫn của hình ảnh vào cơ sở dữ liệu
            //string maSP = txt_IDsanpham.Text;
            //LuuDuongDanHinhAnhVaoDatabase(maSP, selectedImagePath);
        }
        private void LuuDuongDanHinhAnhVaoDatabase(string maSP, string duongDanHinhAnh)
        {
            // Cập nhật đường dẫn hình ảnh vào cơ sở dữ liệu
            //string sql = $"UPDATE MATHANG SET HINH = @duongDanHinhAnh WHERE MAMH = @maSP";
            //SqlCommand cmd = new SqlCommand(sql, con);

            //// Thay thế các tham số trong câu truy vấn
            //cmd.Parameters.AddWithValue("@maSP", maSP);
            //cmd.Parameters.AddWithValue("@duongDanHinhAnh", duongDanHinhAnh);

            //try
            //{
            //    con.Open();
            //    int rowsAffected = cmd.ExecuteNonQuery();

            //    if (rowsAffected <= 0)
            //    {
            //        // Cập nhật đường dẫn hình ảnh không thành công
            //        MessageBox.Show("Không thể cập nhật đường dẫn hình ảnh.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Handle exceptions (e.g., display error message, log the error)
            //    MessageBox.Show("Error occurred: " + ex.Message);
            //}
            //finally
            //{
            //    con.Close();
            //}
        }
        //private bool KiemTraTonTaiMaSP(string maSP)
        //{
        //    // Kiểm tra xem mã sản phẩm đã tồn tại hay chưa
        //    string sql = "SELECT COUNT(*) FROM MATHANG WHERE MAMH = @maSP";
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@maSP", maSP);

        //    try
        //    {
        //        con.Open();
        //        int count = (int)cmd.ExecuteScalar();
        //        return count > 0;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            //DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông Báo", MessageBoxButtons.YesNo);
            //if (r == DialogResult.Yes)
            //{
            //    con.Open();
            //    string sql = "DELETE MATHANG WHERE MAMH='" + txt_IDsanpham + "'";
            //    cmd = new SqlCommand(sql, con);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    loaddata();
            //}
            string tenSP = txt_tensp.Text; // Tên dịch vụ cần xóa
            string maSP = txt_IDsanpham.Text;
            // Constructing the SQL query for deleting the record
            string sql = $"DELETE FROM MATHANG WHERE MAMH = @maSP";
            SqlCommand cmd = new SqlCommand(sql, con);

            // Thay thế tham số trong câu truy vấn
            cmd.Parameters.AddWithValue("@maSP", maSP);
            try
            {
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Record deleted successfully
                    MessageBox.Show("Xóa Dữ Liệu Thành Công.");
                    // Reload data in the DataGridView after deleting the record
                    loaddata();
                }
                else
                {
                    // No record found with the given TENDV value
                    MessageBox.Show("Không Thể Xóa Dữ Liệu.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., display error message, log the error)
                MessageBox.Show("Error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public bool checkkey(string s)
        {
            cmd = new SqlCommand(s, con);
            int count = (int)cmd.ExecuteScalar();
            if (count > 0)
                return false;
            else
                return true;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string sql;
            btn_sua.Enabled = false;
            con.Open();
            if (txt_IDsanpham.Text == "")
            {
                MessageBox.Show("Nhập mã món :");
                txt_IDsanpham.Focus();

            }
            if (txt_tensp.Text == "")
            {
                MessageBox.Show("Nhập tên món :");
                txt_tensp.Focus();
            }
            if (txt_IDsanpham.Enabled == false)
                sql = string.Format("update MATHANG set tenmathang=N'{0}',dongiaban='{1}',soluong='{2}',loai='{3}',hinh='{4}', where mamh='{5}'", txt_tensp.Text, int.Parse(txtgia.Text), int.Parse(txt_soluong.Text), cbox_loaisp.SelectedValue.ToString(), textBox1.Text,txt_IDsanpham.Text);
            else
            {
                sql = string.Format("insert into mathang values('{0}','N{1}','{2}','{3}','{4}','{5}')", txt_IDsanpham.Text, txt_tensp.Text, txtgia.Text, txt_soluong.Text, cbox_loaisp.SelectedValue.ToString(), textBox1.Text);
                string s = "select count (*) from MATHANG where MAMH ='" + txt_IDsanpham.Text + "'";
                if (checkkey(s) == false)
                {

                    MessageBox.Show("Trùng Khóa");
                    return;
                }
            }
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            loaddata();
            con.Close();
            btn_luu.Enabled = false;
        }
        //string maSP = txt_IDsanpham.Text;
        //string loaiSP = cbox_loaisp.SelectedItem?.ToString();
        //string tenSP = txt_tensp.Text;
        //int soLuong = (int)nup_soluong.Value;
        //string gia = txtgia.Text;

        //// Constructing the SQL query for updating the record
        //string sql = $"UPDATE MATHANG SET MAMH = @maSP, TENMATHANG = @tenSP, SOLUONG = @soLuong,LOAI=@loaiSP,DONGIABAN = @gia WHERE MAMH = @maSP";
        //SqlCommand cmd = new SqlCommand(sql, con);

        //// Thay thế các tham số trong câu truy vấn
        //cmd.Parameters.AddWithValue("@maSP", maSP);
        //cmd.Parameters.AddWithValue("@tenSP", tenSP);
        //cmd.Parameters.AddWithValue("@soLuong", soLuong);
        //cmd.Parameters.AddWithValue("@loaiSP", loaiSP);
        //cmd.Parameters.AddWithValue("@gia", gia);

        //try
        //{
        //    con.Open();
        //    int rowsAffected = cmd.ExecuteNonQuery();

        //    if (rowsAffected > 0)
        //    {
        //        // Record updated successfully
        //        MessageBox.Show("Cập Nhật Dữ Liệu Thành Công.");
        //        // Reload data in the DataGridView after updating the record
        //        loaddata();
        //    }
        //    else
        //    {
        //        // No record found with the given MABAN value
        //        MessageBox.Show("Cập nhật không thành công.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    // Handle exceptions (e.g., display error message, log the error)
        //    MessageBox.Show("Error occurred: " + ex.Message);
        //}
        //finally
        //{
        //    con.Close();
        //}
        //SqlDataAdapter da_Kao = new SqlDataAdapter("select * from MATHANG", con);
        //SqlCommandBuilder cmb = new SqlCommandBuilder(da_Kao);
        //da_Kao.Update(ds, "MATHANG");
        ////DataBindings(ds.Tables["MATHANG"]);
        //MessageBox.Show("Thành Công");
        //btn_luu.Enabled = false;
        //string maSP = txt_IDsanpham.Text;
        //string loaiSP = cbox_loaisp.SelectedValue?.ToString(); // Use SelectedValue instead of SelectedItem?.ToString()
        //string tenSP = txt_tensp.Text;
        //int soLuong = (int)nup_soluong.Value;
        //string gia = txtgia.Text;

        //if (string.IsNullOrWhiteSpace(maSP) || string.IsNullOrWhiteSpace(loaiSP) || string.IsNullOrWhiteSpace(tenSP) || string.IsNullOrWhiteSpace(gia))
        //{
        //    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
        //    return;
        //}

        //if (txt_IDsanpham.Enabled == true)
        //{
        //    // Adding a new record
        //    string sql = "INSERT INTO MATHANG (MAMH,TENMATHANG, SOLUONG, LOAI, DONGIABAN, HINH) " +
        //                 "VALUES (@maSP,@tenSP, @soLuong, @loaiSP, @gia, @duongDanHinhAnh)";
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@maSP", maSP);
        //    cmd.Parameters.AddWithValue("@tenSP", tenSP);
        //    cmd.Parameters.AddWithValue("@soLuong", soLuong);
        //    cmd.Parameters.AddWithValue("@loaiSP", loaiSP);
        //    cmd.Parameters.AddWithValue("@gia", gia);

        //    if (pictureBox1.Image != null)
        //    {
        //        string duongDanHinhAnh = GetImageFilePath(maSP);
        //        cmd.Parameters.AddWithValue("@duongDanHinhAnh", duongDanHinhAnh);
        //    }
        //    else
        //    {
        //        cmd.Parameters.AddWithValue("@duongDanHinhAnh", DBNull.Value);
        //    }

        //    try
        //    {
        //        con.Open();
        //        //  int rowsAffected = cmd.ExecuteNonQuery();
        //        cmd.ExecuteNonQuery();
        //        // if (rowsAffected > 0)
        //        // {
        //        MessageBox.Show("Thêm Dữ Liệu Thành Công.");
        //        loaddata();
        //        // }
        //        //else
        //        //{
        //        //MessageBox.Show("Không Thể Thêm Dữ Liệu.");
        //        // }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error occurred: " + ex.Message);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        //else
        //{
        //    // Editing an existing record
        //    string sql = "UPDATE MATHANG SET TENMATHANG = @tenSP, SOLUONG = @soLuong, LOAI = @loaiSP, DONGIABAN = @gia, HINH = @duongDanHinhAnh " +
        //                 "WHERE MAMH = @maSP";
        //    SqlCommand cmd = new SqlCommand(sql, con);

        //    cmd.Parameters.AddWithValue("@maSP", maSP);
        //    cmd.Parameters.AddWithValue("@tenSP", tenSP);
        //    cmd.Parameters.AddWithValue("@soLuong", soLuong);
        //    cmd.Parameters.AddWithValue("@loaiSP", loaiSP);
        //    cmd.Parameters.AddWithValue("@gia", gia);

        //    if (pictureBox1.Image != null)
        //    {
        //        string duongDanHinhAnh = GetImageFilePath(maSP);
        //        cmd.Parameters.AddWithValue("@duongDanHinhAnh", duongDanHinhAnh);
        //    }
        //    else
        //    {
        //        cmd.Parameters.AddWithValue("@duongDanHinhAnh", DBNull.Value);
        //    }

        //    try
        //    {
        //        con.Open();
        //        int rowsAffected = cmd.ExecuteNonQuery();

        //        if (rowsAffected > 0)
        //        {
        //            MessageBox.Show("Cập Nhật Dữ Liệu Thành Công.");
        //            loaddata();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Không Thể Cập Nhật Dữ Liệu.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error occurred: " + ex.Message);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        //private string GetImageFilePath(string maSP)
        //{
        //    string imageFolder = Path.Combine(Application.StartupPath, "Images");
        //    if (!Directory.Exists(imageFolder))
        //    {
        //        Directory.CreateDirectory(imageFolder);
        //    }

        //    string imageName = $"{maSP}_Image.jpg";
        //    return Path.Combine(imageFolder, imageName);
        //}

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "(*.jpg)|*.jpg|(*.png)|*.png";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                string ten = openfile.SafeFileName;
                textBox1.Text = "../Icon/" + ten;
            }
        }
    }
}
