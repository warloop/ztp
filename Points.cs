using graNaZtp.Models.aliens;
using graNaZtp.Models.graNaZtp.Models;
using System.Windows.Controls;

namespace graNaZtp.Models
{
    internal class Points
    {
        private Label labelWithScore;
        private int value;
        private string playerName;

        public Points(Label labelWithScore)
        {
            this.labelWithScore = labelWithScore;
            value = 0;
            labelWithScore.Content = "Points: " + value;
            playerName = "";
        }

        public Points(Points points)
        {
            this.labelWithScore = points.labelWithScore;
            this.value = points.value;
            this.playerName = points.playerName;
        }

        public int getValue()
        {
            return value;
        }

        public void addPoints(int newPoints)
        {
            this.value = value + newPoints;
            labelWithScore.Content = "Points: " + value;

        }
        public void setPoints(int value)
        {
            this.value = value;
        }
        
        public string getPlayerName()
        {
            return playerName;
        }
        public void setPlayerName(string playerName)
        {
            this.playerName = playerName;
        }
        public void AddPointsForAlien(Alien alien)
        {
            int pointsToAdd = alien.CalculatePoints();
            addPoints(pointsToAdd);
        }
    }
    }
