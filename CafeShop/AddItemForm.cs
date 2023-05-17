using CafeShop.BUS;
using CafeShop.Data;
using CafeShop.Entity;
using CafeShop.Utils;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeShop
{
    public partial class AddItemForm : Form
    {
        public AddItemForm()
        {
            InitializeComponent();
        }

        MonAnBUS _bus;
        LoaiMonBUS _loaiMonBus;

        MonAn _monAn;
        private void AddItemForm_Load(object sender, EventArgs e)
        {
            _bus = new MonAnBUS();

            _loaiMonBus = new LoaiMonBUS();
            LoadComboBoxLoaiMon();

            _monAn = new MonAn();
            _monAn.MaMon = _bus.TaoMoiMa("M");
            txtMaMon.DataBindings.Add("Text", _monAn, "MaMon", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTenMon.DataBindings.Add("Text", _monAn, "TenMon", false, DataSourceUpdateMode.OnPropertyChanged);
            cboLoaiMon.DataBindings.Add("SelectedValue", _monAn, "MaLoai", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void LoadComboBoxLoaiMon()
        {
            cboLoaiMon.DataSource = _loaiMonBus.GetAll();
            cboLoaiMon.DisplayMember = "TenLoai";
            cboLoaiMon.ValueMember = "MaLoai";
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaMon.Text))
            {
                MessageBox.Show("Vui lòng nhập vào mã món ăn !");
                return;
            }

            if (string.IsNullOrEmpty(txtTenMon.Text))
            {
                MessageBox.Show("Tên món ăn không được để trống !");
                return;
            }


            if (_bus.trungMon(txtMaMon.Text))
            {
                MessageBox.Show("Mã món ăn đã tồn tại !");
                return;
            }

            if (!decimal.TryParse(txtGiaTien.Text, out decimal giaTien))
            {
                MessageBox.Show("Giá tiền không hợp lệ !");
                return;
            }

            _monAn.DonGia = giaTien;

            if (_bus.Them(_monAn))
            {
                MessageBox.Show("Thêm món ăn thành công !");
                _monAn.MaMon = _bus.TaoMoiMa("M");
                _monAn.TenMon = "";
                _monAn.MaLoai = "";
                _monAn.DonGia = 0;
                return;
            }

            MessageBox.Show("Thêm món ăn thất bại !");

        }

        private void btnHinhAnh_Click(object sender, EventArgs e)
        {

            //Create a new instance of openFileDialog
            OpenFileDialog res = new OpenFileDialog();

            //Filter
            res.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";

            //When the user select the file
            if (res.ShowDialog() != DialogResult.OK)
                return;


            //Get the file's path
            var filePath = res.FileName;
            string fileName = Path.GetFileName(filePath);

            if (!File.Exists(filePath))
                return;

            string imgsPath = Commons.GetImagesPath();
            if (!Directory.Exists(imgsPath))
            {
                Directory.CreateDirectory(imgsPath);
            }

            var savedImagePath = Path.Combine(Commons.GetImagesPath()
                , fileName);

            File.Copy(filePath, savedImagePath);

            _monAn.HinhAnh = fileName;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
