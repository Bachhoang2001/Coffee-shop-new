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
    public partial class OrderListForm : Form
    {
        public OrderListForm()
        {
            InitializeComponent();
        }

        HoaDonBUS _hoaDonBUS = new HoaDonBUS();

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            PanelScrollHelper panelScrollHelper = new PanelScrollHelper(pnlDSOrder, guna2VScrollBar1, true);
            LoadDSHoaDon();
        }

        private void LoadDSHoaDon()
        {
            pnlDSOrder.Controls.Clear();

            foreach (var item in _hoaDonBUS.GetList())
            {
                OrderListControl orderControl = new OrderListControl();
                orderControl.HoaDon = item;
                orderControl.Dock = DockStyle.Top;
                pnlDSOrder.Controls.Add(orderControl);
            }
        }
    }
}
