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
    public class NhanVien : BaseEntity
    {
        private string _maNV;
        private string _hoTen;
        private string _diaChi;
        private string _sDT;
        private bool _gioiTinh;
        private string _matKhau;
        private string _maQuyen;

        [Key]
        public string MaNV { get => _maNV; set { _maNV = value; InvokePropertyChanged(new PropertyChangedEventArgs("MaNV")); } }
        public string HoTen { get => _hoTen; set { _hoTen = value; InvokePropertyChanged(new PropertyChangedEventArgs("HoTen")); } }
        public string DiaChi { get => _diaChi; set { _diaChi = value; InvokePropertyChanged(new PropertyChangedEventArgs("DiaChi")); } }
        public string SDT { get => _sDT; set { _sDT = value; InvokePropertyChanged(new PropertyChangedEventArgs("SDT")); } }
        public bool GioiTinh { get => _gioiTinh; set { _gioiTinh = value; InvokePropertyChanged(new PropertyChangedEventArgs("GioiTinh")); } }
        public string MatKhau { get => _matKhau; set { _matKhau = value; InvokePropertyChanged(new PropertyChangedEventArgs("MatKhau")); } }
        public string MaQuyen { get => _maQuyen; set { _maQuyen = value; InvokePropertyChanged(new PropertyChangedEventArgs("MatKhau")); } }
        
        [ForeignKey(nameof(MaQuyen))]
        public virtual Quyen Quyen { get;set;}
    }
}
