using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontendMaga.RegistrationModule
{
    public partial class Registration : Form
    {
        //Hardcoded passwords
        private string _userPass = "123";
        private string _adminPass = "admin";

        public event Action<bool> OnSuccess;
        public Registration()
        {
            InitializeComponent();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(((Panel)sender).ClientRectangle,
                                                            Color.FromArgb(255, 46, 49, 45),
                                                            Color.FromArgb(255, 46, 255, 255),
                                                            0F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        //Need Db connection
        private void button1_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text == _userPass)
            {
                OnSuccess(false);
                return;
            }

            if (tbPassword.Text == _adminPass)
            {
                OnSuccess(true);
                return;
            }

            lbError.Text = "Wrong email or password!";
        }

        private void Registration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(null, null);
        }

        private void Registration_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
