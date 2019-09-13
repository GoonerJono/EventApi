<?php
//requires the connection to the database
include_once('conn.php');
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\SMTP;
use PHPMailer\PHPMailer\Exception;

$conn= mysqli_connect("localhost", "root", "", "queuesystem");  
$username = $_POST['username'];
$name = $_POST['name'];
$surname = $_POST['surname'];
$birthdate = $_POST['birthdate'];
$gender = $_POST['gender'];
$email = $_POST['email'];
$password = $_POST['password'];
$verified = 0;




if($password==$password)
{
	$code = md5(uniqid());
	$iq = mysqli_query($conn,"INSERT INTO reguser(username, name, surname, birthdate, gender,email,password,code) VALUES ('{$username}', '{$name}', '{$surname}','{$birthdate}','{$gender}','{$email}','{$password}','{$code}')") or die(mysqli_error($conn));

	if($iq)
	{
		require_once('PHPMailer/src/PHPMailer.php');
		require_once('PHPMailer/src/SMTP.php');
		require ('PHPMailer/src/Exception.php');

		$mail = new PHPMailer;
		$mail->IsSMTP();
		$mail->SMTPDebug = 2;
		$mail->SMTPAuth=true;
		$mail->SMTPSecure="ssl";
		$mail->Host = "smtp.gmail.com";
		$mail->Port = 465;
		$mail->Username = "sjtollemache@gmail.com";
		$mail->Password = "";
		$mail->AddReplyTo("sjtollemache@gmail.com", "Digital Que");
		$mail->SetFrom('sjtollemache@gmail.com', 'Digital Que');
		$mail->AddReplyTo("sjtollemache@gmail.com", "Digital Que");
		$address = $email;
		$mail->AddAddress($address,"Digital");
		$mail->Subject = " Hello This is Digital Queueing";
		$body = "Hello This Is Digital Queueing Please click Link Below to activate your Account http://localhost:8080/quesystem/users/activate.php?code=$code";
		$mail->MsgHTML($body);

		if(!$mail->Send())
		{
			echo "Mailer Error:".$mail->ErrorInfo;
		}else
		{
			echo "Email Sent on your Email Account! Please activate your account";
		}
	}
}else
{
	echo "passwords not inputing correctly";
}

//make query to the database


header("Location: login.php");
?>