﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;
using Label = System.Windows.Forms.Label;

namespace Car_Service_App
{
    public partial class Worksheet : Form
    {
        //Work Properties: Name of work; Required time in minutes; Material costs
        private List<Work> works = new List<Work>();
        private List<CheckBox> checkBoxes = new List<CheckBox>();
        private List<Label> totalCostsLabels = new List<Label>();

        private bool Saved ;


        public static double total = 0, materialCost = 0, timeCost = 0;
        public static int selectedWorks = 0;


        public Worksheet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Saved = true;
            Calculate();
            this.Close();
        }

        public void Reset()
        {
            materialCost = 0;
            timeCost = 0;
            selectedWorks = 0;
        }

        private void Calculate()
        {
            Reset();

            for (int i = 0; i < works.Count; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    selectedWorks++;

                }
            }
            materialCost = Int32.Parse(this.label5.Text.Replace("Ft", "").Trim());
            timeCost = Int32.Parse(this.label7.Text.Replace("Ft", "").Trim());
            total = materialCost + timeCost;
        }



        private void Worksheet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Saved)
            {
                {
                    const string message = "You didn't register this worksheet.\n Are you sure you want to close without saving?";
                    const string caption = "Attention";
                    var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Saved = false;
                    }
                    else { e.Cancel = true; }
                }

            }
        }

        private void Worksheet_Load(object sender, EventArgs e)
        {
            Saved = false;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                MessageBox.Show("Checkbox checked!");
            }
            else
            {
                MessageBox.Show("Checkbox unchecked!");
            }
        }



        internal void renderWorks(List<Work> works)
        {
            this.works = works;
            label5.Text = "0" + " Ft";
            label7.Text = "0" + " Ft";
            panel1.Controls.Clear();
            checkBoxes.Clear();

            for(int i = 0; i < works.Count; i++)
            {

                //name of the service
                Label label1 = new Label();
                label1.Text = works[i].Service;
                label1.Size = new Size(100, 50);
                label1.Location = new Point(10, 10 + (i * 60));
                panel1.Controls.Add(label1);

                //Time required for the service
                Label label2 = new Label();
                label2.Text = works[i].Time.ToString() + " min" ;
                label2.Size = new Size(100, 50);
                label2.Location = new Point(160, label1.Location.Y);
                panel1.Controls.Add(label2);


                //Material Cost
                Label label3 = new Label();
                label3.Text = works[i].MaterialCost.ToString() + " Ft";
                label3.Size = new Size(100, 50);
                label3.Location = new Point(label2.Location.X + 150, label1.Location.Y);
                panel1.Controls.Add(label3);


                




                //total Cost
                Label label41 = new Label();
                double totalCost = works[i].MaterialCost + (15000/60) * works[i].Time;
                label41.Text = totalCost.ToString() + " Ft";
                label41.Size = new Size(80, 40);
                label41.Location = new Point(label3.Location.X + 140, label1.Location.Y);
                totalCostsLabels.Add(label41);
                label41.Visible = false;


                panel1.Controls.Add(label41);



                //checkboxes
                CheckBox checkBox = new CheckBox();
                checkBox.Size = new Size(30, 50);
                checkBox.Location = new Point(label3.Location.X + 100, label1.Location.Y - 18);

                // Add event handler for CheckedChanged event
                checkBox.CheckedChanged += new EventHandler(CheckBox_Checked);

                panel1.Controls.Add(checkBox);
                checkBoxes.Add(checkBox);
            }

        }


        private void CheckBox_Checked(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;
            double materialCost = 0, timeCost = 0;


            for (int i = 0; i < works.Count; i++)
            {
                totalCostsLabels[i].Visible = false;
                if (checkBoxes[i].Checked)
                {

                    //All started 30 minutes are invoiced?
                    if (works[i].Time % 30 == 0)
                    {
                        timeCost += (15000 / 60) * works[i].Time;
                    }
                    else
                    {
                        timeCost += (15000 / 2) * ((works[i].Time/30)+1);
                    }

                    totalCostsLabels[i].Visible = true;
                    materialCost += works[i].MaterialCost;
                }
            }
            
            label5.Text = materialCost.ToString() + " Ft";
            label7.Text = timeCost.ToString() + " Ft";
        }

    }
}