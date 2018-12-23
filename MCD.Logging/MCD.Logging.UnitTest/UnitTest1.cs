using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace MCD.Logging.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            

        [TestMethod]
        public void TestMethod1()
        {
            LoggerFactory fac = new LoggerFactory();
            var logger = fac.GetLogger();

            logger.Info("INFO MESSAGE");

            logger.Info("PUNKS MESSAGE");
            try
            {
                var a = 1;
                var b = 0;
                var c = a / b;
            }
            catch (Exception e)
            {
                logger.Error("Houve erro", e);
            }

            for (var i = 0; i < 10; i++)
            {
                logger.Info($"Its is a test: {i}");
            }

            logger.Info("End");



            Console.ReadKey();
        }
    }
}
