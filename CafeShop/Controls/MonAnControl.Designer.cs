namespace CafeShop.Controls
{
    partial class MonAnControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonAnControl));
            this.lblDonGia = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTenMon = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.btnThemMon = new Guna.UI2.WinForms.Guna2ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDonGia
            // 
            this.lblDonGia.BackColor = System.Drawing.Color.Transparent;
            this.lblDonGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblDonGia.Location = new System.Drawing.Point(27, 146);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(45, 15);
            this.lblDonGia.TabIndex = 2;
            this.lblDonGia.Text = "10 000 đ";
            // 
            // lblTenMon
            // 
            this.lblTenMon.BackColor = System.Drawing.Color.Transparent;
            this.lblTenMon.Location = new System.Drawing.Point(27, 125);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(47, 15);
            this.lblTenMon.TabIndex = 3;
            this.lblTenMon.Text = "Cafe sữa";
            // 
            // picHinhAnh
            // 
            this.picHinhAnh.Image = ((System.Drawing.Image)(resources.GetObject("picHinhAnh.Image")));
            this.picHinhAnh.Location = new System.Drawing.Point(15, 11);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Size = new System.Drawing.Size(124, 87);
            this.picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHinhAnh.TabIndex = 4;
            this.picHinhAnh.TabStop = false;
            // 
            // btnThemMon
            // 
            this.btnThemMon.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnThemMon.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnThemMon.Image = ((System.Drawing.Image)(resources.GetObject("btnThemMon.Image")));
            this.btnThemMon.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnThemMon.ImageRotate = 0F;
            this.btnThemMon.ImageSize = new System.Drawing.Size(32, 32);
            this.btnThemMon.Location = new System.Drawing.Point(100, 117);
            this.btnThemMon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnThemMon.Size = new System.Drawing.Size(48, 44);
            this.btnThemMon.TabIndex = 6;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // MonAnControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnThemMon);
            this.Controls.Add(this.lblDonGia);
            this.Controls.Add(this.lblTenMon);
            this.Controls.Add(this.picHinhAnh);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MonAnControl";
            this.Size = new System.Drawing.Size(162, 170);
            this.Load += new System.EventHandler(this.MonAnControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDonGia;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenMon;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private Guna.UI2.WinForms.Guna2ImageButton btnThemMon;
    }
}
