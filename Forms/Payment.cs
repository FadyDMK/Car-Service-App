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
        private MainForm mainForm;

        public Payment(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            //label5-8
            

            //total selected works
            label5.Text = mainForm.TotalSelectedWorks.ToString() + " db";
            label5.ForeColor = Color.Orange;

            //total material cost
            label6.Text = mainForm.TotalMaterialCost.ToString() + " Ft";
            label6.ForeColor = Color.Green;

            //total cost for the time 
            label7.Text = mainForm.TotalTimeCost.ToString() + " Ft";
            label7.ForeColor = Color.Red;

            //big total
            label8.Text = mainForm.BigTotal.ToString() + " Ft";
            label8.ForeColor = Color.CadetBlue;

            //number of worksheets NoWorksheets
            label10.Text = MainForm.NoWorksheets.ToString() + " db";
            label10.ForeColor = Color.MediumPurple;

            
            int hours = mainForm.BigTotalTime / 60;
            int minutes = mainForm.BigTotalTime % 60;
            label12.Text = hours.ToString() + ":" + minutes.ToString();


            //TODO u can use the worksheet button multiple times before
            //pressing the payment
            //payment should also mention how many times u used a worksheet to register work



        }
    }
}
