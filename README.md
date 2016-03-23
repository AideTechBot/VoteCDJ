### Preface
For a non-technical explanation in French, please refer to the user’s manual.

***

### Introduction
This project is meant to enable the students of the Cité des Jeunes to quick and easy voting for the student government. In this document, there will be a full technical documentation of the inner workings of the system. Included in this document are: explanations, code samples and diagrams to explain key concepts of the system. Expect this text to be fairly technical and the reader should be proficient in C#, PHP, HTML and SQL databases before making changes to the system. **For security, passwords have been withheld from this page and are present in the physical copy of the documentation.**

***

### Design (Server)
#### Users
To set up the MySQL users that the systems require you need to enable remote access on port 3306. Then edit the my.cnf or my.ini file and comment out: <br>
    `bind-address = 127.0.0.1` <br>
Once you did that you can now create two users to be controlled by the system called sec_user and sec_remote. <br>
    `CREATE USER 'sec_remote'@'%' IDENTIFIED BY '**password**';	` <br>
    `CREATE USER 'sec_user'@'%' IDENTIFIED BY '**password**';` <br>
Then give the users permissions using these queries: <br>
    `GRANT SELECT, INSERT, UPDATE, DELETE ON 'Vote'.* TO 'sec_remote'@'%';` <br>
    `GRANT SELECT, INSERT, UPDATE ON 'Vote'.* TO 'sec_user'@'localhost';` <br>
Then add the test user into the database using: <br>
    `INSERT INTO 'Vote'.'members' VALUES(1, 'test_user','**longhash**','**longhash**',0,9);` <br>
And now you're set up all ready to go <br>

#### MySQL Database Layout
In the case of a file system corruption or accidental deletion of important tables, this section aims to help the user understand the layout of the database itself. Below is the hierarchy of the database and the type of columns.
> **Vote: database name** <br>
> 1-**candidates**: table name <br>
> |-id: INT NOT NULL AUTO_INCREMENT PRIMARY KEY <br>
> |-postID: INT NOT NULL <br>
> |-name: CHAR(128) NOT NULL <br>
> |-grade: INT NOT NULL <br>
> | <br>
> 2-**login_attempts**: table name <br>
> |-user_id: INT(11) NOT NULL <br>
> |-time: VARCHAR(30) NOT NULL <br>
> | <br>
> 3-**members**: table name <br>
> |-id: INT NOT NULL AUTO_INCREMENT PRIMARY KEY <br>
> |-username: VARCHAR(30) NOT NULL <br>
> |-password: CHAR(128) NOT NULL <br>
> |-salt: CHAR(128) NOT NULL <br>
> |-hasvoted: INT NOT NULL <-- Boolean int (1 or 0) <br>
> |-grade: INT NOT NULL <br>
> | <br>
> 4-**post**: table name <br>
> |-id: INT NOT NULL AUTO_INCREMENT PRIMARY KEY <br>
> |-name: CHAR(128) NOT NULL <br>
> |-grade: INT NOT NULL <br>
> | <br>
> 5-**vars**: table name <br>
> |-voteStarted: INT NOT NULL <-- Boolean int (1 or 0) <br>
> | <br>
> 6-**voteHistory**: table name <br>
> |-id: INT NOT NULL AUTO_INCREMENT PRIMARY KEY <br>
> |-voteTime: DATETIME NOT NULL <br>
> |-candidateID: INT NOT NULL <br>
> |-postID: INT NOT NULL <br>

#### Web server
The web server used is Apache v2.2.22 and PHP v5.4.41. Whether it’s Linux or Windows it doesn’t matter. The setup was built on a Raspberry Pi B+ but it was designed for multiple operating systems. To install the system, copy the files of the www folder (https://github.com/AideTechBot/VoteCDJ/tree/master/www) to the web server’s index. You can test if the server is working by logging in using this test user: <br>
> USERNAME: foo <br>
> PASSWORD: bar <br>

***

### Authors and Contributors
* Manuel Dionne (@aidetechbot)
* the internet

***

### Support or Contact
Having trouble with VoteCDJ? Contact me at [***REMOVED***](mailto:***REMOVED***). 