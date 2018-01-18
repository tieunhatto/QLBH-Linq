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
    public partial class frmPXuat : Form
    {
        public frmPXuat()
        {
            InitializeComponent();
        }
        void VisibleButton(bool flag) {
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = flag;
            btnGhi.Visible = btnKhong.Visible = !flag;
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            VisibleButton(false);
            LockTextBoxs(false);

            btnGhi.Text = "Ghi";

            txtNameKH.Text = "";
            dtNgayXuat.Text = "";
            txtPx.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            VisibleButton(false);
            LockTextBoxs(false);

            txtPx.ReadOnly = true;
            btnGhi.Text = "Cập nhật";

            txtNameKH.Text = "";
            dtNgayXuat.Text = "";
            txtPx.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn có muốn xóa P xuất hay không??", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            if (thongbao==DialogResult.OK)
            {
                QLVTDataContext da = new QLVTDataContext();
                PXUAT px = da.PXUATs.Single(p_x => p_x.SoPx == txtPx.Text);
                da.PXUATs.DeleteOnSubmit(px);
                da.SubmitChanges();
                MessageBox.Show("Xóa thành công P xuất!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                LoadData();
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (checkValiDate() == false) return;

            if (btnGhi.Text=="Ghi")
            {
                QLVTDataContext da = new QLVTDataContext();
                PXUAT px = new PXUAT();
                px.SoPx = txtPx.Text;
                px.TenKH = txtNameKH.Text;
                px.NgayXuat = DateTime.Parse(dtNgayXuat.Text);
                da.PXUATs.InsertOnSubmit(px);
                da.SubmitChanges();
                MessageBox.Show("Thêm thành công!","thông báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                LoadData();

                VisibleButton(true);
                LockTextBoxs(true);
                return;
            }
            if (btnGhi.Text=="Cập nhật")
            {
                QLVTDataContext da = new QLVTDataContext();
                PXUAT px = da.PXUATs.Single(p_x => p_x.SoPx == txtPx.Text);
                px.TenKH = txtNameKH.Text;
                px.NgayXuat = DateTime.Parse(dtNgayXuat.Text);
                da.SubmitChanges();
                MessageBox.Show("Sửa thành công!","thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
            LoadData();
            
        }

        private void txtSearchPx_TextChanged(object sender, EventArgs e)
        {
            QLVTDataContext da = new QLVTDataContext();
            var list = from p_x in da.PXUATs
                     where p_x.SoPx == txtSearchPx.Text
                     select p_x;
            gvPx.DataSource = list;
        }

        private void gvPx_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtPx.Text = gvPx.Rows[e.RowIndex].Cells[0].Value.ToString();
                dtNgayXuat.Text = gvPx.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNameKH.Text = gvPx.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void frmPXuat_Load(object sender, EventArgs e)
        {
            LoadData();
            VisibleButton(true);
            LockTextBoxs(true);
            
        }

        private void LoadData()
        {
            using (QLVTDataContext da = new QLVTDataContext())
            {
                gvPx.AutoGenerateColumns = false;
                var px = from p_x in da.PXUATs select p_x;
                gvPx.DataSource = px;

                lbTongCo.Text = "Tổng có: " + px.Count().ToString() + " P Xuất.";
            }
        }

        bool checkValiDate() {
            if (txtPx.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số Px!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPx.Focus();
                return false;
            }
            if (txtNameKH.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNameKH.Focus();
                return false;
            }
            if (btnGhi.Text == "Ghi")
            {
                QLVTDataContext da = new QLVTDataContext();
                var px = from p_x in da.PXUATs
                         where p_x.SoPx == txtPx.Text
                         select p_x;
                if (px.Count() > 0)
                {
                    MessageBox.Show("Số px này đã có, hãy nhập số px khác", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtPx.BackColor = Color.Orange;
                    txtPx.Focus();
                    return false;
                }
            }
            return true;
        }
    }
}
