using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Systemweb.ReportPDFProcessor.Core;

namespace Systemweb.ReportPDFProcessor
{
    /// <summary>
    /// ResultModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultModel<T>
    {
        /// <summary>
        /// 資料內容
        /// </summary>
        public T Datas { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccessful { get; set; } = false;

        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; } = "";

        /// <summary>
        /// 設定成功
        /// </summary>
        public ResultModel<T> SetSuccess() 
        {
            IsSuccessful = true;
            return this;
        }

        /// <summary>
        /// 設定失敗
        /// </summary>
        public ResultModel<T> SetError(string msg) 
        { 
            IsSuccessful = false;
            Message = msg;
            return this;
        }

        /// <summary>
        /// 設定異常
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public ResultModel<T> SetException(Exception ex) 
        {
            IsSuccessful = false;
            Message = ex.Message;
            Global.Log.Trace(Message, ex);
            return this;
        }
    }
}