<?php
include_once('conn.php');
?>


<!DOCTYPE html>
<html>
<head>

 <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="Colorlib Templates">
    <meta name="author" content="Colorlib">
    <meta name="keywords" content="Colorlib Templates">

    <!-- Title Page-->
    <title>VIEW TICKETS HERE</title>

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
<form action="ticket.php" method="post" align = "center">
 
   
        ticket number: <output type="text" name="ticketnumber" id="ticketnumber"></output><br><br>
        Organization Name: <output type="text" name="orgname" id="orgname"></output><br><br>
        name: <output type="text" name="name" id="name"></output><br><br>
        date: <output type="text" name="date" id="date"></output><br><br>


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