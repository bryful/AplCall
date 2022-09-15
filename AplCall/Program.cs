// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

#pragma warning disable CS8600
namespace AplCall // Note: actual namespace depends on the project name.
{
	internal class Program
	{
		static string CallExePath()
		{
			string ret = "";
			string fullName = Environment.ProcessPath;
			string d = Path.GetDirectoryName(fullName);
			string n = Path.GetFileNameWithoutExtension(fullName);
			string e = Path.GetExtension(fullName);

			string nn = n;
			if (n.IndexOf("Call") >= 0) nn = n.Replace("Call", "");
			else if (n.IndexOf("call") >= 0) nn = n.Replace("call", "");
			else if (n.IndexOf("CALL") >= 0) nn = n.Replace("call", "");
			if (nn == n) return ret;

			ret = Path.Combine(d, nn + e);
			return ret;
		}
		static void Main(string[] args)
		{
			string opt = "";
			if (args.Length > 0)
			{
				for (int i = 0; i < args.Length; i++)
				{
					if (opt != "") opt += " ";
					opt += "\"" + args[i] + "\"";
				}
			}

			string n = CallExePath();
			Console.WriteLine(n);
			if (File.Exists(n) == false)
			{
				Console.WriteLine("[APleCall]");
				Console.WriteLine("opt: "+ opt);
				return;
			}
			else
			{
				using Process proc = new Process();
				proc.StartInfo.FileName = n;
				proc.StartInfo.Arguments = opt;
				if (proc.Start())
				{
					//Console.WriteLine("exec!");
				}
				//Console.WriteLine("fin");
				return;
			}
		}
	}
}
#pragma warning restore CS8600
