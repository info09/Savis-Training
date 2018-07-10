using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using NewCMS.Business;
using NewCMS.Business.Config;
using NewCMS.Common;
using Newtonsoft.Json;

namespace NewCMS.API.Controllers.CMS
{
    public class ValuesController : ApiController
    {

        [HttpGet]
        [Route("api/values")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string GetValue()
        {
            ILogService logService = BusinessServiceLocator.Instance.GetService<ILogService>();

            // logService.Info("Application Started");

            return "Data successfully returned / API is now running";
        }


    }
}
