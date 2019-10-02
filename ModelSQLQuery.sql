USE CoffeeShop
CREATE  DATABASE CoffeeShop
DROP TABLE Orders

CREATE TABLE Customers(
Id INT IDENTITY(1,1) PRIMARY KEY,
CustomerName VARCHAR (50),
[Address] VARCHAR (50),
Contact VARCHAR (50),
)


CREATE TABLE Items(
Id INT IDENTITY(1,1) PRIMARY KEY,
ItemName VARCHAR (50),
Price FLOAT,
)


CREATE TABLE Orders(
Id INT IDENTITY(1,1) PRIMARY KEY,
CustomerId INT REFERENCES Customers(Id),
ItemId INT REFERENCES Items(Id),
Quantity INT,
Price FLOAT,
TotalPrice FLOAT 
)


INSERT INTO Items VALUES ('Black',120)
INSERT INTO Items VALUES ('Hot',90)
INSERT INTO Items VALUES ('Cold',110)

INSERT INTO Customers VALUES ('fatema', 'Tangail' ,'01738494077')
INSERT INTO Customers VALUES ('Asif', 'Sylhet' ,'017675677941')
INSERT INTO Customers VALUES ('Jannat', 'Narsindi' ,'01738494055')


INSERT INTO Orders VALUES (2,2,2 ,90,180)
INSERT INTO Orders VALUES (2,3,1 ,110,110)
INSERT INTO Orders VALUES (3,1,2 ,120,240)

SELECT * FROM Items
SELECT * FROM Customers
SELECT * FROM Orders

SELECT o.Id, c.CustomerName,i.ItemName,Quantity,i.Price,TotalPrice FROM Orders As o
LEFT JOIN Customers As c ON c.Id = o.CustomerId 
LEFT JOIN Items As i ON i.Id = o.ItemId 

