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
    public class MonAn : BaseEntity
    {
        private string _maMon;
        private string _tenMon;
        private string _maLoai;
        private decimal _donGia;
        private string _hinhAnh;

        [Key]
        public string MaMon
        {
            get => _maMon; set
            {
                _maMon = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("MaMon"));
            }
        }
        public string TenMon
        {
            get => _tenMon; set
            {
                _tenMon = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("TenMon"));
            }
        }
        public string MaLoai
        {
            get => _maLoai; set
            {
                _maLoai = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("MaLoai"));
            }
        }
        public decimal DonGia
        {
            get => _donGia; set
            {
                _donGia = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("DonGia"));
            }
        }
        public string HinhAnh
        {
            get => _hinhAnh; set
            {
                _hinhAnh = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("HinhAnh"));
            }
        }

        [ForeignKey("MaLoai")]
        public LoaiMon LoaiMon { get; set; }
    }
}
