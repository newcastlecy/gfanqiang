:: gfangqiang-standalone.bat
:: Main Batch File - GoAgent Only, Use your own browser

@echo off
title Starting GFanQiang FanQiang software suite...

call genhash.inc.bat
call update.inc.bat
call bootstrap.inc.bat
call miscellaneous.inc.bat
echo �������޸����������Ϊ�Զ����ã�λַΪ�� http://127.0.0.1:8965/proxy.pac
echo �������IEʹ���ߣ�������utility\HOWTO-IE.png
echo ������ǻ��ʹ���ߣ�������utility\HOWTO-Firefox.png
echo �������Chrome ʹ���ߣ�����Ҫ SwitchySharp ���
:: pause
call startgoagent.inc.bat