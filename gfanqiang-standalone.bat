:: gfangqiang-standalone.bat
:: Main Batch File - GoAgent Only, Use your own browser

@echo off
title Starting GFanQiang FanQiang software suite...

call genhash.inc.bat
call update.inc.bat
call bootstrap.inc.bat
call miscellaneous.inc.bat
echo 请自行修改浏览器代理为自动设置，位址为： http://127.0.0.1:8965/proxy.pac
echo 如果你是IE使用者，请叁看utility\HOWTO-IE.png
echo 如果你是火狐使用者，请叁看utility\HOWTO-Firefox.png
echo 如果你是Chrome 使用者，你需要 SwitchySharp 插件
:: pause
call startgoagent.inc.bat