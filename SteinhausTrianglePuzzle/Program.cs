using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteinhausTrianglePuzzle {
	class Program {
		static void Main(string[] args) {
			var str = Console.ReadLine();
			if (int.TryParse(str, out var width) == false)
				return;
			var sol = new SteinhausTriangle(width);
			var r = sol.Triangles();
			PrintResult(r);

		}

		private static void PrintResult(IEnumerable<bool[][]> result) {
			var sb = new StringBuilder();
			int n = 0;
			foreach (var tr in result) {
				var s = string.Format("({0})\n", ++n);
				int spacecnt = 2;
				foreach (var line in tr) {
					s += new string(' ', spacecnt) +
						line.Aggregate("", (t, c) => t + (c ? "1" : "0") + " ") +
						"\n";
					spacecnt++;
				}
				sb.AppendLine(s);
			}
			if (sb.Length == 0)
				Console.WriteLine("ステインハウスの三角形はありません");
			else
				Console.WriteLine(sb.ToString());
		}
	}
}
