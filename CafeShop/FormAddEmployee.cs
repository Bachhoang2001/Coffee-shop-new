using CafeShop.BUS;
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

namespace CafeShop
{
    public partial class FormAddEmployee : Form
    {
        public FormAddEmployee()
        {
            InitializeComponent();
        }

        NhanVienBUS _nhanVienBUS = new NhanVienBUS();
        QuyenBUS _quyenBUS = new QuyenBUS();
        NhanVien _nv;
        private void FormAddEmployee_Load(object sender, EventArgs e)
        {
            _nv = new NhanVien();
            _nv.MaNV = _nhanVienBUS.TaoMoiMa("NV");
            LoadComboQuyen();
            txtMaNV.DataBindings.Add("Text", _nv, "MaNV");
            txtHoTen.DataBindings.Add("Text", _nv, "HoTen");
            txtDiaChi.DataBindings.Add("Text", _nv, "DiaChi");
            txtSoDT.DataBindings.Add("Text", _nv, "SDT");
            txtMatKhau.DataBindings.Add("Text", _nv, "MatKhau");
            rdoNam.DataBindings.Add("Checked", _nv, "GioiTinh");
            cboQuyen.DataBindings.Add("SelectedValue", _nv, "MaQuyen");
        }

        private void LoadComboQuyen()
        {
            var dsQuyen = _quyenBUS.GetAll();
            cboQuyen.DataSource = dsQuyen;
            cboQuyen.DisplayMember = "TenQuyen";
            cboQuyen.ValueMember = "MaQuyen";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập vào mã nhân viên !");
                return;
            }

            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập vào họ tên nhân viên !");
                return;
            }

            if (_nhanVienBUS.GetByMaNV(txtMaNV.Text) != null)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại !");
                return;
            }

            if (_nhanVienBUS.Add(_nv))
            {
                MessageBox.Show("Thêm nhân viên thành công !");
                _nv.MaNV = _nhanVienBUS.TaoMoiMa("NV");
                _nv.HoTen = "";
                _nv.SDT = "";
                _nv.DiaChi = "";
                _nv.GioiTinh = true;
                return;
            }
            
            MessageBox.Show("Thêm nhân viên thất bại !");
            
        }
    }
}
