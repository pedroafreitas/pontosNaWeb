USE CustomerOrderViewer;

--This is the uddc
CREATE TYPE [dbo].[CustomerOrderType] AS TABLE
(
	CustomerOrderId INT NOT NULL, --this data we be int and not null
	CustomerId INT NOT NULL,
	ItemId INT NOT NULL

);
GO --we say go so we can keep continue with other statements. We can do separeted batches]]


ALTER VIEW [dbo].[CustomerOrderDetail] AS
	SELECT 
		t1.CustomerOrderId,
		t2.CustomerId,
		t3.ItemId,
		t2.FirstName,
		t2.LastName,
		t3.[Description],
		t3.Price,
		t1.ActiveInd
	FROM
		dbo.CustomerOrder t1
	INNER JOIN
		dbo.Customer t2  ON t2.CustomerId = t1.CustomerId
	INNER JOIN
		dbo.Item t3 ON t3.ItemId = t1.ItemId
GO


--the procedures
--this procedure select all the data from our previous view
CREATE PROCEDURE [dbo].[CustomerOrderDetail_GetList]
AS
	SELECT 
		CustomerOrderId,
		CustomerId,
		ItemId,
		FirstName,
		LastName,
		[Description],
		Price
	FROM
		dbo.CustomerOrderDetail
	WHERE
		ActiveInd = CONVERT(BIT, 1)
GO


CREATE PROCEDURE [dbo].[CustomerOrderDetail_Delete]
	--parameters
	@CustomerOrderId INT,
	@UserId VARCHAR(50)

	--We want to keep the row, but inactivate it
	--DELETE FORM CustomerOrder WHERE CustomerOrderId = @CustomerOrderId
AS
	UPDATE CustomerOrder
	SET
		ActiveInd = CONVERT(BIT, 0),
		UpdateId = @UserId,
		UpdateDate = GETDATE()
	WHERE
		CustomerOrderId = @CustomerOrderId AND
		ActiveInd = CONVERT(BIT, 1);
GO


--give as a list of all customerOrders that we wants to insert or update 
CREATE PROCEDURE [dbo].[CustomerOrderDetail_Upsert]
	@CustomerOrderType CustomerOrderType READONLY, --a table of CustomerOrder
	@UserId VARCHAR(50)
AS
		MERGE INTO CustomerOrder TARGET --merge can insert, update and delete. dont delete with it
		USING 
		(
			SELECT --selecting the source input using our uddt
				CustomerOrderId,
				CustomerId,
				ItemId,
				@UserId [UpdateId], --making UserId a named collum. UserId is UserId
				GETDATE() [UpdateDate], 
				@UserId [CreateId],
				GETDATE() [CreateDate]

			FROM
				@CustomerOrderType
		) AS SOURCE
    ON 
		(
		--how are you ganna match the source to the target? 
			TARGET.CustomerOrderId = COALESCE(SOURCE.CustomerOrderId, -1) --we dont need coalesce, but certains fields sometimes have Null fields. Coalesce is a null check
		)								--in this case customer id is never gonna be null
	WHEN MATCHED THEN
		UPDATE SET --just the update statement
			TARGET.CustomerId = SOURCE.CustomerId,
			TARGET.ItemId = SOURCE.ItemId,
			TARGET.UpdateId = SOURCE.UpdateId,
			TARGET.UpdateDate = SOURCE.UpdateDate
	
	--if it is not matched it means its an insert and not update
	WHEN NOT MATCHED BY TARGET THEN
		INSERT 
			(
				CustomerId,
				ItemId,
				CreateId,
				CreateDate,
				UpdateId,
				UpdateDate,
				ActiveInd) 
		VALUES 
			(
				SOURCE.CustomerId, SOURCE.ItemId, SOURCE.CreateId, SOURCE.CreateDate, SOURCE.UpdateId, SOURCE.UpdateDate, CONVERT(BIT, 1));
GO