:: bootstrap.inc.bat
:: Step3 - Bootstrap

utility\php\php.exe bootstrapgc.php
::IF ERRORLEVEL 0 (echo Done!) ELSE (echo Error!)

utility\sleep.exe -m 1000