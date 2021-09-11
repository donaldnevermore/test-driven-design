using System;
using Dotnet.Script;
using Dotnet.Script.Core;
using Dotnet.Script.Core.Commands;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Scripting.Hosting;
using CSScriptLib;

#region csscript

var source = @"using System;
               public class Script : ICalc
               {
                   public int Sum(int a, int b)
                   {
                       return a+b;
                   }
               }";

var calc = CSScript.Evaluator
    .LoadCode<ICalc>(source);
var result = calc.Sum(1, 2);
Console.WriteLine(result);

#endregion

#region dotnetscript

var logFactory = LogHelper.CreateLogFactory("debug");
var assemblyLoadContext = new ScriptAssemblyLoadContext();
var fileCommandOptions = new ExecuteScriptCommandOptions(
    new ScriptFile(AppContext.BaseDirectory + "data/Test.csx"),
    new[] { "" },
    OptimizationLevel.Debug,
    null,
    false,
    false
) {
    AssemblyLoadContext = assemblyLoadContext
};
var fileCommand = new ExecuteScriptCommand(ScriptConsole.Default, logFactory);
var res = await fileCommand.Run<int, CommandLineScriptGlobals>(fileCommandOptions);
Console.WriteLine(res);

#endregion

public interface ICalc {
    int Sum(int a, int b);
}
