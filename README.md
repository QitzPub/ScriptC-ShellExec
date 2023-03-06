# 概要

こちらはC#のインタプリタ（今時のC#はインタプリタで実行できる！すごい）

をつかいつつ、さらにShellも実行するぜ！という内容となっています。

要は使い慣れたC#でバッチ処理を書きつつ、Shellの便利なコマンド（gitとかcurlとか・・・）

も使ってバッチ処理を行いたい！というときに使えるプロジェクトとなっています。

# 環境構築

## dotnet-script のインストール

```
dotnet tool install -g dotnet-script
```

以下コマンドが通るようになっていればOK

```
dotnet script
```

試しに本スクリプト実行する

```
dotnet script ./shell_exec.csx
```

↓

```
実行結果=test!!!
```

と出力されればOK!

# スクリプト解説

```C#
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
```

シェル実行用関数が定義されており、実行結果を受け取ることができます。

commandは"echo test!!!"が初期で設定されているので、任意のコマンド（git やcurlなど）に書き換えて対応をおこなえばOKです。

# 他

インテリセンス・入力補完を聞かせたい時
https://qiita.com/Midoliy/items/a033b763399c242dc5c5
に沿って対応しVisualStudioで.csxをひらけばOK
