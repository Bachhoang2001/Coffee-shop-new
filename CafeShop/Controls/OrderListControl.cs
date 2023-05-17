using CafeShop.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeShop.Controls
{
    public partial class OrderListControl : UserControl
    {
        public OrderListControl()
        {
            InitializeComponent();
        }

        HoaDon _hoaDon;

        [Description("Hoá đơn"), Category("Hoá đơn")]
        public HoaDon HoaDon
        {
            get => _hoaDon;
            set
            {
                _hoaDon = value;
                if (_hoaDon == null)
                    return;
                lblMaHD.Text = _hoaDon.MaHD;
                lblTenKH.Text = "";
                if (_hoaDon.KhachHang != null)
                    lblTenKH.Text = _hoaDon.KhachHang.HoTen;
                lblTongTien.Text = _hoaDon.TongTien.ToString("0.##");
                lblNgayLap.Text = _hoaDon.NgayLap.ToString("dd/MM/yyyy");
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Người dùng click vào nút xem chi tiết")]
        public delegate void XemChiTietClickHandler(object sender, XemChiTietHoaDonEventArgs e);
        public event XemChiTietClickHandler XemChiTietClick;

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (this.XemChiTietClick == null)
                return;

            this.XemChiTietClick(this, new XemChiTietHoaDonEventArgs()
            {
                MaHD = _hoaDon.MaHD
            });
        }
    }
}
