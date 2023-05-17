using CafeShop.BUS;
using CafeShop.Entity;
using CafeShop.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace CafeShop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        NhanVienBUS _nhanVienBUS = new NhanVienBUS();

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Global.LOGIN_USER = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text)) 
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            NhanVien nv = _nhanVienBUS.GetUserInfoByLogin(txtMaNV.Text, txtMatKhau.Text);

            if (nv != null)
            {
                Global.LOGIN_USER = nv;
                Global.LOGIN_ROLE = nv.MaQuyen;
                this.Close();
                this.DialogResult = DialogResult.OK;
                return;
            }

             MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
        }
    }
}
