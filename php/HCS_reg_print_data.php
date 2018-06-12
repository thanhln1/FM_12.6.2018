<?php
	include_once ("./HCS_dbname.php");	//MySQL接続用の設定の読み込み

	$tblname = "printdata";			//新ファイルを保存するテーブル
	$userid = $_GET['uid'];			//ログインUserIDを取得する
	$cocode = $_GET['cc'];			//URLから企業コードの情報を取得する
	$storeno = $_GET['sno'];		//URLから店舗コードの情報を取得する
	if(empty($userid) || empty($cocode) || empty($storeno)) exit();
	
	//データ接続
	$sqllink = mysql_connect($hostname,$sqlusername,$sqluserpass);
	if (!$sqllink) exit();

	$db_selected = mysql_select_db($dbname, $sqllink);
	if (!$db_selected) exit();
	
	//ストアのフォルダにあるデータファイルのリストを取得する
	$scan_dir = $_SERVER["DOCUMENT_ROOT"]."/".$cocode."/store/".$storeno;
	$pdffiles = array();
	$files = array();
	
	foreach (glob($scan_dir."/*.pdf") as $pdff) {
	  $pdffiles[] = $pdff;
	}
	
	if(sizeof($pdffiles) > 0)
	{
		foreach($pdffiles as $filepdftmp)
		{
			if(date("Y-m-d",filemtime($filepdftmp)) == date("Y-m-d"))
			{
				$txtfile = str_replace('.pdf','.txt',$filepdftmp);
				if(file_exists($txtfile))
				{
					$files[] = $txtfile;
					$files[] = $filepdftmp;
				}
			}
		}
	}

	if(sizeof($files) > 0)
	{
		//ファイルをチェックし、新ファイルであれば、DBを入れる。
		mysql_query('SET NAMES utf8');
		foreach($files as $filetmp)
		{
			$query = 	" SELECT print_data_id FROM ".$tblname;
			$query .= 	" WHERE cocode = '".$cocode."' AND storeno = '".$storeno."' AND file_path = '".$filetmp."'";
			$result = mysql_query($query);
			$row = mysql_num_rows($result);

			if($row == 0)
			{
				$ins_sql = 	" INSERT INTO ".$tblname."";
				$ins_sql .= " (cocode,storeno,file_path,is_printed,created_date, created_by) VALUES ";
				$ins_sql .= " ('".$cocode."','".$storeno."','".$filetmp."',0,'".date("Y-m-d H:i:s",filemtime($filetmp))."','".$userid."')";
				$result = mysql_query($ins_sql);
			}
		}
	}
?>