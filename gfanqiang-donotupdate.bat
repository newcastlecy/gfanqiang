:: gfangqiang.bat
:: Main Batch File - No Update
   
@echo off
title Starting GFanQiang FanQiang software suite...

call genhash.inc.bat
call bootstrap.inc.bat
call miscellaneous.inc.bat
call startfirefox.inc.bat
call startgoagent.inc.bat