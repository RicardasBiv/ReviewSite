CREATE TABLE [dbo].[Recenzija] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [Pavadinimas]       NVARCHAR (MAX) NULL,
    [Aprasymas]         NVARCHAR (MAX) NULL,
    [KritikoVertinimas] INT            NOT NULL,
    [RasytojasId]       INT            NOT NULL,
    [Tipas]             INT            NOT NULL,
    [Zanras]            INT            NOT NULL,
    CONSTRAINT [PK_Recenzija] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Recenzija_AspNetUsers_RasytojasId] FOREIGN KEY ([RasytojasId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Recenzija_Tipas_Tipas] FOREIGN KEY ([Tipas]) REFERENCES [dbo].[Tipas] ([Id]),
    CONSTRAINT [FK_Recenzija_Zanrai_Zanras] FOREIGN KEY ([Zanras]) REFERENCES [dbo].[Zanrai] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Recenzija_RasytojasId]
    ON [dbo].[Recenzija]([RasytojasId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Recenzija_Tipas]
    ON [dbo].[Recenzija]([Tipas] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Recenzija_Zanras]
    ON [dbo].[Recenzija]([Zanras] ASC);

