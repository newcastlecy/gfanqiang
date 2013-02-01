:: startchrome.inc.bat
:: Step5 - Start Chrome

echo Starting GoogleChrome...
start %LOCALAPPDATA%\Google\Chrome\Application\chrome.exe --proxy-server=https://127.0.0.1:8964 "https://gfangqiang.googlecode.com/svn/home.html"
utility\sleep.exe -m 1000