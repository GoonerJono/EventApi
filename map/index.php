<?php
session_start(); 
       
$locations=array(); // creating array to store 

$uname="root"; //Username of a database.

$pass="";  //Password of database.

$servername="localhost"; //Database servername.

$dbname="queuesystem";  // Your database name.

$db=new mysqli($servername,$uname,$pass,$dbname); // This line is connecting to database using mysqli method.

$query =  $db->query("SELECT * FROM regorgs"); //Retriving the value database.
        //$number_of_rows = mysql_num_rows($db);  
        //echo $number_of_rows;

echo "<center>";
echo "<h1>Queuesystem businesses</h1>";
echo "<Select id = 'search'";
echo "<option>select</option>";
while( $row = $query->fetch_assoc() ){ //fetching row and column from location table.
$orgname = $row['orgname'];

echo "<option>$orgname</option>";

$longitude = $row['lng'];                              
$latitude = $row['lat'];
$link=$row['city'];
            /* Each row is added as a new array */
$locations[]=array( 'orgname'=>$orgname, 'lat'=>$latitude, 'lng'=>$longitude, 'lnk'=>$link );

}

echo "</select>";
echo "<center>";
        //echo $locations[0]['name'].": In stock: ".$locations[0]['lat'].", sold: ".$locations[0]['lng'].".<br>";
        //echo $locations[1]['name'].": In stock: ".$locations[1]['lat'].", sold: ".$locations[1]['lng'].".<br>";
?>

<html>
<body>
    <head>
        <title>ORGANIZATION MAP LOCATION</title>
        <style>
        #map{
            height:100%;
            weight:100px;
        }
        </style>
    
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDrMTfBa9NXyO3izpTE1hrR96YGxmMin4g"></script> 
    <script type="text/javascript">
    var map;
    var Markers = {};
    var infowindow;
    var locations = [
        <?php for($i=0;$i<sizeof($locations);$i++){ $j=$i+1;?>
        [
            'AMC Service',
            '<p>Here is direction of <?php echo $locations[$i]['orgname']?></p><p><a href="<?php echo $locations[$i]['lnk'];?>"><?php echo $locations[$i]['lat'];?>,<?php echo $locations[$i]['lng'];?></a></p>',
            <?php echo $locations[$i]['lat'];?>,
            <?php echo $locations[$i]['lng'];?>,
            0
        ]<?php if($j!=sizeof($locations))echo ","; }?>
    ];
    var origin = new google.maps.LatLng(locations[0][2], locations[0][3]);
    function initialize() {
      var mapOptions = {
        zoom: 16,
        center: origin
      };
      map = new google.maps.Map(document.getElementById('map'), mapOptions);
        infowindow = new google.maps.InfoWindow();
        for(i=0; i<locations.length; i++) {
            var position = new google.maps.LatLng(locations[i][2], locations[i][3]);
            var marker = new google.maps.Marker({
                position: position,
                map: map,

            });
            google.maps.event.addListener(marker, 'click', (function(marker, i) {
                return function() {
                    infowindow.setContent(locations[i][1]);
                    infowindow.setOptions({maxWidth: 200});
                    infowindow.open(map, marker);
                }
            }) (marker, i));
            Markers[locations[i][4]] = marker;
        }
        locate(0);
    }
    function locate(marker_id) {
        var myMarker = Markers[marker_id];
        var markerPosition = myMarker.getPosition();
        map.setCenter(markerPosition);
        google.maps.event.trigger(myMarker, 'click');
    }
    google.maps.event.addDomListener(window, 'load', initialize);
    </script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet">

    <script>
        $("#search").chosen();
    </script>
</head>

<div id="map"></div>

</body>
</html>