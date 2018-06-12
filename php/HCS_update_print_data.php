<?php
	include_once ("./HCS_dbname.php");	//MySQL接続用の設定の読み込み

	$tblname = "printdata";			//新ファイルを保存するテーブル
	$userid = $_GET['uid'];			//ログインUserIDを取得する
	$cocode = $_GET['cc'];			//URLから企業コードの情報を取得する
	$storeno = $_GET['sno'];		//URLから店舗コードの情報を取得する
	$filetmp = $_GET['f'];			//URLからファイルの情報を取得する
	if(empty($cocode) || empty($storeno) || empty($filetmp)) exit();
	
	//データ接続
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