IF UPDATE (<Attribute>)
BEGIN
	Select @NewValue = Attribute From (Select <Attribute> as Attribute, ROW_NUMBER() OVER(ORDER BY <OrderItem> ASC) AS rownumber from inserted) as f WHERE @iterator = rownumber 
	Select @OldValue = Attribute From (Select <Attribute> as Attribute, ROW_NUMBER() OVER(ORDER BY <OrderItem> ASC) AS rownumber from deleted) as f WHERE @iterator = rownumber 
	SET @AttributeName = '<Attribute>'
	INSERT INTO dbo.Protocol
	VALUES 
	(GETDATE(), @IP,@UserName, @OperationName, @ObjectName,@AttributeName, @NewValue , @OldValue)
END