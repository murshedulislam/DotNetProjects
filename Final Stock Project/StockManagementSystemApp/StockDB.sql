CREATE DATABASE StockDB

USE StockDB

CREATE TABLE Category(
SL int IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(50)

)

CREATE TABLE Company(
SL int IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(50)

)

CREATE TABLE Item(
ID int IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(50),
ReorderLevel int,
AvailableQuantity int,
CategorySL int FOREIGN KEY REFERENCES Category(SL),
CompanySL int FOREIGN KEY REFERENCES Company(SL),

)

CREATE TABLE StockIN(

DT Date,
ItemID int FOREIGN KEY REFERENCES Item(ID),
Amount int
)

CREATE TABLE StockOUT(
DT Date,
ItemID int FOREIGN KEY REFERENCES Item(ID),
StockCondition VARCHAR(50),
Amount int
)

SELECT * FROM Category
SELECT * FROM Company
SELECT * FROM Item
SELECT * FROM StockIN
SELECT * FROM StockOUT

ALTER TABLE StockIn ADD ID int IDENTITY(1,1)

ALTER TABLE StockOUT ADD ID int IDENTITY(1,1)



CREATE VIEW StocksInView
AS
SELECT StockIN.ID AS ID,StockIN.DT AS Date, Item.Name AS Item, StockIN.Amount AS Quantity FROM Item JOIN StockIN ON Item.ID = StockIN.ItemID

SELECT * FROM StocksInView

SELECT * FROM StockOUT

DELETE FROM StockOUT WHERE ID = 4

SELECT * FROM Category WHERE SL IN(SELECT DISTINCT CategorySL FROM Item WHERE CompanySL = '')

CREATE VIEW SearchView
AS
SELECT Item.Name AS Item, Company.Name AS Company, Category.Name AS Category, item.AvailableQuantity, item.ReorderLevel
FROM Item JOIN Company ON 
Company.SL = Item.CompanySL JOIN Category ON Category.SL = Item.CategorySL 


SELECT * FROM SearchView WHERE Category = 'Soda'

CREATE VIEW StockOutView
AS
SELECT Item.Name AS Item, Company.Name AS Company, StockOUT.Amount AS Amount, StockOUT.DT AS Date, StockOUT.StockCondition AS StockCondition FROM  Item JOIN Company ON Company.SL = Item.CompanySL
JOIN StockOUT ON StockOUT.ItemID = Item.ID


SELECT * FROM StockOutView WHERE Date BETWEEN '2019-06-30' AND '2019-07-02' AND StockCondition = 'Lost' 

--DROP VIEW StockOutView