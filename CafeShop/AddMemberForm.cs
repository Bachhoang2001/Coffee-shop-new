using CafeShop.BUS;
using CafeShop.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeShop
{
    public partial class AddMemberForm : Form
    {
        public AddMemberForm()
        {
            InitializeComponent();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        KhachHangBUS _khachHangBUS = new KhachHangBUS();

        KhachHang _obj = new KhachHang();

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Mã khách hàng không được để trống");
                return;
            }

            if (_khachHangBUS.GetByMaKH(txtMaKH.Text) != null)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống");
                return;
            }
            
            if (_khachHangBUS.Add(_obj))
            {
                MessageBox.Show("Thêm thành công");
                _obj.MaKH = _khachHangBUS.TaoMoiMa("KH");
                _obj.HoTen = "";
                _obj.SDT = "";
                _obj.DiaChi = "";
                _obj.GioiTinh = true;

                return;
            }

            MessageBox.Show("Thêm thất bại");

        }

        private void AddMemberForm_Load(object sender, EventArgs e)
        {
            _obj.MaKH = _khachHangBUS.TaoMoiMa("KH");
            txtMaKH.DataBindings.Add("Text", _obj, "MaKH", false, DataSourceUpdateMode.OnPropertyChanged);
            txtHoTen.DataBindings.Add("Text", _obj, "HoTen", false, DataSourceUpdateMode.OnPropertyChanged);
            txtSoDT.DataBindings.Add("Text", _obj, "SDT", false, DataSourceUpdateMode.OnPropertyChanged);
            txtDiaChi.DataBindings.Add("Text", _obj, "DiaChi", false, DataSourceUpdateMode.OnPropertyChanged);
            rdoNam.DataBindings.Add("Checked", _obj, "GioiTinh", false, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
