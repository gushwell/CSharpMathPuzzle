using System;

namespace PalindromicSquarePuzzle {
	class Program {

		static void Main(string[] args) {
			using (new Timewatch()) {
				var solver = new PalindromicSquare();
				foreach (var n in solver.Solve(100000000)) {
					Console.WriteLine($"{n} * {n} = {(long)n * n}");
				}
			}
		}
	}
}
