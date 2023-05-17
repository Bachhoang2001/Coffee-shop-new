using CafeShop.BUS;
using CafeShop.Controls;
using Guna.UI2.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeShop
{
    public partial class EmployeeListForm : Form
    {
        public EmployeeListForm()
        {
            InitializeComponent();
        }

        NhanVienBUS _nhanVienBUS = new NhanVienBUS();

        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            PanelScrollHelper panelScrollHelper = new PanelScrollHelper(pnlDSNhanVien, guna2VScrollBar1, true);
            LoadDSNhanVien();
        }

        private void LoadDSNhanVien()
        {
            pnlDSNhanVien.Controls.Clear();

            foreach (var item in _nhanVienBUS.GetAll())
            {
                EmployeeItemControl employeeControl = new EmployeeItemControl();
                employeeControl.NhanVien = item;
                employeeControl.Dock = DockStyle.Top;
                pnlDSNhanVien.Controls.Add(employeeControl);
            }
        }
    }
}
