using System;

namespace KomachiPuzzle {
	class Program {
		static void Main(string[] args) {
			KomachiSolver sol = new KomachiSolver();
			int n = sol.Solve();
			Console.WriteLine("{0}個の解が見つかりました", n);
			Console.ReadLine();
		}
	}
}
