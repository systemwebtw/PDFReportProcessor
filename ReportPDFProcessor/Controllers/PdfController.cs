using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Systemweb.ReportPDFProcessor.Core;
using Systemweb.ReportPDFProcessor.Models;

namespace Systemweb.ReportPDFProcessor.Controllers
{
    /// <summary>
    /// PDF 控制器
    /// </summary>
    [RoutePrefix("api/pdf")]
    public class PdfController : BaseApiController
    {  

        /// <summary>
        /// PDF切割與加密
        /// </summary>
        [HttpPost]
        [Route("SplitEncrypt")]
        public ResultModel<PdfSplitEncryptResponse> PdfSplitEncrypt(PdfSplitEncryptRequest request)
        {
            var result = new ResultModel<PdfSplitEncryptResponse>();
            if (request == null)
            {
                result.SetError("所傳入的Request為Null");
            }
            else
            {
                result = PdfHelper.PdfSplitEncrypt(request.PdfFile, request.FileNames, request.UserKey, request.OwnerKey);
            }

            return result;
        }

        /// <summary>
        /// PDF加密
        /// </summary>
        [HttpPost]
        [Route("Encrypt")]
        public ResultModel<byte[]> PdfEncrypt(PdfEncryptRequest request)
        {
            var result = new ResultModel<byte[]>();
            if (request == null)
            {
                result.SetError("所傳入的Request為Null");
            }
            else
            {
                result = PdfHelper.PdfEncrypt(request.PdfFile,true, request.UserKey, request.OwnerKey);
            }
            
            return result;
        }
    }
}