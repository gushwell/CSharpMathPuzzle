using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomachiUnitFraction {
	class Program {
		static void Main(string[] args) {
			// n が2～9までのすべての場合の、解を求め、プリントする
			for (var denominator = 2; denominator <= 9; denominator++) {
				var ans = UnitFractionKomachi.Solve(denominator);
				PrintResult(denominator, ans);
			}
		}

		// n == denominatorの時の解をプリントする
		private static void PrintResult(int denominator, IEnumerable<int> numerators) {
			StringBuilder sb = new StringBuilder();
			int i = 1;
			foreach (var n in numerators) {
				int den2 = n * denominator;
				sb.AppendFormat("{0,2} : {1} / {2} = 1 / {3}\n", i++, n, den2, denominator);
			}
			Console.WriteLine(sb.ToString());
		}
	}


	static class UnitFractionKomachi {
		// denominator 分母 2-9 まで
		// 1/denominatorとなる小町数を求める
		// 単位分数の分母が 2-9までの場合は、小町数になる分数の分子と分母は、４桁/5桁になる
		public static IEnumerable<int> Solve(int denominator) {
			// 小町数で単位分数
			for (int m = 1000; m <= 9876; m++) {
				string s = (denominator * m).ToString() + m.ToString();
				if (s.OrderBy(c => c).SequenceEqual("123456789")) {
					yield return m;
				}
			}
		}
	}
}
