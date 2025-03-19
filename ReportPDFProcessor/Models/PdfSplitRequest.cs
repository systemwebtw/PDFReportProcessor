using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Systemweb.ReportPDFProcessor.Models
{
    /// <summary>
    /// PdfSplit Request
    /// </summary>
    public class PdfSplitRequest
    {
        /// <summary>
        /// 欲切割原始PDF檔案(含路徑)
        /// </summary>
        public string SourceFilePath { get; set; }

        /// <summary>
        /// PDF切割後儲存路徑(目錄)
        /// </summary>
        public string TargetFolderPath { get; set; }
    }
}