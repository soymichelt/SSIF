EXEC dbo.SpAccountsToPay
	@ProviderCode = '',
	@ProviderName = '',
	@BusinessName = '',
	@Money = 'C'
GO

DELETE FROM Producto
GO

DROP DATABASE SadaraDbV2
GO

SELECT * FROM Compra ORDER BY Compra.N
GO

UPDATE Compra SET FECHACREDITOVENCIMIENTO = '2018-05-20 20:01:38.597'
WHERE N = 8
GO


