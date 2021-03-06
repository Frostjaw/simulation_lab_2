namespace simulation_lab_2
{
    public class Team
    {
        private PoissonRNG _rng;

        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draw { get; set; }
        public int TotalGoals { get; set; }
        public int Score { get; set; }
        public double Skill { get; set; }

        public Team()
        {
            _rng = new PoissonRNG();
            Wins = 0;
            Losses = 0;
            Draw = 0;
            TotalGoals = 0;
            Score = 0;
        }

        public void PlayGame(Team team)
        {
            var _score = _rng.GetRandomNumber(Skill);
            TotalGoals += _score;

            var score = _rng.GetRandomNumber(team.Skill);
            team.TotalGoals += score;

            if (_score > score)
            {
                Score += 2;
                Wins++;
                team.Losses++;

                return;
            }
            if (_score == score)
            {
                Score++;
                Draw++;
                team.Score++;
                team.Draw++;

                return;
            }

            team.Score += 2;
            team.Wins++;
            Losses++;
        }
    }
}
