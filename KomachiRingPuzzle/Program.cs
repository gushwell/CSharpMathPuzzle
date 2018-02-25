using System;
using System.Linq;

namespace KomachiRingPuzzle {
	class Program {
		static void Main(string[] args) {
			Solver solver = new Solver();
			foreach (var ans in solver.Solve()) {
				var s = ans.Aggregate("", (r, n) => r + $"[{n}] ");
				Console.WriteLine(s);
			}

		}
	}
}
