using System;

namespace FourDigitReverseNumberPuzzle {
	class Program {
		static void Main(string[] args) {
			for (int n = 1000; n < 9999; n++) {
				int r = ReverseNumber(n);
				if (n != r && (n % r == 0) && (r > 1000))
					Console.WriteLine(n);
			}
		}

		private static int ReverseNumber(int n) {
			int ans = 0;
			while (n > 0) {
				int remainder = n % 10;
				ans = ans * 10 + remainder;
				n /= 10;
			}
			return ans;
		}
	}
}
