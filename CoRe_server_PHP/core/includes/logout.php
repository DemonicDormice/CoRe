<?php
include_once 'includes/functions.php';
sec_session_start();
 
// reset all session variables
$_SESSION = array();
 
// get session parameters
$params = session_get_cookie_params();
 
// delete cookie
setcookie(session_name(),
        '', time() - 42000, 
        $params["path"], 
        $params["domain"], 
        $params["secure"], 
        $params["httponly"]);
 
session_destroy();
header('Location: ../index.php');
?>