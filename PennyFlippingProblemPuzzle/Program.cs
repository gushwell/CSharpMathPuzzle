﻿using System;
using System.Linq;

namespace PennyFlippingProblemPuzzle {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("コインの枚数は?");
			var line = Console.ReadLine();
			if (int.TryParse(line, out var number)) {
				number = Math.Max(3, Math.Min(20, number));
				var pf = new PennyFlipping(number);
				var result = pf.Solve().ToArray();
				foreach ((var n, var coins) in result) {
					PrintDisks(n, coins);
				}
				Console.WriteLine($"{result.Length}手で元に戻る");
			}
		}

		private static void PrintDisks(int count, bool[] coins) {
			string s = string.Format("({0,2}枚) : ", count);
			foreach (var d in coins) {
				s += (d ? "1 " : "0 ");
			}
			Console.WriteLine(s); ;
		}
	}
}
