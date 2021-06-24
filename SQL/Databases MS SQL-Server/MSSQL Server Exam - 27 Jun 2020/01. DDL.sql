--CREATE DATABASE WMS

--USE WMS

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY ,
	FirstName NVARCHAR(50) ,
	LastName NVARCHAR(50) ,
	Phone VARCHAR(12)
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) ,
	LastName NVARCHAR(50) ,
	[Address] NVARCHAR(255)
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY  NOT NULL,
	[Name] NVARCHAR(50) UNIQUE,

)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY ,
	ModelId INT REFERENCES Models(ModelId) NOT NULL,
	[Status] NVARCHAR(11) CHECK ([Status] in  ('Pending' , 'In Progress' , 'Finished')) DEFAULT ('Pending'),
	ClientId INT REFERENCES Clients(ClientId) NOT NULL, 
	MechanicId INT REFERENCES Mechanics(MechanicId) ,
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY  NOT NULL,
	JobId INT REFERENCES Jobs(JobId),
	IssueDate DATE ,
	Delivered BIT DEFAULT(0)  
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY  NOT NULL,
	[Name] NVARCHAR(50) UNIQUE,
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY  NOT NULL,
	SerialNumber NVARCHAR(50) UNIQUE,
	[Description] NVARCHAR(50) ,
	Price DECIMAL (15,2) ,
	VendorId INT REFERENCES Vendors(VendorId),
	StockQty INT DEFAULT(0) CHECK (StockQty >= 0)
)

CREATE TABLE OrderParts
(
	OrderId  INT  REFERENCES Orders(OrderId)   NOT NULL,
	PartId INT  REFERENCES Parts(PartId)  NOT NULL,
	Quantity INT DEFAULT (1) CHECK (Quantity >= 1)
	PRIMARY KEY  (OrderId, PartId) 
)

CREATE TABLE PartsNeeded
(
	JobId INT REFERENCES Jobs(JobId)  ,
	PartId INT REFERENCES Parts(PartId) ,
	Quantity  INT DEFAULT (1) CHECK (Quantity >= 1)
	PRIMARY KEY (JobId, PartId)
)