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
    public partial class usVeTauHoa : UserControl
    {
        void KetnoiCSDL()
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection(@"Data Source=THANHBINH\SQLEXPRESS;Initial Catalog=BanVe;Integrated Security=True"); //Khai báo biến connection
                sqlConn.Open();
                string sql = "Select * from ChiTietVeTau";
                SqlCommand cmd = new SqlCommand(sql , sqlConn); // thực thi các chức năng câu lệnh trong sql
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
            public usVeTauHoa()
        {

            InitializeComponent();
          
        }

        private void btnTimVeTH_Click(object sender, EventArgs e)
        {
           
            
        }

        private void usVeTauHoa_Load(object sender, EventArgs e)
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
            txtDayghe.Text = "";
            txtKihieutau.Text = "";
            txtMaghe.Text = "";
            txtMasove.Text = "";
            cbToaTau.Text = "";


        }
     
        string them;
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection(@"Data Source=THANHBINH\SQLEXPRESS;Initial Catalog=BanVe;Integrated Security=True"); //Khai báo biến connection
                them = "INSERT INTO ChiTietVeTau (maghe,masove,dayghe, toatau, kihieuTau) VALUES('" + txtMaghe.Text + "','" + txtMasove.Text + "','" + txtDayghe.Text + "','" + cbToaTau.Text + "'," + txtKihieutau.Text + ")";
                SqlCommand cmdThem = new SqlCommand(them, sqlConn);
                cmdThem.ExecuteNonQuery();
                KetnoiCSDL();

            }
            catch
            {
                MessageBox.Show("Lỗi không thêm được");
            }

        }
        string xoaVe;

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
                try
                {
                    SqlConnection sqlConn = new SqlConnection(@"Data Source=THANHBINH\SQLEXPRESS;Initial Catalog=BanVe;Integrated Security=True"); //Khai báo biến connection
                    sqlConn.Open();
                    xoaVe = "delete ChiTietVeTau where masove='" + txtMasove.Text + "'";
                    SqlCommand cmdXoa = new SqlCommand(xoaVe, sqlConn);
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
            string suaVe;
            private void btnSua_Click(object sender, EventArgs e)
            {

                SqlConnection sqlConn = new SqlConnection(@"Data Source=THANHBINH\SQLEXPRESS;Initial Catalog=BanVe;Integrated Security=True"); //Khai báo biến connection
                sqlConn.Open();
                suaVe = "update ChiTietVeTau set dayghe='" + txtDayghe + "',toatau='" + cbToaTau.Text + "',kihieutau='" + txtKihieutau.Text + "' where dayghe='" + txtDayghe.Text;
                SqlCommand cmdSua = new SqlCommand(suaVe, sqlConn);
                cmdSua.ExecuteNonQuery();
                KetnoiCSDL();

            }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearForm();
        }
    }
    }

