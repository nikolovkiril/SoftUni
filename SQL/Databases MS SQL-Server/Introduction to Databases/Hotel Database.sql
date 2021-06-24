--CREATE DATABASE Hotel

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL, 
	FirstName VARCHAR(30) NOT NULL, 
	LastName VARCHAR(30) NOT NULL, 
	Title  VARCHAR(50) NOT NULL, 
	Notes VARCHAR(MAX)
)

CREATE TABLE Customers 
(
	AccountNumber INT PRIMARY KEY IDENTITY NOT NULL,  
	FirstName VARCHAR(30) NOT NULL, 
	LastName VARCHAR(30) NOT NULL, 
	PhoneNumber INT NOT NULL, 
	EmergencyName  VARCHAR(30) NOT NULL, 
	EmergencyNumber INT NOT NULL,
	Notes  VARCHAR(MAX)
)

CREATE TABLE RoomStatus 
(	
	RoomStatus BIT NOT NULL, 
	Notes VARCHAR(MAX)
)

CREATE TABLE RoomTypes 
(	
	RoomType VARCHAR(30) NOT NULL, 
	Notes VARCHAR(MAX)
)

CREATE TABLE BedTypes 
(	
	BedType VARCHAR(30) NOT NULL, 
	Notes VARCHAR(MAX)
)

CREATE TABLE Rooms 
(	
	RoomNumber TINYINT PRIMARY KEY IDENTITY NOT NULL,
	RoomType VARCHAR(30) NOT NULL ,
	BedType VARCHAR(30) NOT NULL,
	Rate TINYINT,
	RoomStatus BIT  NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Payments
 (
	Id INT PRIMARY KEY IDENTITY NOT NULL, 
	EmployeeId INT  NOT NULL, 
	PaymentDate DATETIME  NOT NULL, 
	AccountNumber INT  NOT NULL, 
	FirstDateOccupied DATETIME  NOT NULL, 
	LastDateOccupied DATETIME, 
	TotalDays SMALLINT , 
	AmountCharged DECIMAL(5,2)  NOT NULL, 
	TaxRate DECIMAL(5,2)  NOT NULL , 
	TaxAmount DECIMAL(5,2)  NOT NULL, 
	PaymentTotal DECIMAL(5,2)  NOT NULL, 
	Notes VARCHAR(MAX)
 )

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY NOT NULL, 
	EmployeeId INT  NOT NULL,
	DateOccupied DATETIME,
	AccountNumber INT NOT NULL, 
	RoomNumber TINYINT  NOT NULL, 
	RateApplied TINYINT, 
	PhoneCharge BIT, 
	Notes VARCHAR(MAX)
)


INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
('JOSH','PETROV','HOUSEKEEPING','BEST WORKER IN THAT DEPART.'),
('TRE','WAN','COOK',NULL),
('IVAN','KAMI','WAITER','GOOD PERFORMANCE')

INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
('Mr.Eastwood','',5557841,'Dorroty',5552214,NULL),
('David','Morrell',5551212,'Ms.MorrellY',5551148,NULL),
('James','Cameron',74977415,'Ms.CameronY',5558787,NULL)

INSERT INTO RoomStatus (RoomStatus, Notes) VALUES
(1,NULL),
(1,NULL),
(0,NULL)

INSERT INTO RoomTypes (RoomType, Notes) VALUES
('SINGLE',NULL),
('DOUBLE',NULL),
('APPARTMENT',NULL)

INSERT INTO BedTypes (BedType, Notes) VALUES
('SINGLE',NULL),
('DOUBLE',NULL),
('KING SIZE',NULL)

INSERT INTO Rooms (RoomType, BedType, Rate, RoomStatus, Notes) VALUES
('SINGLE','SINGLE',NULL , 1 , NULL),
('DOUBLE','DOUBLE',NULL , 0 , NULL),
('KING SIZE','KING SIZE',NULL,0,NULL)

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied,
LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
(1,'2020-04-01',41412,'2020-05-01','2020-06-01',30 , 111.11 , 20.00,22.22,133.33,NULL),
(2,'2020-04-01',44444,'2020-05-01','2020-06-01',30 , 111.11 , 20.00,22.22,133.33,NULL),
(3,'2020-04-01',41455,'2020-05-01','2020-06-01',30 , 111.11 , 20.00,22.22,133.33,NULL)

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber,
RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1,'2020-02-01',41412,1,10,1,NULL),
(2,'2020-03-01',44444,2,10 ,1,NULL),
(3,'2020-01-01',41455,3,10,0,NULL)

SELECT * FROM Occupancies


--      Problem 23.Decrease Tax Rate


UPDATE Payments
SET TaxRate-=TaxRate*0.03

SELECT TaxRate FROM Payments

--      Problem 24.Delete All Records

TRUNCATE TABLE Occupancies
