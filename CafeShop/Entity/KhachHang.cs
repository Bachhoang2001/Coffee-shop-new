using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.Entity
{
    public class KhachHang : BaseEntity
    {
        private string _maKH;
        private string _hoTen;
        private string _diaChi;
        private string _sDT;
        private bool _gioiTinh;

        [Key]
        public string MaKH { get => _maKH; set { _maKH = value; InvokePropertyChanged(new PropertyChangedEventArgs("MaKH")); } }
        public string HoTen { get => _hoTen; set  { _hoTen = value; InvokePropertyChanged(new PropertyChangedEventArgs("MaKH")); } }
        public string DiaChi { get => _diaChi; set { _diaChi = value; InvokePropertyChanged(new PropertyChangedEventArgs("DiaChi")); } }
        public string SDT { get => _sDT; set { _sDT = value; InvokePropertyChanged(new PropertyChangedEventArgs("SDT")); } }
        public bool GioiTinh { get => _gioiTinh; set { _gioiTinh = value; InvokePropertyChanged(new PropertyChangedEventArgs("GioiTinh")); } }
    }
}
