﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace KomachiPuzzle {

	public class Expression {

		private const string _sourceCode = @"
        using System;
        namespace Gushwell {{
            public class ExpressionCalculator {{
                public object Calculate() {{
                    return {0};
                }}
            }}
        }}";


		public static object Calculate(string exp) {
			var sourceCode = CreateSourceCode(exp);
			var compilation = CreateCompilation(sourceCode);
			return RunCode(compilation);
		}


		private static object RunCode(CSharpCompilation compilation) {
			using (var ms = new MemoryStream()) {
				EmitResult result = compilation.Emit(ms);

				if (result.Success) {
					ms.Seek(0, SeekOrigin.Begin);
					var assembly = AssemblyLoadContext.Default.LoadFromStream(ms);
					var instance = assembly.CreateInstance("Gushwell.ExpressionCalculator");
					var type = assembly.GetType("Gushwell.ExpressionCalculator");
					var method = type.GetMember("Calculate").First() as MethodInfo;
					var ans = method.Invoke(instance, null);
					return ans;
				} else {
					IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
						diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error);
					string message = "";
					foreach (var diagnostic in failures) {
						message += $"\t{diagnostic.Id}: {diagnostic.GetMessage()}";
					}
					throw new InvalidOperationException(message);
				}
			}
		}

		private static CSharpCompilation CreateCompilation(string sourceCode) {
			var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

			string assemblyName = Path.GetRandomFileName();
			var references = new MetadataReference[] {
			MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location)
		};
			var compilation = CSharpCompilation.Create(
				assemblyName,
				syntaxTrees: new[] { syntaxTree },
				references: references,
				options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
			return compilation;
		}

		private static string CreateSourceCode(string exp) {
			return string.Format(_sourceCode, exp);
		}
	}

}
