using System;
using System.Collections.Generic;
using System.Linq;

namespace RisingEmirpNumbersPuzzle {
    
    public class RisingEmirpNumbers {
        // 問題を解く 答えは文字列として列挙する
        public IEnumerable<string> Solve() {
            int[] nums = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var s in GetRisingNumbers("", nums)) {
                if (IsEmirp(s))
                    yield return s;
            }
        }

        // 上昇数 を求める 再帰メソッドの中で、yield return を使っている。
        private IEnumerable<string> GetRisingNumbers(string rn, IEnumerable<int> nums) {
            if (nums.Count() == 0)
                yield break;
            int i = 0;
            foreach (var n in nums) {
                i++;
                string s = rn + n.ToString();
                yield return s;
                foreach (var r in GetRisingNumbers(s, nums.Skip(i)))
                    yield return r;
            }
        }

        // エマープか？
        private bool IsEmirp(string s) {
            if (s.Length >= 2 &&
                PrimeNumber.IsPrime(long.Parse(s)) &&
                PrimeNumber.IsPrime(long.Parse(ReverseString(s))))
                return true;
            return false;
        }

        // 文字列を反転する
        private string ReverseString(string s) {
            return new string(s.Reverse().ToArray());
        }
    }
}
