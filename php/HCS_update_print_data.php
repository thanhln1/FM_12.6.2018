<?php
	include_once ("./HCS_dbname.php");	//MySQL$B@\B3MQ$N@_Dj$NFI$_9~$_(B

	$tblname = "printdata";			//$B?7%U%!%$%k$rJ]B8$9$k%F!<%V%k(B
	$userid = $_GET['uid'];			//$B%m%0%$%s(BUserID$B$r<hF@$9$k(B
	$cocode = $_GET['cc'];			//URL$B$+$i4k6H%3!<%I$N>pJs$r<hF@$9$k(B
	$storeno = $_GET['sno'];		//URL$B$+$iE9J^%3!<%I$N>pJs$r<hF@$9$k(B
	$filetmp = $_GET['f'];			//URL$B$+$i%U%!%$%k$N>pJs$r<hF@$9$k(B
	if(empty($cocode) || empty($storeno) || empty($filetmp)) exit();
	
	//$B%G!<%?@\B3(B
	$sqllink = mysql_connect($hostname,$sqlusername,$sqluserpass);
	if (!$sqllink) exit();
	
	$db_selected = mysql_select_db($dbname, $sqllink);
	if (!$db_selected) exit();
	mysql_query('SET NAMES utf8');
	
	//update print_data table
	$upd_sql = 	" UPDATE ".$tblname." SET";
	$upd_sql .= " is_printed = 1,";
	$upd_sql .= " update_date = '".date("Y-m-d H:i:s")."',";
	$upd_sql .= " update_by = '".$userid."'";
	$upd_sql .= " WHERE cocode = '".$cocode."' AND storeno = '".$storeno."' AND file_path = '".$filetmp."'";
	$result = mysql_query($upd_sql);
	
	//update receptiondata table
	$fname = basename($filetmp,".pdf");
	$upd_sql = 	" UPDATE receptiondata SET";
	$upd_sql .= " print_date = '".date("Y-m-d H:i:s")."'";
	$upd_sql .= " WHERE cocode = '".$cocode."' AND storeno = '".$storeno."' AND fname = '".$fname."'";
	$result = mysql_query($upd_sql);
?>