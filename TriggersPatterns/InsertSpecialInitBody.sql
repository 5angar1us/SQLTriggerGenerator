Select @RowCount=count(*) from inserted
DECLARE @NewValue varchar(30)
DECLARE @OperationName varchar(10) = dbo.GetNameOperationInsert()
