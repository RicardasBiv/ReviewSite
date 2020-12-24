CREATE TABLE [dbo].[Vertinimas] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [Vertinimas1]  INT NULL,
    [IdNaudotojas] INT NOT NULL,
    [IdRecenzija]  INT NOT NULL,
    CONSTRAINT [PK_Vertinimas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Vertinimas_AspNetUsers_IdNaudotojas] FOREIGN KEY ([IdNaudotojas]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Vertinimas_Recenzija_IdRecenzija] FOREIGN KEY ([IdRecenzija]) REFERENCES [dbo].[Recenzija] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Vertinimas_IdNaudotojas]
    ON [dbo].[Vertinimas]([IdNaudotojas] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vertinimas_IdRecenzija]
    ON [dbo].[Vertinimas]([IdRecenzija] ASC);

