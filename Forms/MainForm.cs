using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Car_Service_App
{
    public partial class MainForm : Form
    {
        public List<Work> works = new List<Work>();
        public static int NoWorksheets { get; set; }

        private double bigTotal = 0, totalMaterialCost = 0, totalTimeCost = 0;
        private int totalSelectedWorks = 0 , bigTotaltime = 0;

        public double BigTotal { get { return bigTotal; } set {  bigTotal = value; } }
        public double TotalMaterialCost { get { return totalMaterialCost;} set { totalMaterialCost = value; } }
        public double TotalTimeCost { get { return totalTimeCost; } set { totalTimeCost = value; } }
        public int TotalSelectedWorks { get { return totalSelectedWorks; } set { totalSelectedWorks = value; } }
        public int BigTotalTime { get { return bigTotaltime;} set {  bigTotaltime = value; } }



        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public void Reset()
        {
            bigTotal = 0; 
            totalMaterialCost = 0; 
            totalTimeCost = 0; 
            totalSelectedWorks = 0;
            NoWorksheets = 0;
            bigTotaltime = 0;
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void EnableMenuItems()
        {
            worksheetToolStripMenuItem.Enabled = true;
            paymentToolStripMenuItem.Enabled = true;

        }

        private void worksheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Worksheet worksheet = new Worksheet(this);
            worksheet.renderWorks(works);
            worksheet.ShowDialog();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment(this);
            payment.ShowDialog();
            
            Reset();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
            if (ConfirmExit() == DialogResult.Yes)
            { Application.ExitThread(); }
        }
       
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            
            if (ConfirmExit() == DialogResult.Yes)
            { Application.ExitThread(); }
            else { e.Cancel = true; }
        }

        
        private DialogResult ConfirmExit()
        {
            const string message = "Are you sure you want to exit?";
            const string caption = "Exit";
            var result = MessageBox.Show(message, caption,
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
            return result;

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string neptunCode = "Neptun Code: YV9GAA";
            DateTime current = DateTime.Now;
            const string title = "About";
            MessageBox.Show(current.ToString() + "\n"+neptunCode, title,MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                     

					try
                    {
						//Get the path of specified file
						string filePath = openFileDialog.FileName;

                        Loader l = new Loader();
						

						works = l.LoadFile<Work>(filePath);
                        

						openFileDialog.Dispose();
                        if (works.Count == 0)
                        {
                            MessageBox.Show("File is Empty Please choose another File ! ", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("The File Has Loaded Successfully!", "Done", MessageBoxButtons.OK);
                            EnableMenuItems();

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
