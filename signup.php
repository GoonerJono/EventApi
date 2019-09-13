<?php
//requires the connection to the database
include_once('conn.php');


$orgname = $_POST['orgname'];
$password = $_POST['password'];
$email = $_POST['email'];
$regdate = $_POST['regdate'];
$typeofservice = $_POST['typeofservice'];


//make query to the database
$res = $mysqli->query("INSERT INTO regorgs(orgname, password, email, regdate, typeofservice) values ('$orgname', '$password', '$email', '$regdate', '$typeofservice')");


header("Location: ../orgs/login.php");
?>