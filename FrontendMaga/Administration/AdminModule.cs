using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrontendMaga.Interfaces;
using FrontendMaga.Data.DataModels;
using FrontendMaga.Data.Converters;
using Unity;

namespace FrontendMaga.Administration
{
    public partial class AdminModule : Form
    {
        private List<ApparatusModel> _tmpApparatus = new List<ApparatusModel>();
        public AdminModule()
        {

            InitializeComponent();

        }

        private async void AdminModule_Load(object sender, EventArgs e)
        {
            var _loader = Program.Container.Resolve<HttpDataLoader>();
            await _loader.LoadData<ApparatusModel>(
                (x) =>
                {
                    _tmpApparatus.Clear();
                    _tmpApparatus.AddRange(x);
                    var converter = new TreeNodesConverter();
                    var nodes = converter.ConvertTo(x);

                    treeObjects.Nodes.AddRange(nodes.ToArray());

                }, HttpApiRes.Apparatuses,
                HttpApiRes.Host,
                HttpApiRes.Port
                );
        }

        private async void treeMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var msg = _tmpApparatus.Where((x) => x.App_name == e.Node.Text).ToList()[0].Id_Ap;
            var _loader = Program.Container.Resolve<HttpDataLoader>();
            await _loader.LoadData<SensorInfo>((x) =>
            {
                dgSensors.DataSource = null;
                if (x == null)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                dgSensors.DataSource = x;
                dgSensors.Columns["Id"].Visible = false;
                dgSensors.Columns["ParentId"].Visible = false;
            },
            HttpApiRes.SensorLoad,
            HttpApiRes.Host, HttpApiRes.Port, msg.ToString());
        }





    }
}
