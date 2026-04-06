

-- Create Database
CREATE DATABASE ZestIndia;
GO

USE ZestIndia;
GO

-- Create Table
CREATE TABLE Students
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Age INT,
    Course NVARCHAR(100),
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- Create Student
-- =============================================
CREATE PROCEDURE sp_CreateStudent
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Age INT,
    @Course NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Id INT;

    -- check duplicate email
    IF EXISTS (SELECT 1 FROM Students WHERE Email = @Email)
    BEGIN
        SELECT 'Email already exists' AS Message, 409 AS Code, 'false' AS Success;
        RETURN;
    END

    -- insert student
    INSERT INTO Students (Name, Email, Age, Course, CreatedDate)
    VALUES (@Name, @Email, @Age, @Course, GETDATE());

    SET @Id = SCOPE_IDENTITY();

    SELECT 
        'Student created successfully' AS Message,
        200 AS Code,
        'true' AS Success,
        Id, Name, Email, Age, Course, CreatedDate
    FROM Students
    WHERE Id = @Id;
END
GO

-- =============================================
-- Get All Students
-- =============================================
CREATE PROCEDURE sp_AllStudents
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        'Students retrieved successfully' AS Message,
        200 AS Code,
        'true' AS Success,
        Id, Name, Email, Age, Course, CreatedDate
    FROM Students;
END
GO

-- =============================================
-- Update Student
-- =============================================
CREATE PROCEDURE sp_UpdateStudent
    @Id INT,
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Age INT,
    @Course NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- check student exists
    IF NOT EXISTS (SELECT 1 FROM Students WHERE Id = @Id)
    BEGIN
        SELECT 'No student found' AS Message, 404 AS Code, 'false' AS Success;
        RETURN;
    END

    -- prevent duplicate email
    IF EXISTS (SELECT 1 FROM Students WHERE Email = @Email AND Id <> @Id)
    BEGIN
        SELECT 'Email already exists' AS Message, 409 AS Code, 'false' AS Success;
        RETURN;
    END

    UPDATE Students
    SET Name = @Name,
        Email = @Email,
        Age = @Age,
        Course = @Course
    WHERE Id = @Id;

    SELECT 'Student updated successfully' AS Message, 200 AS Code, 'true' AS Success;
END
GO

-- =============================================
-- Delete Student
-- =============================================
CREATE PROCEDURE sp_DeleteStudent
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Students WHERE Id = @Id)
    BEGIN
        SELECT 'No student found' AS Message, 404 AS Code, 'false' AS Success;
        RETURN;
    END

    DELETE FROM Students WHERE Id = @Id;

    SELECT 'Student deleted successfully' AS Message, 200 AS Code, 'true' AS Success;
END
GO

