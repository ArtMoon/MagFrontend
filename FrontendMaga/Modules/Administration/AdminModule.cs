using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrontendMaga.Interfaces;
using FrontendMaga.Data.DataModels;
using FrontendMaga.Data.Converters;
using Unity;
using FrontendMaga.Http.Sender;
using FrontendMaga.Data.DataModels.Knowledge;
using FrontendMaga.Dialogs;
using FrontendMaga.Resources.Res;

namespace FrontendMaga.Administration
{
    public partial class AdminModule : Form
    {
        private List<ApparatusModel> _tmpApparatus = new List<ApparatusModel>();
        private HttpDataLoader _loader;
        private DataGridView _tmpActiveDataGrid;
        private int _selectedId = -1;
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

            _selectedId = -1;
            switch (_tmpActiveDataGrid.Name)
            {
                case "dgSensorRules":
                    ShowRulesDialogue(new string[6]);
                    break;
                case "dgReason":
                    ShowReasonDialogue(new string[6]);
                    break;
                case "dgSolution":
                    ShowSolutionDialogue(new string[6]);
                    break;
            }
        }

        private void ShowRulesDialogue(params string[] text)
        {
            var form = new DialogueCreator(OnSubmitDialogue);
            form.AddControl("tbSensId", "Идентификатор датчика", typeof(TextBox),text[0]);
            form.AddControl("tbCondition", "Условие", typeof(TextBox),text[1]);
            form.AddControl("tbValue", "Значение", typeof(TextBox),text[2]);
            form.AddControl("tbBoundValue", "Граница", typeof(TextBox),text[3]);
            form.AddControl("tbProblem", "Описание проблемы", typeof(TextBox),text[4]);
            form.AddControl("tbNumber", "Номер по регламенту", typeof(TextBox),text[5]);
            form.ShowDialog();
        }

        private void ShowReasonDialogue(params string[] text)
        {
            var form = new DialogueCreator(OnSubmitDialogue);
            form.AddControl("tbReason", "Описание причины", typeof(TextBox),text[0]);
            form.AddControl("tbSensor", "Идентификатор датчика", typeof(TextBox), text[1]);
            form.AddControl("tbReasRule", "Условие", typeof(TextBox), text[2]);
            form.AddControl("tbReasValue", "Значение", typeof(TextBox), text[3]);
            form.AddControl("tbProb", "Веротность возникновения", typeof(TextBox), text[4]);
            form.AddControl("tbReasNumber", "Номер по регламенту", typeof(TextBox), text[5]);
            form.ShowDialog();
        }

        private void ShowSolutionDialogue(params string[] text)
        {
            var form = new DialogueCreator(OnSubmitDialogue);
            form.AddControl("tbSolution", "Возможное решение", typeof(TextBox),text[0]);
            form.AddControl("tbParam", "Параметр воздействия", typeof(TextBox),text[1]);
            form.AddControl("tbSolSensID", "Идентификатор датчика", typeof(TextBox),text[2]);
            form.AddControl("tbSolNumber", "Номер по регламенту", typeof(TextBox),text[3]);
            form.ShowDialog();
        }



        private async void OnSubmitDialogue(DialogueEventArgs args)
        {
            await SaveData(args);
        }

 

        private void btnAddProblem_Click(object sender, EventArgs e)
        {        
            _tmpActiveDataGrid.Rows.Add();
        }


        private void DataClear()
        {
            dgSensorRules.Rows.Clear();
            dgReason.Rows.Clear();
            dgSolution.Rows.Clear();
        }

        private async Task SaveData(DialogueEventArgs args)
        {
            var list = new List<KeyValuePair<string, string>>();
            string res = string.Empty;
            var poster = new HttpDataPostSender();
            switch (_tmpActiveDataGrid.Name)
            {
                case "dgSensorRules":
                    if (_selectedId > 0) list.Add(new KeyValuePair<string, string>("pr_id", _selectedId.ToString()));
                    list.Add(new KeyValuePair<string, string>("pr_cond", args.GetValue("tbCondition")));
                    list.Add(new KeyValuePair<string, string>("pr_value", args.GetValue("tbValue")));
                    list.Add(new KeyValuePair<string, string>("sens_id", args.GetValue("tbSensId")));
                    list.Add(new KeyValuePair<string, string>("pr_text", args.GetValue("tbProblem")));
                    list.Add(new KeyValuePair<string, string>("pr_bound_value", args.GetValue("tbBoundValue")));
                    list.Add(new KeyValuePair<string, string>("pr_color", "r"));
                    list.Add(new KeyValuePair<string, string>("pr_nn", args.GetValue("tbNumber")));
                    list.Add(new KeyValuePair<string, string>("ap_id", ((ApparatusModel)treeObjects.SelectedNode.Tag).ap_id.ToString()));
                    res = await poster.SendHttpPost(HttpApiRes.RulesPost, list,HttpApiRes.Host,HttpApiRes.Port);
                    break;
                case "dgReason":
                    if (_selectedId > 0) list.Add(new KeyValuePair<string, string>("rs_id", _selectedId.ToString()));
                    list.Add(new KeyValuePair<string, string>("pr_id", dgSensorRules.SelectedRows[0].Cells["colPrID"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("rs_text",args.GetValue("tbReason")));
                    list.Add(new KeyValuePair<string, string>("rs_cond", args.GetValue("tbReasRule")));
                    list.Add(new KeyValuePair<string, string>("rs_value", args.GetValue("tbReasValue")));
                    list.Add(new KeyValuePair<string, string>("sens_id", args.GetValue("tbSensor")));
                    list.Add(new KeyValuePair<string, string>("nn_rs", args.GetValue("tbReasNumber")));
                    list.Add(new KeyValuePair<string, string>("rs_probability", args.GetValue("tbProb")));
                    res = await poster.SendHttpPost(HttpApiRes.ReasonPost, list, HttpApiRes.Host, HttpApiRes.Port);
                    break;
                case "dgSolution":
                    if (_selectedId > 0) list.Add(new KeyValuePair<string, string>("sol_id", _selectedId.ToString()));
                    list.Add(new KeyValuePair<string, string>("rs_id", dgReason.SelectedRows[0].Cells["colReasID"].Value.ToString()));
                    list.Add(new KeyValuePair<string, string>("sol_text", args.GetValue("tbSolution")));
                    list.Add(new KeyValuePair<string, string>("sol_par", args.GetValue("tbParam")));
                    list.Add(new KeyValuePair<string, string>("sens_id", args.GetValue("tbSolSensID")));
                    list.Add(new KeyValuePair<string, string>("sol_nn", args.GetValue("tbSolNumber")));
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
        }
        private void dgSensorRules_Enter(object sender, EventArgs e)
        {
            if (_tmpActiveDataGrid != null && _tmpActiveDataGrid.Name == ((DataGridView)sender).Name) return;
            _tmpActiveDataGrid = (DataGridView)sender;
        }

        private async void treeObjects_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            DataClear();

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
                        row.Cells["colBound"].Value = model.pr_bound_value;
                        row.ReadOnly = true;
                        dgSensorRules.Update();
                    }

                }, HttpApiRes.RulesLoad,
                    HttpApiRes.Host,
                    HttpApiRes.Port,
                    ((ApparatusModel)e.Node.Tag).ap_id.ToString()
                );
        }

  

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            _tmpActiveDataGrid = (DataGridView)((ContextMenuStrip)sender).SourceControl;
        }

        private async void dgSensorRules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            dgReason.Rows.Clear();
            dgSolution.Rows.Clear();
            dgReason.Update();
            dgSolution.Update();
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
       
                }, HttpApiRes.ReasonLoad,
                    HttpApiRes.Host,
                    HttpApiRes.Port,
                    ((DataGridView)sender).Rows[e.RowIndex].Cells["colPrID"].Value.ToString()
                );
        }

        private async void dgReason_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgSolution.Rows.Clear();
            dgSolution.Update();
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

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] args = null;
            
            switch (_tmpActiveDataGrid.Name)
            {
                
                case "dgSensorRules":
                    _selectedId = (int)dgSensorRules.SelectedRows[0].Cells["colPrID"].Value;
                    args = new string[6]
                    {
                        dgSensorRules.SelectedRows[0].Cells["colSensId"].Value?.ToString(),
                        dgSensorRules.SelectedRows[0].Cells["colRule"].Value?.ToString(),
                        dgSensorRules.SelectedRows[0].Cells["colValue"].Value?.ToString(),
                        dgSensorRules.SelectedRows[0].Cells["colBound"].Value?.ToString(),
                        dgSensorRules.SelectedRows[0].Cells["colText"].Value?.ToString(),
                        dgSensorRules.SelectedRows[0].Cells["colNumber"].Value?.ToString()
                    };


                    ShowRulesDialogue(args);
                    break;
                case "dgReason":
                    _selectedId = (int)dgReason.SelectedRows[0].Cells["colReasID"].Value;
                    args = new string[6]
                    {
                        dgReason.SelectedRows[0].Cells["colReason"].Value?.ToString(),
                        dgReason.SelectedRows[0].Cells["colSensor"].Value?.ToString(),
                        dgReason.SelectedRows[0].Cells["colReasRule"].Value?.ToString(),
                        dgReason.SelectedRows[0].Cells["colReasValue"].Value?.ToString(),
                        dgReason.SelectedRows[0].Cells["colProb"].Value?.ToString(),
                        dgReason.SelectedRows[0].Cells["colReasNumber"].Value?.ToString()
                    };
                    ShowReasonDialogue(args);
                    break;
                case "dgSolution":
                    _selectedId = (int)dgSolution.SelectedRows[0].Cells["colSolID"].Value;
                    args = new string[4]
                    {
                        dgSolution.SelectedRows[0].Cells["colSolution"].Value?.ToString(),
                        dgSolution.SelectedRows[0].Cells["colParam"].Value?.ToString(),
                        dgSolution.SelectedRows[0].Cells["colSolSensID"].Value?.ToString(),
                        dgSolution.SelectedRows[0].Cells["colSolNumber"].Value?.ToString()

                    };
                    ShowSolutionDialogue(args);
                    break;
            }
        }

        private async void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Вы уверены?",
            "Удаление",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                await DeleteNode();
            }
                
        }

        private async Task DeleteNode()
        {
            var list = new List<KeyValuePair<string, string>>();
            string res = string.Empty;
            var poster = new HttpDataPostSender();
            switch (_tmpActiveDataGrid.Name)
            {
                case "dgSensorRules":

                    list.Add(new KeyValuePair<string, string>("id", dgSensorRules.SelectedRows[0].Cells["colPrID"].Value.ToString()));
                    res = await poster.SendHttpPost(HttpApiRes.DeleteProblem, list, HttpApiRes.Host, HttpApiRes.Port);
                    break;
                case "dgReason":
                    list.Add(new KeyValuePair<string, string>("id", dgReason.SelectedRows[0].Cells["colReasID"].Value.ToString()));
                    res = await poster.SendHttpPost(HttpApiRes.DeleteReason, list, HttpApiRes.Host, HttpApiRes.Port);
                    break;
                case "dgSolution":
                    list.Add(new KeyValuePair<string, string>("id", dgSolution.SelectedRows[0].Cells["colSolID"].Value.ToString()));
                    res = await poster.SendHttpPost(HttpApiRes.DeleteSolution, list, HttpApiRes.Host, HttpApiRes.Port);
                    break;
            }

            if (res == "200")
            {
                MessageBox.Show("Удалено");
            }
            else
            {
                MessageBox.Show($"Государь! Сервер пал... {res}");
            }
        }
    }
}
