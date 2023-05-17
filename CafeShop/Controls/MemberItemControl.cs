using CafeShop.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeShop.Controls
{
    public partial class MemberItemControl : UserControl
    {
        public MemberItemControl()
        {
            InitializeComponent();
        }

        KhachHang _khachHang;

        [Description("Khách hàng"), Category("Khách hàng")]
        public KhachHang KhachHang
        {
            get => _khachHang;
            set
            {
                _khachHang = value;
                if (_khachHang == null)
                    return;
                lblHoTen.Text = _khachHang.HoTen;
                lblDiaChi.Text = _khachHang.DiaChi;
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Người dùng click vào nút edit")]
        public delegate void EditClickHandler(object sender, EditKhachHangEventArgs e);
        public event EditClickHandler EditClick;

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.EditClick == null)
                return;

            this.EditClick(this, new EditKhachHangEventArgs()
            {
                KhachHang = _khachHang
            });
        }
    }
}
