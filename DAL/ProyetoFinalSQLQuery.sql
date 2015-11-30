Create DataBase BillEasyDb

use BillEasyDb

Create Table Clientes(
ClienteId Int Identity Primary Key,
CiudadId Int References Ciudades(CiudadId),
Nombres Varchar(50),
Apellidos Varchar(50),
Telefono Varchar(14),
Celular Varchar(12),
Direccion Varchar(150),
Email Varchar(100),
Cedula Varchar(15)
)

Insert into Clientes(CiudadId,Nombres,Apellidos,Telefono,Celular,Direccion,Email,Cedula) Values(1,'Edwin','Hidalgo','809-234-3433','809-123-3221','Tenares calle Cruz portes esquina Rufino de la cruz # 14','Edwin@gmail.com','0560183232-0')

alter table Productos
 check constraint FK__Productos__Marcas__MarcaId
 alter table  Proveedores NOCHECK constraint ALL 
 --sp_helpconstraint Productos


drop table Usuarios
drop table DetallesCompras
drop table DetallesVentas
drop table Ventas
drop table Compras
drop table Clientes
drop table Productos
drop table Proveedores
drop table Ciudades
drop table Marca

drop table Marcas
select *from DetallesVentas
Create Table Usuarios(
UsuarioId Int Identity Primary Key,
Nombres Varchar(50),
NombreUsuario Varchar(50),
Contrasena Varchar(40),
Area Varchar(100),
Fecha varchar(10)
)
Insert into Usuarios(Nombres,NombreUsuario,Contrasena,Area,Fecha) Values('Juan Perez','Juan24','123456','Master','30-11-2015')
Create Table Ventas(
VentaId Int Identity Primary Key,
UsuarioId Int References Usuarios(UsuarioId),
ClienteId Int References Clientes(ClienteId),
Fecha Varchar(10),
TipoVentas Varchar(9),
NFC Varchar(20),
TipoNFC Varchar(20),
Total Float
)


Create Table Compras(
CompraId Int Identity Primary Key,
ProveedorId Int References Proveedores(ProveedorId),
Fecha Varchar(10),
TipoCompra Varchar(9),
NFC Varchar(20),
TipoNFC Varchar(20),
Flete Float,
Monto Float
)

Create Table Productos(
ProductoId Int Identity Primary Key,
MarcaId Int References Marcas(MarcaId),
Nombre Varchar(50),
Cantidad Int,
Precio Float,
Costo Float,
ITBIS Float
)

Create Table Proveedores(
ProveedorId Int Identity Primary Key,
NombreEmpresa Varchar(70),
Direccion Varchar(150),
Telefono Varchar(14),
Email Varchar(50),
CiudadId Int References Ciudades(CiudadId),
RNC Varchar(20),
NombreRepresentante Varchar(50),
Celular Varchar(13)
)

Create Table DetallesVentas(
VentaId Int References Ventas(VentaId),
ProductoId int references Productos(ProductoId),
Precio Float,
Descuentos Float,
ITBIS float,
Cantidad int,
Importe float
)

Create Table DetallesCompras(
CompraId Int references Compras(CompraId),
ProductoId Int References Productos(ProductoId),
UsuarioId Int References Usuarios(UsuarioId),
Costo Float,
Cantidad int,
Importe float
)

Create Table Marcas(
MarcaId Int Identity Primary Key,
Nombre Varchar (50)
)

Insert into Marcas(Nombre) Values('Nike')

Create Table Ciudades(
CiudadId Int Identity Primary Key,
Nombre Varchar(50),
CodigoPostal int,
)
Insert into Ciudades(Nombre,CodigoPostal) Values('San Francisco',31000)
