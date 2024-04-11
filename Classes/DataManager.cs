using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Car_Service_App
{
    public class DataManager
    {

        public double Total { get { return total; } set { total = value; } }
        public double MaterialCost { get { return materialCost; } set { materialCost = value; } }
        public double TimeCost { get { return timeCost; } set { timeCost = value; } }
        public int SelectedWorks { get { return selectedWorks; } set { selectedWorks = value; } }
        public int TotalTimes { get { return totalTimes; } set { totalTimes = value; } }


        private double total = 0, materialCost = 0, timeCost = 0;
        private int selectedWorks = 0;
        private int totalTimes = 0;

        public void Reset()
        {
            materialCost = 0;
            timeCost = 0;
            selectedWorks = 0;
            total = 0;
        }

        public void AddWorks()
        {
            selectedWorks++;
        }



    }
}
