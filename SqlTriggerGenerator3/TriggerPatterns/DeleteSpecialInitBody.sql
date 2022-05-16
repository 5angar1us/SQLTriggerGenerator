Select @RowCount=count(*) from deleted
DECLARE @OldValue varchar(30)
DECLARE @OperationName varchar(10) = dbo.GetNameOperationDelete()

