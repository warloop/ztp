
namespace graNaZtp.Models
{
    

    class Ranking
    {
        private List<Points> players = new List<Points>();

        public Ranking()
        {
        }

        public List<Points> getPlayers()
        {
            sortPlayersInRanking();
            return players;
        }
        public void addPlayer(Points points)
        {
            players.Add(points);
        }

        private void sortPlayersInRanking()
        {
            for (int i = 0; i < players.Count; i++)
            {
                for (int j = 0; j < players.Count; j++)
                {
                    if (i != j && players[i].getValue() > players[j].getValue())
                    {
                        Points temp = players[i];
                        players[i] = players[j];
                        players[j] = temp;
                    }
                }
            }
        }
    }
}
