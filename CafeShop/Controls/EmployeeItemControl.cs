using CafeShop.Entity;
using CafeShop.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeShop.Controls
{
    public partial class EmployeeItemControl : UserControl
    {
        public EmployeeItemControl()
        {
            InitializeComponent();
        }

        NhanVien _nhanVien;

        [Description("Nhân viên"), Category("Nhân viên")]
        public NhanVien NhanVien
        {
            get => _nhanVien;
            set
            {
                
                _nhanVien = value;
                if (_nhanVien == null)
                    return;

                lblMaNV.Text = _nhanVien.MaNV;
                lblHoTen.Text = _nhanVien.HoTen;
                lblDiaChi.Text = _nhanVien.DiaChi;
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Người dùng click vào nút edit")]
        public delegate void EditClickHandler(object sender, EditNhanVienEventArgs e);
        public event EditClickHandler EditClick;

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.EditClick == null)
                return;

            this.EditClick(this, new EditNhanVienEventArgs()
            {
                NhanVien = _nhanVien
            });
        }
    }
}
