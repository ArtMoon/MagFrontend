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

        

        public MainForm(IDataLoader loader,IDataConverter<string> converter)
        {
            _converter = converter;
            _loader = loader;

            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            pnMonitoring.Visible = true;
            InitChart();
            await LoadSensors((x) =>
            {
                /* dataSet1.Tables.Clear();
                 var table = new DataTable();
                 table.Columns.Add("Sensor");
                 table.Columns.Add("Description");

                 foreach(SensorInfo v in x)
                 {
                     table.Rows.Add(v.SensorName, v.Description);    
                 }
                 dataSet1.Tables.Add(table);
                 dgSensors.DataSource = dataSet1.Tables[0];*/

                dgSensors.DataSource = x;
                dgSensors.Columns["Id"].Visible = false;
                dgSensors.Columns["ParentId"].Visible = false;
            });

        }
        private void InitChart()
        {
            chartMonitoring.Series.Add("Values");
            chartMonitoring.Series["Values"].ChartType = SeriesChartType.Line;
        }

        private async Task LoadSensors(Action<List<SensorInfo>> callBack)
        {
            var host = HttpApiRes.Host;
            var port = HttpApiRes.Port;
            var req = string.Format(HttpApiRes.SensorLoad, host, port, 1);
            var json = await _loader.LoadData(req);
            var list = _converter.ConvertTo<List<SensorInfo>>(json);
           
            callBack(list);
        }


        private async Task LoadSensorData(Action<List<Sensor_Vals>> callBack)
        {
            var host = HttpApiRes.Host;
            var port = HttpApiRes.Port;
            var db = ((DateTime)dtpDateBegin.Value).ToString("yyyy-MM-dd");
            var de = ((DateTime)dtpDateEnd.Value).ToString("yyyy-MM-dd");
            MessageBox.Show(dgSensors.SelectedCells[0].Value.ToString());
            var req = string.Format(HttpApiRes.SensorDataLoad, host, port, dgSensors.SelectedCells[0].Value,db,de);
            var json = await _loader.LoadData(req);
           
            var list = _converter.ConvertTo<List<Sensor_Vals>>(json);
            list.OrderBy((x) => x.Date_time);
            callBack(list);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await LoadSensorData(SensorValsLoaded);
        }

        private void SensorValsLoaded(List<Sensor_Vals> list)
        {
            chartMonitoring.Series["Values"].Points.Clear();
            chartMonitoring.ChartAreas[0].AxisY.Minimum = 2;
            //MessageBox.Show(list[0].Sensor_name);
            foreach (Sensor_Vals vals in list)
            {
                chartMonitoring.Series["Values"].Points.AddXY(vals.Date_time, vals.Sensor_value);
            }
        }

        private void pnSidebar_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                               Color.FromArgb(255,46,49,58),
                                                               Color.FromArgb(255, 46, 49, 120),
                                                               0F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
