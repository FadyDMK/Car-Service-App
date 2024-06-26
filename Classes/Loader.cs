﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service_App
{
    public class Loader
    {
        public List<T> LoadFile<T>(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string line;
            List<string> lines = new List<string>();
            Parser parser = new Parser();
            List<Work> works = new List<Work>();

            while(!reader.EndOfStream)
            {
                line = reader.ReadLine();
                Work work = parser.Parse(line);
                works.Add(work);


            }
			reader.Dispose();
			return new List<T>(works as IEnumerable<T>);

		}
    }
}
