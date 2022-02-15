CREATE TABLE [dbo].[Orokbefogado] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Nev]            VARCHAR (64)  NOT NULL,
    [Lakcim]         VARCHAR (255) NOT NULL,
    [SzuletesiDatum] DATE          NOT NULL,
    [Email]          VARCHAR(64)   NOT NULL
)
