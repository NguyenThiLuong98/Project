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

namespace LTTQ1
{
    public partial class Quanlymuontra : Form
    {
        public Quanlymuontra()
        {
            InitializeComponent();
        }
        

        private void Quanlymuontra_Load(object sender, EventArgs e)
        {
            refreshDataGridView();
            Loadcombox();
        }
        private void refreshDataGridView()
        {
            myDatabase db = new myDatabase();
            dgvMuontra.DataSource = db.getData("Select * from MuonTraSach");
            dgvTraSach.DataSource = db.getData("Select * from MuonTraSach");
        }
        private void refreshDataGridView1(string sql)
        {
            myDatabase db = new myDatabase();
            dgvMuontra.DataSource = db.getData(sql);
        }
        private void Loadcombox()
        {
            myDatabase db = new myDatabase();
            cbMaSach.DataSource = db.getData("Select * From Sach");
            cbMaSach.DisplayMember = "TenSach";
            cbMaSach.ValueMember = "MaSach";

            cbDocGia.DataSource = db.getData("Select * from NguoiMuon");
            cbDocGia.DisplayMember = "TenDG";
            cbDocGia.ValueMember = "MaDG";

            cbMaDG_TraSach.DataSource = db.getData("Select * from MuonTraSach");
            cbMaDG_TraSach.DisplayMember = "MaDG";
            cbMaDG_TraSach.ValueMember = "MaDG";

        }

        private void cbMaSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            myDatabase db = new myDatabase();
             SqlConnection myConnection = new SqlConnection(db.conSt);
            string masach = cbMaSach.SelectedValue.ToString();
            string sql = string.Format("Select MaSach, MaLoaiSach, SoLuong, MaTG From Sach where MaSach=N'{0}'", masach);
            SqlDataAdapter da = new SqlDataAdapter(sql, myConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow drw in dt.Rows)
            {
                txtMaSach1.Text = drw["MaSach"].ToString();
                labMaLoai.Text = drw["MaLoaiSach"].ToString();
                labSoLuong.Text = drw["SoLuong"].ToString();
                lbMaTG.Text = drw["MaTG"].ToString();
            }

           
        }

        private void Quanlymuontra_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.No)
                e.Cancel = true;
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChoMuon_Click(object sender, EventArgs e)
        {

            myDatabase db = new myDatabase();
            SqlConnection con = new SqlConnection(db.conSt);
            string madg = cbDocGia.SelectedValue.ToString();
            string masach = txtMaSach.Text;
            int soluong = Convert.ToInt32(txtSoLuong.Text);
            int soluong1 = Convert.ToInt32(labSoLuong.Text);
            string ngaymuon = Convert.ToDateTime(dtMuon.Text).ToShortDateString();
            string ngayhentra = Convert.ToDateTime(dtTra.Text).ToShortDateString();
            if (soluong1 >= soluong) { 
            string sql = string.Format("Insert into  MuonTraSach(MaDG,MaSach,SoLuong,NgayMuon,NgayHenTra) values('{0}','{1}',{2},'{3}','{4}')", madg, masach, soluong, ngaymuon, ngayhentra);
            db.getData(sql);
            string sql1 = string.Format("UPDATE Sach SET SoLuong= SoLuong- {0} WHERE MaSach='{1}'", soluong, masach);
            db.getData(sql1);
            refreshDataGridView();
            }
            else
            {
                MessageBox.Show("lỗi, Sách trong kho không đủ");
            }

        }
        //Trả sách
        private void btnTraSach_Click(object sender, EventArgs e)
        {
            DateTime ngayhentra = dtNgayHenTra_TraSach.Value;
            DateTime ngaytra = dtNgayTra.Value;
            if (ngaytra <= ngayhentra)
            {
                lblTinhTrangTraSach.Text = "Đúng hạn";
            }
            else
            {
                lblTinhTrangTraSach.Text = "Quá hạn";
            }
        }

        private void dgvTraSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbMaDG_TraSach.Text = dgvTraSach.Rows[e.RowIndex].Cells["MaDG"].Value.ToString();
            txtMaSach_TraSach.Text = dgvTraSach.Rows[e.RowIndex].Cells["MaSach"].Value.ToString();
            txtSoLuong_TraSach.Text = dgvTraSach.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString();
            dtNgayMuon_TraSach.Text = dgvTraSach.Rows[e.RowIndex].Cells["NgayMuon"].Value.ToString();
            dtNgayHenTra_TraSach.Text = dgvTraSach.Rows[e.RowIndex].Cells["NgayHenTra"].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            myDatabase db = new myDatabase();
            SqlConnection con = new SqlConnection(db.conSt);
            string MaDG = cbMaDG_TraSach.SelectedValue.ToString();
            string Masach = txtMaSach_TraSach.Text;
            int soluong = Convert.ToInt32(txtSoLuong_TraSach.Text);
            string ngaytra = Convert.ToDateTime(dtNgayTra.Text).ToShortDateString();
            string sql = string.Format("UPDATE MuonTraSach SET NgayTra='{0}' WHERE MaDG='{1}'AND MaSach='{2}'",ngaytra, MaDG,Masach);
            db.getData(sql);
            string sql1 = string.Format("Update Sach set SoLuong= SoLuong + {0} where MaSach='{1}'", soluong, Masach);
            db.getData(sql1);
            refreshDataGridView();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbDocGia.Text = "";
            txtMaSach.Text = "";
            dtMuon.Text = "";
            dtTra.Text = "";
            txtSoLuong.Text = "";
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            myDatabase db = new myDatabase();
            SqlConnection con = new SqlConnection(db.conSt);
            string madg = cbDocGia.Text;
            string sql = string.Format("Select * from MuonTraSach where MaDG='{0}'", madg);
            db.getData(sql);
            refreshDataGridView1(sql);
            DataTable dt = (DataTable)dgvMuontra.DataSource;
            
            Excel.Application exApp;
            Excel.Workbook exBook;
            Excel.Worksheet exSheet;
            Excel.Range exRange;
            exApp = new Excel.Application();
            exBook = (Excel.Workbook)(exApp.Workbooks.Add(true));
            exSheet = (Excel.Worksheet)exBook.ActiveSheet;
            int iRow = 7;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                exSheet.Cells[iRow, 2] = dt.Rows[i]["MaDG"].ToString();
                exSheet.Cells[iRow, 3] = dt.Rows[i]["MaSach"].ToString();
                exSheet.Cells[iRow, 4] = dt.Rows[i]["SoLuong"].ToString();
                exSheet.Cells[iRow, 5] = dt.Rows[i]["NgayMuon"].ToString();
                exSheet.Cells[iRow, 6] = dt.Rows[i]["NgayHenTra"].ToString();
                iRow++;
            }
            exRange = exSheet.get_Range("B6", "F" + (iRow - 1).ToString());
            exRange.Borders.Color = Color.Black.ToArgb();
            exRange.Font.Size = "18";

            Excel.Range cl1 = exSheet.get_Range("B6", "B6");
            cl1.Value = "Mã độc giả";
            cl1.ColumnWidth = "15";

            Excel.Range cl2 = exSheet.get_Range("C6", "C6");
            cl2.Value = "Mã sách";
            cl2.ColumnWidth = "20";

            Excel.Range cl3 = exSheet.get_Range("D6", "D6");
            cl3.Value = "Số lượng";
            cl3.ColumnWidth = "15";

            Excel.Range cl4 = exSheet.get_Range("E6", "E6");
            cl4.Value = "Ngày mượn";
            cl4.ColumnWidth = "30";

            Excel.Range cl5 = exSheet.get_Range("F6", "F6");
            cl5.Value = "Ngày hẹn trả";
            cl5.ColumnWidth = "30";

            Excel.Range cl6 = exSheet.get_Range("B3", "F4");
            cl6.Merge(false);
            cl6.HorizontalAlignment = 3;
            cl6.VerticalAlignment = 3;
            cl6.FormulaR1C1 = "PHIẾU MƯỢN SÁCH";
            cl6.Font.Size = "20";
            exApp.UserControl = false;
            exApp.Visible = true;

        }
    }
}
