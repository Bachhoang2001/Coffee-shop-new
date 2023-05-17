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
    public partial class MonAnControl : UserControl
    {
        public MonAnControl()
        {
            InitializeComponent();
        }

        private void MonAnControl_Load(object sender, EventArgs e)
        {

        }

        private MonAn _monAn;

        [Description("Món ăn"), Category("Món ăn")]
        public MonAn MonAn
        {
            get => _monAn;
            set
            {
                _monAn = value;
                
                if (_monAn == null)
                    return;

                var pic = Commons.GetImagesPath() + _monAn.HinhAnh;
                if (File.Exists(pic))
                    picHinhAnh.ImageLocation = pic;
                lblTenMon.Text = value.TenMon;
                lblDonGia.Text = value.DonGia.ToString("0.##");
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Người dùng click vào thêm món")]
        public delegate void ThemMonClickHandler(object sender, ChonMonEventArgs e);
        public event ThemMonClickHandler ThemMonClick;

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (this.ThemMonClick == null)
                return;

            this.ThemMonClick(this, new ChonMonEventArgs()
            {
                MonAn = _monAn
            });
        }
    }
}
