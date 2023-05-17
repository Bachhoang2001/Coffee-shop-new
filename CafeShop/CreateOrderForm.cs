using CafeShop.BUS;
using CafeShop.Controls;
using CafeShop.Entity;
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
    public partial class CreateOrderForm : Form
    {
        private readonly HoaDon _hoaDon;
        HoaDonBUS _hoaDonBUS = new HoaDonBUS();
        public CreateOrderForm(Entity.HoaDon hoaDon)
        {
            InitializeComponent();
            this._hoaDon = hoaDon;
        }

        private void CreateOrderForm_Load(object sender, EventArgs e)
        {
            PanelScrollHelper panelScrollHelper = new PanelScrollHelper(pnlDSChiTiet, scrollBar, true);

            if (_hoaDon == null)
                this.Close();

            lblMaHD.Text = _hoaDon.MaHD;
            lblNgayLap.Text = _hoaDon.NgayLap.ToString("dd/MM/yyyy");
            lblTongThanhTien.Text = _hoaDon.TongTien.ToString("0.##");
            HienThiChiTiet();
        }

        private void HienThiChiTiet()
        {
            pnlDSChiTiet.Controls.Clear();

            foreach (var ct in _hoaDon.ChiTietHoaDons)
            {
                var item = new OrderDetailControl();
                item.ChiTiet = ct;
                item.Dock = DockStyle.Top;
                pnlDSChiTiet.Controls.Add(item);
            }
        }

        private void btnHoaDonMoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            _hoaDon.NgayLap = DateTime.Now;

            if (_hoaDonBUS.Add(_hoaDon))
            {
                MessageBox.Show("In hóa đơn thành công");
                return;
            }

            MessageBox.Show("In hóa đơn thất bại");
        }
    }
}
