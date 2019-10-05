USE FirstDB

SELECT * FROM StocksInView

select * from StockIN

SELECT * FROM Item

ALTER TABLE StockIn ADD ID int IDENTITY(1,1)

ALTER TABLE StockOUT ADD ID int IDENTITY(1,1)


DROP VIEW	StocksInView

CREATE VIEW StocksInView
AS
SELECT StockIN.ID AS ID, StockIN.ItemID, StockIN.DT AS Date, Item.Name AS Item, StockIN.Amount AS Amount FROM Item JOIN StockIN ON Item.ID = StockIN.ItemID

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

INSERT INTO StockOUT(DT, ItemID, StockCondition, Amount) VALUES('2019-06-30', 1, 'Lost', 9)

USE StockDB

DELETE FROM Item WHERE ID = 3