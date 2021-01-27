using System;

namespace TestDrivenDesign {
    public class ThreeTeams {
        public static void Start() {
            int times = int.Parse(Console.ReadLine());
            var lines = new string[times];

            for (int i = 0; i < times; i++) {
                string line = Console.ReadLine();
                lines[i] = line;
            }

            foreach (string line in lines) {
                string[] array = line.Split(' ');
                int total = int.Parse(array[0]);
                int played = int.Parse(array[1]);
                int diff1 = int.Parse(array[2]);
                int diff2 = int.Parse(array[3]);

                bool result = CanEqual(total, played, diff1, diff2);
                Console.WriteLine(result ? "yes" : "no");
            }
        }

        private static bool CanEqual(int total, int played, int diff1, int diff2) {
            if (total % 3 != 0) {
                return false;
            }

            int remain = total - played;

            // t1 < t2 < t3
            int condition1 = played - diff1 - diff1 - diff2;
            if (IsValid(condition1)) {
                int need = diff1 + diff1 + diff2;
                if (IsValid(remain - need)) {
                    return true;
                }
            }

            // t1 > t2 > t3
            int condition2 = played - diff1 - diff1 + diff2;
            if (IsValid(condition2)) {
                int need = diff1 + diff2;
                if (IsValid(remain - need)) {
                    return true;
                }
            }

            // t1 < t2 > t3
            int condition3 = played + diff1 + diff1 + diff2;
            if (IsValid(condition3)) {
                int need = diff1 + diff1 + diff2;
                if (IsValid(remain - need)) {
                    return true;
                }
            }

            // t1 > t2 < t3
            int condition4 = played - diff1 - diff1 - diff2;
            if (IsValid(condition4)) {
                int need;
                if (diff1 >= diff2) {
                    need = diff1 + diff1 - diff2;
                }
                else {
                    need = diff2 - diff1 + diff2;
                }

                if (IsValid(remain - need)) {
                    return true;
                }
            }

            return false;
        }

        private static bool IsValid(int number) {
            if (number >= 0 && number % 3 == 0) {
                return true;
            }

            return false;
        }
    }
}
