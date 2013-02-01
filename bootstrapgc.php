<?php
#  Gfanqiang - Software suite for breakthrough GFW
#  
#  bootstrapgc.php - Bootstrap Phase 2
#  "gc" is stand for googleCode. In the old version, we use GAE for Bootstrap, not GoogleCode.

echo "Bootstrap:\r\n";

/* Set Current Directory */
preg_match('/(.*?)\\\bootstrapgc\.php$/',__FILE__,$currentdir); 
chdir($currentdir[1]);

$hosts=array();

$host = "gfangqiang.googlecode.com";
require_once("makegservers.inc.php");

if(file_exists("custom.ini")){
	$custom = parse_ini_file("custom.ini");
	
}

if(is_array($custom["appid"])){
	$customappid=implode("|",$custom["appid"]);
}

/* If cannot load bootstrap.txt, use fallback APPID instead. */
$fallbackid=parse_ini_file("fallback.ini");
$fallbackid=implode("|",$fallbackid["fallbackid"]);

/* Last Known Good*/
	/*echo "\tLast known good...";
	if($lkg=@file_get_contents("data/last-known-good")){
		echo "exists!\r\n";
		$lkg=explode("\n",str_replace("\r\n","\n",$lkg));
		echo "\tLAST-KNOWN-GOOD=".implode(",",$lkg)."\r\n";
		foreach($lkg as $value){
			if(($key = array_search($value, $gservers)) !== false) {
				unset($gservers[$key]);
			}
			array_unshift($gservers,$value);
		}
		array_unique($gservers);
	}else{
		echo "Not exists!\r\n";
	}
	echo "\r\n";*/

/* GOOGLE-IP */
echo " Host file...";
if(file_exists("data/host")){
	echo "Exists!\r\n";
	$ip=file_get_contents("data/host");
	
	/*if(filter_var($ip,FILTER_VALIDATE_IP)){*/
	$ip=explode("\n",str_replace("\r\n","\n",$ip));
	foreach($ip as $key=>$value){
		//echo "\tTrying {$value}...";
		//if(! $fp = fsockopen('ssl://'.$value, 443,$errno,$errstr,3)){
		//	echo "Walled!\r\n";
		//	unset($ip[$key]);
		//}else{
		//	echo "OK!\r\n";
			array_unshift($gservers,$value);
		//}
		//@fclose($fp);
	
	}
	array_unique($gservers);
	/*}else{
		unset($ip);
		echo "\thost file is no vaild\r\n";
	}*/

}else{
	echo "Not Exists!\r\n";
}
//echo "\tTotal: ".count($ip)." IP fetched\r\n";
echo "\r\n";

/* Get bootstrap.txt and try to get a list of aviliable Gserver IP Address */
echo " Downloading bootstrap file:\r\n";
$request="GET /svn/bootstrap.txt HTTP/1.1\r\nHost:{host}\r\nConnection: close\r\n\r\n";
$success=false;
$successcount=0;
$successtarget=4;

foreach($gservers as $gkey=>$gserver){ 
	if($successcount<$successtarget){
		echo " Trying\t".$gserver."...";
		
		if($fp = @fsockopen('ssl://'.$gserver, 443,$errno,$errstr,3)){
			if($success){
				$successcount++;
				$hosts[]=$gservers[$gkey];
				echo "OK! ({$successcount}/{$successtarget})\r\n";
			}else{
				if (fwrite($fp, str_replace('{host}',$host,$request)) ) {
					while (!feof($fp) ) {
						$response .= fgets($fp, 1024);
					}	
					if(preg_match('/HTTP\/1.1 200 OK/',$response)){
						$response=explode("\r\n\r\n",$response);
						$response=$response[1];
						$success=true;
						$successcount++;
						$hosts[]=$gservers[$gkey];
						
						echo "OK! (1/{$successtarget})\r\n";
					}else{
						echo "Cannot grab bootstrap.txt\r\n";
					}
				}
			}
			fclose($fp);
		} elseif(! $fp){
			@fclose($fp);
			echo "Walled!\r\n";
			unset($gservers[$gkey]);
		}
	}
}

echo "\r\n";

/* Load proxy.ini template */
echo " Generating proxt.ini...\r\n";
$template=@file_get_contents("goagent-local/proxy.ini.template");

/* Final Bootstrap: Write proxt.ini */
if($success){
	$response=explode("|",$response);
	shuffle($response);
	$response=implode("|",$response);
	if($customappid){
		$response=$customappid."|".$response;
	}

	$ini=str_replace("<appid>",$response,$template);
	$ini=str_replace("<hosts>",implode("|",$hosts),$ini);
	$ini=str_replace("<profile>","google_gfq",$ini);
	
	echo "\tHOSTS=".implode("|",$hosts)."\r\n";
	
	file_put_contents("data/last-known-good",implode("\r\n",$hosts));
}else{
	/* If cannot load bootstrap.txt, use fallback data instead. */
	$ini=str_replace("<appid>",$fallbackid,$template);
	$ini=str_replace("<hosts>","www.google.com|mail.google.com|www.l.google.com|mail.l.google.com",$template);
	$ini=str_replace("<profile>","google_hk",$ini);
}

/* Output proxy.ini */
if(! file_put_contents("goagent-local/proxy.ini",$ini)){
	echo "ERROR to wrtie proxy.ini!";
}

echo "\r\n";
?>