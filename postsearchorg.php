<?php  
 //load_data.php  
 $connect = mysqli_connect("localhost", "root", "", "queuesystem");  
 $output = '';  
 if(isset($_POST["serviceid"]))  
 {  
      if($_POST["serviceid"] != '')  
      {  
           $sql = "SELECT * FROM regorgs WHERE serviceid = '".$_POST["serviceid"]."'";  
      }  
      else  
      {  
           $sql = "SELECT * FROM regorgs";  
      }  
      $result = mysqli_query($connect, $sql);  
      while($row = mysqli_fetch_array($result))  
      {  
        
          $output .= '<div style="border:1px solid #ccc; padding:20px; margin-bottom:20px;">'.$row["orgname"].' '.$row["province"].'  '.$row["city"].'  '.$row["suburb"].'  '.$row["distance"].' KMs </div>'; 
        
      }  
      echo $output;  
 }  


if(isset($_POST["provinceid"]))  
 {  
      if($_POST["provinceid"] != '')  
      {  
           $sql = "SELECT * FROM regorgs WHERE provinceid = '".$_POST["provinceid"]."'";  
      }  
      else  
      {  
           $sql = "SELECT * FROM regorgs";  
      }  
      $result = mysqli_query($connect, $sql);  
      while($row = mysqli_fetch_array($result))  
      {  
        
          $output .= '<div style="border:1px solid #ccc; padding:20px; margin-bottom:20px;">'.$row["orgname"].' '.$row["province"].'  '.$row["city"].'  '.$row["suburb"].'  '.$row["distance"].' KMs </div>'; 
        
      }  
      echo $output;  
 }  



 ?>  