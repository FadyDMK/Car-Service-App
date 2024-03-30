using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service_App
{
    public class Work
    {
        //Name of work; Required time in minutes; Material costs
        public string name { set; get; }
        public int time { set; get; }
        public int materialCost { set; get; }


        public Work(string name,int time,int materialCost) {
            this.name = name;
            this.time = time;
            this.materialCost = materialCost;
        }







    }
}
