using System;
using System.Collections.Generic;

namespace SteinhausTrianglePuzzle {
	public static class EnumerableExtensions {
		// 要素の数だけ、actionを呼び出す
		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
			foreach (var x in source) {
				action(x);
			}
		}

		// n回、actionを呼び出す
		public static void Times(this int count, Action<int> action) {
			for (int i = 0; i < count; i++)
				action(i);
		}
	}

}
