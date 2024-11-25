CREATE TABLE [dbo].[TipoGuardado] (
    [IdTipoGuardado] INT            IDENTITY (1, 1) NOT NULL,
    [Descripcion]    NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdTipoGuardado] ASC)
);

