using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCMS.Common
{
    public interface IGenericCacheService
    {
        bool HasInCache(string key);

        Response<string> DeleteFromCache(string key);

        string ClearAllCache();
    }

}
