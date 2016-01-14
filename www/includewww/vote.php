<?php
include_once 'db_connect.php';
include_once 'functions.php';
 
sec_session_start(); // Our custom secure way of starting a PHP session.
?>
<?php if (login_check($mysqli) == true) : ?>
    <?php
    $poste = $mysqli->query("SELECT * FROM post WHERE grade IN (SELECT grade FROM members WHERE username='{$_SESSION['username']}')");
    while($row = $poste->fetch_assoc()) {
        if (isset($_POST[str_replace(' ', '',$row['name'])], $_POST['submit'])) { 
            $id = $_POST[str_replace(' ', '',$row['name'])];
            if (vote(mysqli_real_escape_string($mysqli,$id), $mysqli) == false) {
                goto end;
            }
        } else {
            // The correct POST variables were not sent to this page. 
            error_log("Invalid post variables sent.");
            echo 'Invalid Request';
            exit(1);
        }
    }


    $qry = "UPDATE members SET hasvoted=True WHERE username='{$_SESSION['username']}';";
    $mysqli->query($qry);

    header('Location: vote_pass.php');
    exit(0);
    end:
    header('Location: logout.php');

    ?>
<?php else : ?>
    Not logged in.
<?php endif; ?>
