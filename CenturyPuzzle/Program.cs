using System;
using System.Text;

namespace CenturyPuzzle {
	class Program {
		static void Main(string[] args) {
			var solver = new Solver();
			var sb = new StringBuilder();
			foreach (var a in solver.Solve()) {
				sb.AppendFormat("{0} + {1} / {2} = 100\n",
								 a.WholeNumber, a.Numerator, a.Denominator);
			}
			Console.WriteLine(sb.ToString());
		}
	}
}
