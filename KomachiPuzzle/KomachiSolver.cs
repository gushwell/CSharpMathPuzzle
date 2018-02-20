﻿using System;
using System.Linq;

namespace KomachiPuzzle {
	class KomachiSolver {
		private string[] operators = { "", "+", "-" };
		public int Solve() {
			var q = from c1 in operators
					from c2 in operators
					from c3 in operators
					from c4 in operators
					from c5 in operators
					from c6 in operators
					from c7 in operators
					from c8 in operators
					select new { c1, c2, c3, c4, c5, c6, c7, c8 };
			int count = 0;
			foreach (var x in q) {
				string exp = string.Format("1{0}2{1}3{2}4{3}5{4}6{5}7{6}8{7}9",
					x.c1, x.c2, x.c3, x.c4, x.c5, x.c6, x.c7, x.c8);
				var r = (int)Expression.Calculate(exp);
				if (r == 100) {
					Console.WriteLine(exp);
					count++;
				}
			}
			return count;
		}
	}
}
