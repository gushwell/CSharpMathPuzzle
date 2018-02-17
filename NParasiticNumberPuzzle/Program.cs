using System;

namespace NParasiticNumberPuzzle {
    
    class Program {
        static void Main(string[] args) {
            var pn = new NParasiticNumber();
            for (int n = 1; n <= 9; n++) {
                var ans = pn.Get(n);
                Console.WriteLine("{0}: {1}", n, ans);
            }
        }
    }
}
