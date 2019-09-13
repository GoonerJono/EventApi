<?php
//requires the connection to the database
session_start();
require 'conn.php';
$conn = mysqli_connect("localhost", "root", "", "queuesystem");

$errors = array();
$username = "";
$name = "";
$surname = "";
$birthdate = "";
$gender = "";
$email = "";
$password = "";

if(isset($_POST['REGISTER']))
{
$username = $_POST['username'];
$name = $_POST['name'];
$surname = $_POST['surname'];
$birthdate = $_POST['birthdate'];
$gender = $_POST['gender'];
$email = $_POST['email'];
$password = $_POST['password'];

	if (empty($username)) 
	{
		$errors['username'] = "Username required";
	}

	if (empty($name)) 
	{
		$errors['name'] = "Name required";
	}

	if (empty($surname)) 
	{
		$errors['surname'] = "Surname required";
	}

	if (empty($birthdate)) 
	{
		$errors['birthdate'] = "Birthdate required";
	}

	if (empty($gender)) 
	{
		$errors['gender'] = "Gender required";
	}

		if (!filter_var($email, FILTER_VALIDATE_EMAIL)) 
	{
		$errors['email'] = "E-mail is Invalid/Already Exists";
	}


	if(empty($email))
	{
		$errors['email'] = "E-mail required";
	}
	

		if (empty($password)) 
	{
		$errors['password'] = "Password required";
	}

	$emailquery = "SELECT * FROM reguser WHERE email=? LIMIT 1";
	$stmt = $conn->prepare($emailquery);
	$stmt->bind_param('s',$email);
	$stmt->execute();
	$result = $stmt->get_result();
	$userCount = $result->num_rows;
	$stmt->close();

	if ($userCount > 0) 
	{
			$errors['email'] = "E-mail already exists";
	}

	if(count($errors) === 0)
	{
		$password = password_hash($password, PASSWORD_DEFAULT);
		$token = bin2hex(random_bytes(50));
		$verified = false;

		$res = $mysqli->query("INSERT INTO reguser (username, name, surname, birthdate, gender, email, verified, token, password) values (?, ?, ?, ?, ?, ?, ?, ?, ?)");

		$stmt = $conn->prepare($res);
		$stmt->bind_param('ssssssbss', $username, $name, $surname, $birthdate, $gender, $email, $verified, $token, $password);

		if ($stmt->execute())
		{
			$ID = $conn->insert_ID;
			$_SESSION['ID'] = $ID;
			$_SESSION['username'] = $username;
			$_SESSION['name'] = $name;
			$_SESSION['surname'] = $surname;
			$_SESSION['birthdate'] = $birthdate;
			$_SESSION['gender'] = $gender;
			$_SESSION['email'] = $email;
			$_SESSION['verified'] = $verified;
			

			$_SESSION['message'] = "You are now logged in!";
			$_SESSION['alert-class'] = "alert-success";
			header('location:registration.php');
			exit();

			
		}
		else 
				{	
					$errors['db_error'] = "Database error: failed to register";
				}

	}
}


?>