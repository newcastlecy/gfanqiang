:: gfangqiang-debug.bat
:: Main Batch File - Debug
   
@echo off
title Starting GFanQiang FanQiang software suite...

call genhash.inc.bat
call update.inc.bat
call bootstrap.inc.bat
call miscellaneous.inc.bat

pause
cls
gfanqiang-debug.bat