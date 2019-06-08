namespace Algorithms.Algorithms
{
    /// <summary>
    /// Two realizations of fibonacci series: with and without memoization.
    /// </summary>
    public static class Fibonacci
    {
        /// <summary>
        /// Array for caching results of fib values.
        /// </summary>
        private static readonly int[] _memo = new int[1001];

        /// <summary>
        /// Naive implementation of fibonacci series value calculation.
        /// </summary>
        /// <param name="n">Number of fibonacci series.</param>
        /// <returns>Value from fibonacci series.</returns>
        public static int Fib(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return Fib(n - 1) + Fib(n - 2);
            }
        }

        /// <summary>
        /// Optimized (by runtime speed) implementation of fibonacci series.
        /// </summary>
        /// <param name="n">Number of fibonacci series.</param>
        /// <returns>Value from fibonacci series.</returns>
        public static int OFib(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else if (_memo[n] == 0)
            {
                _memo[n] = Fib(n - 1) + Fib(n - 2);
            }

            return _memo[n];
        }
    }
}
