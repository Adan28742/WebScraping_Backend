CREATE TABLE [dbo].[Lista_Guardado] (
    [IdLista_Guardado] INT      IDENTITY (1, 1) NOT NULL,
    [IdVideoGenerado]  INT      NULL,
    [IdUsuario]        INT      NULL,
    [FechaCreacion]    DATETIME DEFAULT (getdate()) NULL,
    [Estado]           BIT      NULL,
    [IdTipoGuardado]   INT      NULL,
    PRIMARY KEY CLUSTERED ([IdLista_Guardado] ASC),
    FOREIGN KEY ([IdTipoGuardado]) REFERENCES [dbo].[TipoGuardado] ([IdTipoGuardado]),
    FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuario] ([IdUsuario]),
    FOREIGN KEY ([IdVideoGenerado]) REFERENCES [dbo].[VideoGenerado] ([IdVideoGenerado])
);

