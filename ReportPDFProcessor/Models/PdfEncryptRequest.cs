using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Systemweb.ReportPDFProcessor.Models
{
    /// <summary>
    /// PdfEncrypt Request
    /// </summary>
    public class PdfEncryptRequest
    {
        /// <summary>
        /// 要加密的Pdf檔案
        /// </summary>
        public byte[] PdfFile { get; set; }

        /// <summary>
        /// 使用者開啟Key
        /// </summary>
        public string UserKey { get; set; }

        /// <summary>
        /// 擁有者開啟Key
        /// </summary>
        public string OwnerKey { get; set; }

    }
}