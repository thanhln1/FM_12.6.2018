<?php ob_start();
	include_once ("./HCS_dbname.php");	//MySQL$B@\B3MQ$N@_Dj$NFI$_9~$_(B
	
	$tblname = "printdata";			//$B?7%U%!%$%k$rJ]B8$9$k%F!<%V%k(B
	$cocode = $_GET['cc'];			//URL$B$+$i4k6H%3!<%I$N>pJs$r<hF@$9$k(B
	$storeno = $_GET['sno'];		//URL$B$+$iE9J^%3!<%I$N>pJs$r<hF@$9$k(B
	if(empty($cocode) || empty($storeno)) exit();

	//$B%G!<%?@\B3(B
	$sqllink = mysql_connect($hostname,$sqlusername,$sqluserpass);
	if (!$sqllink) exit();

	$db_selected = mysql_select_db($dbname, $sqllink);
	if (!$db_selected) exit();

	//$B0u:~$5$l$F$$$J$$?7$7$$%G!<%?$N%j%9%H$r<hF@$9$k(B
	mysql_query('SET NAMES utf8');
	$query = 	" SELECT fname FROM receptiondata WHERE cocode='".$cocode."' AND storeno='".$storeno."'";
	//$query = 	" SELECT fname_dtl FROM datFiles WHERE cocode='".$cocode."' AND storeno='".$storeno."'";
	$query .= 	" AND DATE_ADD(date,INTERVAL 4 DAY) > CURDATE()";
	$query .=   " AND fname NOT LIKE '*%'";
	$query .= 	" AND print_date='0000-00-00 00:00:00'";
	
	
	
	$result = mysql_query($query);
	$row = mysql_num_rows($result);
	
	if($row != 0)
	{
		//zip$B%U%!%$%k$r:n@.$9$k(B
		$zip_dir = $_SERVER["DOCUMENT_ROOT"]."/".$cocode."/store/".$storeno."/";
		$zip_name = $cocode.$storeno.time().".zip"; 	// Zip name
		$zip = new ZipArchive(); 						// Load zip library
		
		if($zip->open($zip_dir.$zip_name, ZipArchive::CREATE) == TRUE)
		{
			while ($row = mysql_fetch_assoc($result)) {
				$fname = $row['fname'];
				// $txtfile = $fname.".txt";
				$pdffile = "1".$fname.".pdf";
				
				// if($filetype = "txt"){		
				 // // $txtfiledata = file_get_contents("https://health-care-fm.jp/prescription-sys/Smartphone-sys/get.php/P7tg815kL0.mb5exZo1k_6J5w/".$cocode."/store/".$storeno."/".$fname);
				 // // $txtfiledata_utf8 = mb_convert_encoding($txtfiledata, 'UTF-8', mb_detect_encoding($txtfiledata,'JIS, SJIS'));
				 // // if($txtfiledata_utf8) $zip->addFromString($fname,$txtfiledata_utf8); // Adding file into zip
				// }
			
				 $pdffiledata = file_get_contents("https://health-care-fm.jp/prescription-sys/Smartphone-sys/get.php/P7tg815kL0.mb5exZo1k_6J5w/".$cocode."/store/".$storeno."/".$pdffile);
				 if($pdffiledata) $zip->addFromString($pdffile,$pdffiledata); // Adding file into zip
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
ob_flush();?>