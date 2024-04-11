using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service_App
{
    public class GlobalDataManager
    {
        private double bigTotal, totalMaterialCost, totalTimeCost;
        private int totalSelectedWorks, bigTotaltime;

        public GlobalDataManager() {
            bigTotal = 0;
            totalMaterialCost = 0;
            totalTimeCost = 0;
            totalSelectedWorks = 0;
            bigTotaltime = 0;
        }



        public double BigTotal { get { return bigTotal; } set { bigTotal = value; } }
        public double TotalMaterialCost { get { return totalMaterialCost; } set { totalMaterialCost = value; } }
        public double TotalTimeCost { get { return totalTimeCost; } set { totalTimeCost = value; } }
        public int TotalSelectedWorks { get { return totalSelectedWorks; } set { totalSelectedWorks = value; } }
        public int BigTotalTime { get { return bigTotaltime; } set { bigTotaltime = value; } }


        public void Reset()
        {
            bigTotal = 0;
            totalMaterialCost = 0;
            totalTimeCost = 0;
            totalSelectedWorks = 0;
            NoWorksheets = 0;
            bigTotaltime = 0;
        }

        public int NoWorksheets { get; set; }

        public void AddWorksheet()
        {
            NoWorksheets++;
        }



    }
}
