<html>
	<head>
		<script type="text/JavaScript" src="js/sha512.js"></script> 
	    <script type="text/JavaScript" src="js/form.js"></script>
	</head>
	<body>
		<form action="salt.php" method="post">
		  <input type="text" name="pass" value="" />
		  <input type="submit" />
		</form>
		<?php
			echo "hello<br>";
			if (isset($_POST['pass']))
			{
				echo "password set<br>";
				$random_salt = hash('sha512', uniqid(mt_rand(1, mt_getrandmax()), true));

				$password = hash('sha512', $_POST['pass'] . $random_salt);

				echo "SALT: {$random_salt}<br>";
				echo "PASS: {$password}<br>";
			}
		?>
	</body>
</html>
