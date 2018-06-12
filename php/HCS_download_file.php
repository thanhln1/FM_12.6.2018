<?php
	include_once ("./HCS_dbname.php");	//MySQL接続用の設定の読み込み
	
	$tblname = "printdata";			//新ファイルを保存するテーブル
	$cocode = $_GET['cc'];			//URLから企業コードの情報を取得する
	$storeno = $_GET['sno'];		//URLから店舗コードの情報を取得する
	if(empty($cocode) || empty($storeno)) exit();

	//データ接続
	$sqllink = mysql_connect($hostname,$sqlusername,$sqluserpass);
	if (!$sqllink) exit();

	$db_selected = mysql_select_db($dbname, $sqllink);
	if (!$db_selected) exit();

	//印刷されていない新しいデータのリストを取得する
	mysql_query('SET NAMES utf8');
	$query = 	" SELECT file_path FROM ".$tblname." WHERE cocode = '".$cocode."' AND storeno = '".$storeno."'";
	$query .= 	" AND is_printed = 0 AND DATE_ADD(created_date,INTERVAL 1 DAY) > CURDATE()";
	$result = mysql_query($query);
	$row = mysql_num_rows($result);

	if($row != 0)
	{
		//zipファイルを作成する
		$zip_dir = $_SERVER["DOCUMENT_ROOT"]."/".$cocode."/store/".$storeno."/";
		$zip_name = $cocode.$storeno.time().".zip"; 	// Zip name
		$zip = new ZipArchive(); 						// Load zip library
		if($zip->open($zip_dir.$zip_name, ZipArchive::CREATE) == TRUE)
		{
			while ($row = mysql_fetch_assoc($result)) {
				$file_path = $row['file_path'];		//Get full path of file
				if(file_exists($file_path)) $zip->addFile($file_path); // Adding file into zip
			}
			$zip->close();
		}
		
		if (file_exists($zip_dir.$zip_name)) 
		{
			$path_parts = pathinfo($zip_name);
		    $ext = strtolower($path_parts["extension"]);
		    
		    switch ($ext) {
		        case "pdf":
			        header("Content-type: application/pdf");
		            header('Content-Disposition: attachment; filename="'.basename($zip_name).'"');
		        	break;
		        case "txt":
			        header("Content-type: text/plain");
		            header('Content-Disposition: attachment; filename="'.basename($zip_name).'"');
		        	break;
		        case "zip":
			        header("Content-type: application/zip");
		            header('Content-Disposition: attachment; filename="'.basename($zip_name).'"');
		        	break;
		        default;
			        header("Content-type: application/octet-stream");
			        header("Content-Disposition: filename=\"".$path_parts["basename"]."\"");
			        break;
		    }    
		    
		    header('Content-Description: File Transfer');
		    header('Expires: 0');
		    header('Cache-Control: must-revalidate');
		    header('Pragma: public');
		    header('Content-Length: ' . filesize($zip_dir.$zip_name));
		    readfile($zip_dir.$zip_name);
		    unlink($zip_dir.$zip_name);
		}			
	}
?>