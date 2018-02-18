using System;
using System.Collections.Generic;

namespace PalindromicSquarePuzzle {

	public class PalindromicSquare {

		private bool IsPalindrome(long num) {
			string s = num.ToString();
			int len = s.Length;
			int rx = len - 1;
			int lx = 0;
			while (lx < len / 2)
				if (s[lx++] != s[rx--])
					return false;
			return true;
		}

		public IEnumerable<int> Solve(int maxnum) {
			for (var i = 1; i <= maxnum; i++) {
				if (IsPalindrome((long)i * i) && !IsPalindrome(i))
					yield return i;
			}
		}
	}
}
