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
using System.Collections;
using FrontendMaga.Data.DataModels;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;



namespace FrontendMaga
{
    public partial class MainForm : Form
    {
        private IDataConverter<string> _converter;
        private IDataLoader _loader;
        private INotifyService<Sensor_Vals> _notifyServise;
        private List<ApparatusModel> _tmpApparatus = new List<ApparatusModel>();
        public MainForm(IDataLoader loader,IDataConverter<string> converter,INotifyService<Sensor_Vals> notifyService)
        {
            _converter = converter;
            _loader = loader;
            _notifyServise = notifyService;

            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            pnMonitoring.Visible = true;
            InitSensorChart();
            InitPieChart();
            await LoadData<ApparatusModel>(
                (x) =>
                {
                    x.OrderBy((n)=> n.Parent_id);
                    var rootNodes = new List<TreeNode>();                   
                    var enterNodes = x;
                    var levels = new Dictionary<int, List<ApparatusModel>>();
                    int lvlIndex = 0;
                    while (x.Count > 0)
                    {
                        var roots = new List<ApparatusModel>();
                        for (int i = 0; i < x.Count; i++)
                        {
                            for (int j = 0; j < enterNodes.Count; j++)
                            {
                                if (x[i].Parent_id == enterNodes[j].Id_Ap)
                                {                                 
                                    break;
                                }

                                if (j == enterNodes.Count-1)
                                {
                                    roots.Add(x[i]);
                                }

                            }
                        }
                        var list = new List<ApparatusModel>();
                    
                        foreach (ApparatusModel m in roots)
                        {
                            list.Add((ApparatusModel)m.Clone());
                            x.Remove(m);
                        }
                        lvlIndex++;
                        levels.Add(lvlIndex, list);
                        
                    }

                    var nodes = new List<TreeNode>();
                    var root = new List<ApparatusModel>();
                    levels.TryGetValue(1,out root);
                    var childs = new List<ApparatusModel>();
                    levels.TryGetValue(2, out childs);
                    for(int i = 0; i < root.Count; i++)
                    {
                        nodes.Add(new TreeNode(root[i].App_name));
                        for(int j = 0; j < childs.Count; j++)
                        {
                            if(childs[j].Parent_id == root[i].Id_Ap)
                            {
                                nodes[i].Nodes.Add(new TreeNode(childs[j].App_name));
                            }
                        }

                    }
                    _tmpApparatus = childs;
                    _tmpApparatus.AddRange(root);
          
                    treeMain.Nodes.AddRange(nodes.ToArray());

                },HttpApiRes.Apparatuses,
                HttpApiRes.Host,
                HttpApiRes.Port
                );

        }




        private void InitPieChart()
        {
            chartPie.Series.Clear();
            chartPie.ChartAreas[0].AxisY.IsStartedFromZero = false;
            chartPie.Series.Add("Efficiency");
            chartPie.Series["Efficiency"].ChartType = SeriesChartType.Pie;
            chartPie.Series["Efficiency"].Color = Color.Azure;
            chartPie.ChartAreas[0].Area3DStyle.Enable3D = true;
            chartPie.ChartAreas[0].Area3DStyle.IsClustered = true;
            chartPie.ChartAreas[0].Area3DStyle.Inclination = 30;

        }

        private void InitSensorChart()
        {
            chartMonitoring.Series.Clear();
            chartMonitoring.ChartAreas[0].AxisY.IsStartedFromZero = false;
            chartMonitoring.Series.Add("Values");
            chartMonitoring.Series["Values"].ChartType = SeriesChartType.Line;
            chartMonitoring.Series["Values"].Color = Color.Blue;
            chartMonitoring.Series["Values"].XValueType = ChartValueType.DateTime;

            chartMonitoring.Series.Add("MinNorm");
            chartMonitoring.Series["MinNorm"].XValueType = ChartValueType.DateTime;
            chartMonitoring.Series["MinNorm"].ChartType = SeriesChartType.Line;
            chartMonitoring.Series["MinNorm"].Color = Color.Red;

            chartMonitoring.Series.Add("MaxNorm");
            chartMonitoring.Series["MaxNorm"].XValueType = ChartValueType.DateTime;
            chartMonitoring.Series["MaxNorm"].ChartType = SeriesChartType.Line;
            chartMonitoring.Series["MaxNorm"].Color = Color.Red;

        }

        private async Task LoadData<T>(Action<List<T>> callBack,string request,params string[] args)
        {
            var req = string.Format(request, args);
            var json = await _loader.LoadData(req);
            var list = _converter.ConvertTo<List<T>>(json);
           
            callBack(list);
        }


        private async void btnSearch_Click(object sender, EventArgs e)
        {

            if (dgSensors.Rows.Count == 0 )
            {
                MessageBox.Show("Choose your hero");
                return;
            }
            if(dtpDateBegin.Value > dtpDateEnd.Value)
            {
                MessageBox.Show("Date time value not correct!");
                return;
            }
            var db = dtpDateBegin.Value.ToString("yyyy-MM-dd");
            var de = dtpDateEnd.Value.AddDays(1).ToString("yyyy-MM-dd");
            await LoadData<Sensor_Vals>(SensorValsLoaded,HttpApiRes.SensorDataLoad, HttpApiRes.Host, 
                HttpApiRes.Port, dgSensors.SelectedCells[0].Value.ToString(),db,de);
        }

        private void SensorValsLoaded(List<Sensor_Vals> list)
        {
            if(list == null)
            {
                MessageBox.Show("No data");
                return;
            }

            UpdateSensorChart(list);
            UpdatePieChart();
        }

        private void UpdatePieChart()
        {
            chartPie.Series["Efficiency"].Points.Clear();
            chartPie.Series["Efficiency"].Points.AddXY("KPI",89);
            chartPie.Series["Efficiency"].Points.AddXY("", 11);
        }

        private void UpdateSensorChart(List<Sensor_Vals> list)
        {
            list.OrderBy((x) => x.Date_time);
            chartMonitoring.Series["Values"].Points.Clear();

            foreach (Sensor_Vals vals in list)
                chartMonitoring.Series["Values"].Points
                    .AddXY(vals.Date_time, vals.Sensor_value);

            chartMonitoring.Series["MinNorm"].Points.Clear();

            var minNormValue = chartMonitoring.Series["Values"].Points.Last().YValues[0] - 0.5f;
            var maxNormValue = minNormValue + 1;

            chartMonitoring.Series["MinNorm"].Points.AddXY(chartMonitoring.Series["Values"].Points[0].XValue,
                minNormValue);
            chartMonitoring.Series["MinNorm"].Points.AddXY(chartMonitoring.Series["Values"].Points.Last().XValue,
              minNormValue);

            chartMonitoring.Series["MaxNorm"].Points.Clear();

            chartMonitoring.Series["MaxNorm"].Points.AddXY(chartMonitoring.Series["Values"].Points[0].XValue,
               maxNormValue);
            chartMonitoring.Series["MaxNorm"].Points.AddXY(chartMonitoring.Series["Values"].Points.Last().XValue,
              maxNormValue);

            LoadNotifications(list, minNormValue, maxNormValue);
        }

        private void LoadNotifications(List<Sensor_Vals> vals,double minNormValue, double maxNormValue)
        {
            dgNotifications.DataSource = _notifyServise.GetNotification(vals, maxNormValue, minNormValue);
        }

        


        private void pnSidebar_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                               Color.FromArgb(255,46,49,48),
                                                               Color.FromArgb(255, 46, 49, 255),
                                                               90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private async void treeMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var msg = _tmpApparatus.Where((x) => x.App_name == e.Node.Text).ToList()[0].Id_Ap;
            await LoadData<SensorInfo>((x) =>
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
            HttpApiRes.Host,HttpApiRes.Port,msg.ToString());
        }
    }
}
