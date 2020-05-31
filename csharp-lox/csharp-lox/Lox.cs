using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;


namespace csharp_lox
{
  public class Lox
  {
    private static bool _hadError = false;
    
    static void Main(string[] args)
    {
      if (args.Length > 1)
      {
        Console.WriteLine("usage clox [file]");
        Environment.Exit(65);
      } else if (args.Length == 1)
      {
        RunFile(args[0]);
      }
      else
      {
        RunPrompt();
      }
    }

    private static void RunFile(string path)
    {
      if(File.Exists(path))
        Run(File.ReadAllText(path));
      
      if(_hadError) Environment.Exit(65);
    }

    // ReSharper disable FunctionNeverReturns
    private static void RunPrompt()
    {
      for (;;)
      {
        Console.WriteLine("> ");
        Run(Console.ReadLine());
        _hadError = false;
      }
    }

    private static void Run(string source)
    {
      var scanner = new Scanner(source);
      List<Token> tokens = scanner.ScanTokens();
      
      tokens.ForEach(token =>
      {
        Console.WriteLine(token);
      });
    }

    public static void Error(int line, string message)
    {
      Report(line, "", message);
    }

    private static void Report(int line, string where, string message)
    {
      Console.WriteLine("[line " + line + "] Error" + where + ":" + message);
    }
  }
}