﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Triangle15Puzzle {
	class Solver {
		private Triangle _triangle;

		private int _steps;

		private List<int> _baseLine = new List<int>();  // 一番上の段の数字列

		public Solver(int n) {
			_steps = n;
			_triangle = new Triangle(n);
		}

		public IEnumerable<Triangle> Solve() {
			return _Solve(0, Enumerable.Range(1, _triangle.TotalCount));
		}

		private IEnumerable<Triangle> _Solve(int count, IEnumerable<int> rest) {
			if (count == _steps) {
				_triangle.BuildFrom(_baseLine);  // baeLineから三角形を作る
				if (_triangle.IsCorrect()) {     // 作成した三角形が条件を満たすか調べる
					yield return _triangle;
				}
				yield break;
			}
			if (IsPopssible()) { // この判定は、速度アップのため （不要な探索は行わないようにする）
				foreach (var a in rest) {
					_baseLine.Add(a);
					var results = _Solve(count + 1, rest.Where(n => n != a));
					foreach (var t in results)
						yield return t;
					_baseLine.Remove(a);
				}
			}
		}

		private bool IsPopssible() {
			// 引き算をして得られた数が、baseLineにある数と同じならばダメ。
			var q = from n in _baseLine
					join m in Diff(_baseLine) on n equals m
					select m;
			return !q.Any();
		}

		static IEnumerable<int> Diff(IEnumerable<int> xs) {
			var ite = xs.GetEnumerator();
			if (ite.MoveNext())
				for (int prev = ite.Current; ite.MoveNext(); prev = ite.Current) {
					yield return ite.Current - prev;
				}
		}
	}

	class Triangle {
		private int _steps;

		private List<int> _list = new List<int>();

		public int TotalCount { get; private set; } = 0;

		public Triangle(int side) {
			_steps = side;
			TotalCount = Enumerable.Range(1, _steps).Sum();
		}

		public void Add(int n) {
			_list.Add(n);
		}

		public void Remove(int n) {
			_list.Remove(n);
		}

		public int this[int x, int y] {
			get {
				int index = Enumerable.Range(1, _steps).Reverse().Take(x).Sum() + y;
				if (index < TotalCount && index < _list.Count)
					return _list[index];
				return 0;
			}
		}

		public int this[int index] {
			get { return _list[index]; }
		}

		public bool IsCorrect() {
			return Enumerable.Range(1, TotalCount).SequenceEqual(_list.OrderBy(n => n));
		}

		public void BuildFrom(List<int> baseLine) {
			_list = baseLine.ToList();
			int col = _steps;
			for (int i = 0; i < _steps - 1; i++) {
				for (int j = 0; j < _steps - i - 1; j++) {
					int a = this[i, j];
					int b = this[i, j + 1];
					int c = Math.Abs(a - b);
					_list.Add(c);
				}
			}
		}

		public void Print() {
			for (var i = 0; i < _steps; i++) {
				for (var j = 0; j < _steps - i; j++)
					Console.Write("{0,3}", this[i, j]);
				Console.WriteLine();
			}
		}
	}
}