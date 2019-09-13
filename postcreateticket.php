<?php
//requires the connection to the database
include_once('conn.php');
session_start();

$res2 = $mysqli->query("SELECT ID FROM reguser");
$orgname = $_POST['orgname'];
$name = $_POST['name'];

$ID=$_SESSION['ID'];
//make query to the database
$res = $mysqli->query("INSERT INTO tickets (orgname, ID) values ('$orgname', '$ID')");


header("Location: ticket.php");
?>