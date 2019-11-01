CREATE TABLE [dbo].[Games] (
    [GameID]           INT         NOT NULL IDENTITY,
    [GameName]         NCHAR (256) NULL,
    [GameSaveLocation] NCHAR (256) NULL,
    PRIMARY KEY CLUSTERED ([GameID] ASC)
);

