CREATE TABLE [dbo].[Orokbefogadas] (
    [Id]                   INT  PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [OrokbefogadasDatuma]  DATE NOT NULL,
    [UtoellenorzesDatuma]  DATE NOT NULL,
    [UtoellenorzesSikeres] BIT  NULL,
    [OrokbefogadoID]       INT  NOT NULL,
    [AllatID]              VARCHAR(64) NOT NULL
);