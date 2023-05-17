using CafeShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.Controls
{
    public class EditNhanVienEventArgs : EventArgs
    {
        public NhanVien NhanVien { get; set; }
    }
}
