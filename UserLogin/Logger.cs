using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    static public class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities where activity.Contains(filter) select activity).ToList();
            StringBuilder sb = new StringBuilder();
            foreach(string e in filteredActivities)
            {
                sb.Append(e);
            }
            Console.WriteLine(sb.ToString());
        }

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";" + 
                                  LoginValidation.currentUserUsername + ";" + 
                                  LoginValidation.currentUserRole + ";" + 
                                  activity;
            currentSessionActivities.Add(activityLine);
            Console.WriteLine(activityLine);
            // Console.ReadKey();
        
            string fileLocation = "C:/Users/RADIKAL/Downloads/test.txt";
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation).Close();
                File.WriteAllText(fileLocation, activityLine + Environment.NewLine);
            }
            else
            {
                File.AppendAllText(fileLocation, activityLine + Environment.NewLine);
            }

        }
    }
}
