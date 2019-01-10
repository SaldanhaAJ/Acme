using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace Acme.Feature.Promotion.Helpers
{
    public interface IParamSerializer
    {
        string Serialize(object obj);

        object Deserialize(string input);

        T Deserialize<T>(string input);

        object Deserialize(NameValueCollection input);

        T Deserialize<T>(NameValueCollection input);
    }
}
