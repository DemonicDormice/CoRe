<?php
include_once '../includes/db_connect.php';

include_once '../includes/functions.php';

$msg = "";
$msgcode = 0;
$data = null;
sec_session_start(); //start secure session

if (isset($_POST['email'], $_POST['p'], $_POST['level'], $_POST['attitude'], $_POST['playername']))
{
	$email = $_POST['email'];
	$password = $_POST['p']; // the hashed password
	$playername = $_POST['playername'];
	$level = $_POST['level'];
	$attitude = $_POST['attitude'];
	if (login($email, $password, $mysqli) == true)
	{
		$msg = "Login successful. \n";
		$msgcode = 200;

		// get the user data

		if ($stmt = $mysqli->prepare("SELECT id
            FROM users
           WHERE email = ?
            LIMIT 1"))
		{
			$stmt->bind_param('s', $email);
			$stmt->execute();
			$stmt->store_result();
			$stmt->bind_result($user_id);
			$stmt->fetch();
			if ($stmt = $mysqli->prepare("SELECT idplayer
            FROM player
           WHERE users_id = ?
            LIMIT 1"))
			{
				$stmt->bind_param('s', $user_id);
				$stmt->execute();
				$stmt->store_result();
				$stmt->bind_result($player_id);
				$stmt->fetch();
				if ($stmt->num_rows == 1)
				{

					// player available... update

					if ($insert_stmt = $mysqli->prepare("UPDATE player SET playername=?, attitude=?, level=? WHERE users_id=?"))
					{
						$insert_stmt->bind_param('ssss', $playername, $attitude, $level, $user_id);
						if (!$insert_stmt->execute())
						{
							$msg.= "Playerdata update not successful!";
							$msgcode = 500;
						}
						else
						{
							$msg.= "Playerdata update successful!";
							$msgcode = 201;
						}
					}
					else
					{

						// player not available... insert

						if ($insert_stmt = $mysqli->prepare("INSERT INTO player (playername, attitude, level, users_id) VALUES (?, ?, ?, ?)"))
						{
							$insert_stmt->bind_param('ssss', $playername, $attitude, $level, $user_id);
							if (!$insert_stmt->execute())
							{
								$msg.= "Playercreation not successful!";
								$msgcode = 500;
							}
							else
							{
								$msg.= "Playercreation successful!";
								$msgcode = 201;

								// create 3 armys for the new player

								if ($stmt = $mysqli->prepare("SELECT idplayer
            FROM player
           WHERE users_id = ?
            LIMIT 1"))
								{
									$stmt->bind_param('s', $user_id);
									$stmt->execute();
									$stmt->store_result();
									$stmt->bind_result($player_id);
									$stmt->fetch();
									if ($stmt->num_rows == 1)
									{
										if ($insert_stmt = $mysqli->prepare("INSERT INTO army (player_idplayer) VALUES (?), (?), (?)"))
										{
											$insert_stmt->bind_param('sss', $player_id, $player_id, $player_id);
											if (!$insert_stmt->execute())
											{
												$msg.= "Army creation for new player not successful!";
												$msgcode = 500;
											}
											else
											{
												$msg.= "Army creation for new player successful!";
												$msgcode = 201;
											}
										}
										else
										{
											$msg.= "Player not found for creating armys!";
											$msgcode = 500;
										}
									}
								}
							}
						}
						else
						{
							$msg.= 'Database error';
							$msgcode = 500;
						}
					}
				}
				else
				{
					// login not successful
					$msg = "E-Mail or password not correct. Please try again.";
					$msgcode = 401;
				}
			}
			else
			{
				$msg = "Invalid request. Some Parameters are missing.";
				$msgcode = 420;
			}

			if ($data != null)
			{
				$json_data = json_encode($data, JSON_FORCE_OBJECT);
			}

			$post_data = array(
				'http_status' => $msgcode,
				'msg' => $msg,
				'data' => $json_data
			);
			echo json_encode($post_data, JSON_FORCE_OBJECT);
?>