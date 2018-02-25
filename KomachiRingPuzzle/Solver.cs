﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace KomachiRingPuzzle {
	public class Solver {
		public IEnumerable<int[]> Solve() {
			// nums は、_Solveの作業用領域
			var nums = new List<int>();
			return _Solve(nums);
		}

		// バックトラックにより、解を求める。
		private IEnumerable<int[]> _Solve(List<int> nums) {
			if (IsRight(nums)) {
				if (nums.Count() == 9) {
					// 解が求まった
					yield return nums.ToArray();
				} else {
					for (int i = 1; i <= 9; i++) {
						if (nums.Contains(i))
							continue;
						// i をリストに入れて試す
						nums.Add(i);
						// _Solveを再帰的に呼び出す。
						foreach (var ans in _Solve(nums))
							yield return ans.ToArray();
						// 次のiを試すために、iをリストから削除する。
						nums.Remove(i);
					}
				}
			}
			// 現在のnumsでの試行が終了した。
		}

		// ９つ揃っていなくても、途中までを判断する。
		// 完全な誤りならば、falseを返す。そうでないならば、trueを返す
		// 例えば、[4, 9, 1]というリストは、まだ間違いとは言えないので、trueが返る。
		// これを元に枝刈りをする。
		private bool IsRight(List<int> nums) {
			var ite = GetSums(nums).GetEnumerator();
			if (!ite.MoveNext())
				// まだ、海のものとも山のものともわからない。次を調べる必要があるから、trueを返す。
				return true;
			int sum = ite.Current;
			while (ite.MoveNext()) {
				if (sum != ite.Current)
					// 小町リングになっていない
					return false;
			}
			// 現時点で、小町リングになっている
			return true;
		}

		// numsの値をもとに、各リング内の合計を求める。
		// nums.Length ==9 ならば、5つの値(合計)が列挙される。
		private IEnumerable<int> GetSums(List<int> nums) {
			int length = nums.Count;
			if (length < 2)
				yield break;
			yield return nums[0] + nums[1];
			for (int i = 3; i < length; i += 2) {
				yield return nums[i - 2] + nums[i - 1] + nums[i];
			}
			if (length == 9)
				yield return nums[7] + nums[8];
		}
	}
}
