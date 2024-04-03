using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Car_Service_App
{
    public class Work
    {
        //Name of work; Required time in minutes; Material costs
        public string Service { private set; get; }
        public int Time { private set; get; }
        public int MaterialCost { private set; get; }
        public string TimeInHours
        {
            get { 
                int hours = Time / 60;
                int minutes = Time % 60;

                return hours.ToString() + ":" + minutes.ToString();
            }
            private set { }
        }

        public Work(string service,int time,int materialCost) {
            this.Service = service;
            this.Time = time;
            this.MaterialCost = materialCost;
        }









    }
}
