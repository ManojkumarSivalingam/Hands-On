using HCSOneTapService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HCSOneTapServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            HCSOneTapWindowService service = new HCSOneTapWindowService();

            Type service1Type = typeof(HCSOneTapWindowService);

            MethodInfo onStart = service1Type.GetMethod("OnStart", BindingFlags.NonPublic | BindingFlags.Instance); //retrieve the OnStart method so it can be called from here

            onStart.Invoke(service, new object[] { null }); //call the OnStart method
            Console.WriteLine("completedservice");

            Console.ReadKey();
            //if (Environment.UserInteractive)
            //{
            //    service.OnStart(args);
            //    Console.WriteLine("Press any key to stop program");
            //    Console.Read();
            //    service.OnStop();
            //}
            //else
            //{
            //    //ServiceBase.Run(service);
            //}
        }  
    }
}
