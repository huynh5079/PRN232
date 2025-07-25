-- 1. Tạo database
CREATE DATABASE PEBolomadtoDB;
GO

USE PEBolomadtoDB;
GO

-- 2. Bảng Users
CREATE TABLE Users (
    UserId INT IDENTITY PRIMARY KEY,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    PasswordHash VARCHAR(100) NOT NULL,
    Role INT NOT NULL DEFAULT 0 -- 0: Staff, 1: Admin
);

-- 3. Bảng Books
CREATE TABLE Books (
    BookId INT IDENTITY PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Author NVARCHAR(100),
    Genre NVARCHAR(100),
    AssignedTo INT FOREIGN KEY REFERENCES Users(UserId)
);

-- 4. Bảng Borrowers
CREATE TABLE Borrowers (
    BorrowerId INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL
);

-- 5. Bảng BorrowRecords
CREATE TABLE BorrowRecords (
    RecordId INT IDENTITY PRIMARY KEY,
    BookId INT FOREIGN KEY REFERENCES Books(BookId),
    BorrowerId INT FOREIGN KEY REFERENCES Borrowers(BorrowerId),
    BorrowDate DATETIME DEFAULT GETDATE(),
    IsReturned BIT DEFAULT 0
);

-- 6. Dữ liệu mẫu: Users
INSERT INTO Users (Email, PasswordHash, Role) VALUES
('admin@fpt.edu.vn', '$2a$11$3DtzViAdQpHTArP3EjrXZ.pNaDLWxEFSTCIi/NQuqD0rOdE0v6FDe', 1), -- password: admin123
('staff1@fpt.edu.vn', '$2a$11$Pq5EY09A7jhFgdyK/cEHeOR9M1YZYXDa5xoT2MH6V0qKXRaqbmT0y', 0), -- password: staff123
('staff2@fpt.edu.vn', '$2a$11$qS8oOACQjCQPaKjHbZt4ieGQ3WxEog3Lq7ZJylg6i/xkekPuMeZx6', 0); -- password: staff123

-- 7. Dữ liệu mẫu: Books
INSERT INTO Books (Title, Author, Genre, AssignedTo) VALUES
('C# Fundamentals', 'John Sharp', 'Programming', 2),
('ASP.NET Core Web API', 'Adam Freeman', 'Web Development', 2),
('Data Structures in Java', 'Robert Lafore', 'Computer Science', 3),
('C# for Beginners', 'Andrew Troelsen', 'Programming', 3);

-- 8. Dữ liệu mẫu: Borrowers
INSERT INTO Borrowers (Name, Email) VALUES
('Nguyen Van A', 'a.nguyen@fpt.edu.vn'),
('Le Thi B', 'b.le@fpt.edu.vn');

-- 9. Dữ liệu mẫu: BorrowRecords
INSERT INTO BorrowRecords (BookId, BorrowerId, BorrowDate, IsReturned) VALUES
(1, 1, GETDATE(), 0),
(3, 2, GETDATE(), 1);
