Drop TRIGGER <OperationType>_<TableName>
go
CREATE TRIGGER <OperationType>_<TableName>
ON <TableName>
AFTER <OperationType>
AS
	SET NOCOUNT ON
	DECLARE @IP varchar(50)
	DECLARE @UserName nvarchar(50)
	DECLARE @ObjectName varchar(30)
	
	EXECUTE @IP = GetIP
	EXECUTE @UserName = GetLogin
	EXECUTE @ObjectName = GetTableName @idTable=@@PROCID
	
	DECLARE @AttributeName varchar(50)
	DECLARE @RowCount int
	DECLARE @iterator int = 1
	
	<SpecialInitBody>
	
	While(@iterator <= @RowCount)
	BEGIN
		<SpecialMainBody>
		set @iterator = @iterator +1
	END
go 
	
