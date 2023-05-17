using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.Entity
{
    public class HoaDon : BaseEntity
    {
        private string _maHD;
        private string _maKH;
        private string _maNV;
        private DateTime _ngayLap;
        private decimal _tongTien;
        private string _ghiChu;

        [Key]
        public string MaHD { get => _maHD; set { _maHD = value; InvokePropertyChanged(new PropertyChangedEventArgs("MaHD")); } }
        public string MaKH { get => _maKH; set { _maKH = value; InvokePropertyChanged(new PropertyChangedEventArgs("MaKH")); } }
        public string MaNV { get => _maNV; set { _maNV = value; InvokePropertyChanged(new PropertyChangedEventArgs("MaNV")); } }
        public DateTime NgayLap { get => _ngayLap; set { _ngayLap = value; InvokePropertyChanged(new PropertyChangedEventArgs("NgayLap")); } }
        public decimal TongTien { get => _tongTien; set { _tongTien = value; InvokePropertyChanged(new PropertyChangedEventArgs("TongTien")); } }
        public string GhiChu { get => _ghiChu; set { _ghiChu = value; InvokePropertyChanged(new PropertyChangedEventArgs("GhiChu")); } }

        [ForeignKey("MaKH")]
        public KhachHang KhachHang { get; set; }

        [ForeignKey("MaNV")]
        public NhanVien NhanVien { get; set; }

        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; private set; } = new List<ChiTietHoaDon>();

    }
}
