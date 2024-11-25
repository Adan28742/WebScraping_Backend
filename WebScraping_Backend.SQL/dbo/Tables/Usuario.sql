CREATE TABLE [dbo].[Usuario] (
    [IdUsuario]       INT            IDENTITY (1, 1) NOT NULL,
    [IdTipoUsuario]   INT            NULL,
    [Nombres]         NVARCHAR (100) NOT NULL,
    [Apellidos]       NVARCHAR (100) NOT NULL,
    [FechaNacimiento] DATE           NULL,
    [Email]           NVARCHAR (100) NOT NULL,
    [Password]        NVARCHAR (100) NOT NULL,
    [Estado]          BIT            NULL,
    [FechaCreacion]   DATETIME       DEFAULT (getdate()) NULL,
    [Telefono]        NVARCHAR (15)  NULL,
    [UltimoAcceso]    DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC),
    FOREIGN KEY ([IdTipoUsuario]) REFERENCES [dbo].[TipoUsuario] ([IdTipoUsuario]),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

