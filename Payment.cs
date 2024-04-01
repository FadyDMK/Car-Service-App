using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Service_App
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            //label5-8
            label5.Text = Worksheet.selectedWorks.ToString() + "db";
            label6.Text = Worksheet.materialCost.ToString() + "Ft";
            label7.Text = Worksheet.timeCost.ToString() + "Ft";
            label8.Text = Worksheet.total.ToString() + "Ft";

            //TODO u can use the worksheet button multiple times before
            //pressing the payment ADD THAT FEATURE
            //payment should also mention how many times u used a worksheet to register work



        }
    }
}
