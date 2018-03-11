using System;
using System.Linq;

namespace KomachiSquarePuzzle {
	
	class Program {
		static void Main(string[] args) {
			foreach (var n in Enumerable.Range(100, 900).Where(n => IsKomachi(n)))
				Console.WriteLine($"{n}の2乗 = {n * n}");
		}

		// LINQバージョン
		static private bool IsKomachi(int n) {
			string s = n.ToString() + (n * n).ToString();
			return "123456789".All(c => s.Contains(c));
		}

		// 非LINQバージョン
		static private bool IsKomachiWithoutLinq(int n) {
			char[] array = (n.ToString() + (n * n).ToString()).ToArray();
			Array.Sort(array);
			var s = new string(array);
			return s == "123456789";
		}

	}
}
