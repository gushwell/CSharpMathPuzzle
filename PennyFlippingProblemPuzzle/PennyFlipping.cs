﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace PennyFlippingProblemPuzzle {
	public class PennyFlipping {
		private int _number;
		// falseが表
		private bool[] _disks;

		public PennyFlipping(int n) {
			_number = n;
			_disks = new bool[n];
		}


		// 問題を解く 
		public IEnumerable<(int, bool[])> Solve() {
			int count = 0;
			foreach (var n in Repeat(Enumerable.Range(1, _number))) {
				Turn(n);
				yield return (n, _disks.ToArray());
				count++;
				if (IsFin())
					break;
			}
		}

		// 1,2,3,...n,1,2,3,...n,1,2,3,...nを永遠に繰り返す
		private IEnumerable<int> Repeat(IEnumerable<int> nums) {
			while (true) {
				foreach (var n in nums)
					yield return n;
			}
		}

		// 先頭N枚のコインをひっくり返す。
		public void Turn(int n) {
			var r = _disks.Take(n).Reverse().ToArray();
			for (int i = 0; i < n; i++) {
				_disks[i] = !r[i];
			}
		}

		// 終了したかどうか
		public bool IsFin() {
			return _disks.All(d => d == false);
		}
	}
}
