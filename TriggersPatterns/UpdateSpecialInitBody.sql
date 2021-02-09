Select @RowCount=count(*) from deleted
DECLARE @NewValue varchar(30)
DECLARE @OldValue varchar(30)
DECLARE @OperationName varchar(10) = dbo.GetNameOperationUpdate()