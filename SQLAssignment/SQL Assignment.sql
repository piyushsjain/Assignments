USE AdventureWorks2008R2

------------------------------------------------------------------Exercise 1-----------------------------------------------------
--1
SELECT COUNT(*) as NumberOfRecords 
FROM Sales.SalesPerson;

--2
SELECT FirstName,LastName 
FROM Person.Person
WHERE FirstName LIKE 'B%';

--3
SELECT Person.Person.FirstName, Person.Person.LastName, Person.Person.BusinessEntityID
FROM Person.Person INNER JOIN HumanResources.Employee
ON Person.Person.BusinessEntityID = HumanResources.Employee.BusinessEntityID
WHERE HumanResources.Employee.JobTitle = 'Design Engineer' OR 
HumanResources.Employee.JobTitle = 'Tool Designer' OR 
HumanResources.Employee.JobTitle ='Marketing Assistant';

--4
SELECT Name, Color
FROM Production.Product
WHERE weight = (SELECT MAX(Weight) FROM Production.Product);

--5
SELECT description, ISNULL(MaxQty,0.00)
FROM Sales.SpecialOffer;

--6
SELECT AVG(AverageRate) AS 'Average exchange rate for the day'
FROM Sales.CurrencyRate
WHERE FromCurrencyCode = 'USD' AND ToCurrencyCode = 'GBP' and datepart(year,CurrencyRateDate)=2005;

--7
SELECT ROW_NUMBER() over (order by FirstName asc) as ROWNUMBER, FirstName, LastName
FROM Person.Person
WHERE Firstname LIKE '%ss%';

--8
SELECT BusinessEntityID,
CASE
    WHEN CommissionPct = 0.00 THEN 'Band 0'
    WHEN CommissionPct > 0 and CommissionPct<= 0.01 THEN 'Band 1'
    WHEN CommissionPct > 0.01 and CommissionPct <= 0.015 THEN 'Band 2'
	WHEN CommissionPct > 0.015 THEN 'Band 3'
END as CommissionBand
FROM Sales.SalesPerson
order by CommissionPct;

--9
DECLARE @return_value as int

Select @return_value = BusinessEntityID
From person.Person
Where FirstName ='Ruth' and lastname = 'Ellerbrock' and PersonType='EM'

EXEC [dbo].[uspGetEmployeeManagers]
@BusinessEntityID = @return_value

--10
Select ProductID
FROM Production.Product
WHERE safetystocklevel = (SELECT max(SafetyStockLevel) FROM Production.Product);


------------------------------------------------------------------Exercise 2-----------------------------------------------------

--JOIN
	SELECT FirstName, LastName
	FROM Person.Person JOIN
	Sales.Customer ON
	Person.Person.BusinessEntityID = Sales.Customer.CustomerID LEFT JOIN
	Sales.SalesOrderHeader ON
	Sales.Customer.CustomerID = Sales.SalesOrderHeader.CustomerID
	WHERE Sales.SalesOrderHeader.SalesOrderID IS NULL;

--Subquery
	SELECT FirstName, LastName
	FROM Person.Person
	Where BusinessEntityID IN (SELECT CustomerID FROM Sales.Customer
							  WHERE CustomerID NOT IN  (SELECT CustomerID FROM Sales.SalesOrderHeader));
	
--CTE
	WITH UnorderProductCustomers (FirstName, LastName)
	AS (
	SELECT FirstName, LastName
	FROM Person.Person JOIN
	Sales.Customer ON
	Person.Person.BusinessEntityID = Sales.Customer.CustomerID LEFT JOIN
	Sales.SalesOrderHeader ON
	Sales.Customer.CustomerID = Sales.SalesOrderHeader.CustomerID
	WHERE Sales.SalesOrderHeader.SalesOrderID IS NULL
   )
	SELECT FirstName, LastName
	FROM UnorderProductCustomers;

--EXIST
	SELECT Person.Person.FirstName + Person.Person.LastName
	FROM Person.Person
	WHERE EXISTS (SELECT Sales.Customer.CustomerID
	FROM Sales.Customer
	WHERE Person.Person.BusinessEntityID = Sales.Customer.CustomerID AND
	NOT EXISTS(SELECT Sales.SalesOrderHeader.CustomerID
	FROM Sales.SalesOrderHeader
	WHERE Sales.SalesOrderHeader.CustomerID = Sales.SalesOrderHeader.CustomerID));

------------------------------------------------------------------Exercise 3-----------------------------------------------------
	SELECT  TOP 5* 
	FROM Sales.SalesOrderHeader 
	WHERE TotalDue>70000 
	ORDER BY OrderDate DESC;


------------------------------------------------------------------Exercise 4-----------------------------------------------------

	Select * from dbo.Fun(43659,'USD','07/01/2005') 
	
	Alter Function Fun (
		@SalesOrderID int, 
		@CurrencyCode nvarchar(3), 
		@dte date
	)
	Returns table
	as
	Return
		Select OrderQty,ProductID,UnitPrice, UnitPrice*EndOfDayRate as UnitPriceConverted 
		From Sales.SalesOrderDetail, Sales.CurrencyRate
		Where SalesOrderID = @SalesOrderID AND ToCurrencyCode = @CurrencyCode AND Sales.CurrencyRate.CurrencyRateDate = @Dte 

------------------------------------------------------------------Exercise 5-----------------------------------------------------

	Execute seekingname
	
	Alter PROCEDURE seekingname 
	@Name nvarchar(30) = 'Piyush'
	AS
	BEGIN
		SELECT FirstName,MiddleName,LastName
		FROM Person.Person
		WHERE FirstName=@Name
	END


------------------------------------------------------------------Exercise 6-----------------------------------------------------


CREATE TRIGGER [Production].UpdateTrigger
ON Production.Product
INSTEAD OF UPDATE
AS
SET NOCOUNT ON
BEGIN
	IF UPDATE(ListPrice)						
	DECLARE @OldListPrice money
	DECLARE @InsertedListPrice money
	DECLARE @ID int
	SELECT @OldListPrice = p.ListPrice,
		   @InsertedListPrice=inserted.ListPrice,
		   @ID = inserted.ProductID
	FROM Production.Product p, inserted
	WHERE p.ProductID = inserted.ProductID;

	IF( @InsertedListPrice > ( @OldListPrice + (0.15*@OldListPrice) ) ) 
	BEGIN
		RAISERROR('LIST PRICE MORE THAN 15 PERCENT, TRANSACTION FAILED',16,0)
		ROLLBACK TRANSACTION
	END
	ELSE
	BEGIN
		Update Production.Product SET ListPrice=@InsertedListPrice 
		WHERE Production.Product.ProductID = @ID;
	END
	
END;
SELECT Production.Product.ProductID,
	   Production.Product.ListPrice
FROM PRODUCTION.Product;

UPDATE PRODUCTION.Product 
SET ListPrice=2
WHERE Product.ProductID=4;
