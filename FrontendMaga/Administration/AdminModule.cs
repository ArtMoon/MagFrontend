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
using FrontendMaga.Http.Sender;
using FrontendMaga.Data.DataModels.Knowledge;

namespace FrontendMaga.Administration
{
    public partial class AdminModule : Form
    {
        private List<ApparatusModel> _tmpApparatus = new List<ApparatusModel>();
        private HttpDataLoader _loader;
        private DataGridView _tmpActiveDataGrid;
        public AdminModule()
        {
            _loader = Program.Container.Resolve<HttpDataLoader>();         
            InitializeComponent();

        }

        private async void AdminModule_Load(object sender, EventArgs e)
        {            
            await _loader.LoadData<ApparatusModel>(
                (x) =>
                {
                    if (x == null) return;
                    _tmpApparatus.Clear();
                    _tmpApparatus.AddRange(x);
                    var converter = new TreeNodesConverter();
                    var nodes = converter.GetNodes(x);

                    treeObjects.Nodes.AddRange(nodes.ToArray());

                }, HttpApiRes.Apparatuses,
                HttpApiRes.Host,
                HttpApiRes.Port
                );
            btnSave.Enabled = false;
            _tmpActiveDataGrid = dgSensorRules;
        }
        //Get Request
        private void LoadSensorRules(string sensorId)
        {
            dgSensorRules.Rows.Clear();
            MessageBox.Show(sensorId);

                     
        }

 
        private void button1_Click(object sender, EventArgs e)
        {
            dgSensorRules.Rows.Add();
        }

 

        private void btnAddProblem_Click(object sender, EventArgs e)
        {
            
            _tmpActiveDataGrid.Rows.Add();
            btnSave.Enabled = true;
            btnAddProblem.Enabled = false;
        }

        private async void btnSave_Click_1(object sender, EventArgs e)
        {
            await SaveData(_tmpActiveDataGrid.Rows.Count - 1);
        }

        private void DataClear()
        {
            dgSensorRules.Rows.Clear();
            dgReason.Rows.Clear();
            dgSolution.Rows.Clear();
        }

        private async Task SaveData(int rowIndex)
        {
            var list = new List<KeyValuePair<string, string>>();
            var row = _tmpActiveDataGrid.Rows[rowIndex];
            var res = string.Empty;
            var poster = new HttpDataPostSender();
            switch (_tmpActiveDataGrid.Name)
            {
                case "dgSensorRules":
                    list.Add(new KeyValuePair<string, string>("pr_cond", row.Cells["colRule"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("pr_value", row.Cells["colValue"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("sens_id", row.Cells["colSensId"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("pr_text", row.Cells["colText"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("pr_color", "r"));
                    list.Add(new KeyValuePair<string, string>("pr_nn", row.Cells["colNumber"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("ap_id", ((ApparatusModel)treeObjects.SelectedNode.Tag).ap_id.ToString()));
                    res = await poster.SendHttpPost(HttpApiRes.RulesPost, list,HttpApiRes.Host,HttpApiRes.Port);
                    break;
                case "dgReason":
                    list.Add(new KeyValuePair<string, string>("pr_id", dgSensorRules.SelectedRows[0].Cells["colPrID"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("rs_text", row.Cells["colReason"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("rs_cond", row.Cells["colReasRule"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("rs_value", row.Cells["colReasValue"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("sens_id", row.Cells["colSensor"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("nn_rs", row.Cells["colReasNumber"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("rs_probability", row.Cells["colProb"].Value.ToString()));
                    res = await poster.SendHttpPost(HttpApiRes.ReasonPost, list, HttpApiRes.Host, HttpApiRes.Port);
                    break;
                case "dgSolution":
                    list.Add(new KeyValuePair<string, string>("rs_id", dgReason.SelectedRows[0].Cells["colReasID"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("sol_text", row.Cells["colSolution"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("sol_par", row.Cells["colParam"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("sens_id", row.Cells["colSolSensID"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("sol_nn", row.Cells["colSolNumber"].Value.ToString()));
                    res = await poster.SendHttpPost(HttpApiRes.SolutionPost, list, HttpApiRes.Host, HttpApiRes.Port);
                    break;
            }
                   
            if (res == "200")
            {
                MessageBox.Show("Успешно");
            }
            else
            {
                MessageBox.Show($"Государь! Сервер пал... {res}");
            }
            btnSave.Enabled = false;
            btnAddProblem.Enabled = true;
        }
        private void dgSensorRules_Enter(object sender, EventArgs e)
        {
            if (_tmpActiveDataGrid != null && _tmpActiveDataGrid.Name == ((DataGridView)sender).Name) return;
            if (btnSave.Enabled)
            {
                btnSave.Enabled = false;
                btnAddProblem.Enabled = true;
                _tmpActiveDataGrid.Rows.RemoveAt(_tmpActiveDataGrid.Rows.Count - 1);
            }
            _tmpActiveDataGrid = (DataGridView)sender;
        }

        private async void treeObjects_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            DataClear();
            dgSensorRules.RowEnter -= dgSensorRules_RowEnter;
            await _loader.LoadData<Problem>(
                (x) =>
                {
                    if (x == null) return;
                    foreach (var model in x)
                    {
                        var i = dgSensorRules.Rows.Add();
                        var row = dgSensorRules.Rows[i];
                        row.Cells["colPrID"].Value = model.pr_id;
                        row.Cells["colRule"].Value = model.pr_cond;
                        row.Cells["colValue"].Value = model.pr_value;
                        row.Cells["colSensId"].Value = model.sens_id;
                        row.Cells["colText"].Value = model.pr_text;
                        row.Cells["colNumber"].Value = model.pr_nn;
                        row.ReadOnly = true;
                    }

                    dgSensorRules.RowEnter += dgSensorRules_RowEnter;

                }, HttpApiRes.RulesLoad,
                    HttpApiRes.Host,
                    HttpApiRes.Port,
                    ((ApparatusModel)e.Node.Tag).ap_id.ToString()
                );
        }

  

        private async void dgSensorRules_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (btnSave.Enabled) return;
            dgReason.RowEnter -= dgReason_RowEnter;
            dgReason.Rows.Clear();
            dgSolution.Rows.Clear();
            await _loader.LoadData<Reason>(
                (x) =>
                {
                    if (x == null) return;
                    foreach (var model in x)
                    {
                        var i = dgReason.Rows.Add();
                        var row = dgReason.Rows[i];
                        row.Cells["colReasID"].Value = model.rs_id;
                        row.Cells["colReason"].Value = model.rs_text;
                        row.Cells["colReasRule"].Value = model.rs_cond;
                        row.Cells["colReasValue"].Value = model.rs_value;
                        row.Cells["colSensor"].Value = model.sens_id;
                        row.Cells["colReasNumber"].Value = model.nn_rs;
                        row.Cells["colProb"].Value = model.rs_probability;
                        row.ReadOnly = true;
                    }
                    dgReason.RowEnter += dgReason_RowEnter;
                }, HttpApiRes.ReasonLoad,
                    HttpApiRes.Host,
                    HttpApiRes.Port,
                    ((DataGridView)sender).Rows[e.RowIndex].Cells["colPrID"].Value.ToString()
                );
        }

        private async void dgReason_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (btnSave.Enabled) return;
            dgSolution.Rows.Clear();
            await _loader.LoadData<Solution>(
                (x) =>
                {
                    if (x == null) return;
                    foreach (var model in x)
                    {
                        var i = dgSolution.Rows.Add();
                        var row = dgSolution.Rows[i];
                        row.Cells["colSolID"].Value = model.sol_id;
                        row.Cells["colSolution"].Value = model.sol_text;
                        row.Cells["colParam"].Value = model.sol_par;
                        row.Cells["colSolSensID"].Value = model.sens_id;
                        row.Cells["colSolNumber"].Value = model.sol_nn;
                        row.ReadOnly = true;
                    }

                }, HttpApiRes.SolutionLoad,
                    HttpApiRes.Host,
                    HttpApiRes.Port,
                    ((DataGridView)sender).Rows[e.RowIndex].Cells["colReasID"].Value.ToString()
                );
        }
    }
}
