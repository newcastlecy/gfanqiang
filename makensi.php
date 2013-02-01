<?php
#  Gfanqiang - Software suite for breakthrough GFW
#  
#  makensi.php - Generate Gfanqiang.nsi
#  to execute this file:
#  1. CD to your Gfanqiang Directory	
#  2. >utility\php\php.exe makensi.php > gfanqiang.nsi

$path = realpath(dirname(__FILE__));
$dir = new RecursiveIteratorIterator(
new RecursiveDirectoryIterator($path), RecursiveIteratorIterator::CHILD_FIRST);

$path=addslashes($path."\\");
$ignorelist=array("/\\\\\.$/",
"/\\\\\.\.$/",
"/^{$path}\\.svn/",
"/^{$path}goagent-local\\\\certs\\\\(.*?)\.crt$/",
"/^{$path}goagent-local\\\\certs\\\\(.*?)\.key$/",
"/^{$path}\.settings/",
"/^{$path}\.project$/",
"/^{$path}commit\.bat$/",
"/^{$path}gfanqiang\.nsi$/",
"/^{$path}gfanqiang\.exe$/",
"/^{$path}uninstall\.exe$/",
"/^{$path}data\\\\last-known-good$/",
"/^{$path}data\\\\host$/",
"/\\\\\.url$/");

foreach($dir as $name => $object){
	$ignore=false; $relpath=null;
	foreach($ignorelist as $patten){
		if(preg_match($patten,$object->getPathname())){
			$ignore=true;
			break;
		}

	}

	if(! $ignore){
		$relpath=preg_replace("/^{$path}/",NULL,$object->getPathname());
		if(! is_dir($object->getPathname())){
			
			preg_match("/^(.*)\\\\/",$relpath,$reldir);
			$reldir=$reldir[1];
			
			if($currentdir!=$reldir){

				$insstring.="SetOutPath \"\$INSTDIR\\{$reldir}\"\r\n";
				$currentdir=$reldir;
				$rmdirarray[$dir->getDepth()][]="RmDir \"\$INSTDIR\\{$reldir}\"";
			}
			
			$insstring.="File \"".$object->getPathname()."\"\r\n";
			$delstring.="Delete \"\$INSTDIR\\$relpath\"\r\n";
		}		
	}
}

krsort($rmdirarray);
foreach($rmdirarray as $level => $array){
	$rmdirarray[$level]=array_unique($rmdirarray[$level]);
	$rmdirstring.=implode("\r\n",$rmdirarray[$level])."\r\n";
}

$template=file_get_contents("gfanqiang.nsi.template");
$search=array("<gfq:file>","<gfq:delete>","<gfq:rmdir>");
$replace=array($insstring,$delstring,$rmdirstring);
echo str_replace($search,$replace,$template);
?>