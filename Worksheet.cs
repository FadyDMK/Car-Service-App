using System;
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

        private bool Saved = false;


        public static double sum = 0, materialCost = 0, timeCost = 0, numberOfCheck = 0;


        public Worksheet()
        {
            InitializeComponent();
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
                label2.Text = works[i].Time.ToString() + "min" ;
                label2.Size = new Size(100, 50);
                label2.Location = new Point(160, label1.Location.Y);
                panel1.Controls.Add(label2);


                //Material Cost
                Label label3 = new Label();
                label3.Text = works[i].MaterialCost.ToString();
                label3.Size = new Size(100, 50);
                label3.Location = new Point(label2.Location.X + 150, label2.Location.Y);
                panel1.Controls.Add(label3);


                




                //total Cost
                Label label4 = new Label();
                double totalCost = works[i].MaterialCost + (15000/60) * works[i].Time;
                label4.Text = totalCost.ToString();
                label4.Size = new Size(100, 50);
                label4.Location = new Point(label3.Location.X + 140, label1.Location.Y);
                label4.Text = totalCost.ToString();
                label4.Visible = false;
                panel1.Controls.Add(label4);



                //checkboxes
                CheckBox checkBox = new CheckBox();
                checkBox.Size = new Size(30, 50);
                checkBox.Location = new Point(label3.Location.X + 100, label1.Location.Y - 18);

                // Add event handler for CheckedChanged event
                checkBox.CheckedChanged += CheckBox_CheckedChanged;

                panel1.Controls.Add(checkBox);
                checkBoxes.Add(checkBox);
                











            }

        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;
            for (int i = 0; i < works.Count; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    label4.Visible = true;
                }
            }
        }

    }
}
