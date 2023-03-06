#!/usr/bin/env dotnet-script
using System;
using System.IO;
using System.Text;

string command ="echo test!!!";

//シェル実行用関数
string ExecShell(string cmd){
        var p = new Process();
        p.StartInfo.FileName = "/bin/bash";
        p.StartInfo.Arguments = "-c \" " + cmd + " \"";
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.Start();

        var output = p.StandardOutput.ReadToEnd();
        p.WaitForExit();
        p.Close();

        return output;
}


var output = ExecShell(command);
Console.WriteLine("実行結果="+output);

