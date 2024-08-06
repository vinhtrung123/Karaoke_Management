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
using System.Drawing.Imaging;
using System.IO;

namespace QL_QUANKARAOKE
{
    public partial class ThongTinNV : Form
    {
        SqlConnection con;
        DataSet ds;
        SqlCommand cmd;
        SqlDataAdapter adap;
        DataTable tb;
        
        public ThongTinNV()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=KIM-PHUNG\SQLEXPRESS;Initial Catalog=QL_QUANKARAOKE;Integrated Security=True");
        }

        void loaddata()
        {
            string sql = "select * from NHANVIEN";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            DataTable tb = new DataTable();
            adap.Fill(tb);
            dataGridView1.DataSource = tb;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ThongTinNV_Load(object sender, EventArgs e)
        {
            loaddata();
            btn_xoa.Enabled = btn_sua.Enabled = btn_luu.Enabled = false;
            txt_IDnv.Enabled = txt_tennv.Enabled = txt_matkhau.Enabled = txt_taikhoan.Enabled = txt_sdt.Enabled=textBox1.Enabled = false;

            
    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string image;
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                btn_xoa.Enabled = btn_sua.Enabled = true;
                txt_IDnv.Enabled = txt_tennv.Enabled = txt_taikhoan.Enabled = txt_matkhau.Enabled = txtanh.Enabled = txt_sdt.Enabled = textBox1.Enabled = false;

                txt_taikhoan.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                txt_IDnv.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                txt_tennv.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();

                txt_matkhau.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                txt_sdt.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
                textBox1.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
                string s = dataGridView1.Rows[index].Cells[6].Value.ToString();
                //Image img = Image.FromFile(s);
                //pictureBox1.Image = img;
                txtanh.Text = s;

                //image = dataGridView1.Rows[index].Cells[6].Value.ToString();
                if (File.Exists(s))
                {
                    Image imagee = Image.FromFile(s);
                    pictureBox1.Image = imagee;
                }
                else
                {
                    // Nếu đường dẫn không hợp lệ, có thể xóa PictureBox hoặc đặt ảnh mặc định
                    pictureBox1.Image = null;
                }
                //    //txt_taikhoan.Enabled = false;
                //    //txt_tennv.Enabled = false;
                //    //txt_IDnv.Enabled = false;
                //    //txt_matkhau.Enabled = false;
                //    //txt_sdt.Enabled = false;
                //    //textBox1.Enabled = false;
                //    //txtanh.Enabled = false;

                //}
            }
        }

        private Image ByteToImage(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            Image image = Image.FromStream(memoryStream);
            return image;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            btn_luu.Enabled = true;
            btn_xoa.Enabled = btn_sua.Enabled = false;
            txt_taikhoan.Enabled = true;
            txt_tennv.Enabled = true;
            txt_IDnv.Enabled = true;
            txt_matkhau.Enabled = true;
            txt_sdt.Enabled = true;
            textBox1.Enabled = true;
            txtanh.Enabled = true;
            txt_IDnv.Clear();
            txt_IDnv.Focus();
            txt_matkhau.Clear();
            txt_sdt.Clear();
            txt_taikhoan.Clear();
            txtanh.Clear();
            textBox1.Clear();
            txt_tennv.Clear();
            pictureBox1.Image = null;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn xóa ?", "Thông Báo", MessageBoxButtons.YesNo);
            if(r==DialogResult.Yes)
            {
                con.Open();
                string sql = "Delete NHANVIEN where manv = '" + txt_IDnv.Text +"'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                loaddata();
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "(*.jpg)|*.jpg|(*.png)|*.png";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                string ten = openfile.SafeFileName;
                txtanh.Text = "../Icon/" + ten;
                
            }

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btn_luu.Enabled = true;
            txt_tennv.Enabled = txtanh.Enabled =txt_matkhau.Enabled=txt_taikhoan.Enabled=textBox1.Enabled=txt_sdt.Enabled= true;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string sql;
            btn_sua.Enabled = false;
            con.Open();
            if(txt_IDnv.Text=="")
            {
                MessageBox.Show("Nhập mã nhân viên :");
                txt_IDnv.Focus();

            }    
            if(txt_tennv.Text=="")
            {
                MessageBox.Show("Nhập tên nhân viên :");
                txt_tennv.Focus();
            }
            if (txt_IDnv.Enabled == false)
                sql = string.Format("update NHANVIEN set taikhoan='{0}',tennv=N'{1}',matkhau='{2}',dienthoai='{3}',diachi=N'{4}',hinhnv='{5}' where manv='{6}'", txt_taikhoan.Text,txt_tennv.Text,txt_matkhau.Text,int.Parse(txt_sdt.Text),textBox1.Text,txtanh.Text,txt_IDnv.Text);
            else
            {
                sql = string.Format("insert into NHANVIEN values('{0}','{1}',N'{2}','{3}','{4}',N'{5}','{6}')",txt_taikhoan.Text,txt_IDnv.Text,txt_tennv.Text,txt_matkhau.Text,txt_sdt.Text,textBox1.Text,txtanh.Text);
                string s="select count (*) from NHANVIEN where MANV ='"+txt_IDnv.Text+"'";
                if(checkkey(s)==false)
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

        private void txtanh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
