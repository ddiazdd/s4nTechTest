using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DroneDelivery.Models;
using DroneDelivery.Providers;

namespace DroneDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerProvider loggerProvider = new LoggerProvider();
            try
            {                
                List<DroneProvider> providers = new List<DroneProvider>();
                for (int i = 1; i <= Constants.Application.DRONES_NUMBER; i++)
                {
                    providers.Add(new DroneProvider(new Drone(i)));                    
                }
                Task.WhenAll(providers.Select(i => i.ExecuteDelivery()));
            }
            catch (Exception e)
            {
                loggerProvider.LogWrite(string.Format("{0}:{1}", e.Message, e.InnerException));
            }
        }
    }
}
