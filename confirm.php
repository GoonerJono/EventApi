<?php
if(!isset($_GET['email'] || !isset($_GET['token'])))
{
	header('Location:registration.php');
	exit();
}else
{
	$conn = new mysqli_connect("localhost", "root", "", "queuesystem");
	$email = $conn->real_escape_string($_GET['email']);
	$email = $conn->real_escape_string($_GET['token']);
	$sql = $conn->query("SELECT ID from reguser WHERE email='$email' AND token='$token'AND verified=0")
	if($sql->num_rows > 0)
	{
		$conn->query("UPDATE reguser SET verified=1, token ='' WHERE email='$email'");
		echo'your email has been verified you can login now!';
	}else
	{
		redirect();
	}
}

?>