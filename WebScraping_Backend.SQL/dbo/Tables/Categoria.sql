CREATE TABLE [dbo].[Categoria] (
    [IdCategoria] INT            IDENTITY (1, 1) NOT NULL,
    [Descripcion] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdCategoria] ASC)
);

