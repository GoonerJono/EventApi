
<!DOCTYPE html>
<html>
<head>
  <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="Colorlib Templates">
    <meta name="author" content="Colorlib">
    <meta name="keywords" content="Colorlib Templates">

    <!-- Title Page-->
    <title>Registration</title>

    <!-- Icons font CSS-->
    <link href="loginandreg/vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all">
    <link href="loginandreg/vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all">
    <!-- Font special for pages-->
    <link href="loginandreg/https://fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">

    <!-- Vendor CSS-->
    <link href="loginandreg/vendor/select2/select2.min.css" rel="stylesheet" media="all">
    <link href="loginandreg/vendor/datepicker/daterangepicker.css" rel="stylesheet" media="all">

    <!-- Main CSS-->
    <link href="loginandreg/css/main.css" rel="stylesheet" media="all">
</head>


<body>

	 <div class="page-wrapper bg-gra-01 p-t-180 p-b-100 font-poppins">
        <div class="wrapper wrapper--w780">
            <div class="card card-3">
                <div class="card-heading"></div>
                <div class="card-body">
                <h1 class="title">Queue System</h1>
                    <h2 class="title">Registration Information</h2>
<form action="signup.php" method="post">

<div class = "input-group">
  <input  class="input--style-3" type="text"  placeholder="orgname" id = "orgname" name="orgname"></input><br><br>
</div>

<div class = "input-group">
  <input  class="input--style-3" type="password"  placeholder="password" id = "password" name="password"></input><br><br>
</div>

<div class = "input-group">
  <input  class="input--style-3" type="email"  placeholder="email" id = "email" name="email"></input><br><br>
</div>
 


 <div class="input-group">
                            <input class="input--style-3 js-datepicker" id = "typeofservice" type="text" placeholder="Date of Registration" name="regdate">
                            <i class="zmdi zmdi-calendar-note input-icon js-btn-calendar"></i>
                        </div>

<div class = "input-group">
	     <div class="rs-select2 js-select-simple select--no-search" id = "typeofservice">
                                <select name="typeofservice">
                                		    <option disabled="disabled" selected="selected">Type of Service Provided</option>
                                    <option>Repairs</option>
                                    <option>Clinical</option>
                                    <option>Other</option>
                                </select>
                                <div class="select-dropdown"></div>
                            </div>
                        </div>
 

 

  <input class="btn btn--pill btn--green" type="submit" value="REGISTER"></input>

  <br>Organization Already registered?
	<input class="btn btn--pill btn--green" type="button" onclick="window.location.href = 'login.php';" value="login"/>
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

