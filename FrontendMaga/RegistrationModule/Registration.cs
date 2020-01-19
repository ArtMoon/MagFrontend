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
        public event Action OnSuccess;
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

     
        private void button1_Click(object sender, EventArgs e)
        {
            OnSuccess();
        }
    }
}
