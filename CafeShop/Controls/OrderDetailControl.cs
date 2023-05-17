using CafeShop.Entity;
using CafeShop.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeShop.Controls
{
    public partial class OrderDetailControl : UserControl
    {
        public OrderDetailControl()
        {
            InitializeComponent();
        }

        private ChiTietHoaDon _chiTietHoaDon;

        [Description("Chi tiết hoá đơn"), Category("Hoá đơn")]
        public ChiTietHoaDon ChiTiet
        {
            get => _chiTietHoaDon;
            set
            {
                _chiTietHoaDon = value;
                if (_chiTietHoaDon == null) return;
                var pic = Commons.GetImagesPath() + _chiTietHoaDon.HinhAnh;
                if (File.Exists(pic))
                    picHinhAnh.ImageLocation = pic;
                lblTenMon.Text = value.TenMon;
                lblSoLuong.Text = value.SoLuong.ToString();
                lblDonGia.Text = value.DonGia.ToString("0.##");
                lblThanhTien.Text = value.ThanhTien.ToString("0.##");
            }
        }
    }
}
