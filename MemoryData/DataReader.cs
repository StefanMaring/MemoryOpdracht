using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryData
{
    public class DataReader : Data
    {
        public List<Data> ReadDataFromJSON(string filePath)
        {
            List<Data> allScores = new List<Data>();

            if(File.Exists(filePath)) {
                string scores = File.ReadAllText(filePath);
                allScores = JsonConvert.DeserializeObject<List<Data>>(scores);

                return allScores;
            } else
            {
                Trace.WriteLine("File does not exist!");
                return allScores;
            }
        }
    }
}
