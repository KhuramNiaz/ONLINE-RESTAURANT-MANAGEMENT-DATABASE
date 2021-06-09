--Creation of DATABASE
CREATE DATABASE hotel

--Using 'hotel' DATABASE
USE hotel

-----------------------------------------------Hotel adiministration--------------------------------------------

--Promotions Available
--PromotionID, Promotion Name, off value percentage (BCNF)
CREATE TABLE promotion(
 promotionID NUMERIC(5) IDENTITY PRIMARY KEY,
  promotionName VARCHAR(20) NOT NULL,
   valueOff NUMERIC(5) NOT NULL)

--Dishes Available
--dishesID, Promotion Name, off value percentage
CREATE TABLE dishes(
 dishID NUMERIC(5) IDENTITY PRIMARY KEY,
  dishName VARCHAR(20) NOT NULL,
   price NUMERIC(10),
    dishtype INT,
	 ingredientsID INT)

--ingredients
CREATE TABLE ingredients(
 ingredientsId INT,
  flour CHAR CHECK(flour = 'Y' OR flour='N'),
   chicken CHAR CHECK(chicken = 'Y' OR chicken='N'),
    mutton CHAR CHECK(mutton = 'Y' OR mutton='N'),
	 banana CHAR CHECK(banana = 'Y' OR banana='N'),
	  apple CHAR CHECK(apple = 'Y' OR apple='N'),
	   mango CHAR CHECK(mango = 'Y' OR mango='N'))

INSERT INTO ingredients VALUES(1, 'Y', 'Y', 'Y', 'Y', 'Y', 'Y')

--Resorces Available
--resouceID, Resource Name, Available Quantity (BCNF)
CREATE TABLE resources(
 resouceID NUMERIC(5) IDENTITY PRIMARY KEY,
  resourceName VARCHAR(20) NOT NULL,
   quantity NUMERIC(5) DEFAULT 0 NOT NULL)

------------------------------------------------------Customer--------------------------------------------------

--Customer TABLE
--Customer ID, Customer Name, Customer Address, VIP Status (BCNf)
CREATE TABLE customer(
customerno NUMERIC(5) IDENTITY PRIMARY KEY,
 customerName VARCHAR(20),
  userName VARCHAR(20),
   [passWord] VARCHAR(20),
    phone VARCHAR(20),
	 city VARCHAR(20),
	  [status] INT DEFAULT 0 NOT NULL)
 
--Customer Cart
CREATE TABLE customerCart(
 cartID INT PRIMARY KEY,
  customerID NUMERIC(5),
   capacity NUMERIC(1),
    FOREIGN KEY (customerID) REFERENCES customer(customerno))



--SELECT * FROM customer
--SELECT * FROM customerCart

GO--------------------------Logiin----------------------------
CREATE PROCEDURE [Login]
	@UserName VARCHAR(20),
	@passWord VARCHAR(20),
	@OUTPUT INT OUTPUT
AS
BEGIN
	IF (SELECT [passWord] FROM customer WHERE userName=@UserName)=@passWord
		SET @OUTPUT=1
	ELSE
		SET @OUTPUT=0
END
GO

DECLARE @ans INT
EXECUTE [Login]
	@UserName='khuram',
	@passWord='fASt',
	@OUTPUT=@ans OUTPUT

SELECT @ans

SELECT * FROM customer

GO
--------------------------------------------------
--Sign-Up
--Signup procedure STARTED
CREATE PROCEDURE signUp
	@CsustomerName VARCHAR(20),
	@UserName VARCHAR(20),
	@passWord VARCHAR(20),
	@phone VARCHAR(20),
	@city  VARCHAR(20),
	@OUTPUT INT OUTPUT
AS
BEGIN
	IF (SELECT userName FROM customer WHERE userName=@UserName)=@UserName
		SET @OUTPUT=0
	ELSE
		BEGIN
			SET @OUTPUT=1
			--SET identity_INSERT dbo.customer on
			INSERT INTO customer(customerName,
			 userName,
			  [passWord],
			   phone,
			    city) VALUES(
				@CsustomerName,
				 @UserName,
				  @passWord,
				   @phone,
				    @city)
			--SET identity_INSERT dbo.customer off
		END
END
--Signup Procedure ENDED

GO
DECLARE
	@ans INT
EXECUTE signUp
	@CsustomerName='Abubakar', 
	@UserName='abubakar', 
	@passWord='1234', 
	@phone='456768', 
	@city='Lahore', 
	@OUTPUT=@ans OUTPUT

SELECT @ans

SELECT * FROM customer

GO
--------------------------------------------------
--addDish
--addDish procedure STARTED
CREATE PROCEDURE addDish
	@dishName VARCHAR(20),
	@price NUMERIC(10),
	@dishtype INT,
	@ingredientsID INT,
	@OUTPUT INT OUTPUT
AS
BEGIN
	IF (SELECT dishName FROM dishes WHERE dishName=@dishName)=@dishName
		SET @OUTPUT=0
	ELSE
		BEGIN
			SET @OUTPUT=1
			--SET identity_INSERT dbo.dishes on
			INSERT INTO dishes(dishName, price, dishtype, ingredientsID) VALUES(
				@dishName,
				 @price,
				  @dishtype,
				   @ingredientsID)
			--SET identity_INSERT dbo.dishes off
		END
END
--addDish Procedure ENDED

GO
DECLARE
	@ans INT
EXECUTE addDish
	@dishName='Nihari', @price=200, @dishType=1, @ingredientsID=1,
	@OUTPUT=@ans OUTPUT

SELECT @ans

GO
--------------------------------------------------
--addResource
--addResource procedure STARTED
CREATE PROCEDURE addResoerce
	@resourceName VARCHAR(20),
	@quantity NUMERIC(5),
	@OUTPUT INT OUTPUT
AS
BEGIN
	IF (SELECT resourceName FROM resources WHERE resourceName=@resourceName)=@resourceName
		SET @OUTPUT=0
	ELSE
		BEGIN
			SET @OUTPUT=1
			INSERT INTO resources(resourceName, quantity) VALUES(
			 @resourceName,
			  @quantity)
		END
END
--addResource Procedure ENDED

GO
DECLARE
	@ans INT
EXECUTE addResoerce
	@resourceName='H',
	@quantity=30,
	@OUTPUT=@ans OUTPUT

SELECT @ans

GO
--------------------------------------------------
--addPromotion
--addPromotion procedure STARTED
CREATE PROCEDURE addPromotion
	@promotionName VARCHAR(20),
	@valueOff NUMERIC(5),
	@OUTPUT INT OUTPUT

AS
BEGIN
	IF (SELECT promotionName FROM promotion WHERE promotionName=@promotionName)=@promotionName
		SET @OUTPUT=0
	ELSE
		BEGIN
			SET @OUTPUT=1
			INSERT INTO promotion(promotionName, valueOff) VALUES(
			 @promotionName,
			  @valueOff)
		END
END
--addResource Procedure ENDED

GO
DECLARE
	@ans INT
EXECUTE addPromotion
	@promotionName='H',
	@valueOff=30,
	@OUTPUT=@ans OUTPUT

SELECT @ans



SELECT * FROM dbo.customer --INSERT
SELECT * FROM dbo.customerCart
SELECT * FROM dbo.dishes --INSERT
SELECT * FROM dbo.ingredients --INSERT
SELECT * FROM dbo.promotion --INSERT
SELECT * FROM dbo.resources --INSERT