using System;
using System.Diagnostics;

namespace PalindromicSquarePuzzle {

	class Timewatch : IDisposable {
		private Stopwatch sw = new Stopwatch();

		public Timewatch() {
			sw.Start();
		}
		public void Dispose() {
			sw.Stop();
			Console.WriteLine($"{sw.ElapsedMilliseconds}ミリ秒 (約{sw.Elapsed.TotalSeconds:#.0}秒)");
		}
	}
}
