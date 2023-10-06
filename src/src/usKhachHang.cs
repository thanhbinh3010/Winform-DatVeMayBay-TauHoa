using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DOAN
{
    public partial class usKhachHang : UserControl
    {
        void KetnoiCSDL()
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection(@"Data Source=THANHBINH\SQLEXPRESS;Initial Catalog=BanVe;Integrated Security=True"); //Khai báo biến connection
                sqlConn.Open();
                string sql = "Select * from KhachHang";
                SqlCommand cmd = new SqlCommand(sql, sqlConn); // thực thi các chức năng câu lệnh trong sql
                SqlDataAdapter da = new SqlDataAdapter(cmd); // vận chuyển dữ liệu
                DataTable table = new DataTable(); // tạo 1 bảng ảo trong hệ thống
                da.Fill(table); // đổ dữ liệu vào bảng ảo
                dataGridView1.DataSource = table; // bảng ảo được đổ vào datagridview1
            }
            catch
            {
                MessageBox.Show("Loi Ket Noi VUi Long KTRa Lai", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                SqlConnection sqlConn = new SqlConnection(@"Data Source=THANHBINH\SQLEXPRESS;Initial Catalog=QLTHUVIEN;Integrated Security=True"); //Khai báo biến connection
                sqlConn.Close(); // đóng kết nối lại
            }
        }
        public usKhachHang()
        {
            InitializeComponent();
        }

        private void usKhachHang_Load(object sender, EventArgs e)
        {

            KetnoiCSDL();
            setButton(true);
        }
        public void setButton(bool value)
        {
            btnThem.Enabled = value;
            btnXoa.Enabled = value;
            btnSua.Enabled = value;
            btnLuu.Enabled = !value;
            btnLamMoi.Enabled = !value;

        }
        void clearForm()
        {
            txtDiaChi.Text = "";
            txtMaKH.Text = "";
            txtMsve.Text = "";
            txtSDT.Text = "";
            txtTenKH.Text = "";


        }
        string them;
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection(@"Data Source=THANHBINH\SQLEXPRESS;Initial Catalog=BanVe;Integrated Security=True"); //Khai báo biến connection
                them = "INSERT INTO KhachHang (maKH,tenKH,diachi,SDT,masove) VALUES('" + txtMaKH.Text + "','" + txtTenKH.Text + "','" + txtDiaChi.Text + "','" + txtSDT.Text + "'," + txtMsve.Text + ")";
                SqlCommand cmdThem = new SqlCommand(them, sqlConn);
                cmdThem.ExecuteNonQuery();
                KetnoiCSDL();

            }
            catch
            {
                MessageBox.Show("Lỗi không thêm được");
            }

        }
        string xoaKH;
        private void btnXoa_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection sqlConn = new SqlConnection(@"Data Source=THANHBINH\SQLEXPRESS;Initial Catalog=BanVe;Integrated Security=True"); //Khai báo biến connection
                sqlConn.Open();
                xoaKH = "delete KhachHang where masove='" + txtTenKH.Text + "'";
                SqlCommand cmdXoa = new SqlCommand(xoaKH, sqlConn);
                cmdXoa.ExecuteNonQuery();
                KetnoiCSDL();

            }
            catch
            {
                MessageBox.Show("Lỗi không Xóa được");
            }
            finally
            {
                SqlConnection sqlConn = new SqlConnection(@"Data Source=THANHBINH\SQLEXPRESS;Initial Catalog=BanVe;Integrated Security=True"); //Khai báo biến connection
                sqlConn.Close();
            }
        }
        string suaKh;
        private void btnSua_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConn = new SqlConnection(@"Data Source=THANHBINH\SQLEXPRESS;Initial Catalog=BanVe;Integrated Security=True"); //Khai báo biến connection
            sqlConn.Open();
            suaKh= "update KhachHang  set tenKH='" + txtTenKH + "',diachi='" + txtDiaChi.Text + "',SDT='" + txtSDT.Text + "' where tenKH='" + txtTenKH.Text;
            SqlCommand cmdSua = new SqlCommand(suaKh, sqlConn);
            cmdSua.ExecuteNonQuery();
            KetnoiCSDL();

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearForm();
        }
    }
}

