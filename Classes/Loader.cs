using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service_App
{
    public class Loader
    {
        public StreamReader LoadFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            return reader;
        }
    }
}
