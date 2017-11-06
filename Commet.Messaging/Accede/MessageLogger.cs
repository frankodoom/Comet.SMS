using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comet.SMS
{
    public class MessageLogger
    {
        public static List<string> outbox = new List<string>();
        public static List<string> sent = new List<string>();
        public static string LogPath = @"\log.txt";
        public static bool EnableLogging;

        public static void logOutbox( string data, string message )
        {
            outbox.Add(data);
            //Add to reject list
            if(MessageLogger.EnableLogging == true)
            {
                LogStatus(LogPath, " Message TO " + data +" " +message);
            }        
        }

        public static void logSent(string data, string message)
        {  
            //Store List of Sent Items in Memory
            sent.Add(data);
            
            //Write To Database or File (.Txt, .Xml) 
            if (MessageLogger.EnableLogging == true)
            {
                LogStatus(LogPath, " Sent message to " + data + "successfully, Logged as Sent");
            }
        }

        public static void LogStatus(string dir, string logMessage)
        {        
            string path = Environment.CurrentDirectory + dir;

            using (StreamWriter w = File.AppendText(path))
            {

                Log(System.DateTime.UtcNow + "-" + logMessage, w);

            }
            using (StreamReader r = File.OpenText(path))
            {
                DumpLog(r);
            }
          // Console.ReadKey();
        }

        private static void Log(string logMessage, TextWriter w)
        {
       
            w.WriteLine("{0}", logMessage );
            //w.WriteLine("..........................................................................");
        }

       private static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
  }
