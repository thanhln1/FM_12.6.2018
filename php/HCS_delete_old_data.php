<?php
	include_once ("./HCS_dbname.php");	//MySQL�ڑ��p�̐ݒ�̓ǂݍ���

	$tblname = "printdata";			//�V�t�@�C����ۑ�����e�[�u��
	$cocode = $_GET['cc'];			//URL�����ƃR�[�h�̏����擾����
	$storeno = $_GET['sno'];		//URL����X�܃R�[�h�̏����擾����
	$olddays = $_GET['od'];			//URL����X�܃R�[�h�̏����擾����
	if(empty($cocode) || empty($storeno) || empty($olddays)) exit();
	
	//�f�[�^�ڑ�
	$sqllink = mysql_connect($hostname,$sqlusername,$sqluserpass);
	if (!$sqllink) exit();

	$db_selected = mysql_select_db($dbname, $sqllink);
	if (!$db_selected) exit();

	mysql_query('SET NAMES utf8');
	$del_sql = 	" DELETE FROM ".$tblname."";
	$del_sql .= " WHERE cocode = '".$cocode."' AND storeno = '".$storeno."' AND DATE_ADD(created_date,INTERVAL ".$olddays." DAY) < CURDATE()";
	$result = mysql_query($del_sql);
?>