﻿using System;
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
using FrontendMaga.Administration;

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
            menuStrip1.Visible = false;
            _activeForm = Program.Container.Resolve<Registration>();
            _activeForm.MdiParent = this;
            ((Registration)_activeForm).OnSuccess += RegistrationCallBack;
            _activeForm.Show();
        }





        private void RegistrationCallBack(bool isAdmin)
        {

            OpenMonitoringForm();

            if (!isAdmin)
                menuStrip1.Items[1].Visible = false;
        }

        private void openSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_activeForm != null) _activeForm.Dispose();

            _activeForm = new AdminModule();
            _activeForm.MdiParent = this;
            _activeForm.Show();

        }

        private void OpenMonitoringForm()
        {
            if (_activeForm != null) _activeForm.Dispose();
            menuStrip1.Visible = true;
            _activeForm = Program.Container.Resolve<MainForm>();
            _activeForm.MdiParent = this;
            _activeForm.Show();

        }

        private void monitoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMonitoringForm();
        }
    }
}
