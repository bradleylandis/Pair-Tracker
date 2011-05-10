@echo off


start tools\WinTail\WinTail.exe temp\TestResult.txt

tools\AutoBuild\AutoBuild.Console.exe ".\src" "PairTracker.build"

pause