<?php
	include_once ("./HCS_dbname.php");	//MySQL$B@\B3MQ$N@_Dj$NFI$_9~$_(B

	$tblname = "printdata";			//$B?7%U%!%$%k$rJ]B8$9$k%F!<%V%k(B
	$userid = $_GET['uid'];			//$B%m%0%$%s(BUserID$B$r<hF@$9$k(B
	$cocode = $_GET['cc'];			//URL$B$+$i4k6H%3!<%I$N>pJs$r<hF@$9$k(B
	$storeno = $_GET['sno'];		//URL$B$+$iE9J^%3!<%I$N>pJs$r<hF@$9$k(B
	if(empty($userid) || empty($cocode) || empty($storeno)) exit();
	
	//$B%G!<%?@\B3(B
	$sqllink = mysql_connect($hostname,$sqlusername,$sqluserpass);
	if (!$sqllink) exit();

	$db_selected = mysql_select_db($dbname, $sqllink);
	if (!$db_selected) exit();
	
	//$B%9%H%"$N%U%)%k%@$K$"$k%G!<%?%U%!%$%k$N%j%9%H$r<hF@$9$k(B
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
		//$B%U%!%$%k$r%A%'%C%/$7!"?7%U%!%$%k$G$"$l$P!"(BDB$B$rF~$l$k!#(B
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