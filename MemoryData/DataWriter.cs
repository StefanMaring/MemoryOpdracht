using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MemoryData
{
    public class DataWriter : Data
    {
        private const string filePath = "highscores.json";

        public DataWriter(string playerName, double score, int amountOfCards) { 
            PlayerName = playerName;
            Score = score;
            AmountOfCards = amountOfCards;
        }

        public bool WriteDataToJSON()
        {
            string newScore;

            if(File.Exists(filePath))
            {
                string existingScores = File.ReadAllText(filePath);
                List<Data> scoreList = JsonConvert.DeserializeObject<List<Data>>(existingScores);

                scoreList.Add(this);

                newScore = JsonConvert.SerializeObject(scoreList);
                File.WriteAllText(filePath, newScore);
                return true;
            } else
            {
                Trace.WriteLine("File does not exist!");
                return false;
            }
        }
    }
}
