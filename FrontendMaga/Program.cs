using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using FrontendMaga.Interfaces;
using FrontendMaga.Http;
using FrontendMaga.Data.Converters;
using FrontendMaga.NotificationModule;
using FrontendMaga.Data.DataModels;
using System.Data;

namespace FrontendMaga
{
    static class Program
    {
        public static IUnityContainer Container;

        //Only for demo!!!!!!!!!!!!!
        public static DataTable TEMP_DEMO_DATA_CONTAINER;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ResolveDependancies();
            InitDemoContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EnterForm());
        }

        private static void ResolveDependancies()
        {
            Container = new UnityContainer();
            Container.RegisterType<IDataLoader, JsonHttpLoader>();
            Container.RegisterType<INotifyService<Sensor_Vals>, SensorNotificationService>();
            Container.RegisterType<IDataConverter<string>, JsonConverter>();
            

        }
        //DEMO BLYAT SUKA
        
        private static void InitDemoContainer()
        {
            TEMP_DEMO_DATA_CONTAINER = new DataTable();
            TEMP_DEMO_DATA_CONTAINER.Columns.Add("Sens_id",typeof(string));
            TEMP_DEMO_DATA_CONTAINER.Columns.Add("min",typeof(float));
            TEMP_DEMO_DATA_CONTAINER.Columns.Add("max",typeof(float));
            TEMP_DEMO_DATA_CONTAINER.Columns.Add("recomendation");
        }
    }
}
