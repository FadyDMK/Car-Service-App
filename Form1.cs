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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

                        //using insures the correct use of the streamReader (disposes of the instance automatically)
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            string fileContent = reader.ReadToEnd();
                        }

                        EnableMenuItems();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    MessageBox.Show("The File Has Loaded Successfully!","Done" , MessageBoxButtons.OK);

                }
            }
        }
    }
}
