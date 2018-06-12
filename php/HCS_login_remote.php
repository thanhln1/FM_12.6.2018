<?php
	include_once ("./HCS_dbname.php");	//MySQLÚ‘±—p‚ÌÝ’è‚Ì“Ç‚Ýž‚Ý
	$login_successfull = false;

	$sqllink = mysql_connect($hostname,$sqlusername,$sqluserpass);
	if (!$sqllink) 
	{
		print("Login fail");
		exit();
	}

	$db_selected = mysql_select_db($dbname, $sqllink);
	if (!$db_selected)
	{
		print("Login fail");
		exit();
	}

	$login_id = $_GET['uid'];
	$login_pwd = $_GET['pwd'];
	$tblname = "mtenpo";

	mysql_query('SET NAMES utf8');
	$query = "SELECT * FROM ".$tblname." WHERE BINARY id = '".$login_id."' AND BINARY passw = '".$login_pwd."'";

	$result = mysql_query($query);
	$row = mysql_num_rows($result);

	if($row != 0){
		print("Successfully");
	}
	else {
		print("Login fail");
	}
?>