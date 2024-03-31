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
    public partial class Worksheet : Form
    {
        private List<Work> works = new List<Work>();
        public Worksheet()
        {
            InitializeComponent();
        }
        internal void renderWorks(List<Work> works)
        {
            this.works = works;
        }


    }
}
