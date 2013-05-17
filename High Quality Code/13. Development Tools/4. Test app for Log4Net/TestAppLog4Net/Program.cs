using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using log4net.Config;
using System.Text;
using System.Threading.Tasks;

namespace TestAppLog4Net
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            log.Info("app initalizes...");
            TestClassToIllustrate tc = new TestClassToIllustrate();
            tc.Start();
            log.Info("app finished...");
        }
    }

    public class TestClassToIllustrate {

        private static readonly ILog log = LogManager.GetLogger(typeof(TestClassToIllustrate));

        public void Start()
        {
            log.Info("In another method!");
        }
    }
}
