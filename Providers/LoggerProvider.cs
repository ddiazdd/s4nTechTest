using System;
using System.IO;

namespace DroneDelivery.Providers
{
    public class LoggerProvider
    {
        private string logPath = Constants.Application.FILES_PATH;
        
        public void LogWrite(string logMessage)
        {
            try
            {
                using (StreamWriter w = File.AppendText(logPath + "\\" + "log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0}", DateTime.Now);
                txtWriter.WriteLine("{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
    }
}