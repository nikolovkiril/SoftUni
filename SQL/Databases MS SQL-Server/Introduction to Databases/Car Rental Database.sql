CREATE DATABASE CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY NOT NULL ,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate DECIMAL(10,2)  NOT NULL,
	WeeklyRate DECIMAL(10,2) NOT NULL,
	MonthlyRate DECIMAL(10,2) NOT NULL,
	WeekendRate DECIMAL(10,2) NOT NULL 
)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY NOT NULL ,
	PlateNumber NVARCHAR(15) NOT NULL,
	Manufacturer VARCHAR(20) NOT NULL,
	Model VARCHAR(20) NOT NULL,
	CarYear	SMALLINT NOT NULL, 
	CategoryId INT NOT NULL,
	Doors TINYINT  NOT NULL,
	Picture VARCHAR(MAX) NOT NULL,
	Condition VARCHAR(50) NOT NULL,
	Available BIT NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY NOT NULL ,
	FirstName VARCHAR(15) NOT NULL,
	LastName VARCHAR(15) NOT NULL,
	Title VARCHAR(25) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY NOT NULL ,
	DriverLicenceNumber INT NOT NULL,
	FullName VARCHAR(150) NOT NULL,
	[Address] VARCHAR(150) NOT NULL, 
	City VARCHAR(30) NOT NULL, 
	ZIPCode INT NOT NULL, 
	Notes VARCHAR(MAX) 
)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY NOT NULL ,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel TINYINT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd VARCHAR(MAX) ,
	TotalKilometrage INT,
	StartDate DATE NOT NULL,
	EndDate DATE,
	TotalDays SMALLINT,
	RateApplied TINYINT ,
	TaxRate DECIMAL(10,2) NOT NULL ,
	OrderStatus BIT,
	Notes VARCHAR(MAX) 
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES 
('VAN', 55.50,350.23,1220,102.89),
('RALLY', 420.80,2750.23,12202.62,700),
('LIMO', 95.50,550.23,2220.27,172)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES 
('CA5544MH', 'KIA','Sedona Prices',2012,1,5,'https://cars.usnews.com/static/images/Auto/izmo/i159614110/2021_kia_sedona_angularfront.jpg',
'USED - CLEEN', 1),
('CB1111AB', 'Peugeot','2008DKR',2008,2,2,'https://img.redbull.com/images/c_crop,x_0,y_0,h_2133,w_3200/c_fill,w_1500,h_1000/q_auto,f_auto/redbullcom/2017/12/21/4f230e5e-400a-4e46-8c11-51f23e5ef720/the-history-peugeot-dakar-rally',
'USED - CLEEN - VERRY FAST', 1),
('CB888888A', 'AUDI','E-TRON GT',2022,3,4,'https://audimediacenter-a.akamaihd.net/system/production/media/71164/images/a41672e1a01de586f023e4491da3f88548b52984/A1814539_blog.jpg?1582474723',
'NEW', 0)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES 
('Jan Clo','Van Damme','Car cleaner','Need some improvment :)'),
('Vin','Diesel','Petrol worker','Steel petrol sometimes'),
('Kiano','Riis','Valley','Dosnt know how to drive')

INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes) VALUES 
(524755562,'Wiz Khalifa','California (CA)','Los Angeles', 90025 , 'Smoking merch'),
(32323255,'Arnold Schwarzenegger','California (CA)','Los Angeles',90005,null),
(10,'Ali Baba','Unknown','Unknown',1,'Has Driver Licence only for carpet')

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel,
KilometrageStart, KilometrageEnd, TotalKilometrage,StartDate, 
EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES 

(3,1,2,75,90025,90458,433,'2005-05-11','2005-06-11',31,NULL,10.28,1,NULL),
(1,3,1,75,190025,190025,0,'2021-01-11','2021-01-15',4,NULL,0.28,1,NULL),
(2,2,3,75,25,NULL,NULL,'2021-01-13',NULL,NULL,NULL,11.44,0,NULL)


SELECT * FROM Cars
