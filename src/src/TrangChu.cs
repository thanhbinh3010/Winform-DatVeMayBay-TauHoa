using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
                     
        }

        private void btnMB_Click(object sender, EventArgs e)
        {
            active.Height = btnMB.Height;
            active.Top = btnMB.Top;
            usVeMayBay1.BringToFront();

           
           
        }

        private void btnTH_Click(object sender, EventArgs e)
        {
            active.Height = btnTH.Height;
            active.Top = btnTH.Top;
            usVeTauHoa1.BringToFront();
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKh_Click(object sender, EventArgs e)
        {
            active.Height = btnKh.Height;
            active.Top = btnKh.Top;
            usKhachHang1.BringToFront();
          
     
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            usVeMayBay1.BringToFront();
        }

        private void usVeMayBay1_Load(object sender, EventArgs e)
        {
            active.Height = btnMB.Height;
            active.Top = btnMB.Top;
      

        }
    }
}
