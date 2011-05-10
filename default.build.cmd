@echo off


tools\AutoBuild\nant\nant -f:PairTracker.build -D:configuration=release

pause