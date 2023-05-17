using CafeShop.BUS;
using CafeShop.Data;
using CafeShop.ViewModel;
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
    public partial class FormReportDailyRevenue : Form
    {
        public FormReportDailyRevenue()
        {
            InitializeComponent();
        }

        ThongKeBUS _thongKeBUS = new ThongKeBUS();

        private void FormReportDailyRevenue_Load(object sender, EventArgs e)
        {
            dgvDoanhThu.DataSource = _src;
            dateTimePicker1.Value = DateTime.Now;
            LoadDoanhThu();
        }

        BindingSource _src = new BindingSource();

        private void LoadDoanhThu()
        {
           _src.DataSource = _thongKeBUS.GetDoanhThu(dateTimePicker1.Value);
           _src.ResetBindings(true);
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In báo cáo");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadDoanhThu();
        }
    }
}
