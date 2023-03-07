using iTextSharp.text;
using iTextSharp.text.pdf;

using Org.BouncyCastle.Asn1.X509;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.iTextSharp.Windman
{
    public class MetadataHandler
    {
        #region -- 變數宣告 ( Declarations ) --   

        private string l_sFilePath;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public MetadataHandler(string pi_sFilePath)
        {
            this.l_sFilePath = pi_sFilePath;
        }

        #endregion

        #region -- 事件處理 ( Event Handlers ) --
        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static MetadataHandler Initial(string pi_sFilePath)
        {
            return new MetadataHandler(pi_sFilePath);
        }

        #endregion

        #region -- 方法 ( Public Method ) --

        public string Read(string pi_sKey)
        {
            var sReturn = string.Empty;
            using (PdfReader objPdfReader = new PdfReader(l_sFilePath))
            {
                var objInfo = objPdfReader.Info;
                if(objInfo.TryGetValue(pi_sKey, out string sValue))
                {
                    sReturn = sValue;
                }
            }
            return sReturn;
        }

        public string WriteInto(string pi_sKey, string pi_sValue)
        {
            var sOutputFilePath = Path.Combine(Path.GetDirectoryName(l_sFilePath),
                $@"{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.pdf");
            var objPdfReader = new PdfReader(l_sFilePath);
            var objFileStream = new FileStream(sOutputFilePath, FileMode.OpenOrCreate);
            var objPdfStamper = new PdfStamper(objPdfReader, objFileStream);

            objPdfStamper.MoreInfo = new Dictionary<string, string>() { { pi_sKey, pi_sValue } };
            objPdfStamper.Close();
            return sOutputFilePath;
        }
        #endregion

        #region -- 屬性 ( Properties ) --
        #endregion

        #region -- 事件 ( Events ) --
        #endregion

        #region -- 介面實做 ( Implements ) - [InterfaceName] --
        #endregion

        #region -- 私有函式 ( Private Method) --
        #endregion

        #region -- 衍生函式 ( Protected Method ) -- 
        #endregion

        #region -- 抽象函式 ( Abstract Method ) --        
        #endregion
    }
}
