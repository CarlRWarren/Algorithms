using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsMyFriendCheating
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static List<long[]> removNb(long n)
        {
            long sum = (1 + n) * n / 2;
            List<long[]> candidates = new List<long[]>();

            for (long y = n; y >= 1; y--)
            {
                long x = (-y + sum) / (y + 1);

                if (x % 1 == 0 && 1 <= x && x <= n)
                {
                    long[] xyPair = { x, y };
                    candidates.Add(xyPair);
                }
            }
            return candidates;
        }

        public static void Print()
        {

        }
    }
}
