using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service_App
{
    public class Parser
    {
        public Work Parse(string line) 
        {
            string[] data;
            data = line.Split(';');
            Work work = new Work(data[0], Int32.Parse(data[1]), Int32.Parse(data[2]));
            return work;
        }

    }
}
