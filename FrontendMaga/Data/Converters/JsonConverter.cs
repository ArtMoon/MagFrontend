using System;
using FrontendMaga.Interfaces;
using Newtonsoft.Json;

namespace FrontendMaga.Data.Converters
{
    public class JsonConverter: IDataConverter<string> 
    {
        

        public T1 ConvertTo<T1>(string obj)
        {
            if (obj.Length < 5) return default;
            try
            {       
                var res = JsonConvert.DeserializeObject<T1>(obj);
                return res;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}
