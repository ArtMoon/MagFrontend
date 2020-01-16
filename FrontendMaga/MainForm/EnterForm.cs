using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using FrontendMaga.RegistrationModule;


namespace FrontendMaga
{
    public partial class EnterForm : Form
    {
        private Form _activeForm;
        public EnterForm()
        {
            InitializeComponent();
        }

        private void EnterForm_Load(object sender, EventArgs e)
        {
            _activeForm = Program.Container.Resolve<Registration>();
            _activeForm.MdiParent = this;
            ((Registration)_activeForm).OnSuccess += RegistrationCallBack;
            _activeForm.Show();
        }



    

        private void RegistrationCallBack()
        {
            if (_activeForm != null) _activeForm.Dispose();

            _activeForm = Program.Container.Resolve<MainForm>();
            _activeForm.MdiParent = this;
            _activeForm.Show();
        }
    }
}
