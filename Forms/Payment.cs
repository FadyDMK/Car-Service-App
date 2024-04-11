using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Car_Service_App
{
    public partial class Payment : Form
    {
        GlobalDataManager gdm;

        public Payment(GlobalDataManager gdm)
        {
            InitializeComponent();
            this.gdm = gdm;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            //label5-8
            

            //total selected works
            label5.Text = gdm.TotalSelectedWorks.ToString() + " db";
            label5.ForeColor = Color.Orange;

            //total material cost
            label6.Text = gdm.TotalMaterialCost.ToString() + " Ft";
            label6.ForeColor = Color.Green;

            //total cost for the time 
            label7.Text = gdm.TotalTimeCost.ToString() + " Ft";
            label7.ForeColor = Color.Red;

            //big total
            label8.Text = gdm.BigTotal.ToString() + " Ft";
            label8.ForeColor = Color.CadetBlue;

            //number of worksheets NoWorksheets
            label10.Text = gdm.NoWorksheets.ToString() + " db";
            label10.ForeColor = Color.MediumPurple;

            
            int hours = gdm.BigTotalTime / 60;
            int minutes = gdm.BigTotalTime % 60;
            label12.Text = hours.ToString() + ":" + minutes.ToString();





        }
    }
}
