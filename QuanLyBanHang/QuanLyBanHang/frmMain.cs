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
    public partial class frmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            frmNhaCC frm = new frmNhaCC();
            frm.Show();
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            frmQuanLyVatTu frm = new frmQuanLyVatTu();
            frm.ShowDialog();
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            frmPXuat frm = new frmPXuat();
            frm.Show();
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            frmPNhap frm = new frmPNhap();
            frm.Show();
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            frmDonDH frm = new frmDonDH();
            frm.Show();
        }
    }
}
