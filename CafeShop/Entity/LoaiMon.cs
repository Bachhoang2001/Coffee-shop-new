using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.Entity
{
    public class LoaiMon : BaseEntity
    {
        private string _maLoai;
        private string _tenLoai;

        [Key]
        public string MaLoai { get => _maLoai; set { _maLoai = value; InvokePropertyChanged(new PropertyChangedEventArgs("MaLoai")); } }
        public string TenLoai { get => _tenLoai; set { _tenLoai = value; InvokePropertyChanged(new PropertyChangedEventArgs("TenLoai")); } }
    }
}
