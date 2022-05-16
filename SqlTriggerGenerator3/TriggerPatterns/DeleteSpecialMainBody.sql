Select @OldValue = Attribute From (Select <Attribute> as Attribute, ROW_NUMBER() OVER(ORDER BY <OrderItem> ASC) AS rownumber from deleted) as f WHERE @iterator = rownumber 
SET @AttributeName = '<Attribute>'
INSERT INTO dbo.Protocol
Values(GETDATE(), @IP,@UserName, @OperationName, @ObjectName,@AttributeName,Null, @OldValue)
--