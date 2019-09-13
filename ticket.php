<?php
include_once('conn.php');
?>
 <?php session_start(); ?>
<?php
$db_username = 'root';
    $db_password = '';
    $db_name = 'queuesystem';
    $db_host = 'localhost';

$conn = new mysqli($db_host, $db_username, $db_password, $db_name)
    or die("SORRY YOU COULDN`T CONNECT TO THE DATABASE!");//database connection 

$result = mysqli_query($conn,"SELECT * FROM tickets");

$connect = mysqli_connect("localhost", "root", "", "queuesystem");

$resultSet = $mysqli->query("SELECT orgname FROM regorgs");
 ?>  

<!DOCTYPE html>
<html>

<head>



<meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        
        <style>
            table tr:not(:first-child){
                cursor: pointer;transition: all .25s ease-in-out;
            }
            table tr:not(:first-child):hover{background-color: #ddd;}
        </style>
        
        <script language="javascript" type="text/javascript">
function showRow(row)
{
var x=row.cells;
document.getElementById("ticketnumber").value = x[0].innerHTML;
document.getElementById("orgsname").value = x[1].innerHTML;
document.getElementById("date").value = x[2].innerHTML;


}
</script>


     <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>VIEW TICKETS AND CREATE TICKETS</title>
   
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.7 -->
  <link rel="stylesheet" href="AdminLTE/bower_components/bootstrap/dist/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="AdminLTE/bower_components/font-awesome/css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="AdminLTE/bower_components/Ionicons/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="AdminLTE/dist/css/AdminLTE.min.css">
  <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
  <link rel="stylesheet" href="AdminLTE/dist/css/skins/_all-skins.min.css">
  <!-- Morris chart -->
  <link rel="stylesheet" href="AdminLTE/bower_components/morris.js/morris.css">
  <!-- jvectormap -->
  <link rel="stylesheet" href="AdminLTE/bower_components/jvectormap/jquery-jvectormap.css">
  <!-- Date Picker -->
  <link rel="stylesheet" href="AdminLTE/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css">
  <!-- Daterange picker -->
  <link rel="stylesheet" href="AdminLTE/bower_components/bootstrap-daterangepicker/daterangepicker.css">
  <!-- bootstrap wysihtml5 - text editor -->
  <link rel="stylesheet" href="AdminLTE/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css">

  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

  <!-- Google Font -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
</head>
<body class="hold-transition skin-blue sidebar-mini">

<div class="wrapper">

  <header class="main-header">
    <!-- Logo -->
    <a href= userindex.php class="logo">
      <!-- mini logo for sidebar mini 50x50 pixels -->
      <span class="logo-mini"><b>D</b>QUE</span>
      <!-- logo for regular state and mobile devices -->
      <span class="logo-lg"><b>Digital</b>Queueing</span>
    </a>
    <!-- Header Navbar: style can be found in header.less -->
    <nav class="navbar navbar-static-top">
      <!-- Sidebar toggle button-->
      <a href="#" class="sidebar-toggle" data-toggle="push-menu" role="button">
        <span class="sr-only">Toggle navigation</span>
      </a>

      <div class="navbar-custom-menu">
        <ul class="nav navbar-nav">
          
          <!-- User Account: style can be found in dropdown.less -->
          <li class="dropdown user user-menu">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
              <img src="AdminLTE/dist/img/user2-160x160.jpg" class="user-image" alt="User Image">
              <span class="hidden-xs"><?php echo $_SESSION['username'];?></span>
            </a>
            <ul class="dropdown-menu">
              <!-- User image -->
              <li class="user-header">
                <img src="AdminLTE/dist/img/user2-160x160.jpg" class="img-circle" alt="User Image">

                <p>
                 <?php echo $_SESSION['username'];?>
                  
                </p>
              </li>
              <!-- Menu Body -->
              <li class="user-body">
                
                <!-- /.row -->
              </li>
              <!-- Menu Footer-->
              <li class="user-footer">
                <div class="pull-left">
                  <a href="AdminLTE/pages/examples/profile.php" class="btn btn-default btn-flat">Profile</a>
                </div>
                <div class="pull-right">
                  <a href="login.php" class="btn btn-default btn-flat">Sign out</a>
                </div>
              </li>
            </ul>
          </li>
          <!-- Control Sidebar Toggle Button -->
         
        </ul>
      </div>
    </nav>
  </header>
  <!-- Left side column. contains the logo and sidebar -->
  <aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar">
      <!-- Sidebar user panel -->
      <div class="user-panel">
        <div class="pull-left image">
          <img src="AdminLTE/dist/img/user2-160x160.jpg" class="img-circle" alt="User Image">
        </div>
        <div class="pull-left info">
          <p><?php echo $_SESSION['username'];?></p>
          <a href="#"><i class="fa fa-circle text-success"></i> Online</a>
        </div>
      </div>
      <!-- search form -->
      <form action="#" method="get" class="sidebar-form">
        <div class="input-group">
          <input type="text" name="q" class="form-control" placeholder="Search...">
          <span class="input-group-btn">
                <button type="submit" name="search" id="search-btn" class="btn btn-flat"><i class="fa fa-search"></i>
                </button>
              </span>
        </div>
      </form>
      <!-- /.search form -->
      <!-- sidebar menu: : style can be found in sidebar.less -->
      <ul class="sidebar-menu" data-widget="tree">
        <li class="header">MAIN NAVIGATION</li>
        <li >
            <a href="userindex.php">
            <i class="fa fa-dashboard"></i> Dashboard
            
          </a>
          </li> 
     

               
                  <li >
                  <a href="ticket.php">
                  <i class="fa fa-circle-o"></i> View/Create Tickets         
                </a>
                </li> 

                     <li >
                  <a href="searchorg.php">
                  <i class="fa fa-circle-o"></i> Search Organizations 
                </a>
                </li> 
                
                  <li >
                  <a href="map/index.php">
                  <i class="fa fa-circle-o"></i>Search Organization Location      
                </a>
                </li>     
       

        </ul>
          
    </section>
    <!-- /.sidebar -->
  </aside>



  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
   

    <!-- Main content -->
    <section class="content">
      <!-- Small boxes (Stat box) -->
      <div class="row">
        <div >
          <!-- small box -->
          <div class="small-box bg-aqua">
            <div class="inner">

            <form align = "center" action="postcreateticket.php" method="post">
 <div class="page-wrapper bg-gra-01 p-t-180 p-b-100 font-poppins">
        <div class="wrapper wrapper--w780" >
            <div class="card card-4">
                <div class="card-heading"></div>
                <div class="card-body">

               
<form>

	 </style>
 

 <h4 class="title">Select Organization</h4>


  

         <div class="input--style-3" id = "orgname" placeholder="orgname"> </div>  
<select type = "text" name="orgname" id = "orgname" placeholder="orgname" style='color: black;'>



<?php
while ($rows = $resultSet->fetch_assoc())
{
     $color1 = "red";
    $color2 = "teal";
    $color = $color1;

     $color == $color1 ? $color = $color2 : $color = $color1;                                   
     $orgname = $rows['orgname'];
     echo "Organization: <option value = '$orgname' style=' color: white; background:$color;'>$orgname</option>";
}
?>
</select>

 <div class="select-dropdown" style='color: black;'></div>
                                                         
<p></p>
<p></p>
<style type="text/css">
.btn--green{

  background: #57b846;
   -webkit-border-radius: 3px;
  -moz-border-radius: 3px;
  border-radius: 3px;
  -webkit-border-radius: 20px;
  -moz-border-radius: 20px;
  border-radius: 20px;

}</style>

 <b><input class="btn  btn--green"  type="submit" value="CREATE TICKET"></input>
</b>
<b></b>

 <h1 class="title">VIEW TICKETS FOR <?php echo $_SESSION['username'];?></h1>                    

<?php
$username=$_SESSION["username"];

$query1=mysqli_query($conn,"SELECT * from reguser where username='$username'");
$row1=mysqli_fetch_array($query1);

$ID=$row1["ID"];
$query=mysqli_query($conn,"SELECT * from tickets WHERE ID='$ID'");
$rowcount= mysqli_num_rows($query);
?>
<table border='1' id='table' align='center'>
	<tr onclick='javascript:showRow(this);'> 
		<td>Ticket Number</td>
		<td>Organization Name</td>
		<td>Date</td>
	</tr>
<?php
for($i=1;$i<=$rowcount;$i++)
{
	$row=mysqli_fetch_array($query);
	

?>
<tr onclick='javascript:showRow(this);'>
	<td><?php echo $row["ticketnumber"] ?></td>
	<td><?php echo $row["orgname"] ?></td>
	<td><?php echo $row["date"] ?></td>
</tr>
<?php
}
?>
</table>

</form>


<form align = "center">

        Ticket Number: <output type="text" name="ticketnumber" id="ticketnumber"  style = "color:red;"></output><br><br>

        Organization Name: <output type="text" name="orgsname" id="orgsname" style = "color:red;"></output><br><br>
    
        Date: <output type="text" name="date" id="date" style = "color:red;"></output><br><br>

 </form>


        </section>
        <!-- /.Left col -->
        <!-- right col (We are only adding the ID to make the widgets sortable)-->
  

 

  <!-- Control Sidebar -->
  <aside class="control-sidebar control-sidebar-dark" style="display: none;">
  
  </aside>
  <!-- /.control-sidebar -->
  <!-- Add the sidebar's background. This div must be placed
       immediately after the control sidebar -->
  <div class="control-sidebar-bg"></div>
</div>
<!-- ./wrapper -->

<!-- jQuery 3 -->
<script src="AdminLTE/bower_components/jquery/dist/jquery.min.js"></script>
<!-- jQuery UI 1.11.4 -->
<script src="AdminLTE/bower_components/jquery-ui/jquery-ui.min.js"></script>
<!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
<script>
  $.widget.bridge('uibutton', $.ui.button);
</script>
<!-- Bootstrap 3.3.7 -->
<script src="AdminLTE/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
<!-- Morris.js charts -->
<script src="AdminLTE/bower_components/raphael/raphael.min.js"></script>
<script src="AdminLTE/bower_components/morris.js/morris.min.js"></script>
<!-- Sparkline -->
<script src="AdminLTE/bower_components/jquery-sparkline/dist/jquery.sparkline.min.js"></script>
<!-- jvectormap -->
<script src="AdminLTE/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
<script src="AdminLTE/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"></script>
<!-- jQuery Knob Chart -->
<script src="AdminLTE/bower_components/jquery-knob/dist/jquery.knob.min.js"></script>
<!-- daterangepicker -->
<script src="AdminLTE/bower_components/moment/min/moment.min.js"></script>
<script src="AdminLTE/bower_components/bootstrap-daterangepicker/daterangepicker.js"></script>
<!-- datepicker -->
<script src="AdminLTE/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
<!-- Bootstrap WYSIHTML5 -->
<script src="AdminLTE/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
<!-- Slimscroll -->
<script src="AdminLTE/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
<!-- FastClick -->
<script src="AdminLTE/bower_components/fastclick/lib/fastclick.js"></script>
<!-- AdminLTE App -->
<script src="AdminLTE/dist/js/adminlte.min.js"></script>
<!-- AdminLTE dashboard demo (This is only for demo purposes) -->
<script src="AdminLTE/dist/js/pages/dashboard.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="AdminLTE/dist/js/demo.js"></script>

</body>
</html>

<script>  
 $(document).ready(function(){  
      
           $.ajax({  
                url:"postticket.php",  
                method:"POST",  
                data:{ID:ID},  
                success:function(data){  
                     $('#show_product').html(data);  
                }  
           });  
      });   
 </script>
