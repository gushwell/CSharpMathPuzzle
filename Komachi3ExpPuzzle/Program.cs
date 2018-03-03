﻿using System;

namespace Komachi3ExpPuzzle {
	
	class Program {
		
		static void Main(string[] args) {
			var sol = new Solver();
			foreach (var nums in sol.Solve()) {
				string s = $"答えは、{nums[0]}{nums[1]}-{nums[2]} = " +
					$"{nums[3]}{nums[4]}/{nums[5]} = {nums[6]}+{nums[7]}*{nums[8]} です。";
				Console.WriteLine(s);
			}
		}
	}
}
