using System;
using System.Collections.Generic;
using System.Linq;

namespace Komachi3ExpPuzzle {
	
	public class Permutation {
		
		public IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items) {
			return _GetPermutations<T>(new List<T>(), items.ToList());
		}

		private IEnumerable<T[]> _GetPermutations<T>(IEnumerable<T> perm, IEnumerable<T> items) {
			if (items.Count() == 0) {
				yield return perm.ToArray();
			} else {
				foreach (var item in items) {
					var result = _GetPermutations<T>(perm.Concat(new T[] { item }),
														items.Where(x => x.Equals(item) == false)
									);
					foreach (var xs in result)
						yield return xs.ToArray();
				}
			}
		}

		internal int[] ToArray() {
			throw new NotImplementedException();
		}
	}
}
