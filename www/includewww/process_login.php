<?php
include_once 'db_connect.php';
include_once 'functions.php';
 
sec_session_start(); // Our custom secure way of starting a PHP session.

if (isset($_POST['username'], $_POST['p'])) {
    $username = $_POST['username'];
    $password = $_POST['p']; // The hashed password.
 
    if (login($username, $password, $mysqli) == 1) {
        // Login success 
        error_log($username . " has logged on from: " . $_SERVER['REMOTE_ADDR']);
        if($username == 'test_user') {
            header('Location: ../admin.php');
        }
        else {
            header('Location: ../protected_page.php');
        }
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
}
