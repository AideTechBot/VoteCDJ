<?php
include_once 'db_connect.php';
include_once 'psl-config.php';
$random_salt = hash('sha512', uniqid(mt_rand(1, mt_getrandmax()), true));

// Create salted password 
$password = hash('sha512', "dickbutt6969" . $random_salt);

echo $random_salt;
echo "<br>";
echo $password;