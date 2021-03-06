/*
   jueves, 28 de febrero de 201911:24:02 a.m.
   User: 
   Server: .\SQLEXPRESS
   Database: AccesosSUA
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ACC_rdPerfil_dAcciones ADD
	id numeric(8, 0) NOT NULL IDENTITY (1, 1)
GO
ALTER TABLE dbo.ACC_rdPerfil_dAcciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

ALTER TABLE dbo.ACC_rdPerfil_dAcciones ADD CONSTRAINT
	PK_ACC_rdPerfil_dAcciones PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ACC_rdPerfil_dAcciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

BEGIN TRANSACTION
GO
ALTER TABLE dbo.ACC_rdUsuarios_dPerfiles_dAcciones ADD CONSTRAINT
	PK_ACC_rdUsuarios_dPerfiles_dAcciones PRIMARY KEY CLUSTERED 
	(
	idUsuario, idPerfilAccion
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ACC_rdUsuarios_dPerfiles_dAcciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT