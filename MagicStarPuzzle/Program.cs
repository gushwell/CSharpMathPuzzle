﻿using System;
using System.Collections.Generic;

namespace MagicStarPuzzle {
	class Program {
		static void Main(string[] args) {
			var solver = new MagicStarsSolver();
			var answers = solver.Solve();
			foreach (var (ans, i) in answers.Enumerate(1)) {
				Console.WriteLine($"#{i}");
				Print(ans);
			}
		}

		private static void Print(int[] stars) {
			Console.WriteLine("      ({0,2})", stars[0]);
			Console.WriteLine("({0,2})({1,2})({2,2})({3,2})", stars[1], stars[2], stars[3], stars[4]);
			Console.WriteLine("  ({0,2})    ({1,2})", stars[5], stars[6]);
			Console.WriteLine("({0,2})({1,2})({2,2})({3,2})", stars[7], stars[8], stars[9], stars[10]);
			Console.WriteLine("      ({0,2})", stars[11]);
			Console.WriteLine();
		}
	}

	// これはちょっとしたお遊び。
	// こんな拡張メソッド書けば、インデックス付きのforeachができる。
	static class EnumerableExtensions {
		public static IEnumerable<(T, int)> Enumerate<T>(this IEnumerable<T> seq, int startIndex) {
			var i = startIndex;
			foreach (var e in seq) {
				yield return (e, i);
				i++;
			}
		}
	}
}
