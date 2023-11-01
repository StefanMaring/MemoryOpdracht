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
        public DataWriter(string playerName, double score, int amountOfCards) { 
            PlayerName = playerName;
            Score = score;
            AmountOfCards = amountOfCards;
        }

        public void WriteDataToJSON(string filePath)
        {
            string newScore;

            if(!File.Exists(filePath)) {

                File.AppendAllText(filePath, "[\n]");
            }

            string existingScores = File.ReadAllText(filePath);
            List<Data> scoreList = JsonConvert.DeserializeObject<List<Data>>(existingScores);

            scoreList.Add(this);

            newScore = JsonConvert.SerializeObject(scoreList);
            File.WriteAllText(filePath, newScore);
        }
    }
}
