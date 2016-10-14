<?php
include_once 'db_connect.php';
include_once 'functions.php';
sec_session_start(); // Our custom secure way of starting a PHP session.


if (isset($_POST['username'])) {
    $username = $_POST['username'];
    if(!isset($_POST['p']))
    {
        $password = hash('sha512', $password);
    }
    else
    {
        $password = $_POST['p']; // The hashed password.
    }
 
    if (login($username, $password, $mysqli) == 1) {
        // Login success 
        header('Location: ../protected_page.php');
    } elseif (login($username, $password, $mysqli) == 2) {
        header('Location: ../index.php?error=2');
    } elseif (login($username, $password, $mysqli) == 3) {
        header('Location: ../index.php?error=3');
    } else {
        // Login failed 
        header('Location: ../index.php?error=1');
    }
} else {
    // The correct POST variables were not sent to this page. 
    echo 'Invalid Request';
    error_log("Invalid Request");
}
?>