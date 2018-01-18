using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmNhaCC : Form
    {
        NHACC tbl_nhacc = new NHACC();
        public frmNhaCC()
        {
            InitializeComponent();
        }

        private void frmNhaCC_Load(object sender, EventArgs e)
        {
            LockTextBoxs(true);
            visibleButton(true);
            LoadData();
        }
        void LockTextBoxs(bool flag)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).ReadOnly = flag;
                }
            }
        }
        void visibleButton(bool flag) {
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = flag;
            btnGhi.Visible = btnKhong.Visible = !flag;
        }
        private void LoadData()
        {
            using (QLVTDataContext da = new QLVTDataContext())
            {
                gvNhaCC.AutoGenerateColumns = false;
                var nhaCC = from nha_cc in da.NHACCs select nha_cc;
                gvNhaCC.DataSource = nhaCC;

                lbTong.Text = "Tổng số có: " + nhaCC.Count().ToString() + " nhà cung cấp.";
            }
        }

        private void gvNhaCC_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaNCC.Text = gvNhaCC.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenNCC.Text = gvNhaCC.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDiaChi.Text = gvNhaCC.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDienThoai.Text = gvNhaCC.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockTextBoxs(false);
            visibleButton(false);

            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";

            btnGhi.Text = "Ghi";
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (checkValiDate() == false) return;

            if (btnGhi.Text == "Ghi")
            {
                tbl_nhacc.MaNCC = txtMaNCC.Text;
                tbl_nhacc.TenNCC = txtTenNCC.Text;
                tbl_nhacc.Diachi = txtDiaChi.Text;
                tbl_nhacc.Dienthoai = txtDienThoai.Text;

                QLVTDataContext da = new QLVTDataContext();
                da.NHACCs.InsertOnSubmit(tbl_nhacc);
                da.SubmitChanges();
                MessageBox.Show("Thêm thành công nhà cung cấp!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LoadData();

                LockTextBoxs(true);
                visibleButton(true);
                return;
            }
            if (btnGhi.Text == "Cập nhật")
            {
                QLVTDataContext da = new QLVTDataContext();
                NHACC nha_cc = da.NHACCs.Single(nhaCC => nhaCC.MaNCC == txtMaNCC.Text);
                nha_cc.TenNCC = txtTenNCC.Text;
                nha_cc.Diachi = txtDiaChi.Text;
                nha_cc.Dienthoai = txtDienThoai.Text;
                da.SubmitChanges();
                MessageBox.Show("Sửa thành công nhà cung cấp!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();

                LockTextBoxs(true);
                visibleButton(true);
                return;

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LockTextBoxs(false);
            visibleButton(false);

            txtMaNCC.ReadOnly = true;//Khóa (textbox) mã nhà cung cấp không cho sửa
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";

            btnGhi.Text = "Cập nhật";
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            visibleButton(true);
            LockTextBoxs(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn có muốn xóa nhà cung cấp không??", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (thongbao == DialogResult.OK)
            {
                QLVTDataContext da = new QLVTDataContext();
                tbl_nhacc = da.NHACCs.Where(nhaCC => nhaCC.MaNCC == txtMaNCC.Text).Single();
                tbl_nhacc.TenNCC = txtTenNCC.Text;
                tbl_nhacc.Dienthoai = txtDienThoai.Text;
                tbl_nhacc.Diachi = txtDiaChi.Text;
                da.NHACCs.DeleteOnSubmit(tbl_nhacc);
                da.SubmitChanges();
                MessageBox.Show("Xoá thành công nhà cung cấp!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                frmNhaCC_Load(sender, e);
            }
        }
        bool checkValiDate() {
            if (txtMaNCC.Text.Trim() == "")
            {
                MessageBox.Show("bạn chưa nhập mã nhà cung cấp!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTenNCC.Text.Trim() == "")
            {
                MessageBox.Show("bạn chưa nhập tên nhà cung cấp!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("bạn chưa nhập địa chỉ cho nhà cung cấp!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtDienThoai.Text.Trim()=="")
            {
                MessageBox.Show("bạn chưa nhập số điện thoại cho nhà cung cấp!","thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            QLVTDataContext da = new QLVTDataContext();
            var list = from nhaCC in da.NHACCs
                       where nhaCC.TenNCC.Contains(txtSearch.Text)
                       select nhaCC;
            gvNhaCC.DataSource = list;
        }

        private void txtSearchCode_TextChanged(object sender, EventArgs e)
        {
            QLVTDataContext da = new QLVTDataContext();
            var list = from nhaCC in da.NHACCs
                       where nhaCC.MaNCC.Contains(txtSearchCode.Text)
                       select nhaCC;
            gvNhaCC.DataSource = list;
        }
    }
}
