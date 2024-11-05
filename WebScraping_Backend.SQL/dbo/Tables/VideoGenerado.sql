CREATE TABLE [dbo].[VideoGenerado] (
    [IdVideoGenerado] INT            IDENTITY (1, 1) NOT NULL,
    [IdCategoria]     INT            NULL,
    [LinkVideo]       NVARCHAR (MAX) NULL,
    [FechaCreacion]   DATETIME       DEFAULT (getdate()) NULL,
    [Estado]          BIT            NULL,
    [Duracion]        INT            NULL,
    PRIMARY KEY CLUSTERED ([IdVideoGenerado] ASC),
    FOREIGN KEY ([IdCategoria]) REFERENCES [dbo].[Categoria] ([IdCategoria])
);

