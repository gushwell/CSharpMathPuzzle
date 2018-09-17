﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SteinhausTrianglePuzzle {
	public class SteinhausTriangle {
		private int _width;

		public SteinhausTriangle(int n) {
			this._width = n;
		}

		public IEnumerable<bool[][]> Triangles() {
			int maxcount = (int)Math.Pow(2, _width);
			foreach (var baseline in Enumerable.Range(0, maxcount)) {
				if (IsSteinhausTriangle(baseline, _width))
					yield return MakeTriangle(baseline, _width);
			}
		}

		// 三角形を作る
		private bool[][] MakeTriangle(int baseline, int width) {
			// int型のまま処理するのは、面倒なので、bool[]に変換して処理をする。
			bool[] line = ToArray(baseline, width);
			var triangle = new List<bool[]>();
			while (line.Length >= 1) {
				triangle.Add(line);
				line = NextLine(line);
			}
			return triangle.ToArray();
		}

		// ステインハウスの三角形かどうかを調べる
		private bool IsSteinhausTriangle(int baseline, int width) {
			// int型のまま処理するのは、面倒なので、bool[]に変換して処理をする。
			bool[] line = ToArray(baseline, width);
			if (!NeedCount(line))   // 鏡像を考慮する。
				return false;
			int tcount = 0;   // 1の数
			int fcount = 0;   // 0の数
			while (line.Length >= 1) {
				tcount += line.Where(b => b == true).Count();
				fcount += line.Where(b => b == false).Count();
				line = NextLine(line);
			}
			return tcount == fcount;
		}


		// 鏡像をカウントしないようにするための判定メソッド
		private bool NeedCount(bool[] line) {
			if (IsRound(line))
				// 左右対称ならば、他に鏡像となるパターンはないので、これは調べる必要がある。
				return true;
			// 左右対称でないならば、鏡像のパターンが他にもうひとつあるので、
			// 片方だけを調べるようにする。
			return ToInt(line.Reverse().ToArray()) > ToInt(line);
		}

		// ビットパターンが左右対称かどうかを調べる
		private bool IsRound(bool[] line) {
			int j = line.Length - 1;
			int i = 0;
			while (i < j) {
				if (line[i++] != line[j--]) {
					return false;
				}
			}
			return true;
		}

		// bool[]をビットパターンとみなし、intに変換する
		private int ToInt(bool[] line) {
			return line.Aggregate(0, (r, b) => r * 2 + (b ? 1 : 0));
		}

		// 整数nを width個からなるbool配列に変換する
		public bool[] ToArray(int n, int width) {
			var array = new bool[width];
			int mask = 1;
			width.Times(i => {
				array[i] = (n & mask) != 0;
				mask <<= 1;
			});
			return array;
		}

		// 1段下のラインを排他的論理和を使い求める
		private bool[] NextLine(bool[] line) {
			var next = new bool[line.Length - 1];
			int i = 0;
			// ここで、Aggregateを使うのは邪道かな？
			line.Aggregate((a, b) => {
				next[i++] = a ^ b;
				return b;
			});
			return next;
		}
	}
}
