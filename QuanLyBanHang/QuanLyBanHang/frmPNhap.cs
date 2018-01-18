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
    public partial class frmPNhap : Form
    {
        public frmPNhap()
        {
            InitializeComponent();
        }

        void VisibleButton(bool flag) {
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = flag;
            btnSave.Visible = btnKhong.Visible = !flag;
        }

        void LockTextBoxs(bool flag) {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).ReadOnly = flag;
                }
            }
        }
        private void frmPNhap_Load(object sender, EventArgs e)
        {
            LoadData();
            VisibleButton(true);
            LockTextBoxs(true);
        }

        private void LoadData()
        {
            using (QLVTDataContext da = new QLVTDataContext())
            {
                gvPNhap.AutoGenerateColumns = false;
                var nhap = from p_nhap in da.PNHAPs select p_nhap;
                gvPNhap.DataSource = nhap;

                lbTongCo.Text = "Tổng có: " + nhap.Count().ToString() + " P nhập.";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            VisibleButton(false);
            LockTextBoxs(false);

            txtDH.Text = "";
            txtSoPn.Text = "";
            dtNgayNhap.Text = "";

            btnSave.Text = "Ghi";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            VisibleButton(false);
            LockTextBoxs(false);

            txtSoPn.ReadOnly = true;

            txtDH.Text = "";
            txtSoPn.Text = "";
            dtNgayNhap.Text = "";

            btnSave.Text = "Cập nhật";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn có muốn xóa Pn hay không??", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (thongbao == DialogResult.OK)
            {
                QLVTDataContext da = new QLVTDataContext();
                PNHAP pn = da.PNHAPs.Single(p_nhap => p_nhap.SoPn == txtSoPn.Text);
                da.PNHAPs.DeleteOnSubmit(pn);
                da.SubmitChanges();
                MessageBox.Show("Xóa thành công!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                LoadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkValiDate() == false) return;

            if (btnSave.Text == "Ghi")
            {
                QLVTDataContext da = new QLVTDataContext();
                PNHAP pn = new PNHAP();
                pn.SoDH = txtDH.Text;
                pn.NgayNhap = DateTime.Parse(dtNgayNhap.Text);
                pn.SoPn = txtSoPn.Text;
                da.PNHAPs.InsertOnSubmit(pn);
                da.SubmitChanges();
                MessageBox.Show("Thêm thành công Pn!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LoadData();

                VisibleButton(true);
                LockTextBoxs(true);
                return;
            }
            if (btnSave.Text == "Cập nhật")
            {
                QLVTDataContext da = new QLVTDataContext();
                PNHAP pn = da.PNHAPs.Single(p_nhap => p_nhap.SoPn == txtSoPn.Text);
                pn.SoDH = txtDH.Text;
                pn.NgayNhap = DateTime.Parse(dtNgayNhap.Text);
                da.SubmitChanges();
                MessageBox.Show("Cập nhật thành công!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                VisibleButton(true);
                LockTextBoxs(true);
                return;
            }

        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            VisibleButton(true);
            LockTextBoxs(true);

            using (QLVTDataContext da = new QLVTDataContext())
            {
                gvPNhap.AutoGenerateColumns = false;
                var nhap = from p_nhap in da.PNHAPs select p_nhap;
                gvPNhap.DataSource = nhap;
            }
        }

        private void txtSearchPn_TextChanged(object sender, EventArgs e)
        {
            QLVTDataContext da = new QLVTDataContext();
            var list = from p_nhap in da.PNHAPs
                       where p_nhap.SoPn.Contains(txtSearchPn.Text)
                       select p_nhap;
            gvPNhap.DataSource = list;
        }

        private void gvPNhap_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtSoPn.Text = gvPNhap.Rows[e.RowIndex].Cells[0].Value.ToString();
                dtNgayNhap.Text = gvPNhap.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDH.Text = gvPNhap.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        bool checkValiDate()
        {
            if (txtSoPn.Text.Trim() == "") 
            {
                MessageBox.Show("Bạn chưa nhập số Pn!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoPn.Focus();
                return false;
            }
            if (txtDH.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số đơn hàng!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDH.Focus();
                return false;
            }
            if (btnSave.Text=="Ghi")
            {
                QLVTDataContext da = new QLVTDataContext();
                var pn = from p_nhap in da.PNHAPs
                         where p_nhap.SoPn == txtSoPn.Text
                         select p_nhap;
                if (pn.Count() > 0) 
                {
                    MessageBox.Show("Số Pn này đã có, mời nhập số Pn khác!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtSoPn.Focus();
                    txtSoPn.BackColor = Color.Orange;
                    return false;
                }
            }
            return true;
        }
    }
}
