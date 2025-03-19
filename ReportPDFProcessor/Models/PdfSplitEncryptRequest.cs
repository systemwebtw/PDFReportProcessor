using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Systemweb.ReportPDFProcessor.Models
{
    /// <summary>
    /// PdfSplitEncrypt Request
    /// </summary>
    public class PdfSplitEncryptRequest
    {
        /// <summary>
        /// PDF檔案(欲分割檔案)
        /// </summary>
        public byte[] PdfFile { get; set; }

        /// <summary>
        /// PDF名稱對應清單
        /// </summary>
        public List<FileNameMappingModel> FileNames { get; set; }

        /// <summary>
        /// 使用者開啟Key
        /// </summary>
        public string UserKey { get; set; }

        /// <summary>
        /// 擁有者開啟Key
        /// </summary>
        public string OwnerKey { get; set; }

    }

    /// <summary>
    /// PDF名稱對應表
    /// </summary>
    public class FileNameMappingModel 
    {
        /// <summary>
        /// 戶號
        /// </summary>
        public decimal BF_NO {  get; set; }

        /// <summary>
        /// PDF檔案名稱
        /// </summary>
        public string PDFNAME { get; set; }
    }
}