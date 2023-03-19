using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102210226_NgoDinhPhuoc
{
    public partial class Form2 : Form
    {
        public delegate void MyDelegate(int masp, string tensp, DateTime ngaynh, bool tinhtrang , int idmathang, int idnhsx);
        public MyDelegate Buon;
        public Form2()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnOKI_Click(object sender, EventArgs e)
        {
            int masanpham =Convert.ToInt32( textboxMSP.Text.Trim());
            string tenSanPham = textboxTSP.Text.Trim();
            DateTime ngaynhap1 = ngaynhap.Value.Date;

            string mathang = cbbMathang.SelectedItem.ToString().Trim();
            
            int mamathang = -1;
            if (mathang == "Do uong")
            {
                mamathang = 1;
            }
            else if (mathang == "Thuc an")
            {
                mamathang = 2;
            }
            else if (mathang == "Noi That")
            {
                mamathang = 3;
            }
            else
            {
                mamathang = 4;
            }
            string NhaSanXuat1 = commNhaSanXuat.SelectedItem.ToString().Trim();
            int idNsx = -1;
            if (NhaSanXuat1 == "Cocavn")
            {
                idNsx = 112;
            }
            else if (NhaSanXuat1 == "HAGL")
            {
                idNsx = 114;
            }
            else if (NhaSanXuat1 == "Dinh PHuoc")
            {
                idNsx = 125;

            }
            else
            {
                idNsx = 115;
            }

            bool status = true;
            if (radioConhang.Checked == true && radioHethang.Checked == false)
            {
                status = true;
            }
            else if(radioConhang.Checked == false && radioHethang.Checked == true)
            {
                status = false;
            }
            
            Buon(masanpham, tenSanPham,ngaynhap1, status, mamathang, idNsx);

        }

       /* private void commNhaSanXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mathang = cbbMathang.SelectedItem.ToString().Trim();
            int mamathang = -1;
            if (mathang == "Do uong")
            {
                commNhaSanXuat.Items.Clear();
                
                commNhaSanXuat.Items.Add("Cocavn");
               
            }
            else if(mathang == "Thuc an")
            {
                commNhaSanXuat.Items.Clear();
               
                commNhaSanXuat.Items.Add("DaNang");

            }
            else if (mathang == "Noi That")
            {
                commNhaSanXuat.Items.Clear();

                commNhaSanXuat.Items.Add("Dinh PHuoc");
            }
            else
            {
                commNhaSanXuat.Items.Clear();

                commNhaSanXuat.Items.Add("Kim Dong");
            }
        }*/
        private void ListItemCBBByLTC()
        {
            List<string> LoaiTC = new List<string>() { "Do uong", "Thuc an","Noi That","Sach Vo" };
            for (int i = 0; i < LoaiTC.Count(); i++)
            {
                cbbMathang.Items.Add(LoaiTC[i]);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ListItemCBBByLTC();
        }

        private void cbbMathang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mathang = cbbMathang.SelectedItem.ToString().Trim();
            int mamathang = -1;
            if (mathang == "Do uong")
            {
                commNhaSanXuat.Items.Clear();

                commNhaSanXuat.Items.Add("PepSiVN");

            }
            else if (mathang == "Thuc an")
            {
                commNhaSanXuat.Items.Clear();

                commNhaSanXuat.Items.Add("HAGL");

            }
            else if (mathang == "Noi That")
            {
                commNhaSanXuat.Items.Clear();

                commNhaSanXuat.Items.Add("Thinh Phat");
            }
            else
            {
                commNhaSanXuat.Items.Clear();

                commNhaSanXuat.Items.Add("Kim Dong");
            }
        }
    }
}
