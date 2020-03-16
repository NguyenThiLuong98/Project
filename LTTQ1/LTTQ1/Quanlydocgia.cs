using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTTQ1
{
    public partial class Quanlydocgia : Form
    {
        public Quanlydocgia()
        {
            InitializeComponent();
        }
        private void refreshDataGridView()
        {
            myDatabase db = new myDatabase();
            dgvDocGia.DataSource = db.getData("Select * from NguoiMuon");

        }
        private void refreshDataGridView1(string sql)
        {
            myDatabase db = new myDatabase();
            dgvDocGia.DataSource = db.getData(sql);

        }
        private void setbutton()
        {
            btnThem.Text = "Thêm";
            txtMaDG.Text = "";
            txtTenDG.Text = "";
            txtDiaChi.Text = "";
            txtMaDG.Focus();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

        }


        private void Quanlydocgia_Load(object sender, EventArgs e)
        {
            refreshDataGridView();
            grbChiTietDG.Enabled = false;
            grbChiTietDG.Enabled = true; ;
            grGioiTinh.Enabled = false;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Hủy";
                txtMaDG.Text = "";
                txtTenDG.Text = "";
                txtDiaChi.Text = "";
                txtMaDG.Focus();
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                grbChiTietDG.Enabled = true;
                grGioiTinh.Enabled = true;
            }
            else
            {
                setbutton();
                grbChiTietDG.Enabled = false;
            }

        }
        private void sualuu()
        {
            myDatabase db = new myDatabase();
            string maDG = txtMaDG.Text;
            string tenDG = txtTenDG.Text;
            string diaChi = txtDiaChi.Text;
            string ngayMuon = Convert.ToDateTime(dtNgayMuon.Text).ToShortDateString();
            if (radNam.Checked)
            {
                string gt = "Nam";
                string sql = string.Format("Update NguoiMuon Set TenDG=N'{0}',NgayMuon='{1}',DiaChi=N'{2}',GioiTinh=N'{3}' Where MaDG='{4}'", tenDG, ngayMuon, diaChi, gt,maDG);
                db.getData(sql);
            }
            else
            {
                string gt = "Nữ";
                string sql = string.Format("Update NguoiMuon Set TenDG=N'{0}',NgayMuon='{1}',DiaChi=N'{2}',GioiTinh=N'{3}' Where MaDG='{4}'", tenDG, ngayMuon, diaChi, gt, maDG);
                db.getData(sql);
            }
            refreshDataGridView();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == true)
            {
                myDatabase db = new myDatabase();
                string maDG = txtMaDG.Text;
                string tenDG = txtTenDG.Text;
                string diaChi = txtDiaChi.Text;

                string ngayMuon = Convert.ToDateTime(dtNgayMuon.Text).ToShortDateString();
                if (radNam.Checked)
                {
                    string gioiTinh = "Nam";
                    string sql = string.Format("Insert into NguoiMuon values('{0}',N'{1}',N'{2}','{3}',N'{4}')", maDG, tenDG, gioiTinh, ngayMuon, diaChi);
                    db.getData(sql);
                }
                else
                {
                    string gioiTinh = "Nữ";
                    string sql = string.Format("Insert into NguoiMuon values('{0}',N'{1}',N'{2}','{3}',N'{4}')", maDG, tenDG, gioiTinh, ngayMuon, diaChi);
                    db.getData(sql);
                }
                refreshDataGridView();
            }
            if (btnSua.Enabled == true)
            {
                sualuu();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                grbChiTietDG.Enabled = true;
                btnSua.Text = "Hủy";
                txtMaDG.Enabled = false;
                txtTenDG.Text = "";
                //txt.Text = "";
                grGioiTinh.Enabled = true;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                //grbChiTietLoaiSach.Enabled = true;
            }
            else
            {
                btnSua.Text = "Sửa";
                //txtMaLoaiSach.Text = "";
                //txtTenLoaiSach.Text = "";
                //txtKieuSach.Text = "";
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                // grbChiTietLoaiSach.Enabled = false;
            }

        }

        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grbChiTietDG.Enabled = true;
            radNam.Checked = false;
            radNu.Checked = false;
            txtMaDG.Text = dgvDocGia.Rows[e.RowIndex].Cells["MaDG"].Value.ToString();
            txtTenDG.Text = dgvDocGia.Rows[e.RowIndex].Cells["TenDG"].Value.ToString();
            if (dgvDocGia.Rows[e.RowIndex].Cells["GioiTinh"].Value.ToString() == "Nam")
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }
            dtNgayMuon.Text = dgvDocGia.Rows[e.RowIndex].Cells["NgayMuon"].Value.ToString();
            txtDiaChi.Text = dgvDocGia.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            myDatabase db = new myDatabase();
            string MaDG = txtMaDG.Text;
            string sql = string.Format("Delete NguoiMuon Where MaDG='{0}'", MaDG);
            db.getData(sql);
            refreshDataGridView();


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Quanlydocgia_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult dl = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.No)
                e.Cancel = true;

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable) dgvDocGia.DataSource;

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
                exSheet.Cells[iRow, 3] = dt.Rows[i]["TenDG"].ToString();
                exSheet.Cells[iRow, 4] = dt.Rows[i]["GioiTinh"].ToString();
                exSheet.Cells[iRow, 5] = dt.Rows[i]["NgayMuon"].ToString();
                exSheet.Cells[iRow, 6] = dt.Rows[i]["DiaChi"].ToString();
                iRow++;
            }
            exRange = exSheet.get_Range("B6", "F" + (iRow - 1).ToString());
            exRange.Borders.Color = Color.Black.ToArgb();
            exRange.Font.Size = "18";

            Excel.Range cl1 = exSheet.get_Range("B6", "B6");
            cl1.Value = "Mã độc giả";
            cl1.ColumnWidth = "15";

            Excel.Range cl2 = exSheet.get_Range("C6", "C6");
            cl2.Value = "Tên độc giả";
            cl2.ColumnWidth = "30";

            Excel.Range cl3 = exSheet.get_Range("D6", "D6");
            cl3.Value = "Giới tính";
            cl3.ColumnWidth = "15";

            Excel.Range cl4 = exSheet.get_Range("E6", "E6");
            cl4.Value = "Ngày mượn";
            cl4.ColumnWidth = "30";

            Excel.Range cl5 = exSheet.get_Range("F6", "F6");
            cl5.Value = "Địa chỉ";
            cl5.ColumnWidth = "30";

            Excel.Range cl6 = exSheet.get_Range("B3", "F4");
            cl6.Merge(false);
            cl6.HorizontalAlignment = 3;
            cl6.VerticalAlignment = 3;
            cl6.Value = "THỐNG KÊ ĐỘC GIẢ ĐÃ MƯỢN SÁCH";
            cl6.Font.Size = "20";
            
            exApp.UserControl = false;
            exApp.Visible = true;

        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            myDatabase db = new myDatabase();
            string timkiem = txttimkiem.Text;
            string sql = string.Format("Select * from NguoiMuon where TenDG like N'%{0}%' or MaDG like '%{0}%'", timkiem);
            db.getData(sql);
            refreshDataGridView1(sql);
        }
    }
}
