<?php
	if (isset($_POST['pass']))
	{
		$random_salt = hash('sha512', uniqid(mt_rand(1, mt_getrandmax()), true));
		//$random_salt = $_POST['salt'];
		$password = hash('sha512', hash('sha512', $_POST['pass']) . $random_salt);

		echo "{ \"salt\": \"{$random_salt}\", \"password\": \"{$password}\"   }";
	}
?>

