using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace _102210226_NgoDinhPhuoc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DisplayRecord()
        {

            DataTable dt = new DataTable();
            string query = " select masanpham , tensanpham,tennhasx , ngayNhapHang,ten_mathang, tinhtrang from mathang as  mh , nhasx as nsx , sanpham as sp  where   mh.id_matHang = sp.id_matHang and  nsx.id_nhasanxuat = sp.id_nhasanxuat  ";
            dt = DBHelper.getInStance.getInfo(query);
            dataGridView1.DataSource = dt;
            DisplaySoThuTu();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Text = "AddForm";
            form2.Show();
            form2.Buon += new Form2.MyDelegate(Add);
            
        } 
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Text = "Edit";
            form2.Show();
            form2.Buon += new Form2.MyDelegate(Edit);   
        }

        // lay ra gia tri  hang kick 
        int vitri = -1;
        int masanpham = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            // lay ra hang tai vi tri kick
            DataGridViewRow row = dataGridView1.Rows[vitri];
            masanpham = Convert.ToInt32(row.Cells[1].Value.ToString());
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn Có muốn xóa Sản Phẩm không", "Câu hỏi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            string query = "delete from SanPham where masanpham = '" + masanpham + "'";
            DBHelper.getInStance.ExectuteNonQuery(query);
            DisplaySoThuTu();
            if (result == DialogResult.OK)
            {
                DisplayRecord();
                MessageBox.Show("Xoa thanh cong ");
            }
            else
            {

            }
        }
        private void Add(int masp, string tensp, DateTime ngaynh, bool tinhtrang, int idmathang, int idnhsx)
        {
            SqlParameter[] sqlParameter =
                {

                new SqlParameter("@msp",masp),
                new SqlParameter("@ten",tensp),
                new SqlParameter("@ngaysinh",ngaynh),
                new SqlParameter("@tinhtrang",tinhtrang),
                new SqlParameter("@idmathang",idmathang),
                new SqlParameter("@nam",idnhsx),
            };
            string query = "insert into sanpham values (@msp,@ten,@ngaysinh,@tinhtrang,@idmathang,@nam)";
            //DBHelper.getInStance.getInfo(query, sqlParameter);
            //DataTable dt = new DataTable();
            // dt = DBHelper.getInStance.getInfo(query,sqlParameter);
            DBHelper.getInStance.ExecuteNonQuery(query, sqlParameter);
            DisplayRecord();

        }    
            private void Edit(int masp, string tensp, DateTime ngaynh, bool tinhtrang, int idmathang, int idnhsx)
            {
                SqlParameter[] sqlParameter =
                    {
                new SqlParameter("@msv",masp),
                new SqlParameter("@ten",tensp),
                new SqlParameter("@lopsh",ngaynh),
                new SqlParameter("@ngaySinh",tinhtrang),
                new SqlParameter("@dtb",idmathang),
                new SqlParameter("@nam",idnhsx),
            };
            string query = "update sanpham set masanpham = @msv,tensanpham =@ten,ngayNhapHang=@lopsh," +
            "tinhtrang = @ngaysinh,id_matHang = @dtb,id_nhasanxuat = @nam where masanpham = @msv ";
            //DBHelper.getInStance.getInfo(query, sqlParameter);
            //DataTable dt = new DataTable();
            // dt = DBHelper.getInStance.getInfo(query,sqlParameter);
            DBHelper.getInStance.ExecuteNonQuery(query, sqlParameter);
                DisplayRecord();
            }
        // hien thi số thự tự 
        private void DisplaySoThuTu()
        {

            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i - 1].Cells[0].Value = i;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayRecord();
        }

        // tìm kiếm theo masanpham
        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string searchMaSp = textSearch.Text.Trim();
            string query = " select masanpham , tensanpham,tennhasx , ngayNhapHang,ten_mathang, tinhtrang from mathang as  mh , nhasx as nsx , sanpham as sp  where   mh.id_matHang = sp.id_matHang and  nsx.id_nhasanxuat = sp.id_nhasanxuat and sp.tensanpham Like '%"+ searchMaSp + "%'";

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchMaSp = textSearch.Text.Trim();
            string query = " select masanpham , tensanpham,tennhasx , ngayNhapHang,ten_mathang, tinhtrang from mathang as  mh , nhasx as nsx , sanpham as sp" +
                "  where   mh.id_matHang = sp.id_matHang and  nsx.id_nhasanxuat = sp.id_nhasanxuat " +
                "and sp.tensanpham Like '%" + searchMaSp + "%'";
            DataTable dt = new DataTable();
            dt = DBHelper.getInStance.getInfo(query);
            dataGridView1.DataSource = dt;
            DisplaySoThuTu();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sortClick = comboBox1.SelectedItem.ToString().Trim();
            string query = " select masanpham , tensanpham,tennhasx , ngayNhapHang,ten_mathang, tinhtrang from mathang as mh , nhasx as nsx , sanpham as sp  " +
                "where mh.id_matHang = sp.id_matHang and nsx.id_nhasanxuat = sp.id_nhasanxuat ORDER BY "+ sortClick +  " ASC ";

            dataGridView1.DataSource = DBHelper.getInStance.getInfo(query);
            DisplaySoThuTu();
            MessageBox.Show("Sort Thanh Cong Tang Dan");
           
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
