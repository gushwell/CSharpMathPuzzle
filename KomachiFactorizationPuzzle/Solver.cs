﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace KomachiFactorizationPuzzle {
	public class Solver {
		// 解を求める
		public IEnumerable<int[]> Solve() {
			return Solve(new int[0], Primes(100).ToArray());
		}

		// maxnumまでの素数を求める。 エラトステネスのふるいで求めている
		private static IEnumerable<int> Primes(int maxnum) {
			int[] sieve = Enumerable.Range(0, maxnum + 1).ToArray();
			sieve[1] = 0;  // 0 : 素数ではない
			int squareroot = (int)Math.Sqrt(maxnum);
			for (int i = 2; i <= squareroot; i++) {
				if (sieve[i] <= 0)
					continue;
				for (int n = i * 2; n <= maxnum; n += i)
					sieve[n] = 0;
			}
			return sieve.Where(n => n > 0);
		}


		// primesA 素因数分解した途中結果 (必ず小さい因数から順に並ぶ）
		// primesB 候補となる素数 （どんどん絞られてゆく）
		private IEnumerable<int[]> Solve(IEnumerable<int> primesA, IEnumerable<int> primesB) {
			// 素因数分解した結果を文字列にし、小町数かどうかを調べる
			var s = ToString(primesA);
			if (IsKomachi(s)) {
				yield return primesA.ToArray();
			} else {
				// 小町の可能性があるならば、PrimesBから一つ取り出し、
				// その因数を解PrimesAに加え、再帰処理してゆく。
				if (IsValid(s)) {
					foreach (var n in primesB) {
						var ans = Solve(primesA.Concat(new int[] { n }), primesB.SkipWhile(a => a <= n));
						foreach (var primes in ans)
							yield return primes;
					}
				}
			}
		}

		// 適合しているか （同じ数字があるとダメ）
		private bool IsValid(string s) {
			var length = s.Length;
			// 重複していれば、Distinctした個数とは一致しない
			return s.Distinct().Count() == length;
		}

		// int配列を文字列に変換
		private string ToString(IEnumerable<int> nums) {
			var s = "";
			foreach (var n in nums) {
				s += n.ToString();
			}
			return s;
		}

		// 小町数か、（引数は数値を文字列に変換したもの）
		private bool IsKomachi(string s) {
			if (s.Length != 9)
				return false;
			return s.OrderBy(c => c).SequenceEqual("123456789");
		}

	}
}
