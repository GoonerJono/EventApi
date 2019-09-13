<?php
if(isset($_GET["outID"]))
{
session_start();
$_SESSION["ID"]=0;
$_SESSION["username"]=0;
$_SESSION["password"]=0;
$_SESSION["email"]=0;

} 
?>
<?php
$hold="";
if(isset($_POST['Enter']))
{
$email = $_POST['email'];
$password = $_POST['password'];



     if($email =="" && $password =="")
	 { 
	      $hold.="Please enter your E-mail and Password";
	 } 
			 else if($email=="")
				 {
				   $hold.="Please enter your E-mail";
				 } 
				 else if(!filter_var($email, FILTER_VALIDATE_EMAIL)) 
			 {
			   $hold.=" E-mail Adress is Invalid";
			 }
			 else if($password=="")
				 {
				   $hold.="Please enter your Password";
				 } 
				 else if($password != "$password")
				 {
				   $hold.="Password is incorrect please Re-enter Password";
				 } 
				 else{
				      
					  include_once("conn.php");
					  $q = "SELECT * FROM reguser WHERE email = '".$email."' AND password = '".$password."'";
					  $res = $mysqli->query($q);

						if($row = $res->fetch_assoc())
						{
						      session_start();
							$_SESSION["ID"]=$row["ID"];
							$_SESSION["username"]=$row["username"];
							$_SESSION["password"]=$row["password"];
							
							
							
							if($_SESSION["accesslevel"]==0)
							{
							     header("Location:userindex.php");
					
							}
								else
								{
							
								$hold.= "Wrong Information! Please try again!";
								}
				 		}
				     

						}
}
?>
<!DOCTYPE html>
<html >
<head>
   <!-- Required meta tags-->
   <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="Colorlib Templates">
    <meta name="author" content="Colorlib">
    <meta name="keywords" content="Colorlib Templates">

    <!-- Title Page-->
    <title>User Login</title>

    <!-- Icons font CSS-->
    <link href="loginandreg/vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all">
    <link href="loginandreg/vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all">
    <!-- Font special for pages-->
    <link href="https://fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">

    <!-- Vendor CSS-->
    <link href="loginandreg/vendor/select2/select2.min.css" rel="stylesheet" media="all">
    <link href="loginandreg/vendor/datepicker/daterangepicker.css" rel="stylesheet" media="all">

    <!-- Main CSS-->
    <link href="loginandreg/css/main.css" rel="stylesheet" media="all">
</head>

<body>
<form action="login.php" method="POST">
  <div class="page-wrapper bg-gra-01 p-t-180 p-b-100 font-poppins">
        <div class="wrapper wrapper--w780">
            <div class="card card-3">
                <div class="card-heading"></div>
                <div class="card-body">
                <h1 class="title">Queue System</h1>
                    <h2 class="title">Login Information</h2>
		
		<div class="login-form">
			<div class="sign-in-htm">
			<?php echo $hold;?>
				<div class="input-group">
					<label for="email" class="label" font="white"><font >PLEASE ENTER YOUR E-MAIL </font></label>
					<input class="input--style-3" placeholder="Email" id="email" name="email" type="text" >
				</div>
				<div class="input-group">
					<label for="pass" class="label">PLEASE ENTER YOUR PASSWORD</label>
					<input class="input--style-3" placeholder="password" id="password" name="password" type="password" class="input" data-type="password">
				</div>
				
				<div class="input-group">
					<input class="btn btn--pill btn--green" type="submit" name="Enter" class="button" value="Sign In">
				</div>
				<div class="hr"></div>
				<div class="foot-lnk">
					
				
					
				</div>
				

				
			</div>

			

	<br><font color = white>Organization not registered?</font>
	<input  class="btn btn--pill btn--green" type="button" onclick="window.location.href = 'registration.php';" value="SignUp"/>

</div>
</form>
 <!-- Jquery JS-->
    <script src="loginandreg/vendor/jquery/jquery.min.js"></script>
    <!-- Vendor JS-->
    <script src="loginandreg/vendor/select2/select2.min.js"></script>
    <script src="loginandreg/vendor/datepicker/moment.min.js"></script>
    <script src="loginandreg/vendor/datepicker/daterangepicker.js"></script>

    <!-- Main JS-->
    <script src="loginandreg/js/global.js"></script>

</body>
</html>