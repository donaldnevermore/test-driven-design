using System;

namespace TestDrivenDesign {
    public class Consecutive {
        public static void Find() {
            var line = Console.ReadLine()?.Split(' ');
            if (line is null) {
                return;
            }

            var len = int.Parse(line[0]);
            var operations = int.Parse(line[1]);

            var str = Console.ReadLine();
            if (str is null) {
                return;
            }

            var result = WindowSolve(str, operations, len);
            Console.WriteLine(result);
        }

        private static int WindowSolve(string str, int operations, int len) {
            var left = 0;
            var right = 0;
            var aCount = 0;
            var bCount = 0;
            var result = 0;

            while (right < len) {
                if (str[right] == 'a') {
                    aCount++;
                }
                else {
                    bCount++;
                }

                if (aCount <= operations || bCount <= operations) {
                    right++;
                }
                else {
                    result = Math.Max(result, right - left);

                    if (str[left] == 'a') {
                        left++;
                        aCount--;
                    }
                    else {
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
