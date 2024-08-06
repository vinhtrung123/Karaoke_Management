using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QUANKARAOKE
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu tc = new TrangChu();
            ShowFormInPanel(tc);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void đặtPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
                DatPhong datphong = new DatPhong();
            ShowFormInPanel(datphong);
               

        }
        private void ShowFormInPanel(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel1.Controls.Clear(); // Xóa bất kỳ control nào đã tồn tại trong Panel
            panel1.Controls.Add(form);
            form.Show();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XuatHoaDon xhd = new XuatHoaDon();
            ShowFormInPanel(xhd);
        }

        private void mónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonAn monan = new MonAn();
            ShowFormInPanel(monan);
        }

        private void nhậpXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhapXuatKho nhapxuat = new NhapXuatKho();
            ShowFormInPanel(nhapxuat);
        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Phong ph = new Phong();
            ShowFormInPanel(ph);
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lgForm = new Login();
            lgForm.Show(); // hoặc mainForm.ShowDialog() nếu bạn muốn chặn ứng dụng cho đến khi MainForm được đóng
            this.Hide();
        }

        private void thôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinNV nv = new ThongTinNV();
            ShowFormInPanel(nv);
        }
    }
}
