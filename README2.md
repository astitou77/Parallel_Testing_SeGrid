# Selenium Grid

## 5. PERFORMANCE

> PERFORMANCE :

```bash
# 1. TRACE PERFORMANCE : 
> dotnet tool install --global dotnet-trace
> dotnet-trace collect -p <PID> --duration 00:00:10 --format speedscope

# Visualize results in :
# [A] https://www.speedscope.app/ or 
# [B] Google Chrome's --->  chrome://tracing


# 2. ANALYZE .NET DUMPS :
dotnet tool install --global dotnet-symbol
dotnet-symbol --symbols --modules --debugging <dump-file-path>

# Analyze .NET dumps with : 
# [A] lldb or dotnet-dump
# [B] https://learn.microsoft.com/en-us/dotnet/core/diagnostics/dotnet-symbol
```


### 5.1 CLI TOOLS

```bash
# [0] Find .NET CLI Tool

# [1] Install .NET CLI Tool
> dotnet tool install --global dotnetsay
> dotnet tool list --global
> dotnet tool uninstall --global dotnetsay

> dotnet new tool-manifest
> dotnet tool install dotnetsay
> dotnet tool restore
```

Here's a fact[^1]
[^1]: This is the footnote.


- [x] Done	
- [x] Done	
- [x] Done	

![Demo](https://media.giphy.com/media/xyz123/giphy.gif)



## 6. TODO

```bash
> dotnet msbuild	                                            # Accesses MSBuild directly for advanced build scenarios
> dotnet exec                                                   # for ordinary projects with 'main()' method
> dotnet workload install		                                # Create a NuGet Package MySolution
```