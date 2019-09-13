<?php

	$db_username = 'root';
	$db_password = '';
	$db_name = 'queuesystem';
	$db_host = 'localhost';
	
	$mysqli = new mysqli($db_host, $db_username, $db_password, $db_name)
	or die("SORRY YOU COULDN`T CONNECT TO THE DATABASE!");//database connection 


?>