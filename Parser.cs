﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service_App
{
    public class Parser
    {
        private List<Work> works = new List<Work>();
        public List<Work> AddWorks(StreamReader reader) 
        {
            string line;
            string[] data;

            while(!reader.EndOfStream)
            {
                line = reader.ReadLine();
                data = line.Split(';');
                Work addedWork = new Work(data[0], Int32.Parse(data[1]), Int32.Parse(data[2]));
                works.Add(addedWork);
            }
            return works;
        }

    }
}
