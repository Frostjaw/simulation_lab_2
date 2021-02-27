using System;

namespace simulation_lab_2
{
    public class PoissonRNG
    {
        private readonly Random _rng;

        public PoissonRNG()
        {
            _rng = new Random();
        }

        public int GetRandomNumber(double lambda)
        {
            int m;
            var sum = 0d;

            for (m = 0; ; m++)
            {
                var a = _rng.NextDouble();
                sum += Math.Log(a);

                if (sum < -lambda) break;
            }

            return m;
        }
    }
}
