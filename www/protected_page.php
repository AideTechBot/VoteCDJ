<!-- VOTE CDJ MANUEL DIONNE -->
<?php
ini_set('include_path', '/var/www/includewww/');

include_once 'db_connect.php';
include_once 'functions.php';
 
sec_session_start();
?>
<!DOCTYPE html>
<html>
    <head>
        <meta name=viewport content="width=device-width, initial-scale=1">
        <meta charset="UTF-8">
        <?php if (login_check($mysqli) == true) : ?>
            <title>VoteCDJ : <?php echo htmlentities($_SESSION['username']); ?></title>
        <?php else : ?>
            <title>VoteCDJ : Erreur</title>
        <?php endif; ?>   
        <link rel="stylesheet" href="styles/main.css" />
    </head>
    <body>
        <?php if (login_check($mysqli) == true) : ?>
            <div class="windowbody">
                <div class="windowheader">
                    Bienvenue <?php echo htmlentities($_SESSION['username']); ?>!
                </div>
                <div class="windowcontent">
                    <?php
                        $post = $mysqli->query("SELECT * FROM post WHERE grade IN (SELECT grade FROM members WHERE username='{$_SESSION['username']}')");

                        echo "<form action='includewww/vote.php' method='post'>";
                        while($row = $post->fetch_assoc()) { 
                            echo "<div class='votecell'>";
                            echo $row['name'];
                            echo "<br>";
                            $candidates = $mysqli->query("SELECT * FROM candidates WHERE postid={$row['id']}");
                            while($candidate = $candidates->fetch_assoc()) { 
                                echo "<input type='radio' name='", str_replace(" ","", $row['name']), "' value='{$candidate['id']}'>";
                                echo $candidate['name'];
                                echo "<br>";
                            }
                            echo "</div>"; 
                        }
                        echo "<input type='submit' name='submit' value='Soumettre'/>"; 
                        echo "</form>";
                    ?> 
                </div>
                <div class="windowfooter">
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