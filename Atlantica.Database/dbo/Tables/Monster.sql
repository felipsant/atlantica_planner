CREATE TABLE [dbo].[Monster] (
    [Id]            INT         IDENTITY (1, 1) NOT NULL,
    [AtlanticaDBId] INT         NULL,
    [URL]           NCHAR (200) NULL,
    [Name]          NCHAR (200) NULL,
    [Level]         INT         NULL,
    [Experience]    INT         NULL,
    [Weapon]        SMALLINT    NULL,
    [Special]       NCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

