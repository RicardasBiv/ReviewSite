CREATE TABLE [dbo].[Komentaras] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Komentaras1]  NVARCHAR (MAX) NOT NULL,
    [VertinimasId] INT            NOT NULL,
    CONSTRAINT [PK_Komentaras] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Komentaras_Vertinimas_VertinimasId] FOREIGN KEY ([VertinimasId]) REFERENCES [dbo].[Vertinimas] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Komentaras_VertinimasId]
    ON [dbo].[Komentaras]([VertinimasId] ASC);

