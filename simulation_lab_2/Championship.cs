using System.Collections.Generic;

namespace simulation_lab_2
{
    public class Championship
    {
        private int _currentRound;

        public Championship()
        {
            _currentRound = 1;
            Teams = new List<Team>
            {
                new Team()
                {
                    Name = "Team A",
                    Skill = 1
                },
                new Team()
                {
                    Name = "Team B",
                    Skill = 1
                },
                new Team()
                {
                    Name = "Team C",
                    Skill = 2
                },
                new Team()
                {
                    Name = "Team D",
                    Skill = 1.5
                },
                new Team()
                {
                    Name = "Team E",
                    Skill = 0.8
                },
                new Team()
                {
                    Name = "Team F",
                    Skill = 1.2
                },
                new Team()
                {
                    Name = "Team G",
                    Skill = 2
                },
                new Team()
                {
                    Name = "Team H",
                    Skill = 0.9
                },
            };
        }

        public List<Team> Teams { get; set; }

        public void PlayRound()
        {
            for (int i = 0; i < Teams.Count - 1; i += 2)
            {
                var team = Teams[i];
                var teamToPlay = Teams[i + _currentRound];
                team.PlayGame(teamToPlay);
            }
        }

        public void Refresh()
        {
            _currentRound = 1;
            
            foreach (var team in Teams)
            {
                team.Wins = 0;
                team.Losses = 0;
                team.Draw = 0;
                team.Score = 0;
                team.TotalGoals = 0;
            }
        }
    }
}
