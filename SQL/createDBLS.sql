CREATE TABLE Position
(
    id INT PRIMARY KEY NOT NULL,
    name VARCHAR(50) NOT NULL,
    cameraId INT NOT NULL
);
CREATE UNIQUE INDEX Position_id_uindex ON Position (id);
CREATE TABLE [User]
(
    id VARCHAR(50) PRIMARY KEY NOT NULL,
    email VARCHAR(50) NOT NULL,
    lastPosition INT,
    appToken VARCHAR(255) NOT NULL,
    lastPositionTime DATE,
    ghostmode BIT DEFAULT 1 NOT NULL,
    name VARCHAR(100) NOT NULL,
    CONSTRAINT User_Position_id_fk FOREIGN KEY (lastPosition) REFERENCES Position (id)
);
CREATE UNIQUE INDEX User_id_uindex ON [User] (id);
CREATE UNIQUE INDEX User_email_uindex ON [User] (email);
CREATE UNIQUE INDEX User_appToken_uindex ON [User] (appToken);