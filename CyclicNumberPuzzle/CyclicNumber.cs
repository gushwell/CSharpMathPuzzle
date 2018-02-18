using System;
using System.Collections.Generic;
using System.Linq;

namespace CyclicNumberPuzzle {
	public class CyclicNumber {
		private int multiplier;
		public CyclicNumber(int multiplier) {
			this.multiplier = multiplier;
		}

		// multiplier倍すると巡回する数を求める。
		public IEnumerable<int> Solve() {
			// 計算時間を考慮して、1-9999999までの自然数に限定しました。
			foreach (var num in Enumerable.Range(1, 10000000 / multiplier)) {
				if (IsCyclicNumber(num)) {
					yield return num;
				}
			}
		}

		// numが巡回数かどうかを調べる
		private bool IsCyclicNumber(int num) {
			string numstr = num.ToString();
			string result = (num * multiplier).ToString();
			// 速度を速めるための泥臭い判断  ここから ↓
			if (result.Length != numstr.Length)
				return false;
			foreach (var c in result)
				if (!numstr.Contains(c))
					return false;
			// ↑ ここまで （無くても正しく動作する）
			return (GetCyclics(num).Any(x => result == x));
		}

		// numを巡回させた数を文字列に変換し列挙する。
		private IEnumerable<string> GetCyclics(int num) {
			string s = num.ToString();
			for (int i = 0; i < s.Length - 1; i++) {
				s = s.Substring(1) + s[0];
				yield return s;
			}
		}
	}

}
