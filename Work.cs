﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service_App
{
    public class Work
    {
        //Name of work; Required time in minutes; Material costs
        public string Service { set; get; }
        public int Time { set; get; }
        public int MaterialCost { set; get; }


        public Work(string service,int time,int materialCost) {
            this.Service = service;
            this.Time = time;
            this.MaterialCost = materialCost;
        }







    }
}
