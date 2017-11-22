<?php
include_once '../includes/db_connect.php';
include_once '../includes/functions.php';
 
$msg = "";
$msgcode = 0;
$data = null;
$json_data = "";

sec_session_start(); //start secure session
if (isset($_POST['email'], $_POST['p'])) {
    $email = $_POST['email'];
    $password = $_POST['p']; // the hashed password
 
    if (login($email, $password, $mysqli) == true) {      
        $msg="Login successful.";
        $msgcode = 200;
        
            //get the user data
        if ($stmt = $mysqli->prepare("SELECT id, username, password
            FROM users
           WHERE email = ?
            LIMIT 1")) {
            $stmt->bind_param('s', $email); 
            $stmt->execute();   
            $stmt->store_result();
            $stmt->bind_result($user_id, $username, $db_password);
            $stmt->fetch();
          }
        
        //get the player data if there is a player
        $player = null;
        
        if ($stmt = $mysqli->prepare("SELECT idplayer, level, attitude, playername
            FROM player
           WHERE users_id = ?
            LIMIT 1")) {
            $stmt->bind_param('s', $user_id); 
            $stmt->execute();   
            $stmt->store_result();
            $stmt->bind_result($player_id, $level, $attitude, $playername);
            $stmt->fetch();
            $player = array('playername' => $playername, 'level' => $level, 'attitude' => $attitude);
          }
        
        $data = array('username' => $username, 'password' => $password, 'email' => $email, 'player' => $player);
        
        } else {
            // login not successful
           $msg="E-Mail or password not correct. Please try again.";
           $msgcode = 401;
        }
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