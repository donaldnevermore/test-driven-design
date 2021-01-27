using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestDrivenDesign {
    public class MultiThread {
        private static bool done;
        private static readonly object locker = new object();

        public static void Run() {
            var signal = new ManualResetEvent(false);
            var thread = new Thread(() => {
                Console.WriteLine("Waiting for signal...");
                signal.WaitOne();
                signal.Dispose();
                Console.WriteLine("Got signal! ");
            });
            thread.Start();
            Thread.Sleep(2000);
            signal.Set();
            // Go();
        }

        public static void Test1() {
            for (var i = 0; i < 10; i++) {
                var temp = i;
                var thread = new Thread(() => { Console.Write(temp); });
                thread.Start();
            }
        }

        public static void Test2() {
            var text = "t1";
            var t1 = new Thread(() => { Console.Write(text); });
            text = "t2";
            var t2 = new Thread(() => { Console.Write(text); });
            t1.Start();
            t2.Start();
        }

        public static async void Test3() {
            Console.WriteLine(1);
            var n = await Task.Run(() => {
                Console.WriteLine(2);
                return 3;
            });
            Console.WriteLine(n);
        }

        private static void Go() {
            lock (locker) {
                if (!done) {
                    Console.WriteLine("Done.");
                    done = true;
                }
            }
        }

        private static void Go2() {
            try {
                throw null;
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
