<?php
ini_set('include_path', '/var/www/includewww/');
include_once 'db_connect.php';
include_once 'functions.php';
sec_session_start();

if (login_check($mysqli) == true) {
    header('Location: ../protected_page.php');
}
?>
<!-- VOTE CDJ MANUEL DIONNE -->
<!DOCTYPE html>
<html>
    <head>
        <title>VoteCDJ</title>
        <link rel="stylesheet" href="styles/main.css" />
        <meta name=viewport content="width=device-width, initial-scale=1">
        <script type="text/JavaScript" src="js/sha512.js"></script> 
        <script type="text/JavaScript" src="js/form.js"></script>
        <script type="text/JavaScript">
        function nextBox() {
            if (event.keyCode == 13) {
                formhash(this.form, this.form.password);
            }
        }

        function logout() {
            if (confirm('\u00CAtes-vous s\u00FBr de vouloir vous d\u00E9connecter?')) {
                window.location = 'includewww/logout.php';
            }
        }
        </script> 
    </head>
    <body>
        <div id="loginbody">
            <div id="logosection">
                <img id="logo" src="images/cdj.png" height=175 width=175>
            </div>
            <?php
            if (isset($_GET['error'])) {
                if ($_GET['error'] == 1) {
                    echo '<p class="error">Le nom d\'utilisateur ou le mot de passe est incorrect.</p>';
                }
                elseif ($_GET['error'] == 2) {
                    echo '<p class="error">Vous avez d&eacute;j&agrave; vot&eacute;.</p>';
                }
                else {
                    echo '<p class="error">Le vote est ferm&eacute;.</p>';
                }
                
            }
            else {
                $line = fgets(fopen("school.txt", 'r'));
                echo '<p class="titleVOTE">', $line, '<br><br></p>';
            }
            ?> 
            <form action="includewww/process_login.php" method="post" name="login_form"> 
                <input placeholder="Nom d'utilisateur" type="text" name="username" onkeyup="nextBox()"/><br>
                <input placeholder="Mot de passe" type="hidden" value="1" name="password" id="password" onkeyup="if (event.keyCode == 13) { formhash(this.form, this.form.password); return false; }"/><br>
                <input type="button" value="Acc&eacute;der" onclick="formhash(this.form, this.form.password);" /> 
            </form> 
        </div>   
    </body>
</html>