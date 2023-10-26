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
    public class DataWriter
    {
        private string playerName;
        private double score;
        private int amountOfCards;
        private const string filePath = "highscores.json";

        public string PlayerName { get { return playerName; } set {  playerName = value; } }
        public double Score { get { return score; } set { score = value; } }
        public int AmountOfCards { get {  return amountOfCards; } set {  amountOfCards = value; } }

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
                List<DataWriter> scoreList = JsonConvert.DeserializeObject<List<DataWriter>>(existingScores);

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
