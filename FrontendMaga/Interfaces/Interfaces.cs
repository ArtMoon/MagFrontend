using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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

    public interface INotifyService<T>
    {
        DataTable GetNotification(List<T> values, double maxValue, double minValue);
    }
}
