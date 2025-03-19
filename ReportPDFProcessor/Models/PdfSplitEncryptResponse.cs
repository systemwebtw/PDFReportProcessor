using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Systemweb.ReportPDFProcessor.Models
{
    /// <summary>
    /// PdfSplitEncrypt Response
    /// </summary>
    public class PdfSplitEncryptResponse
    {
        /// <summary>
        /// PDF加密清單
        /// </summary>
        public List<PdfFileInfo> EncryptPdfList { get; set; } = new List<PdfFileInfo>();
    }

    /// <summary>
    /// PDF檔案資訊
    /// </summary>
    public class PdfFileInfo 
    {
        /// <summary>
        /// PDF檔案
        /// </summary>
        public byte[] PdfFile {  get; set; }

        /// <summary>
        /// PDF檔案名稱
        /// </summary>
        public string PdfFileName { get; set; }
    }
}