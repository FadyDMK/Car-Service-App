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
        private List<Work> works = new List<Work>();

        GlobalDataManager gdm = new GlobalDataManager();


        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
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
            Worksheet worksheet = new Worksheet(gdm);
            worksheet.renderWorks(works);
            worksheet.ShowDialog();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment(gdm);
            payment.ShowDialog();

            gdm.Reset();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (ConfirmExit() == DialogResult.Yes)
            { Application.ExitThread(); }
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {

            if (ConfirmExit() == DialogResult.No)
            { e.Cancel = true; }
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
            DateTime current = DateTime.Now;
            MessageBox.Show(current.ToString() + "\n" + "Neptun Code: YV9GAA", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile lf = new LoadFile();
            works = lf.LoadFileMenu(works);
            if(works.Count > 0)
            {
                EnableMenuItems();
            }


        }
    }
}
