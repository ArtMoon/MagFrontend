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
using System.Threading;
using System.Collections;
using FrontendMaga.Data.DataModels;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;
using FrontendMaga.Data.Converters;
using Unity;
using FrontendMaga.Data.DataModels.Knowledge;
using FrontendMaga.Resources.Res;

namespace FrontendMaga
{
    public partial class MainForm : Form
    {
        private INotifyService<Sensor_Vals> _notifyServise;
        private List<ApparatusModel> _tmpApparatus = new List<ApparatusModel>();
        private List<Alarm> _tmpAlarms = new List<Alarm>();
        private string _currentSensId = string.Empty;
        private System.Threading.Timer _monitoringTimer;
        private List<Problem> _cachedProblems = new List<Problem>();
        private ApparatusModel _chosenApModel;
        private Thread _thread;
        private bool _monitoringIsActive = false;
        private Mutex _mutex = new Mutex();
        public MainForm(INotifyService<Sensor_Vals> notifyService)
        {
            _notifyServise = notifyService;

            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            pnMonitoring.Visible = true;
            var _loader = Program.Container.Resolve<HttpDataLoader>();
            await _loader.LoadData<ApparatusModel>(
                (x) =>
                {
                    if (x == null) return;
                    _tmpApparatus.Clear();
                    _tmpApparatus.AddRange(x);
                    var converter = new TreeNodesConverter();
                    var nodes = converter.GetNodes(x);
          
                    treeMain.Nodes.AddRange(nodes.ToArray());

                },HttpApiRes.Apparatuses,
                HttpApiRes.Host,
                HttpApiRes.Port
                );

        }

 



        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            if (dgSensors.Rows.Count == 0 )
            {
                MessageBox.Show("Choose your hero");
                return;
            }

            StartMonitoring();
          
        }

        private void StartMonitoring()
        { 
            _monitoringIsActive = true;
            btnSearch.Enabled = false;
            btnPause.Enabled = true;
            InitSeries();
            _thread = new Thread(CallBack);
            _thread.IsBackground = true;
            _thread.Name = "MonitoringThread";
            _thread.Start();
            
         

        }

        private async Task LoadRules()
        {
            var ap_id = _chosenApModel.ap_id;
            var _loader = Program.Container.Resolve<HttpDataLoader>();
            await _loader.LoadData<Problem>((x) =>
            {
                dgRules.DataSource = null;
                if (x == null) return;
                dgRules.DataSource = x;
                dgRules.Columns["pr_id"].Visible = false;
                dgRules.Columns["sens_id"].Visible = false;
                dgRules.Columns["pr_color"].Visible = false;
                dgRules.Columns["ap_id"].Visible = false;

                dgRules.Columns["pr_text"].HeaderText = "Описание проблемы";
                dgRules.Columns["pr_nn"].HeaderText = "Номер";
                dgRules.Columns["pr_value"].HeaderText = "Значение";
                dgRules.Columns["pr_cond"].HeaderText = "Условие";
            },
            HttpApiRes.RulesLoad,
            HttpApiRes.Host, HttpApiRes.Port, ap_id.ToString());
        }

        private async void CallBack()
        {
            while (_monitoringIsActive)
            {
                await LoadData();
                await ExecuteAlarmsSearch();
                await LoadAlarms();

                Thread.Sleep(2000);
            }
        }

        private async Task ExecuteAlarmsSearch()
        {
           
            var ap_id = _chosenApModel.ap_id;
            var db = DateTime.Now.AddMinutes(-1).ToString("yyyy-MM-dd hh:mm:ss");
            var de = DateTime.Now.AddMinutes(1).ToString("yyyy-MM-dd hh:mm:ss");
            var _loader = Program.Container.Resolve<HttpDataLoader>();
            await _loader.LoadRawData((x) =>{},
            HttpApiRes.ExecuteAlarmsSearch,
            HttpApiRes.Host, HttpApiRes.Port, ap_id.ToString(),db, de);
        }

        private async Task LoadAlarms()
        {
            var ap_id = _chosenApModel.ap_id;
            var db = DateTime.Now.AddMinutes(-10).ToString("yyyy-MM-dd hh:mm:ss");
            var de = DateTime.Now.AddMinutes(1).ToString("yyyy-MM-dd hh:mm:ss");
            var loader = Program.Container.Resolve<HttpDataLoader>();
            await loader.LoadData<Alarm>((x) =>
            {
                if (x == null) return;
                x = x.OrderByDescending((a) => a.al_date).ToList();
                Invoke(new Action(() =>
                {
           
                    dgNotifications.DataSource = x;
                    dgNotifications.Columns["al_id"].Visible = false;
                    dgNotifications.Columns["sens_id"].Visible = false;
                    dgNotifications.Columns["ap_id"].Visible = false;

                    dgNotifications.Columns["al_date"].HeaderText = "Дата";
                    var objStyle = new DataGridViewCellStyle();
                    objStyle.Format = "hh:mm:ss";
                    dgNotifications.Columns["al_date"].DefaultCellStyle.ApplyStyle(objStyle);
                    dgNotifications.Columns["al_value"].HeaderText = "Значение";
                    dgNotifications.Columns["al_text"].HeaderText = "Ситуация";
                    dgNotifications.Columns["al_reason"].HeaderText = "Наиболее вероятная причина";
                    dgNotifications.Columns["al_param"].HeaderText = "Параметр воздейстия";
                    dgNotifications.Columns["sol_text"].HeaderText = "Решение";
                    dgNotifications.Columns["sens_name"].HeaderText = "Датчик";

                    dgNotifications.Update();
                }));
                

            },
           HttpApiRes.AlarmsDataLoad,
           HttpApiRes.Host, HttpApiRes.Port, dgSensors.SelectedCells[0].Value.ToString(), db, de);
        }
        private async Task LoadData()
        {
            var db = DateTime.Now.AddMinutes(-10).ToString("yyyy-MM-dd hh:mm:ss");
            var de = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            var _loader = Program.Container.Resolve<HttpDataLoader>();
            _currentSensId = dgSensors.SelectedCells[0].Value.ToString();
            await _loader.LoadData<Sensor_Vals>((x) =>
            {
                Invoke(new Action(()=> { SensorValsLoaded(x); }));
            }, HttpApiRes.SensorDataLoad, HttpApiRes.Host,
                    HttpApiRes.Port, dgSensors.SelectedCells[0].Value.ToString(), db, de);
           
        }

        private void InitSeries()
        {
            var ser = new Series("Values");
            ser.ChartType = SeriesChartType.Line;
            ser.XValueType = ChartValueType.Time;
            ser.Color = Color.Blue;
            chartMonitoring.Series.Clear();
            chartMonitoring.Series.Add(ser);
            int i = 0;
            foreach (DataGridViewRow rule in dgRules.Rows)
            {
                var series = new Series($"Rule{i}");
                series.Color = Color.Red;
                series.ChartType = SeriesChartType.Line;
                series.XValueType = ChartValueType.Time;
                series.Points.AddXY(0,Convert.ToDouble(rule.Cells["pr_value"].Value));
                chartMonitoring.Series.Add(series);
                i++; 
            }
        }


        private void SensorValsLoaded(List<Sensor_Vals> list)
        {
            if(list == null)
            {
                StopMonitoring();
                MessageBox.Show("No data");
                return;
            }
            UpdateSensorChart(list);
        }


        private void UpdateSensorChart(List<Sensor_Vals> list, float min = 0, float max = 0)
        {
 
            list.OrderBy((x) => x.val_date);

            chartMonitoring.Series["Values"].Points.Clear();

            foreach (Sensor_Vals vals in list)
                chartMonitoring.Series["Values"].Points
                    .AddXY(vals.val_date, vals.val);

            foreach (var series in chartMonitoring.Series)
            {
                if (series.Name == "Values") continue;
                var cache = series.Points[0].YValues[0];
                series.Points.Clear();
                series.Points.AddXY(chartMonitoring.Series["Values"].Points[0].XValue, cache);
                series.Points.AddXY(chartMonitoring.Series["Values"].Points.Last().XValue, cache);
            }
            chartMonitoring.ChartAreas[0].AxisX.Minimum = chartMonitoring.Series["Values"].Points[0].XValue;
            chartMonitoring.ChartAreas[0].AxisX.Maximum = chartMonitoring.Series["Values"].Points.Last().XValue;
            chartMonitoring.Update();
      
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
            StopMonitoring();
            _chosenApModel = ((ApparatusModel)e.Node.Tag);
            var ap_id = _chosenApModel.ap_id;
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
                dgSensors.Columns["sens_id"].Visible = false;
                
            },
            HttpApiRes.SensorLoad,
            HttpApiRes.Host,HttpApiRes.Port,ap_id.ToString());
        }

        private async void dgSensors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            await LoadRules();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            StopMonitoring();
        }

        private void StopMonitoring()
        {
            _mutex.WaitOne();
            if(!_monitoringIsActive)
            {
                _mutex.ReleaseMutex();
                return;
            }
            _monitoringIsActive = false;
            btnSearch.Enabled = true;
            btnPause.Enabled = false;
            _mutex.ReleaseMutex();

        }
    }
}
