namespace QuanLyBanHang
{
    partial class frmDonDH
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtSearchDDH = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lbTongCo = new DevComponents.DotNetBar.LabelX();
            this.gvDonDH = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.SoDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new DevComponents.DotNetBar.ButtonX();
            this.btnSua = new DevComponents.DotNetBar.ButtonX();
            this.btnXoa = new DevComponents.DotNetBar.ButtonX();
            this.btnKhong = new DevComponents.DotNetBar.ButtonX();
            this.btnGhi = new DevComponents.DotNetBar.ButtonX();
            this.dtDonHang = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtSDH = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtCodeNCC = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDonDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.txtSearchDDH);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.lbTongCo);
            this.groupPanel1.Controls.Add(this.gvDonDH);
            this.groupPanel1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Location = new System.Drawing.Point(28, 161);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(620, 234);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "Danh sách đơn hàng";
            // 
            // txtSearchDDH
            // 
            // 
            // 
            // 
            this.txtSearchDDH.Border.Class = "TextBoxBorder";
            this.txtSearchDDH.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearchDDH.Location = new System.Drawing.Point(478, 179);
            this.txtSearchDDH.Name = "txtSearchDDH";
            this.txtSearchDDH.Size = new System.Drawing.Size(118, 26);
            this.txtSearchDDH.TabIndex = 3;
            this.txtSearchDDH.TextChanged += new System.EventHandler(this.txtSearchDDH_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(257, 180);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(215, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "tìm kiếm theo số đơn hàng:";
            // 
            // lbTongCo
            // 
            // 
            // 
            // 
            this.lbTongCo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTongCo.Location = new System.Drawing.Point(18, 180);
            this.lbTongCo.Name = "lbTongCo";
            this.lbTongCo.Size = new System.Drawing.Size(233, 23);
            this.lbTongCo.TabIndex = 1;
            this.lbTongCo.Text = "Tổng có:";
            // 
            // gvDonDH
            // 
            this.gvDonDH.AllowUserToAddRows = false;
            this.gvDonDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDonDH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoDH,
            this.NgayDH,
            this.MaNCC});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDonDH.DefaultCellStyle = dataGridViewCellStyle1;
            this.gvDonDH.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gvDonDH.Location = new System.Drawing.Point(18, 8);
            this.gvDonDH.Name = "gvDonDH";
            this.gvDonDH.Size = new System.Drawing.Size(578, 166);
            this.gvDonDH.TabIndex = 0;
            this.gvDonDH.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDonDH_RowEnter);
            // 
            // SoDH
            // 
            this.SoDH.DataPropertyName = "SoDH";
            this.SoDH.HeaderText = "Số đơn hàng";
            this.SoDH.Name = "SoDH";
            this.SoDH.Width = 130;
            // 
            // NgayDH
            // 
            this.NgayDH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayDH.DataPropertyName = "NgayDH";
            this.NgayDH.HeaderText = "Ngày đặt hàng";
            this.NgayDH.Name = "NgayDH";
            // 
            // MaNCC
            // 
            this.MaNCC.DataPropertyName = "MaNCC";
            this.MaNCC.HeaderText = "Mã nhà cung cấp";
            this.MaNCC.Name = "MaNCC";
            this.MaNCC.Width = 160;
            // 
            // btnThem
            // 
            this.btnThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThem.Location = new System.Drawing.Point(55, 113);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSua.Location = new System.Drawing.Point(158, 113);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoa.Location = new System.Drawing.Point(257, 112);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnKhong.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnKhong.Location = new System.Drawing.Point(547, 112);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(75, 23);
            this.btnKhong.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnKhong.TabIndex = 3;
            this.btnKhong.Text = "Không";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGhi.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGhi.Location = new System.Drawing.Point(438, 112);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(75, 23);
            this.btnGhi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGhi.TabIndex = 4;
            this.btnGhi.Text = "Lưu";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // dtDonHang
            // 
            // 
            // 
            // 
            this.dtDonHang.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtDonHang.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDonHang.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtDonHang.ButtonDropDown.Visible = true;
            this.dtDonHang.IsPopupCalendarOpen = false;
            this.dtDonHang.Location = new System.Drawing.Point(399, 22);
            // 
            // 
            // 
            this.dtDonHang.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtDonHang.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDonHang.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtDonHang.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtDonHang.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtDonHang.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtDonHang.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtDonHang.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtDonHang.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtDonHang.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtDonHang.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDonHang.MonthCalendar.DisplayMonth = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dtDonHang.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtDonHang.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtDonHang.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtDonHang.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtDonHang.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtDonHang.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtDonHang.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDonHang.MonthCalendar.TodayButtonVisible = true;
            this.dtDonHang.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtDonHang.Name = "dtDonHang";
            this.dtDonHang.Size = new System.Drawing.Size(223, 20);
            this.dtDonHang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtDonHang.TabIndex = 5;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(55, 20);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "Số đơn hàng:";
            // 
            // txtSDH
            // 
            // 
            // 
            // 
            this.txtSDH.Border.Class = "TextBoxBorder";
            this.txtSDH.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSDH.Location = new System.Drawing.Point(159, 22);
            this.txtSDH.Name = "txtSDH";
            this.txtSDH.Size = new System.Drawing.Size(100, 20);
            this.txtSDH.TabIndex = 7;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(299, 20);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(94, 23);
            this.labelX3.TabIndex = 8;
            this.labelX3.Text = "Ngày đơn hàng:";
            // 
            // txtCodeNCC
            // 
            // 
            // 
            // 
            this.txtCodeNCC.Border.Class = "TextBoxBorder";
            this.txtCodeNCC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCodeNCC.Location = new System.Drawing.Point(159, 63);
            this.txtCodeNCC.Name = "txtCodeNCC";
            this.txtCodeNCC.Size = new System.Drawing.Size(100, 20);
            this.txtCodeNCC.TabIndex = 10;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(55, 61);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(98, 23);
            this.labelX4.TabIndex = 9;
            this.labelX4.Text = "Mã nhà cung cấp:";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(28, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 150);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm đơn đặt hàng";
            // 
            // frmDonDH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 407);
            this.Controls.Add(this.txtCodeNCC);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txtSDH);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.dtDonHang);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.btnKhong);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDonDH";
            this.Text = "Đơn đặt hàng";
            this.Load += new System.EventHandler(this.frmDonDH_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDonDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDonHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX gvDonDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNCC;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearchDDH;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lbTongCo;
        private DevComponents.DotNetBar.ButtonX btnThem;
        private DevComponents.DotNetBar.ButtonX btnSua;
        private DevComponents.DotNetBar.ButtonX btnXoa;
        private DevComponents.DotNetBar.ButtonX btnKhong;
        private DevComponents.DotNetBar.ButtonX btnGhi;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtDonHang;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSDH;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCodeNCC;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}