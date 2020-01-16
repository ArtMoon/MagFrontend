using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
