﻿using System;

namespace Triangle15Puzzle {
	class Program {
		static void Main(string[] args) {
			int steps = 5;
			var solver = new Solver(steps);

			foreach (var tri in solver.Solve()) {
				tri.Print();
			}
		}
	}
}
