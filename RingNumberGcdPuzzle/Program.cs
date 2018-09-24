﻿using System;
using System.Linq;

namespace RingNumberGcdPuzzle {
	class Program {
		static void Main(string[] args) {
			var dng = new RingNumberGcd();
			while (true) {
				var line = Console.ReadLine();
				if (line.Length == 8 && "12345678".All(c => line.Contains(c))) {
					Console.WriteLine();
					if (int.TryParse(line, out var num)) {
						Console.WriteLine(dng.Solve(num, PrintNumber).ToString());
					}
				} else {
					Console.WriteLine("1-8のすべての数字を使った8桁の数値を入れてください");
				}
				//break;
			}
		}

		// 8桁の数が求められるたびに呼び出される。
		private static void PrintNumber(int n) {
			Console.WriteLine(n.ToString());
		}
	}
}
