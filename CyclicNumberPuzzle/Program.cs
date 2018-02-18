using System;
using System.Linq;

namespace CyclicNumberPuzzle {
	class Program {
		static void Main(string[] args) {
			for (var multiplier = 2; multiplier < 10; multiplier++) {
				Console.WriteLine($"{multiplier}倍");
				CyclicNumber cn = new CyclicNumber(multiplier);
				var ans = cn.Solve().ToList();
				foreach (var num in ans) {
					Console.WriteLine($"{num} * {multiplier} = {num * multiplier}");
				}
				if (ans.Count == 0) {
					Console.WriteLine("見つかりませんでした");
				}
			}
			Console.WriteLine("end.");
		}
	}
}
