using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FrontendMaga.Data.DataModels;

namespace FrontendMaga.Interfaces
{
   public interface ISearchForm
   {
        void SearchData();
   }
    
   public interface IDataLoader
   {
        Task<string> LoadData(string url);
   }

   public interface IDataConverter<T2>
   {
        T1 ConvertTo<T1>(T2 obj);
   }

    public interface INotificationService<T1,T2>
    {
        DataTable GetNotification(List<T1> values, List<T2> rules);
    }
    public interface INotifyService<T>
    {
        DataTable GetNotification(List<T> values, double maxValue, double minValue);
    }

    public class HttpDataLoader
    {
        protected IDataLoader _dataLoader;
        protected IDataConverter<string> _converter;

        public HttpDataLoader(IDataLoader loader, IDataConverter<string> converter)
        {
            _dataLoader = loader;
            _converter = converter; 
        }

        public async Task LoadData<T>(Action<List<T>> callBack, string request, params string[] args)
        {
            var req = string.Format(request, args);
            var json = await _dataLoader.LoadData(req);
            var list = _converter.ConvertTo<List<T>>(json);

            callBack(list);
        }

        public async Task LoadRawData(Action<string> callBack, string request, params string[] args)
        {
            var req = string.Format(request, args);
            var json = await _dataLoader.LoadData(req);
            callBack(json);
        }


        public class NOtifySerise : INotificationService<Sensor_Vals, Sensor_Vals>
        {
            public DataTable GetNotification(List<Sensor_Vals> values, List<Sensor_Vals> rules)
            {
                throw new NotImplementedException();
            }
        }
    }


}
