using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//for stopwatch
using System.Diagnostics;
using System.Threading;

namespace PeakFinder1D
{
    class PeakFinder1D
    {
        static void Main(string[] args)
        {
            int[] numbers = { 8, 7, 6, 5, 4, 3, 2, 1 }; //element 6 is peak
            //using stopwatch example
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //Put execution here
            //Thread.Sleep(10000); //10 seconds
            //int peak = SlowSearch(numbers);
            int peak = FastSearch(numbers,0,7);

            stopwatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopwatch.Elapsed;

            string elapsedtime = String.Format("Hours{0:00}:Minutes{1:00}:Secs{2:00}.Ticks{3:00}", 
                ts.Hours, ts.Minutes, ts.Seconds, ts.Ticks);

            Console.WriteLine("Peak found at Index array[" + peak + "]");
            Console.WriteLine("RunTime " + elapsedtime);

        }

        private static int SlowSearch(int[] num)
        {
            //check left edge
            if (num[0] >= num[1])
                return 0;
            //check right edge
            int last = num.Length-1;
            if (num[last] >= num[last - 1])
                return last;

            //check all center elements
            for (int i = 1; i < last; ++i)
            {
                //for all non-edges, check left and right side
                if (num[i] >= num[i - 1] && num[i] >= num[ i+1])
                {
                    return i;                    
                }             
            }

            return -1;
        }

        public static int FastSearch(int[] num, int start, int end)
        {
            int index = start + (end - start) / 2;
            bool NotLeftEdge = (index - 1 >= 0);
            bool NotRightEdge = (index + 1 <= num.Length - 1);

            if (NotLeftEdge && num[index] < num[index - 1])
            {
                return FastSearch(num, start, index - 1);
            }
            else if (NotRightEdge && num[index] < num[index + 1])
            {
                return FastSearch(num, index + 1, end);
            }
            else return index;
        }
    }
}
