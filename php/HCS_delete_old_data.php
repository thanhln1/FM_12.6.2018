<?php
	include_once ("./HCS_dbname.php");	//MySQL接続用の設定の読み込み

	$tblname = "printdata";			//新ファイルを保存するテーブル
	$cocode = $_GET['cc'];			//URLから企業コードの情報を取得する
	$storeno = $_GET['sno'];		//URLから店舗コードの情報を取得する
	$olddays = $_GET['od'];			//URLから店舗コードの情報を取得する
	if(empty($cocode) || empty($storeno) || empty($olddays)) exit();
	
	//データ接続
	$sqllink = mysql_connect($hostname,$sqlusername,$sqluserpass);
	if (!$sqllink) exit();

	$db_selected = mysql_select_db($dbname, $sqllink);
	if (!$db_selected) exit();

	mysql_query('SET NAMES utf8');
	$del_sql = 	" DELETE FROM ".$tblname."";
	$del_sql .= " WHERE cocode = '".$cocode."' AND storeno = '".$storeno."' AND DATE_ADD(created_date,INTERVAL ".$olddays." DAY) < CURDATE()";
	$result = mysql_query($del_sql);
?>