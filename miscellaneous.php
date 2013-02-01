<?php
#  Gfanqiang - Software suite for breakthrough GFW
#  
#  miscellaneous.php - Last cleanup

/* 20121207 Remove incorrect Pinyin Filename */
@unlink("gfangqiang-debug.bat");
@unlink("gfangqiang-donotupdate.bat");
@unlink("gfangqiang-donotupdate-debug.bat");

/* 20121207 Remove incorrect Pinyin Filename */
@unlink("gfangqiang-standalone.bat");

/* 20121218 Remove proxy.custom */
/* You may edit the FindProxyForURL() section in /goagent-local/proxy.pac to create custom rules */
if(file_exists('data/proxy.custom')){
	@unlink('data/proxy.custom');
}

@unlink("gfanqiang-chrome.bat");
?>