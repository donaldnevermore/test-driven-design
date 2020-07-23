using System;

namespace TestDrivenDesign
{
    public class Consecutive
    {
        public static void Find()
        {
            string[] line = Console.ReadLine().Split(' ');
            int len = int.Parse(line[0]);
            int operations = int.Parse(line[1]);
            string str = Console.ReadLine();

            int result = WindowSolve(str, operations, len);
            Console.WriteLine(result);
        }

        private static int WindowSolve(string str, int operations, int len)
        {
            int left = 0;
            int right = 0;
            int aCount = 0;
            int bCount = 0;
            int result = 0;

            while (right < len)
            {
                if (str[right] == 'a')
                {
                    aCount++;
                }
                else
                {
                    bCount++;
                }

                if (aCount <= operations || bCount <= operations)
                {
                    right++;
                }
                else
                {
                    result = Math.Max(result, right - left);

                    if (str[left] == 'a')
                    {
                        left++;
                        aCount--;
                    }
                    else
                    {
                        left++;
                        bCount--;
                    }

                    right++;
                }
            }

            result = Math.Max(result, right - left);
            return result;
        }
    }
}
