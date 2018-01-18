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
    public partial class frmQuanLyVatTu : Form
    {
        VATTU vt = new VATTU();
        public frmQuanLyVatTu()
        {
            InitializeComponent();
        }

        //Load dữ liệu
        void LoadData()
        {
            QLVTDataContext QLVT = new QLVTDataContext();
            var list = from ql_vt in QLVT.VATTUs select ql_vt;
            dataGridViewX1.DataSource = list;
        }
        //Khóa/ mở các điều khiển dữ liệu
        void LockTextBoxs(bool flag){
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).ReadOnly = flag;
                }
            }
        }
        // Ẩn hiện nút điều khiển
        void VisibleButtons(bool flag) {
            btnAdd.Visible = btnEdit.Visible = btnDelete.Visible = flag;
            btnGhi.Visible = btnKhong.Visible = !flag;
        }
        //check chưa nhập textbox
        bool checkValiDate() {
            if (txtMaVT.Text.Trim() == "")
            {
                lbErrorMaVT.ForeColor = Color.Red;
                lbErrorMaVT.Text = "Bạn chưa nhập mã vật tư";
                return false;
            }
            if (txtDVT.Text.Trim() == "")
            {
                lbErrorDVT.ForeColor = Color.Red;
                lbErrorDVT.Text = "Bạn chưa nhập đơn vị tính vật tư";
                return false;
            }
            if (txtNameVT.Text.Trim() == "")
            {
                lbErrorNameVT.ForeColor = Color.Red;
                lbErrorNameVT.Text = "Bạn chưa nhập tên vật tư";
                return false;
            }
            if (txtPhanTram.Text.Trim() == "")
            {
                lbErrorPhanTram.ForeColor = Color.Red;
                lbErrorPhanTram.Text = "Bạn chưa nhập % vật tư";
                return false;
            }
            return true;
        }
        private void frmQuanLyVatTu_Load(object sender, EventArgs e)
        {
            LoadData();
            LockTextBoxs(true);
            VisibleButtons(true);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (checkValiDate() == false) return;

            if (btnGhi.Text == "Ghi") 
            {
                QLVTDataContext QLVT = new QLVTDataContext();
                vt.Mavtu = txtMaVT.Text;
                vt.Phantram = float.Parse(txtPhanTram.Text);
                vt.TenVTu = txtNameVT.Text;
                vt.Dvtinh = txtDVT.Text;
                QLVT.VATTUs.InsertOnSubmit(vt);
                QLVT.SubmitChanges();
                MessageBox.Show("Thêm thành công vật tư!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LoadData();

                LockTextBoxs(true);
                VisibleButtons(true);
                return;
            }
            if (btnEdit.Text=="Cập nhật")
            {
                QLVTDataContext QLVT = new QLVTDataContext();
                vt = QLVT.VATTUs.Where(tb_qlvt => tb_qlvt.Mavtu == txtMaVT.Text).Single();
                vt.TenVTu = txtNameVT.Text;
                vt.Phantram = float.Parse(txtPhanTram.Text);
                vt.Dvtinh = txtDVT.Text;
                QLVT.SubmitChanges();
                MessageBox.Show("Sửa thành công vật tư!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();

                LockTextBoxs(true);
                VisibleButtons(true);
                return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LockTextBoxs(false);
            VisibleButtons(false);

            txtMaVT.Text = "";
            txtNameVT.Text = "";
            txtDVT.Text = "";
            txtPhanTram.Text = "";

            btnGhi.Text = "Ghi";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtMaVT.ReadOnly = true;// cột khóa không cho sửa.

            LockTextBoxs(false);
            VisibleButtons(false);

            txtDVT.Text = "";
            txtMaVT.Text = "";
            txtNameVT.Text = "";
            txtPhanTram.Text = "";

            btnEdit.Text = "Cập nhật";

            
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn có muốn xóa vật tư không??", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (thongbao == DialogResult.OK)
            {
                QLVTDataContext QLVT = new QLVTDataContext();
                vt = QLVT.VATTUs.Where(tb_qlvt => tb_qlvt.Mavtu == txtMaVT.Text).Single();
                vt.TenVTu = txtNameVT.Text;
                vt.Phantram = float.Parse(txtPhanTram.Text);
                vt.Dvtinh = txtPhanTram.Text;
                QLVT.VATTUs.DeleteOnSubmit(vt);
                QLVT.SubmitChanges();
                MessageBox.Show("Xoá thành công vật tư!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                frmQuanLyVatTu_Load(sender, e);
            }
        }

        private void dataGridViewX1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                txtMaVT.Text = dataGridViewX1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNameVT.Text = dataGridViewX1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDVT.Text = dataGridViewX1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPhanTram.Text = dataGridViewX1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            VisibleButtons(true);
            LockTextBoxs(true);
        }
    }
}
