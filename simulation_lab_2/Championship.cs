using System.Collections.Generic;

namespace simulation_lab_2
{
    public class Championship
    {
        private int _currentRound;
        private bool _isFinished;
        private int[][][] _schedule;

        public Championship()
        {
            _currentRound = 0;
            _isFinished = false;

            Teams = new List<Team>
            {
                new Team()
                {
                    Name = "Team 1",
                    Skill = 1
                },
                new Team()
                {
                    Name = "Team 2",
                    Skill = 1
                },
                new Team()
                {
                    Name = "Team 3",
                    Skill = 2
                },
                new Team()
                {
                    Name = "Team 4",
                    Skill = 1.5
                },
                new Team()
                {
                    Name = "Team 5",
                    Skill = 0.8
                },
                new Team()
                {
                    Name = "Team 6",
                    Skill = 1.2
                },
                new Team()
                {
                    Name = "Team 7",
                    Skill = 2
                },
                new Team()
                {
                    Name = "Team 8",
                    Skill = 0.9
                },
            };
            _innerTeams = Teams;

            _schedule = new RoundRobinAlgorithm().GetCalculatedSchedule(Teams.Count);
        }

        public List<Team> Teams { get; set; }

        private List<Team> _innerTeams;

        public bool IsFinished
        {
            get
            {
                return _isFinished;
            }
        }

        public void PlayRound()
        {
            var currentRoundSchedule = _schedule[_currentRound];

            foreach (var game in currentRoundSchedule)
            {
                var team = _innerTeams[game[0] - 1];
                var teamToPlay = _innerTeams[game[1] - 1];

                team.PlayGame(teamToPlay);
            }

            Teams = _innerTeams;
            _currentRound++;

            if (_currentRound == _schedule.Length)
            {
                _isFinished = true;
            }
        }

        public void Refresh()
        {
            _currentRound = 0;
            _isFinished = false;
            
            foreach (var team in _innerTeams)
            {
                team.Wins = 0;
                team.Losses = 0;
                team.Draw = 0;
                team.Score = 0;
                team.TotalGoals = 0;
            }

            Teams = _innerTeams;
        }
    }
}
