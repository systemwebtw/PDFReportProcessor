using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Systemweb.ReportPDFProcessor.Models;

namespace Systemweb.ReportPDFProcessor.Core
{
    /// <summary>
    /// PDF 小幫手
    /// </summary>
    public class PdfHelper
    {
        /// <summary>
        /// PDF切割且加密
        /// </summary>
        /// <param name="pdfBytes">欲切割原始PDF檔案</param>
        /// <param name="pdfNames">檔案名稱清單</param>
        /// <param name="userkey">使用者開啟密碼</param>
        /// <param name="ownerkey">擁有者開啟密碼</param>
        /// <returns></returns>
        public static ResultModel<PdfSplitEncryptResponse> PdfSplitEncrypt(byte[] pdfBytes, List<FileNameMappingModel> pdfNames, string userkey, string ownerkey)
        {
            var result = new ResultModel<PdfSplitEncryptResponse>() { Datas = new PdfSplitEncryptResponse() };

            try
            {
                int PageStart = 1;

                using (MemoryStream inputStream = new MemoryStream(pdfBytes))
                using (PdfReader reader = new PdfReader(inputStream))
                {
                    int TotalPDFPages = reader.NumberOfPages;

                    //空白頁的字
                    String WritePageText = String.Empty;
                    int pageWhite = 0;
                    Decimal BF_NO = 0;
                    int BF_NO_Index = 1;
                    String strBF_NO = String.Empty;
                    String strID_NO = String.Empty;
                    for (int pagenumber = 1; pagenumber <= reader.NumberOfPages; pagenumber++)
                    {
                        WritePageText = PdfTextExtractor.GetTextFromPage(reader, pagenumber);

                        //處理分割頁
                        int a = WritePageText.IndexOf("分割頁：");
                        if (a != -1)
                        {
                            int b = WritePageText.IndexOf("結尾");
                            Document document = new Document();
                            BF_NO = Convert.ToDecimal(WritePageText.Substring(a + 4, b - a - 4));

                            string filename = pdfNames.FirstOrDefault(x => x.BF_NO == BF_NO)?.PDFNAME;
                            if (string.IsNullOrEmpty(filename)) 
                            {
                                continue;
                            }

                            using (MemoryStream outputStream = new MemoryStream())
                            {
                                PdfCopy copy = new PdfCopy(document, outputStream);
                                document.Open();

                                pageWhite = pagenumber;

                                for (int j = PageStart; j < pageWhite; j++)
                                {
                                    copy.AddPage(copy.GetImportedPage(reader, j));
                                }
                                document.Close();

                                //進行加密
                                string m_pwd1 = WritePageText.Substring(b + 2, WritePageText.IndexOf("加密用") - b - 2);
                                string m_pwd2 = m_pwd1;
                                var encrryptResult = PdfEncrypt(outputStream.ToArray(), true, m_pwd1, m_pwd2);
                                if (encrryptResult.IsSuccessful)
                                {
                                    var item = new PdfFileInfo
                                    {
                                        PdfFile = encrryptResult.Datas
                                        ,
                                        PdfFileName = filename + ".PDF"
                                    };
                                    result.Datas.EncryptPdfList.Add(item);
                                }
                            }

                            PageStart = pageWhite + 1;

                            BF_NO_Index++;

                            if (PageStart > TotalPDFPages + 1)
                            {
                                break;
                            }
                        }
                    }
                }

                result.SetSuccess();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// PDF檔案崁入開啟密碼
        /// </summary>
        /// <param name="pdfBytes">來源PDF檔</param>
        /// <param name="strength">設為true</param>
        /// <param name="userkey">使用者開啟密碼</param>
        /// <param name="ownerkey">擁有者開啟密碼</param>
        public static ResultModel<byte[]> PdfEncrypt(byte[] pdfBytes, bool strength, string userkey, string ownerkey)
        {
            var result = new ResultModel<byte[]>();

            try
            {
                using (MemoryStream inputStream = new MemoryStream(pdfBytes))
                using (PdfReader reader = new PdfReader(inputStream))
                using (MemoryStream outputStream = new MemoryStream())
                {
                    iTextSharp.text.pdf.PdfEncryptor.Encrypt(
                        reader,
                        outputStream,
                        true,
                        userkey,
                        ownerkey,
                        PdfWriter.AllowPrinting | PdfWriter.ALLOW_COPY);

                    result.Datas = outputStream.ToArray();
                    result.SetSuccess();
                }
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;
        }


    }

 
}