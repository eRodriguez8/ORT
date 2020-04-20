
INSERT INTO [AccesosSUA].[dbo].[ACC_dUsuarios] 
VALUES (@NOMBREPC\USUARIO,6221,'Rotbard','Joan',getdate(),NULL,'A',6221,GETDATE(),NULL)

INSERT INTO [AccesosSUA].[dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] 
VALUES (@idusuario,38,'LAPTOP-JGKUEF1C\JOAN',GETDATE())
  
INSERT INTO [AccesosSUA].[dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] 
VALUES (@idusuario,39,'LAPTOP-JGKUEF1C\JOAN',GETDATE())