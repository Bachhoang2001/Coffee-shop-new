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
    public partial class MemberForm : Form
    {
        public MemberForm()
        {
            InitializeComponent();
        }

        KhachHangBUS _khachHangBUS = new KhachHangBUS();

        private void MemberForm_Load(object sender, EventArgs e)
        {
            PanelScrollHelper panelScrollHelper = new PanelScrollHelper(pnlDSThanhVien, guna2VScrollBar1, true);
            LoadDSThanhVien();
        }

        private void LoadDSThanhVien()
        {
            pnlDSThanhVien.Controls.Clear();
            
            foreach(var item in _khachHangBUS.GetAll())
            {
                MemberItemControl memberControl = new MemberItemControl();
                memberControl.KhachHang = item;
                memberControl.Dock = DockStyle.Top;
                pnlDSThanhVien.Controls.Add(memberControl);
            }
        }
    }
}
