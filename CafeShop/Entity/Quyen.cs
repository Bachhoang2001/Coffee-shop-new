using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.Entity
{
    public class Quyen : BaseEntity
    {
        private string _maQuyen;
        private string _tenQuyen;
        [Key]
        public string MaQuyen { get => _maQuyen; set { _maQuyen = value; InvokePropertyChanged(new PropertyChangedEventArgs("MaQuyen")); } }
        public string TenQuyen { get => _tenQuyen; set { _tenQuyen = value; InvokePropertyChanged(new PropertyChangedEventArgs("TenQuyen")); } }
    }
}
