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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            if (new LoginForm().ShowDialog() == DialogResult.OK)
            {
                InitializeComponent();
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            new UserForm().ShowDialog();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            new OrderListForm().ShowDialog();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            new MemberForm().ShowDialog();
        }

     
        private void btnAddMembers_Click(object sender, EventArgs e)
        {
            new AddMemberForm().ShowDialog();
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            new AddItemForm().ShowDialog();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            new FormAddEmployee().ShowDialog();
        }

        private void btnEmployeeList_Click(object sender, EventArgs e)
        {
            new EmployeeListForm().ShowDialog();
        }

        private void btnDailyReport_Click(object sender, EventArgs e)
        {
            new FormReportDailyRevenue().ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Global.LOGIN_USER = null;
            Global.LOGIN_ROLE = null;
            KiemTraQuyen();

            var result = new LoginForm().ShowDialog();

            if (result == DialogResult.OK)
            {
                KiemTraQuyen();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            KiemTraQuyen();
        }

        private void KiemTraQuyen()
        {
            if (Global.LOGIN_USER == null || Global.LOGIN_ROLE == null)
            {
                btnOrder.Enabled = false;
                btnItems.Enabled = false;
                btnMembers.Enabled = false;
                btnAddMembers.Enabled = false;
                btnAddItems.Enabled = false;
                btnAddEmployee.Enabled = false;
                btnEmployeeList.Enabled = false;
                btnDailyReport.Enabled = false;
                btnLogin.Enabled = true;
                return;
            }

            if (Global.LOGIN_ROLE == "USER")
            {
                btnOrder.Enabled = true;
                btnItems.Enabled = true;
                btnMembers.Enabled = true;
                btnAddMembers.Enabled = true;
                btnAddItems.Enabled = false;
                btnAddEmployee.Enabled = false;
                btnEmployeeList.Enabled = false;
                btnDailyReport.Enabled = false;
            }

            if (Global.LOGIN_ROLE == "ADMIN")
            {
                btnOrder.Enabled = true;
                btnItems.Enabled = true;
                btnMembers.Enabled = true;
                btnAddMembers.Enabled = true;
                btnAddItems.Enabled = true;
                btnAddEmployee.Enabled = true;
                btnEmployeeList.Enabled = true;
                btnDailyReport.Enabled = true;
            }
        }
    }
}
