using CafeShop.BUS;
using CafeShop.Controls;
using CafeShop.Entity;
using Guna.UI2.WinForms;
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
    public partial class UserForm : Form
    {
        private MonAnBUS _monAnBUS;
        private LoaiMonBUS _loaiMonBUS;

        public UserForm()
        {
           InitializeComponent();
        }

        HoaDon _hoaDon = new HoaDon();
        HoaDonBUS _hoaDonBUS = new HoaDonBUS();

        private void UserForm_Load(object sender, EventArgs e)
        {
            _hoaDon.MaHD = _hoaDonBUS.TaoMoiMa("HD");
            _monAnBUS = new MonAnBUS();
            _loaiMonBUS = new LoaiMonBUS();
            var dsMonAn = _monAnBUS.GetAll();
            HienThiDanhSachMonAn(dsMonAn);
            HienThiDanhSachLoaiMon();
        }

        private void HienThiDanhSachLoaiMon()
        {
            var dsLoaiMon = _loaiMonBUS.GetAll();

            if (dsLoaiMon != null)
            {
                layoutMenuLoaiMon.Controls.Clear();

                foreach (var loaiMon in dsLoaiMon)
                {
                    var btnLoaiMon = new Guna2Button();
                    btnLoaiMon.Text = loaiMon.TenLoai;
                    btnLoaiMon.Tag = loaiMon.MaLoai;
                    btnLoaiMon.Width = layoutMenuLoaiMon.Width - 5;
                    btnLoaiMon.Click += BtnLoaiMon_Click; ;
                    layoutMenuLoaiMon.Controls.Add(btnLoaiMon);
                }
            }
        }

        private void BtnLoaiMon_Click(object sender, EventArgs e)
        {
            var obj = sender as Guna2Button;
            
            if (obj == null)
                return;

            var dsMonAn = _monAnBUS.GetAll()
                .Where(x => x.MaLoai == (string) obj.Tag)
                .ToList();

            HienThiDanhSachMonAn(dsMonAn);
        }

        private void HienThiDanhSachMonAn(List<MonAn> dsMonAn)
        {
          
            if (dsMonAn != null)
            {
                layoutMainMenu.Controls.Clear();

                foreach(var monAn in dsMonAn)
                {
                    var btnChonMon = new MonAnControl();
                    btnChonMon.Width = 221;
                    btnChonMon.Height = 221;
                    btnChonMon.MonAn = monAn;
                    btnChonMon.ThemMonClick += BtnChonMon_ThemMonClick;
                    layoutMainMenu.Controls.Add(btnChonMon);
                }
            }
        }

        private void BtnChonMon_ThemMonClick(object sender, ChonMonEventArgs e)
        {
            var item = _hoaDon.ChiTietHoaDons
                .Where(x => x.MaHD == _hoaDon.MaHD && x.MaMon == e.MonAn.MaMon)
                .FirstOrDefault();

            if (item != null)
            {
                item.SoLuong += 1;
                item.ThanhTien = e.MonAn.DonGia * item.SoLuong;
            }
            else
            {
                _hoaDon.ChiTietHoaDons.Add(new ChiTietHoaDon()
                {
                    MaHD = _hoaDon.MaHD,
                    MaMon = e.MonAn.MaMon,
                    TenMon = e.MonAn.TenMon,
                    HinhAnh = e.MonAn.HinhAnh,
                    DonGia = e.MonAn.DonGia,
                    SoLuong = 1,
                    ThanhTien = e.MonAn.DonGia
                });
            }
            
            _hoaDon.TongTien = _hoaDon.ChiTietHoaDons.Sum(x => x.ThanhTien);

            HienThiGioHang();
        }

        private void HienThiGioHang()
        {
            lblShopingCartCount.Text = _hoaDon.ChiTietHoaDons.Sum(x => x.SoLuong).ToString();
        }

        private void btnTatCaMon_Click(object sender, EventArgs e)
        {
            var dsMonAn = _monAnBUS.GetAll();
            HienThiDanhSachMonAn(dsMonAn);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            new CreateOrderForm(_hoaDon).ShowDialog();
        }
    }
}
