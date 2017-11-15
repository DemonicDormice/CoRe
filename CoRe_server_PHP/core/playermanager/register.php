<?php
include_once '../includes/db_connect.php';
include_once '../includes/psl-config.php';
 
$msg = "";
$msgcode = 0;
 
if (isset($_POST['username'], $_POST['email'], $_POST['p'])) {
    $username = filter_input(INPUT_POST, 'username', FILTER_SANITIZE_STRING);
    $email = filter_input(INPUT_POST, 'email', FILTER_SANITIZE_EMAIL);
    $email = filter_var($email, FILTER_VALIDATE_EMAIL);
    if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
        $msg .= 'The email address you entered is not valid';
		$msgcode = 420;
    }
 
    $password = filter_input(INPUT_POST, 'p', FILTER_SANITIZE_STRING);
    if (strlen($password) != 128) {
        // hashed password needs to be 128 chars long
        $msg .= 'Invalid password configuration.';
		$msgcode = 420;
    }
  
    $prep_stmt = "SELECT id FROM users WHERE email = ? LIMIT 1";
    $stmt = $mysqli->prepare($prep_stmt);
 
    if ($stmt) {
        $stmt->bind_param('s', $email);
        $stmt->execute();
        $stmt->store_result();
 
        if ($stmt->num_rows == 1) {
            // user with same e-mail already exists
            $msg .= 'A user with this email address already exists.';
			$msgcode = 420;
        }
    } else {
        $msg .= 'Database error';
		$msgcode = 500;
    }
	
	$prep_stmt = "SELECT id FROM users WHERE username = ? LIMIT 1";
    $stmt = $mysqli->prepare($prep_stmt);
 
    if ($stmt) {
        $stmt->bind_param('s', $username);
        $stmt->execute();
        $stmt->store_result();
 
        if ($stmt->num_rows == 1) {
            // user with same e-mail already exists
            $msg .= 'A user with the same name already exists.';
			$msgcode = 420;
        }
    } else {
        $msg .= 'Database error';
		$msgcode = 500;
    }
 
    if (empty($msg)) {
        // creates random salt
        $random_salt = hash('sha512', uniqid(openssl_random_pseudo_bytes(16), TRUE));
 
        // creates salted password
        $password = hash('sha512', $password . $random_salt);
 
        // insert user into db
        if ($insert_stmt = $mysqli->prepare("INSERT INTO users (username, email, password, salt) VALUES (?, ?, ?, ?)")) {
            $insert_stmt->bind_param('ssss', $username, $email, $password, $random_salt);
            if (! $insert_stmt->execute()) {
                $msg .= "Error: Registration not successful!";
				$msgcode = 500;
            } else {
				 $msg .= "Registration successful! \nPlease confirm the email verification.";
				$msgcode = 201;
				//TODO
				//send email verfication
			}
        }	
    }
} else {
	 $msg .= "Invalid request. Wrong parameters! \n";
	$msgcode = 420;
}
$post_data = array('http_status' => $msgcode, 'msg' => $msg, 'data' => '');
echo json_encode($post_data, JSON_FORCE_OBJECT);
?>