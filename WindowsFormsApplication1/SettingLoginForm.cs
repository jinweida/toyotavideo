using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoApplication
{
    public partial class SettingLoginForm : Form
    {
        public SettingLoginForm()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text.Equals("abc!@#"))
            {
                this.Visible = false;
                SettingForm sf = new SettingForm();
                sf.ShowDialog();
            }
            else
            {
                MessageBox.Show("密码错误", "操作提示");
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnGo_Click(sender, e);
            }
        }
    }
}
