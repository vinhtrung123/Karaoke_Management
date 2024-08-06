using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace QL_QUANKARAOKE
{
    public partial class DatPhong : Form
    {
        
        private string selectedRoomNumber;
        public string SelectedMaBan { get; private set; }
        private dichvuphong dichvuForm;
        SqlConnection con;
        public DatPhong()
        {
            InitializeComponent();
            dichvuForm = new dichvuphong();


            con = new SqlConnection(@"Data Source=KIM-PHUNG\SQLEXPRESS;Initial Catalog=QL_QUANKARAOKE;Integrated Security=True");

        }
        //private void OpenDichvuphongForm()
        //{
        //    dichvuphong form = new dichvuphong();
        //    form.Combobox1FromDatPhong = comboBox1; // Gán tham chiếu của combobox1 từ DatPhong sang dichvuphong
        //    string maBan = GetMaBanFromComboBox();
        //    form.SetMaBan(maBan);
        //    form.Owner = this;
        //    form.Show();
        //        // Gọi hàm GetMaBanFromComboBox từ form DatPhong và truyền giá trị cho form dichvuphong
        //}
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "5";
            //dichvuphong dichvuForm = new dichvuphong();
            //ShowFormInPanel(dichvuForm);
            //dichvuForm.UpdateRoomNumber("5");
            SelectedMaBan = "5";
            ShowRoomInfo();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the regular checkbox is checked
            if (checkBox1.Checked)
            {
                // Regular checkbox is checked, show regular buttons and hide VIP buttons
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button6.Visible = true;
                button5.Visible = true;
                button7.Visible = false;
                button8.Visible = false;
            }
            else
            {
                // Regular checkbox is not checked, hide regular buttons
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = false;
                button5.Visible = false;

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                // VIP checkbox is checked, show VIP buttons and hide regular buttons
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = false;
                button5.Visible = false;
                button7.Visible = true;
                button8.Visible = true;
            }
            else
            {
                // VIP checkbox is not checked, hide VIP buttons
                button7.Visible = false;
                button8.Visible = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "1";
            //dichvuphong dichvuForm = new dichvuphong();
            //ShowFormInPanel(dichvuForm);
            //dichvuForm.UpdateRoomNumber("1");
            SelectedMaBan = "1";
            ShowRoomInfo();
            //dichvuphong form = new dichvuphong();
            //form.Owner = this; // this là đối tượng DatPhong form
            //form.Show();
            string selectedRoomNumber = comboBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedRoomNumber))
            {
                // Gọi form dichvuphong
                dichvuphong formDichVuPhong = new dichvuphong();

                // Gán tham chiếu từ form DatPhong sang form dichvuphong
                formDichVuPhong.Combobox1FromDatPhong = comboBox1;

                // Gọi hàm SetMaBan trên form dichvuphong để cập nhật số phòng
                formDichVuPhong.SetMaBan(selectedRoomNumber);

                // Hiển thị form dichvuphong
                formDichVuPhong.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mã phòng từ danh sách.");
            }

        }

        // Phương thức để lấy giá tiền từ cơ sở dữ liệu dựa trên loại phòng

        private void ShowFormInPanel(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel2.Controls.Clear(); // Xóa bất kỳ control nào đã tồn tại trong Panel
            panel2.Controls.Add(form);
            form.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "2";
            //dichvuphong dichvuForm = new dichvuphong();
            //ShowFormInPanel(dichvuForm);
            //dichvuForm.UpdateRoomNumber("2");
            SelectedMaBan = "2";
            ShowRoomInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "3";
            //dichvuphong dichvuForm = new dichvuphong();
            //ShowFormInPanel(dichvuForm);
            //dichvuForm.UpdateRoomNumber("3");
            SelectedMaBan = "3";
            ShowRoomInfo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "4";
            //dichvuphong dichvuForm = new dichvuphong();
            //ShowFormInPanel(dichvuForm);
            //dichvuForm.UpdateRoomNumber("4");
            SelectedMaBan = "4";
            ShowRoomInfo();
        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "6";
            //dichvuphong dichvuForm = new dichvuphong();
            //ShowFormInPanel(dichvuForm);
            //dichvuForm.UpdateRoomNumber("6");
            SelectedMaBan = "6";
            ShowRoomInfo();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "VIP01";
            //dichvuphong dichvuForm = new dichvuphong();
            //ShowFormInPanel(dichvuForm);
            //dichvuForm.UpdateRoomNumber("VIP01");
            SelectedMaBan = "VIP01";
            ShowRoomInfo();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "VIP02";
            //dichvuphong dichvuForm = new dichvuphong();
            //ShowFormInPanel(dichvuForm);
            //dichvuForm.UpdateRoomNumber("VIP02");
            SelectedMaBan = "VIP02";
            ShowRoomInfo();
        }
        private void DatPhong_Load(object sender, EventArgs e)
        {
            LoadPhongData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SelectedMaBan = comboBox1.Text;
            //dichvuphong dichvuForm = new dichvuphong();
            //ShowFormInPanel(dichvuForm);
            //dichvuForm.UpdateRoomNumber(SelectedMaBan);
            //dichvuForm.loadtextbox();
            ////SelectedMaBan = GetMaBanFromComboBox();
            SelectedMaBan = comboBox1.Text;

            // Hiển thị thông tin phòng tương ứng trong panel2
            ShowRoomInfo();
        }
        private void ShowRoomInfo()
        {
            // Tạo một instance mới của dichvuphong
            dichvuphong dichvuForm = new dichvuphong();

            dichvuForm.DatPhongReference = this; // Gán tham chiếu từ form DatPhong sang form dichvuphong
            // Hiển thị form trong panel2 và cập nhật số phòng
            ShowFormInPanel(dichvuForm);
            dichvuForm.UpdateRoomNumber(SelectedMaBan);

            // Load dữ liệu vào các controls trong form
            dichvuForm.loadtextbox();
        }
        private string GetMaBanFromComboBox()
        {
            
            if (comboBox1.SelectedItem != null)
            {
                return comboBox1.SelectedItem.ToString();
            }
            return null;
        }
        private void LoadPhongData()
        {
            //    try
            //    {
            //        // Mở kết nối đến cơ sở dữ liệu
            //        con.Open();

            //        // Thực hiện truy vấn để lấy danh sách phòng
            //        string query = "SELECT MAPH FROM PHONG";
            //        SqlCommand cmd = new SqlCommand(query, con);
            //        SqlDataReader dr = cmd.ExecuteReader();

            //        // Xóa các mục hiện tại trong ComboBox
            //        comboBox1.Items.Clear();

            //        // Đổ dữ liệu vào ComboBox
            //        while (dr.Read())
            //        {
            //            string maPhong = dr["MAPH"].ToString();
            //            comboBox1.Items.Add(maPhong);
            //        }

            //        // Đóng SqlDataReader
            //        dr.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error: " + ex.Message);
            //    }
            //    finally
            //    {
            //        // Đóng kết nối sau khi hoàn thành
            //        con.Close();
            //    }
            //}
            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                con.Open();

                // Thực hiện truy vấn để lấy danh sách phòng
                string query = "SELECT MAPH FROM PHONG";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();

                // Xóa các mục hiện tại trong ComboBox
                comboBox1.Items.Clear();

                // Đổ dữ liệu vào ComboBox
                while (dr.Read())
                {
                    string maPhong = dr["MAPH"].ToString();
                    comboBox1.Items.Add(maPhong);
                }

                // Đóng SqlDataReader
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối sau khi hoàn thành
                con.Close();
            }
        }
    }
}