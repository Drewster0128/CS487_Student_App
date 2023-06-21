USE student;

CREATE TABLE student (
    aNumber CHAR(9),
    fName VARCHAR(25),
    lName VARCHAR(25),
    email VARCHAR(25),
    username VARCHAR(25),
    password VARCHAR(25),
    token VARCHAR(256),
    PRIMARY KEY (aNumber)
);

INSERT INTO student (aNumber, fName, lName, email, username, password) VALUES ("20457959", "Andrew", "Cook", "acook21@hawk.iit.edu", "acook21", "testPassword");