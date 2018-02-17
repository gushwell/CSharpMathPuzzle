using System;
using System.Collections.Generic;
using System.Linq;

namespace NParasiticNumberPuzzle {
    
    public class NParasiticNumber {
        public string Get(int n) {
            var candidates = Candidates(n).ToArray();
            var min = candidates.Min(s => s[0]);
            return candidates.First(x => x[0] == min);
        }

        public IEnumerable<string> Candidates(int n) {
            var found = false;
            for (int digits = 1; digits < int.MaxValue; digits++) {
                for (int i = 1; i <= 9; i++) {
                    var candidate = GetCandidate(n, i, digits);
                    if (candidate != null) {
                        yield return candidate;
                        found = true;
                    }
                }
                if (found == true)
                    break;
            }
        }

        // 1桁目がfirstDigitであるn-Parasitic_numberを求める。
        // ただし、最大桁はmaxDigitsまでとし、これを超えたら、nullを返す。
        private string GetCandidate(int n, int firstDigit, int maxDigits) {
            int b = firstDigit;            // 求める数値の現時点での最上位桁の数
            string r = b.ToString();       // 求める数を文字列として保持
            int carry = 0;                 // 繰り上がりの数
            while (true) {
                // 例えば N=6,firstDigit=4の場合、最初のループでは、
                int a = b * n + carry;     //   a <- 24 (= 6 * 4 + 0)
                int m = a % 10;            //   m <- 4 (= 24 % 10)
                carry = a / 10;            //   carry <- 2 (= 24 / 10)
                b = m;                     //   現時点での最上位の桁の数は 4 である。
                if (carry == 0 && b == firstDigit && r[0] != '0')
                    break;
                r = b.ToString() + r;
                if (r.Length > maxDigits)
                    return null;
            }
            return r;
        }

    }
}
