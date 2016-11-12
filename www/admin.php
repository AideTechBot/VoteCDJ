<?php
ini_set('include_path', '/var/www/includewww');
include_once 'db_connect.php';
include_once 'functions.php';
sec_session_start();
?>
<!-- VOTE CDJ MANUEL DIONNE -->
<!DOCTYPE html>
<html>
    <head>
        <meta name=viewport content="width=device-width, initial-scale=1">
        <meta charset="UTF-8">
        <?php if (login_check($mysqli) == true) : ?>
            <title>VoteCDJ ADMIN</title>
        <?php else : ?>
            <title>VoteCDJ : Erreur</title>
        <?php endif; ?>   
        <link rel="stylesheet" href="styles/main.css" />
        <link rel="stylesheet" href="styles/admin.css" />
    </head>
    <body>
        <?php if ((login_check($mysqli) == true) && ($_SESSION['username'] == 'test_user')) : ?>
            <div class="adminbody">
                <div class="adminheader">
                    Bienvenue <?php echo htmlentities($_SESSION['username']); ?>!
                </div>
                <div class="adminvotedisplay">
                    <?php
                        $post = $mysqli->query("SELECT * FROM post WHERE grade IN (SELECT grade FROM members WHERE username='{$_SESSION['username']}')");
                        echo "<h4>R&eacute;sult&acirc;ts du vote</h4>";
                        while($row = $post->fetch_assoc()) { 
                            echo "<div class='adminvotecell'>";
                            echo "<h5>" . $row['name'] . "</h5>";
                            //echo "<br>";
                            $candidates = $mysqli->query("SELECT * FROM candidates WHERE postid={$row['id']}");
                            while($candidate = $candidates->fetch_assoc()) { 
                                echo "<div class='voterow'>";
                                $votes = $mysqli->query("SELECT COUNT(*) as votes FROM voteHistory WHERE candidateID={$candidate['id']}");
                                $num = $votes->fetch_assoc();
                                echo($candidate['name'] . ":&nbsp;<span class=votes>" . $num['votes'] . "</span>");
                                echo "</div>";
                            }
                            echo "</div>"; 
                        }
                    ?> 
                </div>
                <div class="adminfooter">
                    <a href="includewww/logout.php">D&eacute;connexion</a>
                </div>
            </div>
        <?php else : ?>
            <p>
                <div class="error">Vous n'&ecirc;tes pas autoris&eacute; &agrave; acc&eacute;der &agrave; cette page. <a href="index.php">Connectez-vous</a>.</div>
            </p>
        <?php endif; ?>
    </body>
</html>