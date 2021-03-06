CREATE DATABASE UsersAndAwards

USE UsersAndAwards

CREATE TABLE Users(
ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Users PRIMARY KEY,
USERNAME nvarchar(50) NOT NULL,
DATE_OF_BIRTH date NOT NULL,
AGE int NOT NULL
)

CREATE TABLE Awards(
ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Awards PRIMARY KEY, 
TITLE nvarchar(50) NOT NULL
)

CREATE TABLE User_To_Awards(
ID_USER int CONSTRAINT FK_User_To_Awards_Users FOREIGN KEY(ID_USER) REFERENCES Users(ID),
ID_AWARD int CONSTRAINT FK_User_To_Awards_Awards FOREIGN KEY(ID_AWARD) REFERENCES Awards(ID)
)