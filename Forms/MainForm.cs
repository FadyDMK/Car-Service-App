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

        public static double bigTotal = 0, totalMaterialCost = 0, totalTimeCost = 0;
        public static int totalSelectedWorks = 0;



        public MainForm()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            bigTotal = 0; 
            totalMaterialCost = 0; 
            totalTimeCost = 0; 
            totalSelectedWorks = 0;
            NoWorksheets = 0;
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
            Worksheet worksheet = new Worksheet();
            worksheet.renderWorks(works);
            worksheet.ShowDialog();
            NoWorksheets++;
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
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
            const string neptunCode = "YV9GAA";
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

                        //Read the contents of the file into a stream

                        var fileStream = openFileDialog.OpenFile();

                        Loader l = new Loader();
						

						works = l.LoadFile<Work>(filePath);
                        

						openFileDialog.Dispose();

					}
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

					if (works.Count == 0)
					{
						MessageBox.Show("File is Empty Please choose another File ! ");
					}
					else
					{
						MessageBox.Show("The File Has Loaded Successfully!", "Done", MessageBoxButtons.OK);
						EnableMenuItems();

					}


                }
            }
        }
    }
}
