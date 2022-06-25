Create proc Sp_GetOrder @Id INT
AS
Begin
	Select O.Id Id,ProductName,Price,Quantity,Price*Quantity Total from Orders O
	Join Products P on O.ProductId = P.Id
	Where O.Id = @Id
End
GO

EXEC Sp_GetOrder 1