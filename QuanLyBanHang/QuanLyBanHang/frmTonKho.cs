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
    public partial class frmTonKho : Form
    {
        public frmTonKho()
        {
            InitializeComponent();
        }

        private void frmTonKho_Load(object sender, EventArgs e)
        {
            LoadData();
            VisibleButton(true);
            LockTextBox(true);
        }
        bool checkValiDate()
        {
            if (txtThang.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tháng và năm!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (txtMVT.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã vật tư!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (txtSLN.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tổng số lượng năm!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (txtSLX.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tổng số lượng xuất!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (txtSLD.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng đầu!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (btnSave.Text=="Lưu")
            {
                QLVTDataContext da = new QLVTDataContext();
                var tonKho = from ton in da.TONKHOs where ton.Mavtu == txtMVT.Text select ton;

            }
            return true;
        }

        private void LoadData()
        {
            using (QLVTDataContext da = new QLVTDataContext())
            {
                gvTonKho.AutoGenerateColumns = false;
                var listDS = from tk in da.TONKHOs select tk;
                gvTonKho.DataSource = listDS;

                lbTong.Text = "Tổng số có: " + listDS.Count().ToString() + " tồn kho";
            }
        }

        void VisibleButton(bool flag) {
            btnAdd.Visible = btnEdit.Visible = btnDelete.Visible = flag;
            btnSave.Visible = btnClose.Visible = !flag;
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            VisibleButton(false);
            LockTextBox(false);

            txtMVT.Text = "";
            txtSLC.Text = "";
            txtSLD.Text = "";
            txtSLN.Text = "";
            txtThang.Text = "";
            txtSLX.Text = "";

            btnSave.Text = "Lưu";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            VisibleButton(false);
            LockTextBox(false);

            txtMVT.Text = "";
            txtSLC.Text = "";
            txtSLD.Text = "";
            txtSLN.Text = "";
            txtThang.Text = "";
            txtSLX.Text = "";

            btnSave.Text = "Edit";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn có muốn xóa tồn kho này không??", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (thongbao == DialogResult.OK)
            {
                QLVTDataContext da = new QLVTDataContext();
                TONKHO ton_kho = da.TONKHOs.Single(ton => ton.Mavtu == txtMVT.Text && ton.NamThang == txtThang.Text);
                da.TONKHOs.DeleteOnSubmit(ton_kho);
                da.SubmitChanges();
                MessageBox.Show("Xóa thành công tồn kho!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                frmTonKho_Load(sender, e);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkValiDate() == false) return;

            if (btnSave.Text=="Lưu")
            {
                QLVTDataContext da = new QLVTDataContext();

                TONKHO tonKho = new TONKHO();
                tonKho.Mavtu = txtMVT.Text;
                tonKho.SLDau = Convert.ToInt32(txtSLD.Text);
                tonKho.TongSLN = Convert.ToInt32(txtSLN.Text);
                tonKho.TongSLX = int.Parse(txtSLX.Text);
                tonKho.NamThang = txtThang.Text;

                da.TONKHOs.InsertOnSubmit(tonKho);
                da.SubmitChanges();
                MessageBox.Show("Thêm thành công tồn kho!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                frmTonKho_Load(sender, e);

                VisibleButton(true);
                LockTextBox(true);
                return;
            }
            if (btnSave.Text=="Edit")
            {
                QLVTDataContext da = new QLVTDataContext();
                TONKHO ton_kho = da.TONKHOs.Single(ton => ton.Mavtu == txtMVT.Text);
                ton_kho.SLDau = Convert.ToInt32(txtSLD.Text);
                ton_kho.TongSLN = Convert.ToInt32(txtSLN.Text);
                ton_kho.TongSLX = int.Parse(txtSLX.Text);
                ton_kho.NamThang = txtThang.Text;
                da.SubmitChanges();
                MessageBox.Show("Sửa thành công tồn kho!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();

                VisibleButton(true);
                LockTextBox(true);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            VisibleButton(true);
            LockTextBox(true);
        }

        private void gvTonKho_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtThang.Text = gvTonKho.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtMVT.Text = gvTonKho.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSLD.Text = gvTonKho.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSLN.Text = gvTonKho.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtSLX.Text = gvTonKho.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSLC.Text = gvTonKho.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void txtSLC_TextChanged(object sender, EventArgs e)
        {
            txtSLC.Enabled = false;
        }
        
    }
}
