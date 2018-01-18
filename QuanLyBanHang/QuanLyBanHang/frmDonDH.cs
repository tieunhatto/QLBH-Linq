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
    public partial class frmDonDH : Form
    {
        public frmDonDH()
        {
            InitializeComponent();
        }

        void VisibleButton(bool flag) {
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = flag;
            btnGhi.Visible = btnKhong.Visible = !flag;
        }

        void LockTextBox(bool flag) {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).ReadOnly = flag;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockTextBox(false);
            VisibleButton(false);

            txtSDH.Text = "";
            txtCodeNCC.Text = "";
            dtDonHang.Text = "";

            btnGhi.Text = "Ghi";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LockTextBox(false);
            VisibleButton(false);

            txtSDH.ReadOnly = true;

            txtSDH.Text = "";
            txtCodeNCC.Text = "";
            dtDonHang.Text = "";

            btnGhi.Text = "Cập nhật";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn có muốn xóa đơn hàng này không??", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (thongbao == DialogResult.OK)
            {
                QLVTDataContext da = new QLVTDataContext();
                DONDH ddh = da.DONDHs.Single(dh => dh.SoDH == txtSDH.Text);
                da.DONDHs.DeleteOnSubmit(ddh);
                da.SubmitChanges();
                MessageBox.Show("Xóa thành công đơn đặt hàng!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                LoadData();
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (checkValiDate() == false) return;

            if (btnGhi.Text == "Ghi")
            {
                QLVTDataContext da = new QLVTDataContext();
                DONDH ddh = new DONDH();
                ddh.SoDH = txtSDH.Text;
                ddh.MaNCC = txtCodeNCC.Text;
                ddh.NgayDH = DateTime.Parse(dtDonHang.Text);
                da.DONDHs.InsertOnSubmit(ddh);
                da.SubmitChanges();
                MessageBox.Show("Thêm thành công đơn hàng!","thông báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                LoadData();

                VisibleButton(true);
                LockTextBox(true);
                return;
            }
            if (btnGhi.Text == "Cập nhật")
            {
                QLVTDataContext da = new QLVTDataContext();
                DONDH ddh = da.DONDHs.Single(dh => dh.SoDH == txtSDH.Text);
                ddh.NgayDH = DateTime.Parse(dtDonHang.Text);
                ddh.MaNCC = txtCodeNCC.Text;
                da.SubmitChanges();
                MessageBox.Show("Cập nhật thành công đơn hàng!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LoadData();

                VisibleButton(true);
                LockTextBox(true);
                return;
            }

        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            VisibleButton(true);
            LockTextBox(true);
            using (QLVTDataContext da = new QLVTDataContext())
            {
                gvDonDH.AutoGenerateColumns = false;
                var load_DDH = from ddh in da.DONDHs select ddh;
                gvDonDH.DataSource = load_DDH;
            }
        }

        private void frmDonDH_Load(object sender, EventArgs e)
        {
            LoadData();
            VisibleButton(true);
            LockTextBox(true);
        }

        private void LoadData()
        {
            using (QLVTDataContext da = new QLVTDataContext())
            {
                gvDonDH.AutoGenerateColumns = false;
                var load_DDH = from ddh in da.DONDHs select ddh;
                gvDonDH.DataSource = load_DDH;

                lbTongCo.Text = "Tổng có: " + load_DDH.Count().ToString() + " đơn đặt hàng";
            }
        }

        private void txtSearchDDH_TextChanged(object sender, EventArgs e)
        {
            QLVTDataContext da = new QLVTDataContext();
            var list = from ddh in da.DONDHs
                       where ddh.SoDH.Contains(txtSearchDDH.Text)
                       select ddh;
            gvDonDH.DataSource = list;
        }

        private void gvDonDH_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtSDH.Text = gvDonDH.Rows[e.RowIndex].Cells[0].Value.ToString();
                dtDonHang.Text = gvDonDH.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCodeNCC.Text = gvDonDH.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }
        bool checkValiDate() {
            if (txtSDH.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số đơn hàng!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDH.Focus();
                return false;
            }
            if (txtCodeNCC.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhà cung cấp!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodeNCC.Focus();
                return false;
            }
            if (btnGhi.Text == "Ghi")
            {
                QLVTDataContext da = new QLVTDataContext();
                var ddh = from dh in da.DONDHs where dh.SoDH == txtSDH.Text select dh;
                if (ddh.Count() > 0)
                {
                    MessageBox.Show("Đơn đặt hàng này đã có, hãy nhập đơn đặt hàng khác!","thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtSDH.Focus();
                    txtSDH.BackColor = Color.Orange;
                    return false;
                }
            }
            return true;
        }
    }
}
