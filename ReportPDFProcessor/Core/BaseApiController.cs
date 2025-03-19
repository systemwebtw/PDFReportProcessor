using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Systemweb.ReportPDFProcessor.Core
{
    /// <summary>
    /// BaseApi Controller
    /// </summary>
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="controllerContext"></param>
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            InitialLogInfo(controllerContext);
        }

        /// <summary>
        /// InitialLogInfo
        /// </summary>
        /// <param name="controllerContext"></param>
        private void InitialLogInfo(HttpControllerContext controllerContext)
        {
            var value = Request.Content == null ? "" : Request.Content.ReadAsStringAsync().Result;
            var methodName = controllerContext.Request.RequestUri.Segments.LastOrDefault() + "";//controllerContext.ControllerDescriptor.ControllerName;

            if (value.Length > 100 * 1024)
            {
                //var loginModel = JsonConvert.DeserializeObject<LoginRequest>(value);
                //var loginString=JsonConvert.SerializeObject(loginModel);
                Global.Log.Trace($"執行方法{methodName},傳入內容大於100k,長度為:{value.Length}");
                Global.Log.Debug($"執行方法{methodName},所傳入參數為:{value}");
            }
            else
            {
                Global.Log.Trace($"執行方法{methodName},所傳入參數為:{value}");
            }            
        }
    }
}