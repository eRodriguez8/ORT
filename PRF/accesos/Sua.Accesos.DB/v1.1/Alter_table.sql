USE [AccesosSUA]
GO

update [dbo].[ACC_dMenu] 
set [imagen] = N'assets/images/usuarios.png',
[url] = N'/Usuario',
[tooltip] = N'Usuario'
where nombre = N'ACC_Usuario'

update [dbo].[ACC_dMenu] 
set [imagen] = N'assets/images/addUser.png',
[url] = N'/Usuario/alta',
[tooltip] = N'Agregar'
where nombre = N'ACC_Usuario_Alta'

update [dbo].[ACC_dMenu] 
set [imagen] = N'assets/images/editUser.png',
[url] = N'/Usuario/modif',
[tooltip] = N'Modificar'
where nombre = N'ACC_Usuario_Modif'

update [dbo].[ACC_dMenu] 
set [imagen] = N'assets/images/removeUser.png',
[url] = N'/Usuario/baja',
[tooltip] = N'Eliminar'
where nombre = N'ACC_Usuario_Baja'

update [dbo].[ACC_dMenu] 
set [imagen] = N'assets/images/findUser.png',
[url] = N'/Usuario/consulta',
[tooltip] = N'Consultar Perfil'
where nombre = N'ACC_Usuario_Consulta'


update [dbo].[ACC_dMenu] 
set [imagen] = N'assets/images/perfiles.png',
[url] = N'/Perfil',
[tooltip] = N'Perfiles'
where nombre = N'ACC_Perfil'

update [dbo].[ACC_dMenu] 
set [imagen] = N'assets/images/addPerfil.png',
[url] = N'/Perfil/alta',
[tooltip] = N'Agregar'
where nombre = N'ACC_Perfil_Alta'

update [dbo].[ACC_dMenu] 
set [imagen] = N'assets/images/removePerfil.png',
[url] = N'/Perfil/baja',
[tooltip] = N'Eliminar'
where nombre = N'ACC_Perfil_Baja'

update [dbo].[ACC_dMenu] 
set [imagen] = N'assets/images/asociarPerfil.png',
[url] = N'/Perfil/asociar',
[tooltip] = N'Asociar Perfil'
where nombre = N'ACC_Perfil_Asociar'

update [dbo].[ACC_dMenu] 
set [imagen] = N'assets/images/copiarPerfil.png',
[url] = N'/Perfil/copiar',
[tooltip] = N'Copiar Perfil'
where nombre = N'ACC_Perfil_Copia'



