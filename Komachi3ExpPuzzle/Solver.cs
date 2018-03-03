﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Komachi3ExpPuzzle {
	
	public class Solver {
		public IEnumerable<int[]> Solve() {
			var nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			return _Solve<int>(nums);
		}

		private IEnumerable<int[]> _Solve<T>(IEnumerable<int> nums) {
			var perm = new Permutation();
			foreach (var n in perm.Enumerate(nums)) {
				var array = n.ToArray();
				if (IskomachiExp(array))
					yield return array;
			}
		}

		// 「○○ー○ = ○○ / ○ ＝ ○ ＋ ○ × ○ 」が成り立つかを調べる
		// nums.Length は9であることが保証されている
		private bool IskomachiExp(int[] nums) {
			var a = nums[0] * 10 + nums[1];
			var b = nums[2];
			var x = a - b;
			var c = nums[3] * 10 + nums[4];
			var d = nums[5];
			var y = c / d;
			if (x != y)
				return false;
			if (y * d != c) // yは切り捨てされるので、ここで、再度チェック
				return false;
			var e = nums[6];
			var f = nums[7];
			var g = nums[8];
			if (x != e + f * g)
				return false;
			return true;
		}
	}
}
