using System;
using System.Linq;

namespace KomachiFactorizationPuzzle {
	class Program {
		static void Main(string[] args) {
			var solver = new Solver();
			foreach (var ans in solver.Solve()) {
				var s = ans.Aggregate((x, y) => x * y).ToString() +
						" = " +
						String.Join(" * ", ans);
				Console.WriteLine(s);
			}
		}
	}
}
