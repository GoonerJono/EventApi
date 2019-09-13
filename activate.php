<?php

require 'conn.php';
$conn= mysqli_connect("localhost", "root", "", "queuesystem");  
if (isset($_GET["code"])) 
{
	$usercode = $_GET["code"];
	$q = mysqli_query($conn,"SELECT * FROM reguser WHERE code='{$usercode}' ")or die(mysqli_error());
	$data = mysqli_fetch_row($q);
	if($data>0)
	{
		mysqli_query($conn,"UPDATE reguser SET verified='1' WHERE code='{$usercode}'")or die(mysqli_error());
		echo "Your email is verified!";
	}
}
else
{
	echo"Sorry Code not Found";
}

 ?>