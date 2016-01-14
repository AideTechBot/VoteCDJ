<?php
include_once 'functions.php';
sec_session_start();
 
// Unset all session values 
$_SESSION = array();
 
// get session parameters 
$params = session_get_cookie_params();
 
// Delete the actual cookie. 
setcookie(session_name(),
        '', time() - 42000, 
        $params["path"], 
        $params["domain"], 
        $params["secure"], 
        $params["httponly"]);
 
// Destroy session 
session_destroy();
?>
<!DOCTYPE html>
<html>
    <head>
        <meta name=viewport content="width=device-width, initial-scale=1">
        <meta charset="UTF-8">
        <title>VoteCDJ</title>
        <link rel="stylesheet" href="../styles/main.css" />
    </head>
    <body>
        <div class="windowbody">
            <div class="windowcontent">
            	Votre vote a &eacute;t&eacute; soumis avec succ&egrave;s. 
            </div>
            <div class="windowfooter">
                <a href="../index.php">Page d'acceuil</a>
            </div>
        </div>
    </body>
</html>