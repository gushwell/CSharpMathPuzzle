﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RingNumberGcdPuzzle {
	public class RingNumberGcd {

		// ８ケタの整数から得られる16個の数の最大公約数は
		public int Solve(int baseNumber, Action<int> callBack) {
			int gcd = 0;
			int a = baseNumber;
			callBack(a);
			foreach (var b in GetNumbers(a).Skip(1)) {
				callBack(b);
				gcd = Gcd(a, b);
				a = gcd;
			}
			return gcd;
		}

		// ８桁の整数から、１６個の８ケタの整数を列挙する。
		private IEnumerable<int> GetNumbers(int num) {
			string s = num.ToString();                      // 右回り用
			string rs = new string(s.Reverse().ToArray());  // 左回り用
			return _GetNumbers(s).Concat(_GetNumbers(rs));
		}

		// GetNumbersの下請けメソッド 右回りの８つの数を列挙する
		private IEnumerable<int> _GetNumbers(string s) {
			yield return int.Parse(s);
			for (int i = 0; i < 7; i++) {
				s = RotateShift(s);
				yield return int.Parse(s);
			}
		}

		// 右へローテートシフト
		private string RotateShift(string s) {
			var s1 = new string(s.Skip(1).ToArray());
			return s1 + s[0];
		}

		// ユークリッドの互除法によるGCD 
		static int Gcd(int a, int b) {
			if (a < b)
				return Gcd(b, a);  // 引数を入替えて自分を呼び出す  
			int d = 0;
			do {
				d = a % b;
				a = b;
				b = d;
			} while (d != 0);
			return a;
		}
	}
}
