<?php 

include_once '../includes/db_connect.php';

include_once '../includes/functions.php';

$player_id = 6;

 if ($armystmt = $mysqli->prepare("SELECT idarmy FROM army WHERE player_idplayer = ?"))
									       {
                                             $armystmt->bind_param('s', $player_id);
								            $armystmt->execute();
								            $armystmt->store_result();

								            while($row = $armystmt->fetch()){
                                                echo $row["idarmy"];
                                            }
                                               
}

?>