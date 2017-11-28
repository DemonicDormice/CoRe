<?php
include_once '../includes/db_connect.php';
include_once '../includes/functions.php';
 
$msg = "";
$msgcode = 0;
$data = null;
$json_data = "";

sec_session_start(); //start secure session
if (isset($_POST['email'], $_POST['p']) {
    $email = $_POST['email'];
    $password = $_POST['p']; // the hashed password
 
    if (login($email, $password, $mysqli) == true) {      
        $msg="Login successful.";
        $msgcode = 200;
        
            //get the world and common realm data
        $worldArray = array();
        if ($stmt = $mysqli->prepare("SELECT idworld, endtime, name
                    FROM world
                   WHERE endtime >= NOW()")) {
            $stmt->execute();
            $stmt->bind_result($idworld,$endtime,$worldname);
            while( $result->fetch()) {
                
                //get the realm data
                $realmsArray = array();
if ($result = $mysqli->query("SELECT idrealm, name, type, x, y
                    FROM realm
                   WHERE world_idworld = ?")) {

    while($row = $result->fetch_array(MYSQL_ASSOC)) {
            $realmsArray[] = $row;
    }
}

$result->close();
                $realmdata = json_encode($realmdata);
                
                //push worlds with 
                array_push($worldArray, array("worldid" => $idworld, "endtime" => $endtime, "worldname" => $worldname, "realms" => $realmdata));
      
            }
           $data = json_encode($worldArray);
        }
        $result->close();
        
       
} else {
    $msg="Invalid request. Some Parameters are missing.";
    $msgcode = 420;
}

if($data != null){
    $json_data = json_encode($data, JSON_FORCE_OBJECT);
}

$post_data = array('http_status' => $msgcode, 'msg' => $msg, 'data' => $json_data);
echo json_encode($post_data, JSON_FORCE_OBJECT);

?>