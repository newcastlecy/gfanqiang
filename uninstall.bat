cd /D "%~dp0"
del /f /s /q goagent-local\certs\*.crt
del /f /s /q goagent-local\certs\*.key
del /f /s /q goagent-local\data\*
start uninstall.exe