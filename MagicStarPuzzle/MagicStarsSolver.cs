using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicStarPuzzle {
	public class MagicStarsSolver {
		// 解が入る配列
		private int[] _star = new int[12];

		// 対称性を省くためのDictionary
		private Dictionary<int, int> _ansPos0 = new Dictionary<int, int>();

		// 位置0 を除いた直線の端の位置を示す。対称性を省くために利用 
		private int[] _tipIndexes = { 1, 4, 7, 10, 11 };

		public IEnumerable<int[]> Solve() {
			// 〇の中に入れる数字1,2,3,...12 を生成して、_Solveを呼ぶ。
			return _Solve(Enumerable.Range(1, 12));
		}

		private IEnumerable<int[]> _Solve(IEnumerable<int> rest) {
			int count = rest.Count();
			if (count == 0) {
				if (IsAnswer()) {
					_ansPos0[_star[0]] = 1; // 位置0に置いた番号を記憶する 対称性排除のため
					yield return _star.ToArray();
				}
				yield break;
			}
			if (IsCorrect()) {
				int nextix = 12 - count;
				foreach (var n in rest) {
					// 回転して得られる対称解を省く
					if (_tipIndexes.Contains(nextix) && _ansPos0.ContainsKey(n))
						continue;

					_star[nextix] = n;
					foreach (var ans in _Solve(rest.Where(x => x != n)))
						yield return ans;
					_star[nextix] = 0;
				}
			}
		}

		// 解か？
		public bool IsAnswer() {
			return GetLines(_star).All(line => line.Sum() == 26);
		}

		// 正しいか （途中の状態を調べる）
		public bool IsCorrect() {
			foreach (var line in GetLines(_star)) {
				// 26より大きければダメ
				if (line.Sum() > 26)
					return false;
				// 直線に数字が全て埋まっていて、26より小さければダメ
				if (line.All(x => x > 0) && line.Sum() < 26)
					return false;
				// 鏡像を省く
				if ((_star[2] != 0 && _star[3] != 0) && (_star[2] > _star[3]))
					return false;
			}
			return true;
		}

		// 6本の直線を列挙する
		public IEnumerable<int[]> GetLines(int[] stars) {
			yield return new int[] { stars[0], stars[2], stars[5], stars[7] };
			yield return new int[] { stars[0], stars[3], stars[6], stars[10] };
			yield return new int[] { stars[1], stars[2], stars[3], stars[4] };
			yield return new int[] { stars[1], stars[5], stars[8], stars[11] };
			yield return new int[] { stars[7], stars[8], stars[9], stars[10] };
			yield return new int[] { stars[4], stars[6], stars[9], stars[11] };
		}
	}
}
