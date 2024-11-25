CREATE TABLE [dbo].[TipoUsuario] (
    [IdTipoUsuario] INT            IDENTITY (1, 1) NOT NULL,
    [Descripcion]   NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdTipoUsuario] ASC)
);

