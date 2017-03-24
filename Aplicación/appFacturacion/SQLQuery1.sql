SELECT * FROM PRODUCTO
GO

UPDATE PRODUCTO SET CMONEDA = 'C'
GO

UPDATE EMPRESA SET MONEDAINVENTARIO = 'C'
GO

update kardex set cmoneda = 'C'
go

select * from kardex
go

select * from devolucion_cliente
go

update devolucion_cliente
set
idventa = null
go