using System;
using System.Linq;

namespace RisingEmirpNumbersPuzzle {
    class Program {
        static void Main(string[] args) {
            var solver = new RisingEmirpNumbers();
            foreach (var n in solver.Solve().OrderBy(s => s.Length))
                Console.WriteLine(n);
        }
    }
}
