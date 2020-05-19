-- выбрать всех пользователей
GO
CREATE PROCEDURE GetAllUsers
AS
BEGIN
SELECT dbo.Users.ID, dbo.Users.USERNAME, dbo.Users.DATE_OF_BIRTH, dbo.Users.AGE, ISNULL (dbo.Awards.TITLE,'no') AS TITLE
FROM     dbo.Users LEFT OUTER JOIN
                  dbo.User_To_Awards ON dbo.Users.ID = dbo.User_To_Awards.ID_USER LEFT OUTER JOIN
                  dbo.Awards ON dbo.User_To_Awards.ID_AWARD = dbo.Awards.ID
ORDER BY dbo.Users.ID
END

-- добавить пользователя
GO
CREATE PROCEDURE AddUser
 @Username NVARCHAR(50),
 @DateOfBirth datetime,
 @Age NVARCHAR(50)
AS
BEGIN
 INSERT INTO Users([USERNAME],[DATE_OF_BIRTH],[AGE]) 
 VALUES(@Username, @DateOfBirth, @Age)
 END

-- удалить пользователя по индексу
GO
CREATE PROCEDURE RemoveUser
@index int
AS
BEGIN
DELETE FROM User_To_Awards
WHERE ID_USER = @index
DELETE FROM Users
WHERE ID = @index
END

-- выбрать все награды
GO
CREATE PROCEDURE GetAllAwards
AS
BEGIN
SELECT * FROM Awards
END

-- добавить награду
GO
CREATE PROCEDURE AddAward
 @Title NVARCHAR(50)
AS
BEGIN
 INSERT INTO Awards([TITLE]) 
 VALUES(@Title)
 END

-- удалить награду по индексу
GO
CREATE PROCEDURE RemoveAward
@index int
AS
BEGIN
DELETE FROM User_To_Awards
WHERE ID_AWARD = @index
DELETE FROM Awards
WHERE ID = @index
END
