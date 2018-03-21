using System;
using System.Collections.Generic;
using System.Linq;

namespace CenturyPuzzle {
	
	public class Solver {
		public IEnumerable<Answer> Solve() {
			// CenturyPuzzle
			// 整数部を基準にして、総当りで求めている
			for (int k = 1; k <= 99; k++) {
				var x = 100 - k;     // X == N / D
				var denominator = 1; // 分母 もっと大きな数から始められるはずだが...
				while (true) {
					// 分子  K + N / D = 100 となる N を求めている --> N = D * (100 - K)  
					var numerator = denominator * x;
					var frac = $"{k}{numerator}{denominator}";
					if (frac.Length > 9)
						// これ以上やっても解はない。小町にはならない
						break;
					if (IsKomachi(frac)) {
						yield return new Answer {
							WholeNumber = k,
							Numerator = numerator,
							Denominator = denominator
						};
					}
					denominator++;
				}
			}
		}

		// 小町数か、（引数は数値を文字列に変換したもの）
		private bool IsKomachi(string s) {
			return s.OrderBy(c => c).SequenceEqual("123456789");
		}
	}
}
