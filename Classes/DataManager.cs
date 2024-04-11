using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Service_App
{
    public class DataManager
    {
        //Work Properties: Name of work; Required time in minutes; Material costs


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

        public void transfer(GlobalDataManager gdm, bool Saved)
        {
            if (Saved)
            {
                gdm.TotalMaterialCost += this.MaterialCost;
                gdm.TotalTimeCost += this.TimeCost;
                gdm.BigTotal += this.Total;
                gdm.TotalSelectedWorks += this.SelectedWorks;
                gdm.BigTotalTime += this.TotalTimes;
                Reset();
            }
        }


        public List<String> CalculateCosts(List<CheckBox> checkBoxes, List<Work> works, List<Label> totalCostsLabels, List<double> totalCostsValue)
        {
            double materialCost = 0, timeCost = 0;
            List<String> costs = new List<String>(2);

            for (int i = 0; i < works.Count; i++)
            {

                if (checkBoxes[i].Checked)
                {

                    //All started 30 minutes are invoiced?
                    if (works[i].Time % 30 == 0)
                    {
                        timeCost += (15000 / 60) * works[i].Time;
                    }
                    else
                    {
                        timeCost += (15000 / 2) * ((works[i].Time / 30) + 1);
                    }

                    totalCostsLabels[i].Text = totalCostsValue[i].ToString() + " Ft";
                    materialCost += works[i].MaterialCost;
                    TotalTimes += works[i].Time;
                }
                else
                {
                    totalCostsLabels[i].Text = "0 Ft";
                }

                
            }
            costs.Add(materialCost.ToString() + " Ft");
            costs.Add(timeCost.ToString() + " Ft");
            return costs;
        }
    }
}
