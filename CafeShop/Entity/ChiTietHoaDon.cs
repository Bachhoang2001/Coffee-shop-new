using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace CafeShop.Entity
{
    public class ChiTietHoaDon : BaseEntity
    {
        private string _maHD;
        private string _maMon;
        private int _soLuong;
        private decimal _donGia;
        private decimal _thanhTien;

        [Key]
        [Column(Order = 1)]
        public string MaHD { get => _maHD; set { _maHD = value; InvokePropertyChanged(new PropertyChangedEventArgs("MaHD")); } }
        [Key]
        [Column(Order = 2)]
        public string MaMon { get => _maMon; set { _maMon = value; InvokePropertyChanged(new PropertyChangedEventArgs("MaMon")); } }
        public int SoLuong { get => _soLuong; set { _soLuong = value; InvokePropertyChanged(new PropertyChangedEventArgs("SoLuong")); } }
        public decimal DonGia { get => _donGia; set { _donGia = value; InvokePropertyChanged(new PropertyChangedEventArgs("DonGia")); } }
        public decimal ThanhTien { get => _thanhTien; set { _thanhTien = value; InvokePropertyChanged(new PropertyChangedEventArgs("ThanhTien")); } }
        [NotMapped]
        public string TenMon { get; set; }
        [NotMapped]
        public string HinhAnh { get; set; }
        [ForeignKey("MaHD")]
        public HoaDon HoaDon { get; set; }

        [ForeignKey("MaMon")]
        public MonAn MonAn { get; set; }
    }
}
