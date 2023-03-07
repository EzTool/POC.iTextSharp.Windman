using Microsoft.VisualStudio.TestTools.UnitTesting;

using POC.iTextSharp.Windman;

using System;
using System.CodeDom;

namespace UT.POC.iTextSharp.Windman.NET461._SPEC
{
    [TestClass]
    public class MetadataHandler_Methods
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var sFilePath = $@"C:\_Request\稅報套印工具\會計師簽名與印鑑尺寸.pdf";
            var sKey = "MyKey";
            var sValue = "1.1.1";
            var sTempFilePath = MetadataHandler.Initial(sFilePath).WriteInto(sKey, sValue);
            
            //Action
            string sActual = MetadataHandler.Initial(sTempFilePath).Read(sKey);

            //Assert
            Assert.AreEqual(sValue, sActual);
        }
    }
}
