using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using FrontendMaga.Interfaces;
using FrontendMaga.Http;
using FrontendMaga.Data.Converters;

namespace FrontendMaga
{
    static class Program
    {
        public static IUnityContainer Container; 
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ResolveDependancies();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EnterForm());
        }

        private static void ResolveDependancies()
        {
            Container = new UnityContainer();
            Container.RegisterType<IDataLoader, JsonHttpLoader>();
            Container.RegisterType<IDataConverter<string>, JsonConverter>();
            

        }
    }
}
